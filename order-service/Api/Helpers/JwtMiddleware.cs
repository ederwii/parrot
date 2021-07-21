using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, token);

            await _next(context);
        }

        private static void AttachUserToContext(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("8at!7TtrV+J9@2ZHjrtqtyg9Tm_wN3^P3A?s9QWQ6y#ASpN!+Z8F!2U+s_nXs2");
                var info = tokenHandler.ReadJwtToken(token);
                var userId = info.Claims.First(x => x.Type == "id").Value;
                var name = info.Claims.First(x => x.Type == "name").Value;
                var email = info.Claims.First(x => x.Type == "email").Value;
                var user = new User
                {
                    Email = email,
                    Id = userId,
                    Name = name
                };
                // attach user to context on successful jwt validation
                context.Items["User"] = user;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}