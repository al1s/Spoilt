using System;
using Xunit;
using Spoilt.Controllers;
using Spoilt.Models;

namespace SpoiltTests
{
    public class SetGetTests
    {
        /// <summary>
        /// Test whether can set OMDB search results name
        /// </summary>
        [Fact]
        public void CanSetOMDBSearchResultsName()
        {
            OMDB oMDB = new OMDB()
            {
                Name = "MyMovie",
                TotalResults = 1
            };
            Assert.Equal("MyMovie", oMDB.Name);
            Assert.Equal(1, oMDB.TotalResults);
        }
        /// <summary>
        /// Test whether can get OMDB search results name
        /// </summary>
        [Fact]
        public void CanGetOMDBSearchResultsName()
        {
            OMDB oMDB = new OMDB()
            {
                Name = "MyMovie",
                TotalResults = 1
            };
            Assert.Equal("MyMovie", oMDB.Name);
        }
        /// <summary>
        /// Test whether can set Movie search description data
        /// </summary>
        [Fact]
        public void CanSetMovieSearchDescriptionData()
        {
            MovieSearchDescription msd = new MovieSearchDescription()
            {
                Title = "MyMovie",
                Year = "1999",
                ImdbID = "DD12211",
                Type = "MyType",
                Poster = "http://a.com"
            };
            Assert.Equal("MyMovie", msd.Title);
            Assert.Equal("1999", msd.Year);
            Assert.Equal("DD12211", msd.ImdbID);
            Assert.Equal("MyType", msd.Type);
            Assert.Equal("http://a.com", msd.Poster);
        }
        /// <summary>
        /// Test whether can get Movie search description title
        /// </summary>
        [Fact]
        public void CanGetMovieSearchDescriptionTitle()
        {
            MovieSearchDescription msd = new MovieSearchDescription()
            {
                Title = "MyMovie",
            };
            Assert.Equal("MyMovie", msd.Title);
        }
        /// <summary>
        /// Test whether can set Movie data
        /// </summary>
        [Fact]
        public void CanSetMovieData()
        {
            Movie movie = new Movie()
            {
                Title = "MyMovie",
                Plot = "MyPlot",
                ID = "DD12211",
                Genre = "MyType",
                Poster = "http://a.com"
            };
            Assert.Equal("MyMovie", movie.Title);
            Assert.Equal("MyPlot", movie.Plot);
            Assert.Equal("DD12211", movie.ID);
            Assert.Equal("MyType", movie.Genre);
            Assert.Equal("http://a.com", movie.Poster);
        }
        /// <summary>
        /// Test whether can get Movie data
        /// </summary>
        [Fact]
        public void CanGetMovieData()
        {
            Movie movie = new Movie()
            {
                Title = "MyMovie",
            };
            Assert.Equal("MyMovie", movie.Title);
        }
        /// <summary>
        /// Test whether can set Spoiler data
        /// </summary>
        [Fact]
        public void CanSetSpoilerData()
        {
            Spoiler spoiler = new Spoiler()
            {
                ID = 1,
                MovieID = "DD12211",
                SpoilerText = "MyText",
                Created = DateTime.Parse("1999/1/1")
            };
            Assert.Equal(1, spoiler.ID);
            Assert.Equal("DD12211", spoiler.MovieID);
            Assert.Equal("MyText", spoiler.SpoilerText);
            Assert.Equal(DateTime.Parse("1999/1/1"), spoiler.Created);
        }
        /// <summary>
        /// Test whether can get Spoiler data
        /// </summary>
        [Fact]
        public void CanGetSpilerData()
        {
            Spoiler spoiler = new Spoiler()
            {
                SpoilerText = "MyText",
            };
            Assert.Equal("MyText", spoiler.SpoilerText);
        }
        /// <summary>
        /// Test whether can set Vote data
        /// </summary>
        [Fact]
        public void CanSetVoteData()
        {
            Vote vote = new Vote()
            {
                ID = 1,
                MovieID = "DD12211",
                SpoilerID = 2,
                CreatedAt = DateTime.Parse("1999/1/1"),
                UserSessionID = "MyUserSessionID"
            };
            Assert.Equal(1, vote.ID);
            Assert.Equal("DD12211", vote.MovieID);
            Assert.Equal(2, vote.SpoilerID);
            Assert.Equal(DateTime.Parse("1999/1/1"), vote.CreatedAt);
            Assert.Equal("MyUserSessionID", vote.UserSessionID);
        }
        /// <summary>
        /// Test whether can get Vote data
        /// </summary>
        [Fact]
        public void CanGetVoteData()
        {
            Vote vote = new Vote()
            {
                UserSessionID = "MyUserSessionID"
            };
            Assert.Equal("MyUserSessionID", vote.UserSessionID);
        }
        /// <summary>
        /// Test whether can set UserSession data
        /// </summary>
        [Fact]
        public void CanSetUserSessionData()
        {
            UserSession uSession = new UserSession()
            {
                ID = "1",
                CreatedAt = DateTime.Parse("1999/1/1"),
            };
            Assert.Equal("1", uSession.ID);
            Assert.Equal(DateTime.Parse("1999/1/1"), uSession.CreatedAt);
        }
        /// <summary>
        /// Test whether can get UserSession data
        /// </summary>
        [Fact]
        public void CanGetUserSession()
        {
            UserSession uSession = new UserSession()
            {
                ID = "1",
            };
            Assert.Equal("1", uSession.ID);
        }
    }
}
