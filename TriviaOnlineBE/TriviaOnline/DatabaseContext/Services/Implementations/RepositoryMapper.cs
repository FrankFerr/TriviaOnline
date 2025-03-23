using AutoMapper;
using Shared.ViewModel;
using TriviaRepository.Context.TriviaModel;

namespace TriviaRepository.Services.Implementations
{
    public class RepositoryMapper : Profile
    {
        public RepositoryMapper()
        {
            CreateMap<UtentiVM, Utenti>();
            CreateMap<PartiteVM, Partite>();
            CreateMap<CategorieVM, Categorie>();
            CreateMap<PartiteDomandeVM, PartiteDomande>();
            CreateMap<PartiteUtentiVM, PartiteUtenti>();
            CreateMap<PartiteUtentiRisposteVM, PartiteUtentiRisposte>();
            CreateMap<DomandeVM, Domande>();
            CreateMap<DomandeRisposteVM, DomandeRisposte>();
            CreateMap<StoricoPartiteVM, StoricoPartite>();
            CreateMap<StoricoPartiteUtentiVM, StoricoPartiteUtenti>();
            CreateMap<StoricoPartiteUtentiDomVM, StoricoPartiteUtentiDom>();
        }
    }
}
