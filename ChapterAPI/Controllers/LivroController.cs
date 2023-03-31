using ChapterAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ChapterAPI.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    [ApiController]

    [Authorize(Roles = "1")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _IlivroRepository;

        public LivroController(ILivroRepository ILivroRepository)
        {
            _IlivroRepository = ILivroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_IlivroRepository.Ler());
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

    }
}
