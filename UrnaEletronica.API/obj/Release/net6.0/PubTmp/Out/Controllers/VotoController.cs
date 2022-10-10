using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Web.Http.Results;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : Controller
    {
        private readonly IVoto _voto;
        private readonly UrnaEletronicaContext _contexto;

        public VotoController(IVoto voto, UrnaEletronicaContext contexto)
        {
            _voto = voto;
            _contexto = contexto;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Votos>>> Index()
        {
            return Json(await _voto.LerVotos());
        }

        [HttpPost("Votacao")]
        [DisableCors]
        public ActionResult Votar(int voto)
        {
            _voto.Adicionar(voto);
            if (_voto.Salvar())
            {
                return Json(Results.Ok());
            }
            else
            {
                return Json(BadRequest("Erro na requisicao"));
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
            return Json(BadRequest("Erro ao excluir voto"));
        }
    }
}
