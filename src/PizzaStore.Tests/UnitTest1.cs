using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;

namespace PizzaStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Container container = new Container();

            Assert.IsNotNull(container.GetInstance<Container>());
        }
    }
}
