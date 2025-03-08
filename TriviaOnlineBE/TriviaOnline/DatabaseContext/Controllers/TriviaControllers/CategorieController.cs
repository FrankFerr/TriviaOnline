using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class CategorieController : StandardRepositoryController<Categorie>
    {
        public CategorieController(TriviaContext context, IStandardRepository<Categorie> repository) : base(context, repository)
        {
        }
    }
}
