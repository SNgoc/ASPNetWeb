using DemoAuthorization.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DemoAuthorization.Security
{
    public class SecurityManager
    {
        //viết thêm 1 hàm hỗ trợ đăng nhập Claim
        private IEnumerable<Claim> GetUserClaims(Account account)
        {
            //claim lưu thông tin của account và role
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, account.Username));
            // add quyền tương ứng của account này
            account.AccountRoles.ToList().ForEach(ar =>
            {
                claims.Add(new Claim(ClaimTypes.Role, ar.Role.Name));
            });
            return claims;
        }

        //signIn với lưu cookie
        public async Task SignIn(HttpContext context, Account account)// sửa void thành task để fix lỗi bên accountcontroller.cs
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(GetUserClaims(account), CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(claimsIdentity);//ClaimsPrincipal quản lý thông tin tài khoản, ko lưu password
            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        //signout
        public async Task SignOut(HttpContext context)
        {
            await context.SignOutAsync();
        }
    }
}
