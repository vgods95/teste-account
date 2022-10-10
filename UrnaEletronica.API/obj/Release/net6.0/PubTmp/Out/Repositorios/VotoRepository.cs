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

        public void Adicionar(int voto)
        {
            Votos item =_contexto.Votos.Where(t => t.Legenda == voto).FirstOrDefault();
            _contexto.Votos.Update(item);
            item.QuantidadeDeVotos += 1;
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
