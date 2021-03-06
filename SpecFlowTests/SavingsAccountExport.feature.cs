﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18052
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace QuestMaster.EasyBankToYnab.DomainTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ExportOfSavingsAccountEntriesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SavingsAccountExport.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Export of savings account entries", "In order to update my list of transactions\r\nAs a user\r\nI want to export my entrie" +
                    "s to YNAB", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Export of savings account entries")))
            {
                QuestMaster.EasyBankToYnab.DomainTests.ExportOfSavingsAccountEntriesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Export savings account entries")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Export of savings account entries")]
        public virtual void ExportSavingsAccountEntries()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Export savings account entries", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 9
  testRunner.Given("I have an account with number \'20027024468\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Booking Date",
                        "Account",
                        "Description",
                        "Payee",
                        "Value Date",
                        "Amount In",
                        "Amount Out",
                        "Currency",
                        "Is New"});
            table1.AddRow(new string[] {
                        "2011-07-02",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000107",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-07-01",
                        "0.00",
                        "5.28",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2011-06-29",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000106",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-06-28",
                        "0.00",
                        "1250",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2011-06-15",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000105",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-06-14",
                        "0.00",
                        "500",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2011-06-02",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000104",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-06-01",
                        "250",
                        "0",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2011-05-03",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000103",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-05-02",
                        "250.00",
                        "0",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2011-04-02",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000102",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-04-01",
                        "250.00",
                        "0",
                        "EUR",
                        "True"});
#line 10
  testRunner.And("the following entries in the account with number \'20027024468\'", ((string)(null)), table1, "And ");
#line 18
  testRunner.When("I export all new entries from the account with number \'20027024468\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 19
  testRunner.Then("the result should be", @"Date,Category,Payee,Memo,Outflow,Inflow                                                                           
01.07.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000107,5.28,0.00       
28.06.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000106,1250.00,0.00    
14.06.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000105,500.00,0.00     
01.06.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000104,0.00,250.00 
02.05.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000103,0.00,250.00 
01.04.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000102,0.00,250.00 ", ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
