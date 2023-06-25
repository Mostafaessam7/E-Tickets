using eTickets.Models.Repositories;
using eTickets.Models.ViewModels;

namespace eTickets.Models.Services
{
    public interface IMovieServices : IRepository<Movie>
    {
        Task<Movie> GetMovieById(int id);
        Task<CreateMovieDropDownsVM> GetCreateMovieDropDownsValues();
        Task AddMovieAsync(CreateMovieVM createMovieVM);
    }
}
