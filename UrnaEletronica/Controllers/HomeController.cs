using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using UrnaEletronica.API.Controllers;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;
using UrnaEletronica.Models;

namespace UrnaEletronica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UrnaEletronicaContext _contexto;
        private readonly ICandidato _candidato;

        public HomeController(ILogger<HomeController> logger, UrnaEletronicaContext contexto, ICandidato candidato)
        {
            _logger = logger;
            _contexto = contexto;
            _candidato = candidato;
        }

        public IActionResult Index()
        {
            var lista = _contexto.Candidato.ToList();
            return View(); 
        }

        [HttpPost]
        public ActionResult EditarCandidato(int id)
        {
            var candidatoParaEdicao = _contexto.Candidato.Where(c => c.IdCandidato == id);
            return View(candidatoParaEdicao);
        }

        [HttpPost("[controller]/legendaDoCandidato")]
        public ActionResult CarregarCandidato(int legenda)
        {
            var carregarCandidato = _contexto.Candidato.Where(c => c.Legenda == legenda);
            return PartialView(carregarCandidato);
        }

        [HttpGet]
        public ActionResult ListarCandidatos()
        {
            var lista = _contexto.Candidato.ToList();
            return View(lista);
        }

        public IActionResult Votos()
        {
            var lista = _contexto.Votos.ToList();
            var candidato = _contexto.Candidato.ToList();
            var ordenar = lista.OrderByDescending(c => c.QuantidadeDeVotos);
            return View(ordenar);
        }

        [HttpGet("Cadastrar")]
        public ActionResult CadastrarCandidato()
        {
            return View();
        }

        [HttpPost(Name = "CadastroDeCandidato")]
        public async Task<IActionResult> CadastroDeCandidato([FromBody] Candidato candidado)
        {
            _candidato.Adicionar(candidado);
            if (await _candidato.Salvar())
            {
                return Json("candidato cadastrado");
            }

            return BadRequest("Erro ao salvar no banco de dados");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}