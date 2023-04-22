using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TarefasFIESC.Models;

namespace TarefasFIESC.Seguranca;

public class GerenciarToken
{
    public static string GerarToken(IdentityUser user, UserManager<IdentityUser> _userManager, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);

        var claims = _userManager.GetClaimsAsync(user).Result;

        var Subject = new ClaimsIdentity(new Claim[]
        {
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("Id", user.Id)
        });

        Subject.AddClaims(claims);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = Subject,

            SigningCredentials = new SigningCredentials(
               new SymmetricSecurityKey(key),
               SecurityAlgorithms.HmacSha256Signature),

            Audience = configuration["JwtBearerTokenSettings:Audience"],

            Issuer = configuration["JwtBearerTokenSettings:Issuer"],

            Expires = DateTime.UtcNow.AddHours(2),
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }


    public static bool VerificarToken(string token, IConfiguration configuration)
    {
        var key = Encoding.ASCII.GetBytes(configuration["JwtBearerTokenSettings:SecretKey"]);

        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = configuration["JwtBearerTokenSettings:Issuer"],
                ValidateAudience = true,
                ValidAudience = configuration["JwtBearerTokenSettings:Audience"],
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public static UsuarioModel DescrToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDesc = tokenHandler.ReadToken(token) as JwtSecurityToken;

        var email = tokenDesc.Claims.First(claim => claim.Type == "email").Value;

        var nome = tokenDesc.Claims.First(claim => claim.Type == "Nome").Value;

        string Id = tokenDesc.Claims.First(claim => claim.Type == "Id").Value;

        var usuario = new UsuarioModel()
        {
            Email = email,
            Nome = nome,
            Id = Guid.Parse(Id)
        };

        return usuario;
    }
}
