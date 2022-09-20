using UrnaEletronica.API.Models;

namespace UrnaEletronica.API.Interfaces
{
    public interface ICandidato
    {
        void Adicionar(Candidato candidato);
        void Alterar(Candidato candidato);
        void Excluir(Candidato candidato);
        Task<bool> Salvar();
        Task<Candidato> RetornarIdCandidato(int id);
        Task<IEnumerable<Candidato>> LerRegistrosDeCandidatos();

    }
}
