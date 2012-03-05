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
namespace QuestMaster.EasyBankRepository.DomainTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.8.1.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Export of checking account entries")]
    public partial class ExportOfCheckingAccountEntriesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CheckingAccountExport.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Export of checking account entries", "In order to update my list of transactions\r\nAs a user\r\nI want to export my entrie" +
                    "s to YNAB", ProgrammingLanguage.CSharp, ((string[])(null)));
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
#line 7
  testRunner.Given("I have an account with number \'20010203008\'");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
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
            table1.AddRow(new string[] {
                        "1",
                        "2011-07-12",
                        "20010203008",
                        "easykreditkarte MasterCard 000000 MC/000002237",
                        "",
                        "2011-07-11",
                        "0.00",
                        "757.70",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "2",
                        "2011-07-12",
                        "20010203008",
                        "Abbuchung Onlinebanking BG/000002236",
                        "14000 06710704145 Margit Obermaier",
                        "2011-07-11",
                        "0.00",
                        "33.00",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "3",
                        "2011-07-09",
                        "20010203008",
                        "Apotheke BG/000002235",
                        "14200 20010351775 Dirk Rombauts",
                        "2011-07-08",
                        "0.00",
                        "23.89",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "4",
                        "2011-07-08",
                        "20010203008",
                        "Kindle Books BG/000002234",
                        "14200 20010306702 Tatjana Habusta",
                        "2011-07-08",
                        "21.64",
                        "0",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "5",
                        "2011-07-06",
                        "20010203008",
                        "Hornbach BG/000002233",
                        "14200 20010351775 Dirk Rombauts",
                        "2011-07-05",
                        "0.00",
                        "9.25",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "6",
                        "2011-07-06",
                        "20010203008",
                        "Kienbacher BG/000002232",
                        "14200 20010351775 Dirk Rombauts",
                        "2011-07-05",
                        "0.00",
                        "489.00",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "7",
                        "2011-07-06",
                        "20010203008",
                        "000006773435 OG/000002231",
                        "32000 00900699090 ORANGE AUSTRIA",
                        "2011-07-05",
                        "0.00",
                        "24.10",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "8",
                        "2011-07-06",
                        "20010203008",
                        "Abbuchung Lastschrift OG/000002230",
                        "WIENER LINIEN GMBH & CO KG 20151 00696216225",
                        "2011-07-05",
                        "0.00",
                        "45.80",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "9",
                        "2011-07-05",
                        "20010203008",
                        "Abbuchung Einzugsermächtigung OG/000002229",
                        "BASLER VERSICHERUNGS-AG 32000 00000062141",
                        "2011-07-04",
                        "0.00",
                        "50.00",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "10",
                        "2011-07-05",
                        "20010203008",
                        "Kindle Books BG/000002228",
                        "14200 20010306702 Tatjana Habusta",
                        "2011-07-04",
                        "23.26",
                        "0",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "11",
                        "2011-07-02",
                        "20010203008",
                        "Abbuchung Einzugsermächtigung OG/000002227",
                        "AMAZON EU SARL 19100 00040593000",
                        "2011-07-01",
                        "0.00",
                        "16.31",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "12",
                        "2011-07-02",
                        "20010203008",
                        "TRN 20110701RX003135",
                        "I7452063 VB/000002226 Walter Rombauts 14000 00118804139",
                        "2011-07-01",
                        "0.00",
                        "250.00",
                        "EUR",
                        "True"});
            table1.AddRow(new string[] {
                        "13",
                        "2011-07-02",
                        "20010203008",
                        "TRN 20110701RX003134",
                        "I7452070 VB/000002225 Walter Rombauts 14000 00118804139",
                        "2011-07-01",
                        "0",
                        "250.00",
                        "EUR",
                        "True"});
#line 8
  testRunner.And("the following entries in that account", ((string)(null)), table1);
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Export checking account entries")]
        public virtual void ExportCheckingAccountEntries()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Export checking account entries", ((string[])(null)));
#line 24
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 25
  testRunner.When("I export all entries");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Number",
                        "Line"});
            table2.AddRow(new string[] {
                        "1",
                        "Date,Category,Payee,Memo,Outflow,Inflow"});
            table2.AddRow(new string[] {
                        "2",
                        "11.07.2011,Import Statements,,easykreditkarte MasterCard 000000 MC/000002237,757." +
                            "70,0.00"});
            table2.AddRow(new string[] {
                        "3",
                        "11.07.2011,Import Statements,14000 06710704145 Margit Obermaier,Abbuchung Onlineb" +
                            "anking BG/000002236,33.00,0.00"});
            table2.AddRow(new string[] {
                        "4",
                        "08.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Apotheke BG/00000223" +
                            "5,23.89,0.00"});
            table2.AddRow(new string[] {
                        "5",
                        "08.07.2011,Import Statements,14200 20010306702 Tatjana Habusta,Kindle Books BG/00" +
                            "0002234,0.00,21.64"});
            table2.AddRow(new string[] {
                        "6",
                        "05.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Hornbach BG/00000223" +
                            "3,9.25,0.00"});
            table2.AddRow(new string[] {
                        "7",
                        "05.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Kienbacher BG/000002" +
                            "232,489.00,0.00"});
            table2.AddRow(new string[] {
                        "8",
                        "05.07.2011,Import Statements,32000 00900699090 ORANGE AUSTRIA,000006773435 OG/000" +
                            "002231,24.10,0.00"});
            table2.AddRow(new string[] {
                        "9",
                        "05.07.2011,Import Statements,WIENER LINIEN GMBH & CO KG 20151 00696216225,Abbuchu" +
                            "ng Lastschrift OG/000002230,45.80,0.00"});
            table2.AddRow(new string[] {
                        "10",
                        "04.07.2011,Import Statements,BASLER VERSICHERUNGS-AG 32000 00000062141,Abbuchung " +
                            "Einzugsermächtigung OG/000002229,50.00,0.00"});
            table2.AddRow(new string[] {
                        "11",
                        "04.07.2011,Import Statements,14200 20010306702 Tatjana Habusta,Kindle Books BG/00" +
                            "0002228,0.00,23.26"});
            table2.AddRow(new string[] {
                        "12",
                        "01.07.2011,Import Statements,AMAZON EU SARL 19100 00040593000,Abbuchung Einzugser" +
                            "mächtigung OG/000002227,16.31,0.00"});
            table2.AddRow(new string[] {
                        "13",
                        "01.07.2011,Import Statements,I7452063 VB/000002226 Walter Rombauts 14000 00118804" +
                            "139,TRN 20110701RX003135,250.00,0.00"});
            table2.AddRow(new string[] {
                        "14",
                        "01.07.2011,Import Statements,I7452070 VB/000002225 Walter Rombauts 14000 00118804" +
                            "139,TRN 20110701RX003134,250.00,0.00"});
#line 26
  testRunner.Then("the resulting string should be", ((string)(null)), table2);
#line hidden
            this.ScenarioCleanup();
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