using System.Text;
using System.Text.Json;

namespace blazorMovieList
{
    public static class ServiceLocator
    {
        public static GoogleAuthService GoogleAuth { get; set; }
    }

}
