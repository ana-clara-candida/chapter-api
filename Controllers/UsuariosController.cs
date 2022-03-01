﻿using Chapter.WebApi.Models;
using Chapter.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Chapter.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
               return Ok(_usuarioRepository.Listar());
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
                Usuario usuarioProcurado = _usuarioRepository.BuscarporId(id);
                if (usuarioProcurado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioProcurado);
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
                _usuarioRepository.Cadastrar(usuario);
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
                _usuarioRepository.Atualizar(id, usuario);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
    
}
