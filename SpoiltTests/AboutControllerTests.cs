using Microsoft.AspNetCore.Mvc;
using Spoilt.Controllers;
using Xunit;

namespace SpoiltTests
{
    public class AboutControllerTests
    {
        /// <summary>
        /// Controller can return ViewResult with a valid Model
        /// </summary>
        /// <returns>Task</returns>
        [Fact]
        public void AboutIndex_ReturnsViewResult()
        {
            // arrange
            var controller = new AboutController();

            // act
            var result = controller.Index();

            // assert 
            Assert.IsType<ViewResult>(result);
        }
    }
}
