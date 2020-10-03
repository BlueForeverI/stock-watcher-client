using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using StockWatcherClient.Models;

namespace StockWatcherClient.Auth
{
    public class LocalStorageAuthStateProvider : AuthenticationStateProvider
    {
        private ISyncLocalStorageService localStorage;

        public LocalStorageAuthStateProvider(ISyncLocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = this.localStorage.GetItem<User>("user");
            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Email),
                }, "Fake authentication type");
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
            }
            else
            {
                return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
            }
        }

        public void NotifyStateChanged(User user = null)
        {
            if (user != null)
            {

            }
            else
            {
                this.NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
            }
        }
    }
}
