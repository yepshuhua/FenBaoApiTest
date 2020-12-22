using FenBaoApiTest.Dtos;
using FenBaoApiTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FenBaoApiTest.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticateController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppcationUser> _userManager;
        private readonly SignInManager<AppcationUser> _signInManager;
        public AuthenticateController(IConfiguration configuration, UserManager<AppcationUser> usermanager, SignInManager<AppcationUser> signInmanager)
        {
            _configuration = configuration;
            _userManager = usermanager;
            _signInManager =signInmanager;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task< IActionResult> login([FromBody] LoginDto loginDto)
        {
            //1.验证用户名密码
            var loginResult = await _signInManager.PasswordSignInAsync(
                loginDto.Phone,
                loginDto.Password,
                false,
                false
                );
            if(!loginResult.Succeeded)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByNameAsync(loginDto.Phone);
            //2.创建jwt
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.Id),
                new Claim(ClaimTypes.Role,"Admin" )
            };
            var roleNames = await _userManager.GetRolesAsync(user);
            foreach( var roleName in roleNames)
            {
                var roleClaim = new Claim(ClaimTypes.Role, roleName);
                claims.Add(roleClaim);
            }
            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);
            var signingKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(signingKey, signingAlgorithm);
            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:issuer"],
                audience: _configuration["Authentication:audience"],
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials
                );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            //3.return 200 ok  +jwt
            return Ok(tokenStr);
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task< IActionResult> Register([FromBody]RegisterDto registerDto)
        {
            // 使用用户名创建用户对象
            var user = new IdentityUser()
            {
                UserName = registerDto.Phone,
                PhoneNumber = registerDto.Phone
            };
            // hash密码保存用户
            var result =await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            // return.
            return Ok();
        }
    }
}
