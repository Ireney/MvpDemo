using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;

namespace MvpDemo.Services.Tests
{
    [TestClass]
    public class RemoteQuoteServiceTests
    {
        private RemoteQuoteService CreateSystemUnderTest(MockHttpMessageHandler httpHandler)
        {
            var client = httpHandler.ToHttpClient();
            client.BaseAddress = new Uri("http://www.test.com");
            return new RemoteQuoteService(client);
        }

        [TestMethod]
        public void ShouldReturnNull_IfRequestFails_OnGetQuotes()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When("/api/stockquotes/AAPL,MSFT")
                .Respond(HttpStatusCode.InternalServerError);

            var sut = CreateSystemUnderTest(mockHttp);

            //Act
            var actual = sut.GetQuotes("AAPL,MSFT");

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ShouldReturnQuotes_IfRequestSucceeds_OnGetQuotes()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();

            mockHttp
                .When("/api/stockquotes/AAPL,MSFT")
                .Respond(HttpStatusCode.OK, "application/json", GetTestJson());

            var sut = CreateSystemUnderTest(mockHttp);

            //Act
            var actual = sut.GetQuotes("AAPL,MSFT");

            //Assert
            Assert.IsTrue(actual.Count == 2);
            Assert.IsTrue(actual[0].Company == "Apple Inc.");
            Assert.IsTrue(actual[1].Company == "Microsoft Corporation");
        }

        [TestMethod]
        public void ShouldReturnNull_IfRequestFails_OnGetProviderName()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();
            mockHttp
                .When("/api/stockquotes")
                .Respond(HttpStatusCode.InternalServerError);

            var sut = CreateSystemUnderTest(mockHttp);

            //Act
            var actual = sut.GetProviderName();

            //Assert
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void ShouldReturnProviderName_IfRequestSucceeds_OnGetProviderName()
        {
            //Arrange
            var mockHttp = new MockHttpMessageHandler();

            mockHttp
                .When("/api/stockquotes")
                .Respond(HttpStatusCode.OK, "application/json", "\"Test provider\"");

            var sut = CreateSystemUnderTest(mockHttp);

            //Act
            var actual = sut.GetProviderName();

            //Assert
            Assert.AreEqual("Test provider", actual);
        }

        private string GetTestJson()
        {
            var apple = "{\"Company\":\"Apple Inc.\",\"CurrentQuote\":\"131.54\",\"Change\":\" +0.96% \",\"Date\":\"2 / 7 / 2017\",\"Time\":\"3:18pm\"}";
            var microsoft = "{\"Company\":\"Microsoft Corporation\",\"CurrentQuote\":\"63.355\",\"Change\":\" -0.448% \",\"Date\":\"2 / 7 / 2017\",\"Time\":\"3:18pm\"}";

            return $"[{apple},{microsoft}]";
        }
    }
}
