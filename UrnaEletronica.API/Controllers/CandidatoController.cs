using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatoController : Controller
    {
        private readonly ICandidato _iCandidato;
        private readonly UrnaEletronicaContext _contexto;

        public CandidatoController(ICandidato iCandidato, UrnaEletronicaContext contexto)
        {
            _iCandidato = iCandidato;
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> Index()
        {
            return Json(await _iCandidato.LerRegistrosDeCandidatos());
        }

        [HttpPost]
        public async Task<ActionResult> CadastroDeCandidato(Candidato candidato)
        {
            _iCandidato.Adicionar(candidato);
            if (await _iCandidato.Salvar())
            {
                return Json("Candidato Registrado com sucesso");
            }
            return Json(BadRequest("Erro ao registrar candidato"));
        }

        [HttpPut]
        public async Task<ActionResult> EditarCandidato(Candidato candidato)
        {
            _iCandidato.Alterar(candidato);
            if (await _iCandidato.Salvar())
            {
                return Json("Alteração realizada com sucesso");
            }
            return Json(BadRequest("Erro ao salvar alteração"));
        }

        [HttpDelete]
        public async Task<ActionResult> ExcluirCandidato(Candidato candidato)
        {
            _iCandidato.Excluir(candidato);
            if (await _iCandidato.Salvar())
            {
                return Json("Candidato Excluído com sucesso");
            }
            return Json(BadRequest("Erro ao excluir candidadto"));
        }
    }
}
