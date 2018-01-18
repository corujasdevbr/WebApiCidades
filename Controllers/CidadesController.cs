using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApiCidades.Models;
using WebApiCidades.Repositorio;

namespace WebApiCidades.Controllers
{
    [Route("api/v1/[controller]")]
    public class CidadesController : Controller
    {
        CidadeRep objCidadeRep = new CidadeRep();

        [HttpGet]
        public IEnumerable<CidadeModel> Listar()
        {

            return objCidadeRep.Listar();

        }

        [HttpGet("{id}")]
        public IActionResult BuscarCidadePorId(int id)
        {
            try
            {
                CidadeModel cidade = objCidadeRep.Listar().Where(c => c.Id == id).FirstOrDefault();

                if (cidade == null)
                {
                    return NotFound(id); ;
                }
                else
                {
                    return Ok(cidade);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CidadeModel cidade)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    objCidadeRep.Cadastrar(cidade);
                    return Ok(cidade);
                }

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);

                return BadRequest(allErrors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar([FromBody] CidadeModel cidade)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    objCidadeRep.Editar(cidade);
                    return Ok(cidade);
                }

                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                
                return BadRequest(allErrors);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {

            try
            {
                objCidadeRep.Excluir(id);
                return Ok(id);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}