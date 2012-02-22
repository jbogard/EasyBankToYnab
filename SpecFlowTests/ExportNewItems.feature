Feature: Export of new entries
  In order to update my list of transactions
  As a user
  I want to export my entries to YNAB

Background:
  Given I have an account with number '20010203008'
  And the following entries in that account
  | Id | Booking Date | Account     | Description                                    | Payee                                                   | Value Date | Amount In | Amount Out | Currency | Is New |
  | 1  | 2011-07-12   | 20010203008 | easykreditkarte MasterCard 000000 MC/000002237 |                                                         | 2011-07-11 | 0.00      | 757.70     | EUR      | True   |
  | 5  | 2011-07-06   | 20010203008 | Hornbach BG/000002233                          | 14200 20010351775 Dirk Rombauts                         | 2011-07-05 | 0.00      | 9.25       | EUR      | False  |
  
Scenario: Export new entries only
  When I export all new entries
  Then the resulting string should be
  | Number | Line                                                                                     |
  | 1      | Date,Category,Payee,Memo,Outflow,Inflow                                                  |
  | 2      | 11.07.2011,Import Statements,,easykreditkarte MasterCard 000000 MC/000002237,757.70,0.00 |
