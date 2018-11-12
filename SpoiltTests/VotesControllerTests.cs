using System;
using System.Linq;
using System.Collections.Generic;
using Spoilt.Controllers;
using Spoilt.Models;
using Spoilt.Models.Interfaces;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpoiltTests
{
    public class VotesControllerTests
    {
        /// <summary>
        /// Controller can return ViewResult with a valid result for already voted user
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task VotesCreate_ReturnsJSONWithFalseObjectResult()
        {
            // arrange
            Vote vote = new Vote()
            {
                MovieID = "Movie1",
                SpoilerID = 1,
                UserSessionID = "UserSessionId1"
            };
            int userHasVoted = 1;
            var expectedValue = JsonConvert.SerializeObject(new { voteCounted = false });
            var sessionMockRepo = new Mock<IUserSession>();
            var votesMockRepo = new Mock<IVote>();
            votesMockRepo.Setup(repo => repo.CheckIfUserAlreadyVotedForSpoiler(vote.SpoilerID, vote.UserSessionID)).Returns(userHasVoted);
            sessionMockRepo.Setup(repo => repo.CreateSessionString(vote.UserSessionID)).Returns(Task.FromResult(0));
            var controller = new VotesController(votesMockRepo.Object, sessionMockRepo.Object);

            // act
            var result = await controller.Create(vote);

            // assert 
            var viewResult = Assert.IsType<JsonResult>(result);
            string value = JsonConvert.SerializeObject(viewResult.Value);
            Assert.Equal(expectedValue, value);
        }
        /// <summary>
        /// Controller can return ViewResult with a valid result for a new user
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task VotesCreate_ReturnsJSONWithTrueObjectResult()
        {
            // arrange
            Vote vote = new Vote()
            {
                MovieID = "Movie1",
                SpoilerID = 1,
                UserSessionID = "UserSessionId1"
            };
            int userHasVoted = 0;
            var expectedValue = JsonConvert.SerializeObject(new { voteCounted = true });
            var sessionMockRepo = new Mock<IUserSession>();
            var votesMockRepo = new Mock<IVote>();
            votesMockRepo.Setup(repo => repo.CheckIfUserAlreadyVotedForSpoiler(vote.SpoilerID, vote.UserSessionID)).Returns(userHasVoted);
            sessionMockRepo.Setup(repo => repo.CreateSessionString(vote.UserSessionID)).Returns(Task.FromResult(0));
            var controller = new VotesController(votesMockRepo.Object, sessionMockRepo.Object);

            // act
            var result = await controller.Create(vote);

            // assert 
            var viewResult = Assert.IsType<JsonResult>(result);
            string value = JsonConvert.SerializeObject(viewResult.Value);
            Assert.Equal(expectedValue, value);
        }
    }
}
