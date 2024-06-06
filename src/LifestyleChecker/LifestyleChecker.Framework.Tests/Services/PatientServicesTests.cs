using Moq;
using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using LifestyleChecker.Framework.Services;
using LifestyleChecker.Framework.Contracts;
using LifestyleChecker.WebApi.Clients;
using Microsoft.Extensions.Configuration;
using LifestyleChecker.WebApi.Models;
using System.Xml.Linq;


namespace LifestyleChecker.Framework.Tests.Services
{
    [ExcludeFromCodeCoverage]
    [TestFixture()]
    public class PatientServicesTests
    {
        private Mock<IAireLogger<PatientService>> _mockLogger;
        private Mock<IPatientClient> _mockPatientClient;
        private IConfiguration configuration;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<IAireLogger<PatientService>>();
            _mockPatientClient = new Mock<IPatientClient>();

            var mockConfig = new Dictionary<string, string>
            {
                { "PatientApiSettings:ApiKey", Faker.StringFaker.AlphaNumeric(6) }
            };

            configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(mockConfig)
                .Build();
        }

        [Test]
        public async Task WhenNameDoesNotMatchMessageIsReturned()
        {
            var mockName = Faker.NameFaker.Name();
            var mockNhs = Faker.NumberFaker.Number().ToString();
            var mockDob = Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy");

            var mockPatient = new Patient
            {
                Name = mockName,
                NhsNumber = mockNhs,
                Born = mockDob
            };

            var service = new PatientService(_mockLogger.Object, _mockPatientClient.Object, configuration);

            _mockPatientClient.Setup(x => x.GetPatient(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(mockPatient);

            var patient = service.GetPatient(mockNhs, Faker.NameFaker.Name(), mockDob);

            Assert.IsNotNull(patient.Result);
            Assert.IsNull(patient.Result.Name);
            Assert.AreEqual(0, patient.Result.Age);
            Assert.IsNotNull(patient.Result.Message);
        }

        [Test]
        public async Task WhenNhsNumberDoesNotMatchMessageIsReturned()
        {
            var mockName = Faker.NameFaker.Name();
            var mockNhs = Faker.NumberFaker.Number().ToString();
            var mockDob = Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy");

            var mockPatient = new Patient
            {
                Name = mockName,
                NhsNumber = mockNhs,
                Born = mockDob
            };

            var service = new PatientService(_mockLogger.Object, _mockPatientClient.Object, configuration);

            _mockPatientClient.Setup(x => x.GetPatient(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(mockPatient);

            var patient = service.GetPatient(Faker.StringFaker.Numeric(6), mockName, mockDob);

            Assert.IsNotNull(patient.Result);
            Assert.IsNull(patient.Result.Name);
            Assert.AreEqual(0, patient.Result.Age);
            Assert.IsNotNull(patient.Result.Message);
        }

        [Test]
        public async Task WhenDateOfBirthDoesNotMatchMessageIsReturned()
        {
            var mockName = Faker.NameFaker.Name();
            var mockNhs = Faker.NumberFaker.Number().ToString();
            var mockDob = Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy");

            var mockPatient = new Patient
            {
                Name = mockName,
                NhsNumber = mockNhs,
                Born = mockDob
            };

            var service = new PatientService(_mockLogger.Object, _mockPatientClient.Object, configuration);

            _mockPatientClient.Setup(x => x.GetPatient(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(mockPatient);

            var patient = service.GetPatient(mockNhs, mockName, Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy"));

            Assert.IsNotNull(patient.Result);
            Assert.IsNull(patient.Result.Name);
            Assert.AreEqual(0, patient.Result.Age);
            Assert.IsNotNull(patient.Result.Message);
        }

        [Test]
        public async Task WhenPatientDoesNotExistReturnNull()
        {
            var mockName = Faker.NameFaker.Name();
            var mockNhs = Faker.NumberFaker.Number().ToString();
            var mockDob = Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy");

            var mockPatient = new Patient
            {
                Name = mockName,
                NhsNumber = mockNhs,
                Born = mockDob
            };

            var service = new PatientService(_mockLogger.Object, _mockPatientClient.Object, configuration);

            _mockPatientClient.Setup(x => x.GetPatient(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).Throws(new Exception());

            var patient = service.GetPatient(mockNhs, mockName, mockDob);

            Assert.IsNull(patient.Result);
        }

        [Test]
        public async Task WhenUserInputIsCorrectPatientIsReturned()
        {
            var mockName = Faker.NameFaker.Name();
            var mockNhs = Faker.NumberFaker.Number().ToString();
            var mockDob = Faker.DateTimeFaker.DateTime().AddYears(-16).Date.ToString("dd-MM-yyyy");

            var mockPatient = new Patient
            {
                Name = mockName,
                NhsNumber = mockNhs,
                Born = mockDob
            };

            var service = new PatientService(_mockLogger.Object, _mockPatientClient.Object, configuration);

            _mockPatientClient.Setup(x => x.GetPatient(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>())).ReturnsAsync(mockPatient);

            var patient = service.GetPatient(mockNhs, mockName, mockDob);

            Assert.IsNotNull(patient.Result);
            Assert.IsNotNull(patient.Result.Name);
            Assert.IsNotNull(patient.Result.Age);
        }
    }
}
