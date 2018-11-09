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

namespace SpoiltTests
{
    public class VotesControllerTests
    {
        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public async Task VotesCreate_ReturnsViewResult()
        {
            // arrange
            Vote vote = new Vote()
            {
                MovieID = "Movie1",
                SpoilerID = 1,
                UserSessionID = "UserSessionId1"
            };
            int userHasVoted = 1;
            var expectedResult = new { voteCounted = false };
            var sessionMockRepo = new Mock<IUserSession>();
            var votesMockRepo = new Mock<IVote>();
            votesMockRepo.Setup(repo => repo.CheckIfUserAlreadyVotedForSpoiler(vote.SpoilerID, vote.UserSessionID)).Returns(userHasVoted);
            sessionMockRepo.Setup(repo => repo.CreateSessionString(vote.UserSessionID));
            var controller = new VotesController(votesMockRepo.Object, sessionMockRepo.Object);

            // act
            var result = await controller.Create(vote);

            // assert 
            var viewResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(expectedResult, viewResult.Value);
        }
    }
}
