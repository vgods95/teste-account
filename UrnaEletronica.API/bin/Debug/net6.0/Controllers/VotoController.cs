using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;
using UrnaEletronica.API.SQL;

namespace UrnaEletronica.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class VotoController : Controller
    {
        private readonly IVoto _voto;
        private readonly UrnaEletronicaContext _contexto;

        public VotoController(IVoto voto, UrnaEletronicaContext contexto)
        {
            _voto = voto;
            _contexto = contexto;
        }
        [HttpGet("index")]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost("votar")]
        public ActionResult Votar(Votos votacao)
        {
            _voto.Adicionar(votacao);

            if (_voto.Salvar())
            {
                return Json(Results.Ok(votacao));
            }
            else
            {
                return Json(BadRequest("Ops, erro ao salvar"));
            }

        }

        [HttpDelete]
        public async Task<ActionResult> ExcluirVoto(Votos voto)
        {
            _voto.Excluir(voto);
            if (_voto.Salvar())
            {
                return Json("Voto Excluído com sucesso");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
