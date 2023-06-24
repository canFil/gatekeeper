using System.Text.Json.Nodes;
using FSH.BlazorWebAssembly.Client.Infrastructure.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace FSH.BlazorWebAssembly.Client.Components.DevExtreme;

public partial class DataGrid
{
    [Parameter]
    [EditorRequired]
    public DataGridContext Context { get; set; } = default!;

    [Inject]
    public IJSRuntime JsRuntime { get; set; }
    [Inject]
    public IConfiguration Configuration { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var importedScript = await JsRuntime.InvokeAsync<IJSObjectReference>("import", Context.PageScript);
        await importedScript.InvokeVoidAsync("setGridColumns");

        await JsRuntime.InvokeVoidAsync("initGrid", Configuration[ConfigNames.ApiBaseUrl], Context.Path,
            Context.EditTitle, Context.ExportName, Context.PopupWidth, Context.PopupHeight).ConfigureAwait(false);
    }
}