using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AspireApp1.Models.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace AspireApp1.Web.Authentication;

public class CustomAuthStateProvider : AuthenticationStateProvider{
private readonly ProtectedLocalStorage protectedLocalStorage;

public CustomAuthStateProvider(ProtectedLocalStorage protectedLocalStorage) {
    this.protectedLocalStorage = protectedLocalStorage;
}

public override async Task<AuthenticationState> GetAuthenticationStateAsync() {
    var token = (await protectedLocalStorage.GetAsync<string>("token")).Value;
    var identity = string.IsNullOrEmpty(token) ? new ClaimsIdentity() : GetClaimsIdentity(token);
    return new AuthenticationState(new ClaimsPrincipal(identity));

}
    public async Task NotifyUserAuthenticated(string token) {
        await protectedLocalStorage.SetAsync("token", token);
        var claimsIdentity = GetClaimsIdentity(token);
        var claimsPrincipal =new ClaimsPrincipal(claimsIdentity);
        
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }
    public async Task NotifyUserLoggedout() {
        await protectedLocalStorage.DeleteAsync("token");
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()))));
    }
    private ClaimsIdentity GetClaimsIdentity(string token) {
        var readToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
        return new ClaimsIdentity(readToken.Claims, "Jwt");
    }
}