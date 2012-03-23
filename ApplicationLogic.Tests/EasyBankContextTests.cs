using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuestMaster.EasyBankToYnab.Gateways;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContextTests
  {
    [TestClass]
    public class ConstructorTests
    {
      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullEasyBankGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          null,
          new Mock<IYnabAgent>().Object,
          new Mock<IXmlAgent>().Object,
          new Mock<IFileAccess>().Object,
          new Mock<IPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullYnabGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvAgent>().Object,
          null,
          new Mock<IXmlAgent>().Object,
          new Mock<IFileAccess>().Object,
          new Mock<IPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullXmlGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvAgent>().Object,
          new Mock<IYnabAgent>().Object,
          null,
          new Mock<IFileAccess>().Object,
          new Mock<IPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullFileAccess_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvAgent>().Object,
          new Mock<IYnabAgent>().Object,
          new Mock<IXmlAgent>().Object,
          null,
          new Mock<IPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullPathProviderFileAccess_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvAgent>().Object,
          new Mock<IYnabAgent>().Object,
          new Mock<IXmlAgent>().Object,
          new Mock<IFileAccess>().Object,
          null);
      }
    }
  }
}