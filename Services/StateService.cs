using Blazored.LocalStorage;
using StockWatcherClient.Auth;
using StockWatcherClient.Models;

namespace StockWatcherClient.Services
{
    public class StateService
    {
        private ISyncLocalStorageService localStorage;
        public StateService(ISyncLocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public User LoggedUser
        {
            get
            {
                return this.localStorage.GetItem<User>("user");
            }
            set
            {
                this.localStorage.SetItem<User>("user", value);
            }
        }
    }
}
