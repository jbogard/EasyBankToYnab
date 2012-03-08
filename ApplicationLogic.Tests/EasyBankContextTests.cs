using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuestMaster.EasyBankToYnab.Gateways.EasyBank;
using QuestMaster.EasyBankToYnab.Gateways.Xml;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

namespace QuestMaster.EasyBankToYnab.ApplicationLogic
{
  public class EasyBankContextTests
  {
    [TestClass]
    public class ConstructorTests
    {
      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void NullEasyBankGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          null,
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlGateway>().Object,
          new Mock<IMapper>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void NullYnabGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<IEasyBankGateway>().Object,
          null,
          new Mock<IXmlGateway>().Object,
          new Mock<IMapper>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void NullXmlGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<IEasyBankGateway>().Object,
          new Mock<IYnabGateway>().Object,
          null,
          new Mock<IMapper>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof(ArgumentNullException))]
      public void NullMapper_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<IEasyBankGateway>().Object,
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlGateway>().Object,
          null);
      }
    }
  }
}