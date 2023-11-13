using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieProject.Model;
using MoviesDotNetCore.Model;
using MoviesDotNetCore.Repositories;

namespace MoviesDotNetCore.Controllers;

[ApiController]
[Route("search")]
public class SearchController
{
    private readonly IMovieRepository _movieRepository;

    public SearchController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public Task<List<Movie>> SearchMovies([FromQuery(Name = "q")] string search)
    {
        return _movieRepository.Search(search);
    }

    [HttpGet]
    public async Task<List<Actor>> RelatedActors([FromQuery(Name = "q")] string search)
    {
        return await _movieRepository.RelatedActors(search);
    }
}