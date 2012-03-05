﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.239
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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Import of savings account statements")]
    public partial class ImportOfSavingsAccountStatementsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "SavingsAccountImport.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Import of savings account statements", "In order to update my list of transactions\r\nAs a user\r\nI want to import CSV files" +
                    " from EasyBank", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
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
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Statement"});
            table1.AddRow(new string[] {
                        "1",
                        "20027024468;Abbuchung Onlinebanking                      BG/000000107#14200 20010" +
                            "203008 Dirk Rombauts;02.07.2011;01.07.2011;-5,28;EUR"});
            table1.AddRow(new string[] {
                        "2",
                        "20027024468;Abbuchung Onlinebanking                      BG/000000106#14200 20010" +
                            "203008 Dirk Rombauts;29.06.2011;28.06.2011;-1.250,00;EUR"});
            table1.AddRow(new string[] {
                        "3",
                        "20027024468;Abbuchung Onlinebanking                      BG/000000105#14200 20010" +
                            "203008 Dirk Rombauts;15.06.2011;14.06.2011;-500,00;EUR"});
            table1.AddRow(new string[] {
                        "4",
                        "20027024468;Gutschrift Dauerauftrag                      BG/000000104#14200 20010" +
                            "203008 Mag Dirk Rombauts;02.06.2011;01.06.2011;+250,00;EUR"});
            table1.AddRow(new string[] {
                        "5",
                        "20027024468;Gutschrift Dauerauftrag                      BG/000000103#14200 20010" +
                            "203008 Mag Dirk Rombauts;03.05.2011;02.05.2011;+250,00;EUR"});
            table1.AddRow(new string[] {
                        "6",
                        "20027024468;Gutschrift Dauerauftrag                      BG/000000102#14200 20010" +
                            "203008 Mag Dirk Rombauts;02.04.2011;01.04.2011;+250,00;EUR"});
#line 7
  testRunner.Given("the following statements", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Booking Date",
                        "Account",
                        "Description",
                        "Payee",
                        "Value Date",
                        "Amount In",
                        "Amount Out",
                        "Currency",
                        "Is New"});
            table2.AddRow(new string[] {
                        "1",
                        "2011-07-02",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000107",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-07-01",
                        "0.00",
                        "5.28",
                        "EUR",
                        "True"});
            table2.AddRow(new string[] {
                        "2",
                        "2011-06-29",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000106",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-06-28",
                        "0.00",
                        "1250",
                        "EUR",
                        "True"});
            table2.AddRow(new string[] {
                        "3",
                        "2011-06-15",
                        "20027024468",
                        "Abbuchung Onlinebanking BG/000000105",
                        "14200 20010203008 Dirk Rombauts",
                        "2011-06-14",
                        "0.00",
                        "500",
                        "EUR",
                        "True"});
            table2.AddRow(new string[] {
                        "4",
                        "2011-06-02",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000104",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-06-01",
                        "250",
                        "0",
                        "EUR",
                        "True"});
            table2.AddRow(new string[] {
                        "5",
                        "2011-05-03",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000103",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-05-02",
                        "250.00",
                        "0",
                        "EUR",
                        "True"});
            table2.AddRow(new string[] {
                        "6",
                        "2011-04-02",
                        "20027024468",
                        "Gutschrift Dauerauftrag BG/000000102",
                        "14200 20010203008 Mag Dirk Rombauts",
                        "2011-04-01",
                        "250.00",
                        "0",
                        "EUR",
                        "True"});
#line 16
  testRunner.And("these expected entries", ((string)(null)), table2);
#line hidden
        }
        
        public virtual void ImportSavingsAccountStatements(string statement, string entry, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Import savings account statements", exampleTags);
#line 26
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 27
  testRunner.Given("I have an account with number \'20027024468\'");
#line 28
  testRunner.When(string.Format("I import statement \'{0}\'", statement));
#line 29
  testRunner.Then(string.Format("that account should contain entry \'{0}\'", entry));
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 1")]
        public virtual void ImportSavingsAccountStatements_1()
        {
            this.ImportSavingsAccountStatements("1", "1", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 2")]
        public virtual void ImportSavingsAccountStatements_2()
        {
            this.ImportSavingsAccountStatements("2", "2", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 3")]
        public virtual void ImportSavingsAccountStatements_3()
        {
            this.ImportSavingsAccountStatements("3", "3", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 4")]
        public virtual void ImportSavingsAccountStatements_4()
        {
            this.ImportSavingsAccountStatements("4", "4", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 5")]
        public virtual void ImportSavingsAccountStatements_5()
        {
            this.ImportSavingsAccountStatements("5", "5", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Import savings account statements, 6")]
        public virtual void ImportSavingsAccountStatements_6()
        {
            this.ImportSavingsAccountStatements("6", "6", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
