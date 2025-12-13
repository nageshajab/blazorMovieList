window.handleCredentialResponse = function (response) {
    console.log("Google login success", response);

    DotNet.invokeMethodAsync("blazorMovieList", "OnGoogleLogin", response.credential);
};