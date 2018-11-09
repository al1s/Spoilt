using System.Linq;
using System.Collections.Generic;
using Spoilt.Controllers;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SpoiltTests
{
    public class MovieControllerTests
    {
        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task MovieIndex_ReturnsViewResult()
        {
            // arrange
            var movieMockRepo = new Mock<IMovie>();
            var votesMockRepo = new Mock<IVote>();
            movieMockRepo.Setup(repo => repo.GetMovies()).ReturnsAsync(GetTestMovies());
            var controller = new MoviesController(movieMockRepo.Object, votesMockRepo.Object);

            // act
            var result = await controller.Index();

            // assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Movie>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task MovieSearch_ReturnsViewResult()
        {
            // arrange
            var movieMockRepo = new Mock<IMovie>();
            var votesMockRepo = new Mock<IVote>();
            movieMockRepo.Setup(repo => repo.GetMoviesByTitle("test")).ReturnsAsync(GetTestMovies());
            var controller = new MoviesController(movieMockRepo.Object, votesMockRepo.Object);

            // act
            var result = await controller.Search("test");

            // assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Movie>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task MovieDetails_ReturnsViewResult()
        {
            // arrange
            var movieMockRepo = new Mock<IMovie>();
            var votesMockRepo = new Mock<IVote>();
            movieMockRepo.Setup(repo => repo.GetMovieById("1")).ReturnsAsync(GetTestMovieWithSpoilers());
            votesMockRepo.Setup(repo => repo.GetVotesBySpoilerID(1)).Returns(1);
            var controller = new MoviesController(movieMockRepo.Object, votesMockRepo.Object);

            // act
            var result = await controller.Details("1");

            // assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Movie>(viewResult.ViewData.Model);
        }


        private List<Movie> GetTestMovies()
        {
            var movies = new List<Movie>() {
            new Movie()
            {
                Title = "Movie1",
                Genre = "Genre1",
                Plot = "Plot1",
                ID = "ID1",
                Poster = "Poster1"
            },
            new Movie()
            {
                Title = "Movie2",
                Genre = "Genre2",
                Plot = "Plot2",
                ID = "ID2",
                Poster = "Poster2"
            }};
            return movies;
        }
        private Movie GetTestMovieWithSpoilers()
        {
            var movie = new Movie()
            {
                Title = "Movie1",
                Genre = "Genre1",
                Plot = "Plot1",
                ID = "ID1",
                Poster = "Poster1",
                Spoilers = new List<Spoiler>()
                {
                    new Spoiler()
                    {
                        SpoilerText = "Spoiler1",
                        Votes = 1
                    }
                }
                
            };
            return movie;
        }
        private Spoiler GetTestSpoiler()
        {
            return new Spoiler()
            {
                SpoilerText = "Spoiler1",
                Votes = 1
            };
        }
    }
}
