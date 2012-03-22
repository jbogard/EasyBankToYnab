Feature: Export of new entries
  In order to update my list of transactions
  As a user
  I want to export my entries to YNAB

Scenario: Export new entries only
  Given I have an account with number '20010203008'
  And the following entries in the account with number '20010203008'
  | Booking Date | Account     | Description                                    | Payee                           | Value Date | Amount In | Amount Out | Currency | Is New |
  | 2011-07-12   | 20010203008 | easykreditkarte MasterCard 000000 MC/000002237 |                                 | 2011-07-11 | 0.00      | 757.70     | EUR      | True   |
  | 2011-07-06   | 20010203008 | Hornbach BG/000002233                          | 14200 20010351775 Dirk Rombauts | 2011-07-05 | 0.00      | 9.25       | EUR      | False  |
  When I export all new entries
  Then the result should be
  """
  Date;Category;Payee;Memo;Outflow;Inflow                                                  
  11.07.2011;Import Statements;;easykreditkarte MasterCard 000000 MC/000002237;757.70;0.00
  """
