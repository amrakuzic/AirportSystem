using DomainModel.Models;
using System;
namespace FlightManagementBlazorServer.Data
{
    public class LoginState
    {
        public bool IsLoggedIn { get; set; }
        public User User { get; set; }
        public event Action OnChange;
        public string Role { get; set; }

        public void SetLogin(bool login, User user)
        {
            IsLoggedIn = login;
            User = user;
            NotifyStateChanged();
        }

        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
    }
}