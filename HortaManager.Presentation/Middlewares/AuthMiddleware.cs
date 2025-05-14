namespace HortaManager.Presentation.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly string _authKey;

        public AuthMiddleware(RequestDelegate requestDelegate, IConfiguration config)
        {
            _requestDelegate = requestDelegate;
            _authKey = config["Authorization:Key"] ?? "";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.TryGetValue("Authorization", out var extractKey))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Authorization não fornecido na requisição.");
                return;
            }


            string token = extractKey.ToString();

            if ( token != $"Bearer {_authKey}")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization invalido para a requisição");
                return;
            }


            await _requestDelegate(context);
        }
    }
}
