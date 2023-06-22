using FSH.BlazorWebAssembly.Client.Components.DevExtreme;
using FSH.BlazorWebAssembly.Client.Components.EntityTable;
using FSH.BlazorWebAssembly.Client.Infrastructure.ApiClient;
using FSH.BlazorWebAssembly.Client.Infrastructure.Auth;
using FSH.WebApi.Shared.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using FSH.BlazorWebAssembly.Client.Components.DevExtreme;
using MudBlazor;

namespace FSH.BlazorWebAssembly.Client.Pages.Identity.Users;

public partial class Users
{
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    [Inject]
    protected IAuthorizationService AuthService { get; set; } = default!;

    [Inject]
    protected IUsersClient UsersClient { get; set; } = default!;

    protected DataGridContext Context { get; set; } = default!;

    public DataGrid DataGrid { get; set; } = default!;

    private bool _canExportUsers;
    private bool _canViewRoles;

    // Fields for editform
    protected string Password { get; set; } = string.Empty;
    protected string ConfirmPassword { get; set; } = string.Empty;

    private bool _passwordVisibility;
    private InputType _passwordInput = InputType.Password;
    private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthState).User;
        _canExportUsers = await AuthService.HasPermissionAsync(user, FSHAction.Export, FSHResource.Users);
        _canViewRoles = await AuthService.HasPermissionAsync(user, FSHAction.View, FSHResource.UserRoles);

        Context = new(
            path: "userscrud",
            fields: new List<object>()
            {
                new
                {
                    dataField = "firstName",
                    caption = "Adı"
                }
            },
            editTitle: "Kullanıcı Ekle",
            popupWidth: 500,
            popupHeight: 500,
            exportName: "Kullanıcı Listesi");
    }

    private void ViewProfile(in Guid userId) =>
        Navigation.NavigateTo($"/users/{userId}/profile");

    private void ManageRoles(in Guid userId) =>
        Navigation.NavigateTo($"/users/{userId}/roles");
}