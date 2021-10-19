using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAuthen.Middlewares
{
    public class AuthenticationMiddle
    {
        private readonly RequestDelegate _next;
        public AuthenticationMiddle(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            var path = context.Request.Path;
            // kiểm tra xem người dùng có truy cập vào admin
            // dựa vào url do trình duyệt gửi lên
            if(path!=null && path.Value.StartsWith(@"/admin"))
            {
                if (context.Session.GetString("username") == null)
                {
                    context.Response.Redirect("/login/index");
                }
            }
            // nếu không phải truy cập vào vùng admin hoặc đã đăng nhập, xử lý tiếp
            return _next(context);
        }
    }
    // tạo extension method để thêm middleware này vào pipeline xử lý của http request
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UserAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddle>();
        }
    }
}
