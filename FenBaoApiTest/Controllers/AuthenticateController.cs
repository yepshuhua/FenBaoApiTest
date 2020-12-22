﻿using FenBaoApiTest.Dtos;
using Microsoft.AspNetCore.Authorization;
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
        public AuthenticateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody] LoginDto loginDto)
        {
            //1.验证用户名密码
            //2.创建jwt
            var signingAlgorithm = SecurityAlgorithms.HmacSha256;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,"fake_user_id")
            };
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
    }
}
