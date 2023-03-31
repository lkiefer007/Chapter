﻿using ChapterAPI.Interfaces;
using ChapterAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iusuarioRepository;

        public UsuarioController(IUsuarioRepository iusuarioRepository)
        {
            _iusuarioRepository= iusuarioRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_iusuarioRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id) 
        {
            try
            {
                Usuario usuarioBuscado = _iusuarioRepository.BuscarPorId(id);
                if(usuarioBuscado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioBuscado);

            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario) 
        {
            try
            {
                _iusuarioRepository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuario usuario)
        {
            try
            {
                _iusuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario atualizado! :)");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            try
            {
                _iusuarioRepository.Deletar(id);
                return Ok("Usuário Excluido! ");
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }

}
