Feature: Import of checking account statements
  In order to update my list of transactions
  As a user
  I want to import CSV files from EasyBank

Scenario: Import checking account statements
  Given I have an account with number '20010203008'
  When I import these statements
   """
   20010203008;Abbuchung Onlinebanking                      BG/000002236|14000 06710704145 Margit Obermaier;12.07.2011;11.07.2011;-33,00;EUR
   20010203008;easykreditkarte MasterCard      000000       MC/000002237;12.07.2011;11.07.2011;-757,70;EUR
   20010203008;Apotheke                                     BG/000002235|14200 20010351775 Dirk Rombauts;09.07.2011;08.07.2011;-23,89;EUR
   20010203008;Kindle Books                                 BG/000002234|14200 20010306702 Tatjana Habusta;09.07.2011;08.07.2011;+21,64;EUR
   20010203008;000006773435                                 OG/000002231|32000 00900699090 ORANGE AUSTRIA;06.07.2011;05.07.2011;-24,10;EUR
   20010203008;Abbuchung Lastschrift                        OG/000002230|WIENER LINIEN GMBH & CO KG          20151 00696216225;06.07.2011;05.07.2011;-45,80;EUR
   20010203008;Hornbach                                     BG/000002233|14200 20010351775 Dirk Rombauts;06.07.2011;05.07.2011;-9,25;EUR
   20010203008;Kienbacher                                   BG/000002232|14200 20010351775 Dirk Rombauts;06.07.2011;05.07.2011;-489,00;EUR
   20010203008;Abbuchung Einzugsermächtigung                OG/000002229|BASLER VERSICHERUNGS-AG             32000 00000062141;05.07.2011;04.07.2011;-50,00;EUR
   20010203008;Kindle Books                                 BG/000002228|14200 20010306702 Tatjana Habusta;05.07.2011;04.07.2011;+23,26;EUR
   20010203008;Abbuchung Einzugsermächtigung                OG/000002227|AMAZON EU SARL                      19100 00040593000;02.07.2011;01.07.2011;-16,31;EUR
   20010203008;TRN         20110701RX003134|I7452070                                     VB/000002225|Walter Rombauts                     14000 00118804139;02.07.2011;01.07.2011;-250,00;EUR
   20010203008;TRN         20110701RX003135|I7452063                                     VB/000002226|Walter Rombauts                     14000 00118804139;02.07.2011;01.07.2011;-250,00;EUR
   """
  Then the account with number '20010203008' should contain these entries
   | Booking Date | Account     | Description                                    | Payee                                                   | Value Date | Amount In | Amount Out | Currency | Is New |
   | 2011-07-12   | 20010203008 | Abbuchung Onlinebanking BG/000002236           | 14000 06710704145 Margit Obermaier                      | 2011-07-11 | 0.00      | 33.00      | EUR      | True   |
   | 2011-07-12   | 20010203008 | easykreditkarte MasterCard 000000 MC/000002237 |                                                         | 2011-07-11 | 0.00      | 757.70     | EUR      | True   |
   | 2011-07-09   | 20010203008 | Apotheke BG/000002235                          | 14200 20010351775 Dirk Rombauts                         | 2011-07-08 | 0.00      | 23.89      | EUR      | True   |
   | 2011-07-09   | 20010203008 | Kindle Books BG/000002234                      | 14200 20010306702 Tatjana Habusta                       | 2011-07-08 | 21.64     | 0          | EUR      | True   |
   | 2011-07-06   | 20010203008 | 000006773435 OG/000002231                      | 32000 00900699090 ORANGE AUSTRIA                        | 2011-07-05 | 0.00      | 24.10      | EUR      | True   |
   | 2011-07-06   | 20010203008 | Abbuchung Lastschrift OG/000002230             | WIENER LINIEN GMBH & CO KG 20151 00696216225            | 2011-07-05 | 0.00      | 45.80      | EUR      | True   |
   | 2011-07-06   | 20010203008 | Hornbach BG/000002233                          | 14200 20010351775 Dirk Rombauts                         | 2011-07-05 | 0.00      | 9.25       | EUR      | True   |
   | 2011-07-06   | 20010203008 | Kienbacher BG/000002232                        | 14200 20010351775 Dirk Rombauts                         | 2011-07-05 | 0.00      | 489.00     | EUR      | True   |
   | 2011-07-05   | 20010203008 | Abbuchung Einzugsermächtigung OG/000002229     | BASLER VERSICHERUNGS-AG 32000 00000062141               | 2011-07-04 | 0.00      | 50.00      | EUR      | True   |
   | 2011-07-05   | 20010203008 | Kindle Books BG/000002228                      | 14200 20010306702 Tatjana Habusta                       | 2011-07-04 | 23.26     | 0          | EUR      | True   |
   | 2011-07-02   | 20010203008 | Abbuchung Einzugsermächtigung OG/000002227     | AMAZON EU SARL 19100 00040593000                        | 2011-07-01 | 0.00      | 16.31      | EUR      | True   |
   | 2011-07-02   | 20010203008 | TRN 20110701RX003134                           | I7452070 VB/000002225 Walter Rombauts 14000 00118804139 | 2011-07-01 | 0         | 250.00     | EUR      | True   |
   | 2011-07-02   | 20010203008 | TRN 20110701RX003135                           | I7452063 VB/000002226 Walter Rombauts 14000 00118804139 | 2011-07-01 | 0.00      | 250.00     | EUR      | True   |
