using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
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
        private readonly IVoto _voto;

        public HomeController(ILogger<HomeController> logger, UrnaEletronicaContext contexto, ICandidato candidato, IVoto voto)
        {
            _logger = logger;
            _contexto = contexto;
            _candidato = candidato;
            _voto = voto;
        }

        public IActionResult Index()
        {
            var lista = _contexto.Candidato.ToList();
            return View(lista); 
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
            return Json(carregarCandidato);
        }

        [HttpGet]
        public ActionResult ListarCandidatos()
        {
            var lista = _contexto.Candidato.ToList();
            return View(lista);
        }

        [HttpGet("Votos")]
        public IActionResult Votos()
        { 
            var votos = _contexto.Votos;
            var votosOrdenados = votos.OrderByDescending(v => v.QuantidadeDeVotos);
            return View(votos.ToList());
        }

        [HttpGet("CadastrarCandidato")]
        public ActionResult CadastrarCandidato()
        {
            return View();
        }

        [HttpPost(Name = "CadastroDeCandidato")]
        public async Task<IActionResult> CadastroDeCandidato(Candidato candidato)
        {
            _candidato.Adicionar(candidato);
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