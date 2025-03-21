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
        }
    }
}
