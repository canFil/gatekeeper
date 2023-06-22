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
        await JsRuntime.InvokeVoidAsync("initGrid", Configuration[ConfigNames.ApiBaseUrl], Context.Path,
            Context.EditTitle, Context.ExportName, Context.PopupWidth, Context.PopupHeight,
            JsonConvert.SerializeObject(Context.Fields)).ConfigureAwait(false);
    }
}