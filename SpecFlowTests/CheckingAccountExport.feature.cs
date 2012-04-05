﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.8.1.0
//      SpecFlow Generator Version:1.8.0.0
//      Runtime Version:4.0.30319.261
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
    [TechTalk.SpecRun.FeatureAttribute("Export of checking account entries")]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Export of checking account entries")))
            {
                QuestMaster.EasyBankToYnab.DomainTests.ExportOfCheckingAccountEntriesFeature.FeatureSetupMsTest(null);
            }
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
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
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetupMsTest(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            new ExportOfCheckingAccountEntriesFeature().FeatureSetup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDownMsTest()
        {
            new ExportOfCheckingAccountEntriesFeature().FeatureTearDown();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Export checking account entries")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Export checking account entries")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Export of checking account entries")]
        public virtual void ExportCheckingAccountEntries()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Export checking account entries", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given("I have an account with number \'20010203008\'");
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
  testRunner.And("the following entries in the account with number \'20010203008\'", ((string)(null)), table1);
#line 23
  testRunner.When("I export all entries from the account with number \'20010203008\'");
#line hidden
#line 24
  testRunner.Then("the result should be", "Date,Category,Payee,Memo,Outflow,Inflow                                          " +
                    "                                            \r\n11.07.2011,Import Statements,,easy" +
                    "kreditkarte MasterCard 000000 MC/000002237,757.70,0.00                          " +
                    "           \r\n11.07.2011,Import Statements,14000 06710704145 Margit Obermaier,Abb" +
                    "uchung Onlinebanking BG/000002236,33.00,0.00              \r\n08.07.2011,Import St" +
                    "atements,14200 20010351775 Dirk Rombauts,Apotheke BG/000002235,23.89,0.00       " +
                    "                         \r\n08.07.2011,Import Statements,14200 20010306702 Tatjan" +
                    "a Habusta,Kindle Books BG/000002234,0.00,21.64                          \r\n05.07." +
                    "2011,Import Statements,14200 20010351775 Dirk Rombauts,Hornbach BG/000002233,9.2" +
                    "5,0.00                                 \r\n05.07.2011,Import Statements,14200 2001" +
                    "0351775 Dirk Rombauts,Kienbacher BG/000002232,489.00,0.00                       " +
                    "      \r\n05.07.2011,Import Statements,32000 00900699090 ORANGE AUSTRIA,0000067734" +
                    "35 OG/000002231,24.10,0.00                           \r\n05.07.2011,Import Stateme" +
                    "nts,WIENER LINIEN GMBH & CO KG 20151 00696216225,Abbuchung Lastschrift OG/000002" +
                    "230,45.80,0.00      \r\n04.07.2011,Import Statements,BASLER VERSICHERUNGS-AG 32000" +
                    " 00000062141,Abbuchung Einzugsermächtigung OG/000002229,50.00,0.00 \r\n04.07.2011," +
                    "Import Statements,14200 20010306702 Tatjana Habusta,Kindle Books BG/000002228,0." +
                    "00,23.26                          \r\n01.07.2011,Import Statements,AMAZON EU SARL " +
                    "19100 00040593000,Abbuchung Einzugsermächtigung OG/000002227,16.31,0.00         " +
                    " \r\n01.07.2011,Import Statements,I7452063 VB/000002226 Walter Rombauts 14000 0011" +
                    "8804139,TRN 20110701RX003135,250.00,0.00\r\n01.07.2011,Import Statements,I7452070 " +
                    "VB/000002225 Walter Rombauts 14000 00118804139,TRN 20110701RX003134,250.00,0.00", ((TechTalk.SpecFlow.Table)(null)));
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
