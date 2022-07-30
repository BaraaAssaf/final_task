﻿using Core.Data;
using Core.Repository;
using Core.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace infra1.Service
{
    public class Authenticationservice : IAuthenticationService
    {

        private readonly IAuthentication authentication;

        public Authenticationservice(IAuthentication authentication)
        {
            this.authentication = authentication;
        }


  
        public string Authentication_jwt(login_api login)
        {
            var result = authentication.auth(login);
            if (result == null)
            {
                return null;
            }
            else
            {
                var tokenhandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]");
                var tokenDescirptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                    new Claim(ClaimTypes.Email, result.username),
                    new Claim(ClaimTypes.Role, result.rolename),
                    new Claim(ClaimTypes.Name, result.id.ToString())

                    }
                    ),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256Signature)


                };

                var generatetoken = tokenhandler.CreateToken(tokenDescirptor);
                return tokenhandler.WriteToken(generatetoken);
            }

        }
    }
}
