using ChapterAPI.Interfaces;
using ChapterAPI.Models;
using ChapterAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;
        public LoginController(IUsuarioRepository iusuarioRepository)
        {
            _iusuarioRepository= iusuarioRepository;
        }

        public BinaryReader JwtRegisterClaimNames { get; private set; }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            Usuario usuarioEncontrado = _iusuarioRepository.Login(login.Email, login.Senha);
            if (usuarioEncontrado == null)
            {
                return Unauthorized(new {msg = "Email e/ou senha inválidos." });
            }

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioEncontrado.Tipo)

            };

            var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                issuer: "chapter.api",
                audience: "chapter.api",
                claims: minhasClaims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credenciais
                );

            return Ok(
                new { Token = new JwtSecurityTokenHandler().WriteToken(meuToken) }
                );

        }

    }
}
