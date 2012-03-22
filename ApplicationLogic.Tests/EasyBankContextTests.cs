﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QuestMaster.EasyBankToYnab.Gateways;
using QuestMaster.EasyBankToYnab.Gateways.Csv;
using QuestMaster.EasyBankToYnab.Gateways.Ynab;

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
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlAgent>().Object,
          new Mock<IMapper>().Object,
          new Mock<IFileAccess>().Object,
          new Mock<IDefaultPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullYnabGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvGateway>().Object,
          null,
          new Mock<IXmlAgent>().Object,
          new Mock<IMapper>().Object,
          new Mock<IFileAccess>().Object,
          new Mock<IDefaultPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullXmlGateway_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvGateway>().Object,
          new Mock<IYnabGateway>().Object,
          null,
          new Mock<IMapper>().Object,
          new Mock<IFileAccess>().Object,
          new Mock<IDefaultPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullMapper_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvGateway>().Object,
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlAgent>().Object,
          null,
          new Mock<IFileAccess>().Object,
          new Mock<IDefaultPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullFileAccess_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvGateway>().Object,
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlAgent>().Object,
          new Mock<IMapper>().Object,
          null,
          new Mock<IDefaultPathProvider>().Object);
      }

      [TestMethod]
      [ExpectedException(typeof (ArgumentNullException))]
      public void NullPathProviderFileAccess_ShouldThrowArgumentNullException()
      {
        new EasyBankContext(
          new Mock<ICsvGateway>().Object,
          new Mock<IYnabGateway>().Object,
          new Mock<IXmlAgent>().Object,
          new Mock<IMapper>().Object,
          new Mock<IFileAccess>().Object,
          null);
      }
    }
  }
}