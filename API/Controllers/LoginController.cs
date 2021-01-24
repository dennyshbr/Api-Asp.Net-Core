using API.Model;
using API.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token(AutenticacaoDTO autenticacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorResponse.FromModelState(ModelState));
            }

            //Implementar o Identity
            //var result = _signInManager.PasswordSignAsync(autenticacao.Login, autenticacao.Password, true, true);

            if (AutenticarComIdentity(autenticacao))
            {
                string token = CriarTokenJwt(autenticacao.Usuario);

                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        private string CriarTokenJwt(string login)
        {
            //Jwt = header + payload >> direitos + signature

            var direitos = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, login),//sujeito
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())//identificador único para este token
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("catologo-filmes-webapi-authentication-valid"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ApiCatologoFilmes",
                audience: "Postman",
                claims: direitos,
                signingCredentials: credenciais,
                expires: DateTime.Now.AddMinutes(30)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }

        private bool AutenticarComIdentity(AutenticacaoDTO autenticacao)
        {
            if (autenticacao.Usuario == "teste" && autenticacao.Senha == "123456")
            {
                return true;
            }
            else
                return false;
        }
    }
}
