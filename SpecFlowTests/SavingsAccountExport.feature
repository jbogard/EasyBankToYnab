Feature: Export of savings account entries
  In order to update my list of transactions
  As a user
  I want to export my entries to YNAB

Background:

Scenario: Export savings account entries
  Given I have an account with number '20027024468'
  And the following entries in the account with number '20027024468'
 | Booking Date | Account     | Description                          | Payee                               | Value Date | Amount In | Amount Out | Currency | Is New |
 | 2011-07-02   | 20027024468 | Abbuchung Onlinebanking BG/000000107 | 14200 20010203008 Dirk Rombauts     | 2011-07-01 | 0.00      | 5.28       | EUR      | True   |
 | 2011-06-29   | 20027024468 | Abbuchung Onlinebanking BG/000000106 | 14200 20010203008 Dirk Rombauts     | 2011-06-28 | 0.00      | 1250       | EUR      | True   |
 | 2011-06-15   | 20027024468 | Abbuchung Onlinebanking BG/000000105 | 14200 20010203008 Dirk Rombauts     | 2011-06-14 | 0.00      | 500        | EUR      | True   |
 | 2011-06-02   | 20027024468 | Gutschrift Dauerauftrag BG/000000104 | 14200 20010203008 Mag Dirk Rombauts | 2011-06-01 | 250       | 0          | EUR      | True   |
 | 2011-05-03   | 20027024468 | Gutschrift Dauerauftrag BG/000000103 | 14200 20010203008 Mag Dirk Rombauts | 2011-05-02 | 250.00    | 0          | EUR      | True   |
 | 2011-04-02   | 20027024468 | Gutschrift Dauerauftrag BG/000000102 | 14200 20010203008 Mag Dirk Rombauts | 2011-04-01 | 250.00    | 0          | EUR      | True   |
  When I export all new entries from the account with number '20027024468'
  Then the result should be
  """
  Date,Category,Payee,Memo,Outflow,Inflow                                                                           
  01.07.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000107,5.28,0.00       
  28.06.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000106,1250.00,0.00    
  14.06.2011,Import Statements,14200 20010203008 Dirk Rombauts,Abbuchung Onlinebanking BG/000000105,500.00,0.00     
  01.06.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000104,0.00,250.00 
  02.05.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000103,0.00,250.00 
  01.04.2011,Import Statements,14200 20010203008 Mag Dirk Rombauts,Gutschrift Dauerauftrag BG/000000102,0.00,250.00 
  """