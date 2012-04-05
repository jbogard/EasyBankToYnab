Feature: Export of checking account entries
  In order to update my list of transactions
  As a user
  I want to export my entries to YNAB

Scenario: Export checking account entries
  Given I have an account with number '20010203008'
  And the following entries in the account with number '20010203008'
  | Booking Date | Account     | Description                                    | Payee                                                   | Value Date | Amount In | Amount Out | Currency | Is New |
  | 2011-07-12   | 20010203008 | easykreditkarte MasterCard 000000 MC/000002237 |                                                         | 2011-07-11 |      0.00 | 757.70     | EUR      | True   |
  | 2011-07-12   | 20010203008 | Abbuchung Onlinebanking BG/000002236           | 14000 06710704145 Margit Obermaier                      | 2011-07-11 |      0.00 | 33.00      | EUR      | True   |
  | 2011-07-09   | 20010203008 | Apotheke BG/000002235                          | 14200 20010351775 Dirk Rombauts                         | 2011-07-08 |      0.00 | 23.89      | EUR      | True   |
  | 2011-07-08   | 20010203008 | Kindle Books BG/000002234                      | 14200 20010306702 Tatjana Habusta                       | 2011-07-08 |     21.64 | 0          | EUR      | True   |
  | 2011-07-06   | 20010203008 | Hornbach BG/000002233                          | 14200 20010351775 Dirk Rombauts                         | 2011-07-05 |      0.00 | 9.25       | EUR      | True   |
  | 2011-07-06   | 20010203008 | Kienbacher BG/000002232                        | 14200 20010351775 Dirk Rombauts                         | 2011-07-05 |      0.00 | 489.00     | EUR      | True   |
  | 2011-07-06   | 20010203008 | 000006773435 OG/000002231                      | 32000 00900699090 ORANGE AUSTRIA                        | 2011-07-05 |      0.00 | 24.10      | EUR      | True   |
  | 2011-07-06   | 20010203008 | Abbuchung Lastschrift OG/000002230             | WIENER LINIEN GMBH & CO KG 20151 00696216225            | 2011-07-05 |      0.00 | 45.80      | EUR      | True   |
  | 2011-07-05   | 20010203008 | Abbuchung Einzugsermächtigung OG/000002229     | BASLER VERSICHERUNGS-AG 32000 00000062141               | 2011-07-04 |      0.00 | 50.00      | EUR      | True   |
  | 2011-07-05   | 20010203008 | Kindle Books BG/000002228                      | 14200 20010306702 Tatjana Habusta                       | 2011-07-04 |     23.26 | 0          | EUR      | True   |
  | 2011-07-02   | 20010203008 | Abbuchung Einzugsermächtigung OG/000002227     | AMAZON EU SARL 19100 00040593000                        | 2011-07-01 |      0.00 | 16.31      | EUR      | True   |
  | 2011-07-02   | 20010203008 | TRN 20110701RX003135                           | I7452063 VB/000002226 Walter Rombauts 14000 00118804139 | 2011-07-01 |      0.00 | 250.00     | EUR      | True   |
  | 2011-07-02   | 20010203008 | TRN 20110701RX003134                           | I7452070 VB/000002225 Walter Rombauts 14000 00118804139 | 2011-07-01 |      0    | 250.00     | EUR      | True   |
  When I export all entries from the account with number '20010203008'
  Then the result should be
  """
  Date,Category,Payee,Memo,Outflow,Inflow                                                                                      
  11.07.2011,Import Statements,,easykreditkarte MasterCard 000000 MC/000002237,757.70,0.00                                     
  11.07.2011,Import Statements,14000 06710704145 Margit Obermaier,Abbuchung Onlinebanking BG/000002236,33.00,0.00              
  08.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Apotheke BG/000002235,23.89,0.00                                
  08.07.2011,Import Statements,14200 20010306702 Tatjana Habusta,Kindle Books BG/000002234,0.00,21.64                          
  05.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Hornbach BG/000002233,9.25,0.00                                 
  05.07.2011,Import Statements,14200 20010351775 Dirk Rombauts,Kienbacher BG/000002232,489.00,0.00                             
  05.07.2011,Import Statements,32000 00900699090 ORANGE AUSTRIA,000006773435 OG/000002231,24.10,0.00                           
  05.07.2011,Import Statements,WIENER LINIEN GMBH & CO KG 20151 00696216225,Abbuchung Lastschrift OG/000002230,45.80,0.00      
  04.07.2011,Import Statements,BASLER VERSICHERUNGS-AG 32000 00000062141,Abbuchung Einzugsermächtigung OG/000002229,50.00,0.00 
  04.07.2011,Import Statements,14200 20010306702 Tatjana Habusta,Kindle Books BG/000002228,0.00,23.26                          
  01.07.2011,Import Statements,AMAZON EU SARL 19100 00040593000,Abbuchung Einzugsermächtigung OG/000002227,16.31,0.00          
  01.07.2011,Import Statements,I7452063 VB/000002226 Walter Rombauts 14000 00118804139,TRN 20110701RX003135,250.00,0.00
  01.07.2011,Import Statements,I7452070 VB/000002225 Walter Rombauts 14000 00118804139,TRN 20110701RX003134,250.00,0.00
  """