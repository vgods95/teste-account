using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Repositorios
{
    public class VotoRepository : IVoto
    {
        private readonly UrnaEletronicaContext _contexto;

        public VotoRepository(UrnaEletronicaContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Votos voto)
        {
            Votos itemVoto = _contexto.Votos.Where(v => v.IdCandidato == voto.IdCandidato).FirstOrDefault();
            if (itemVoto.QuantidadeDeVotos == null) { itemVoto.QuantidadeDeVotos = 0; }
            itemVoto.QuantidadeDeVotos += voto.QuantidadeDeVotos;
            _contexto.Votos.Update(itemVoto);
            //_contexto.Votos.Add(voto);
        }

        public void Excluir(Votos voto)
        {
            _contexto.Votos.Remove(voto);
        }

        public async Task<IEnumerable<Votos>> LerVotos()
        {
            return await _contexto.Votos.ToListAsync();
        }

        public bool Salvar()
        {
            return _contexto.SaveChanges() > 0;
        }

        public async Task<Votos> RetornarIdVoto(int id)
        {
            return await _contexto.Votos.Where(v => v.IdVoto == id).FirstOrDefaultAsync();
        }
    }
}
