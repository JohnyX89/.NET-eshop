using eshop.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eshop.Models.ApplicationServices
{
    public interface ISecurityApplicationService
    {
        Task<string[]> Register(RegisterViewModel vm, Roles role);

        Task<bool> Login(LoginViewModel lvm);

        Task Logout();

        Task<User> FindUserByUserName(string username);

        Task<User> FindUserByEmail(string email);

        Task<IList<string>> GetUserRoles(User user);

        Task<User> GetCurrentUser(ClaimsPrincipal claims);

    }
}
