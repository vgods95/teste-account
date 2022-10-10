using Microsoft.EntityFrameworkCore;
using UrnaEletronica.API.Interfaces;
using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Repositorios
{
    public class CandidatoRepository : ICandidato
    {
        private readonly UrnaEletronicaContext _contexto;

        public CandidatoRepository(UrnaEletronicaContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Candidato candidato)
        {
            _contexto.Candidato.Add(candidato);
        }

        public void Alterar(Candidato candidato)
        {
            _contexto.Entry(candidato).State = EntityState.Modified;
        }

        public void Excluir(Candidato candidato)
        {
            _contexto.Candidato.Remove(candidato);
        }

        public async Task<IEnumerable<Candidato>> LerRegistrosDeCandidatos()
        {
            return await _contexto.Candidato.ToListAsync();
        }

        public async Task<Candidato> RetornarIdCandidato(int id)
        {
            return await _contexto.Candidato.Where(c => c.IdCandidato == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Salvar()
        {
            return await _contexto.SaveChangesAsync() > 0;
        }
    }
}
