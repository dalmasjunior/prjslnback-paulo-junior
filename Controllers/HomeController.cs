using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using prjslnback_paulo_junior.Models;
using prjslnback_paulo_junior.Services;
using prjslnback_paulo_junior.Repositories;

namespace prjslnback_paulo_junior.Controllers
{
    [Route("api/v1")]
    public class prjslnback_paulo_junior : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Invalid user/password" });

            var token = "Bearer " + TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        [HttpPost]
        [Route("password/validate")]
        [Authorize]
        public async Task<ActionResult<dynamic>> ValidatePassword([FromBody]Password model)
        {
            return PasswordService.ValidadePassword(model.Pass) ? "Valid Password" : "Invalid Password";
        }

        [HttpGet]
        [Route("password/generate")]
        [Authorize]
        public string GeneratePassord()
        {
            return PasswordService.GenerateRandomPassword();
        }

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}