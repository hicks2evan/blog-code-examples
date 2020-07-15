using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using _2020_07_15.src.Potato;
using _2020_07_15.src.PotatoProviders;


namespace _2020_07_15.test
{
    [TestClass]
    public class PotatoControllerTest
    {
        private readonly PotatoController potatoController;
        private readonly Mock<IPotatoDbProvider> dbProvider = new Mock<IPotatoDbProvider>();
        private readonly Mock<IPotatoFilestoreProvider> filestoreProvider = new Mock<IPotatoFilestoreProvider>();

        public PotatoControllerTest() {
            potatoController = new PotatoController(dbProvider.Object, filestoreProvider.Object);
        }

        [TestMethod]
        public void CreatePotato_Success_ReturnsId()
        {
            //Setup mock provider
            int returnId = 12345;
            dbProvider.Setup(p => p.CreatePotato(It.IsAny<IPotato>())).Returns(returnId);

            //Call real controller code
            int result = potatoController.CreateNewPotato("Lieutenant J.D. Potato");

            //Check what happened
            Assert.AreEqual(returnId, result);
            dbProvider.Verify(p => p.CreatePotato(It.IsAny<IPotato>()), Times.Once);
        }

        [TestMethod]
        public void CreatePotato_Failure_ReturnsNegative()
        {
            //Setup mock provider with exception
            dbProvider.Setup(p => p.CreatePotato(It.IsAny<IPotato>())).Throws(new System.Exception("database timed out"));

            //Call real controller code
            int result = potatoController.CreateNewPotato("Lieutenant J.D. Potato");

            //Check what happened
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void WritePotatoProfile_Success_ReturnsId()
        {
            //Setup mock provider
            int returnId = 12345;
            filestoreProvider.Setup(p => p.WritePotatoFile(It.IsAny<string>())).Returns(returnId);

            //Call real controller code
            int result = potatoController.WriteProfile("Darth Potato", new string[] {"the force", "fast food"}, "I am a sith lord potato lookin' for love.");

            //Check what happened
            Assert.AreEqual(returnId, result);
            filestoreProvider.Verify(p => p.WritePotatoFile(It.Is<string>(s => s.Contains("the force") && s.Contains("Darth Potato"))), Times.Once);
        }

        [TestMethod]
        public void WritePotatoProfile_Failure_ThrowsException()
        {
            string expectedException = "Something bad happened when trying to write the file.";

            //Setup mock provider
            filestoreProvider.Setup(p => p.WritePotatoFile(It.IsAny<string>())).Throws(new System.Exception("file contained bad data"));

            //Call real controller code
            var exception = Assert.ThrowsException<System.Exception>(() => potatoController.WriteProfile("Darth Potato", new string[] {"the force", "fast food"}, "I am a sith lord potato lookin' for love."));

            //Check what happened
            Assert.AreEqual(expectedException, exception.Message);
        }

        //BAD, this test isn't asserting anything meaningful or making proper use of what Moq has to offer
        [TestMethod]
        public void MeaninglessTest()
        {
            //Setup mock provider
            int potatoId = 12345;
            Potato returnPotato = new Potato();
            dbProvider.Setup(p => p.GetPotato(potatoId)).Returns(returnPotato);

            //Call real controller code
            IPotato result = potatoController.GetPotato(potatoId);

            //No assertions
            //What happened? Who knows? The test passes.
        }
    }
}
