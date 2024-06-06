using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using LifestyleChecker.Framework.Services;
using LifestyleChecker.Framework.Contracts;
using LifestyleChecker.WebApi.Clients;
using Microsoft.Extensions.Configuration;
using LifestyleChecker.WebApi.Models;
using System.Xml.Linq;
using System.Net.Http;
using Moq.Protected;
using System.Net;


namespace LifestyleChecker.Framework.Tests.Services
{
    [ExcludeFromCodeCoverage]
    [TestFixture()]
    public class QuestionsServicesTests
    {
        private Mock<IAireLogger<QuestionsService>> _mockLogger;
        private Mock<IHttpClientFactory> _mockHttpClientFactory;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<IAireLogger<QuestionsService>>();
            _mockHttpClientFactory = new Mock<IHttpClientFactory>();

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(@"[{""from"":16,""to"":21,""q1"":1,""q2"":2,""q3"":1},{""from"":22,""to"":40,""q1"":2,""q2"":2,""q3"":3},{""from"":41,""to"":65,""q1"":3,""q2"":2,""q3"":2},{""from"":64,""to"":null,""q1"":3,""q2"":3,""q3"":1}]"),
            };
            HttpResponseMessage httpResult = new HttpResponseMessage();
            httpMessageHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                        "SendAsync",
                        ItExpr.IsAny<HttpRequestMessage>(),
                        ItExpr.IsAny<CancellationToken>()
                    )
                    .ReturnsAsync(response)
                    .Verifiable();

            var httpClient = new HttpClient(httpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://xxxx")
            };
            _mockHttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);
        }

        [Test]
        public async Task WhenAgeIsIncorrectReturns0()
        {
            var age = 0;
            var mockAnswers = new Dictionary<int, bool>
            {
                { 1, Faker.BooleanFaker.Boolean() },
                { 2, Faker.BooleanFaker.Boolean() }
            };

            var service = new QuestionsService(_mockLogger.Object, _mockHttpClientFactory.Object);

            var result = service.CalculateScore(age, mockAnswers);

            Assert.AreEqual(0, result.Result.Value);
        }

        [Test]
        public async Task WhenNoAnwsersReturns0()
        {
            var age = 18;
            var mockAnswers = new Dictionary<int, bool>
            {
            };

            var service = new QuestionsService(_mockLogger.Object, _mockHttpClientFactory.Object);

            var result = service.CalculateScore(age, mockAnswers);

            Assert.AreEqual(0, result.Result.Value);
        }

        [Test]
        public async Task WhenDataIsCorrectReturnsValue()
        {
            var age = 18;
            var mockAnswers = new Dictionary<int, bool>
            {
                { 1, Faker.BooleanFaker.Boolean() },
                { 2, Faker.BooleanFaker.Boolean() }
            };

            var service = new QuestionsService(_mockLogger.Object, _mockHttpClientFactory.Object);

            var result = service.CalculateScore(age, mockAnswers);

            Assert.AreEqual(0, result.Result.Value);
        }
    }
}
