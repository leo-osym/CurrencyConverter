using System.Reflection;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace CurrencyConverter.Test
{
    [TestFixture]
    public class InteractorTest
    {
        private IInteractor _interactor;
        private Mock<IRequester> _requester;

        [SetUp]
        public void SetUp()
        {
            _requester = new Mock<IRequester>(MockBehavior.Strict);
            _interactor = new Interactor(_requester.Object);
        }

        [Test]
        public void CtorRequesterTest()
        {
            var expected =
                typeof(Interactor)
                    .GetField("_requester",
                    BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(_interactor);
            Assert.AreEqual(_requester.Object, expected);
        }

        [Test]
        public async Task GetCourseTest()
        {
            //Given
            string currencyCode1 = "USD";
            string currencyCode2 = "UAH";
            decimal firstValue = 1M;
            decimal res = 26.4546M;
            decimal expected = res * firstValue;

            _requester.Setup(f => f.RequestAsync(currencyCode1, currencyCode2))
               .Returns(Task.FromResult(res));
            //When
            var actual = await _interactor.GetCourse(currencyCode1, currencyCode2, firstValue);
            //Then
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetCourseIfDataIsNullOrEmptyTest()
        {
            //Given
            string currencyCode1 = "USD";
            string currencyCode2 = "UAH";
            decimal firstValue = 23.5M;
            decimal expected = -1M;
            _requester.Setup(f => f.RequestAsync(currencyCode1, currencyCode2))
               .Returns(Task.FromResult(-1M));
            //When
            var actual = await _interactor.GetCourse(currencyCode1, currencyCode2, firstValue);
            //Then
            Assert.AreEqual(expected, actual);
        }

    }
}
