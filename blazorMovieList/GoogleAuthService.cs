using System.Text.Json;
using System.Text;
using Microsoft.JSInterop;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;


namespace blazorMovieList
{
    public class GoogleAuthService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _nav;

        public GoogleAuthService(ILocalStorageService localStorage, NavigationManager nav)
        {
            _localStorage = localStorage;
            _nav = nav;
        }

        [JSInvokable]
        public static async Task OnGoogleLogin(string jwt)
        {
            var payload = jwt.Split('.')[1];
            payload = payload.PadRight(payload.Length + (4 - payload.Length % 4) % 4, '=');

            var json = Encoding.UTF8.GetString(Convert.FromBase64String(payload));
            var data = JsonSerializer.Deserialize<Dictionary<string, object>>(json);

            var email = data["email"]?.ToString();
            var name = data["name"]?.ToString();
            var picture = data["picture"]?.ToString();

            var service = ServiceLocator.GoogleAuth;

            await service._localStorage.SetItemAsync("email", email);
            await service._localStorage.SetItemAsync("name", name);
            await service._localStorage.SetItemAsync("picture", picture);
            await service._localStorage.SetItemAsync("jwt", jwt);

            service._nav.NavigateTo("/", true);
        }
       
    }

}
