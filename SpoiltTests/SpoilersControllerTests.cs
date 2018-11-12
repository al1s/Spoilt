using System.Collections.Generic;
using Spoilt.Controllers;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpoiltTests
{
    public class SpoilersControllerTests
    {
        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task SpoilersCreate_ReturnsViewResultWithAMovieModel()
        {
            // arrange
            string movieIdToSpoil = "ID1";
            var movieMockRepo = new Mock<IMovie>();
            var spoilerMockRepo = new Mock<ISpoiler>();
            movieMockRepo.Setup(repo => repo.GetMovieById(movieIdToSpoil)).ReturnsAsync(GetTestMovieWithSpoilers());
            var controller = new SpoilersController(movieMockRepo.Object, spoilerMockRepo.Object);

            // act
            var result = await controller.Create(movieIdToSpoil);

            // assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Movie>(viewResult.ViewData["movie"]);
            Assert.Equal(GetTestMovieWithSpoilers().Title, model.Title);
        }
        /// <summary>
        /// Controller can return RedirectToActionResult with a valid redirection route
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task SpoilersCreatePost_ReturnsRedirectToActionResult()
        {
            // arrange
            string movieIdToSpoil = "ID1";
            Spoiler spoiler = GetTestSpoiler();
            var movieMockRepo = new Mock<IMovie>();
            var spoilerMockRepo = new Mock<ISpoiler>();
            movieMockRepo.Setup(repo => repo.GetMovieById(movieIdToSpoil)).ReturnsAsync(GetTestMovieWithSpoilers());
            spoilerMockRepo.Setup(repo => repo.AddOne(spoiler)).ReturnsAsync(true);
            var controller = new SpoilersController(movieMockRepo.Object, spoilerMockRepo.Object);

            // act
            var result = await controller.Create(movieIdToSpoil, spoiler);

            // assert 
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Details", viewResult.ActionName);
            Assert.Equal("Movies", viewResult.ControllerName);
        }
        /// <summary>
        /// Controller can return RedirectToActionResult with a valid redirection route
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task SpoilersCreatePost_WithIncorrectModel_ReturnsDBException()
        {
            // arrange
            string movieIdToSpoil = "ID1";
            Spoiler spoiler = GetTestSpoiler();
            var movieMockRepo = new Mock<IMovie>();
            var spoilerMockRepo = new Mock<ISpoiler>();
            movieMockRepo.Setup(repo => repo.GetMovieById(movieIdToSpoil)).ReturnsAsync(GetTestMovieWithSpoilers());
            spoilerMockRepo.Setup(repo => repo.AddOne(spoiler)).ReturnsAsync(true);
            var controller = new SpoilersController(movieMockRepo.Object, spoilerMockRepo.Object);
            controller.ModelState.AddModelError("SpoilerText", "We need a spoiler text to add it");

            // act
            var result = await controller.Create(movieIdToSpoil, spoiler);

            // assert 
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Movie>(viewResult.ViewData["movie"]);
            Assert.Equal(GetTestMovieWithSpoilers().Title, model.Title);
        }
        /// <summary>
        /// Controller can return RedirectToActionResult with a valid redirection route
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task SpoilersCreatePost_ReturnsNotFoundResultForNotMatchedIDs()
        {
            // arrange
            string movieIdToSpoil = "ID2";
            Spoiler spoiler = GetTestSpoiler();
            var movieMockRepo = new Mock<IMovie>();
            var spoilerMockRepo = new Mock<ISpoiler>();
            movieMockRepo.Setup(repo => repo.GetMovieById(movieIdToSpoil)).ReturnsAsync(GetTestMovieWithSpoilers());
            spoilerMockRepo.Setup(repo => repo.AddOne(spoiler)).ReturnsAsync(true);
            var controller = new SpoilersController(movieMockRepo.Object, spoilerMockRepo.Object);

            // act
            var result = await controller.Create(movieIdToSpoil, spoiler);

            // assert 
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }

        private Spoiler GetTestSpoiler()
        {
            return new Spoiler()
            {
                SpoilerText = "Spoiler1",
                Votes = 1,
                MovieID = "ID1"
            };
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
    }
}
