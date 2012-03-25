Feature: Import skips duplicates

Scenario: Import Duplicates
  Given I have an empty list of accounts
  When I import these statements
   """
   20027024468;Abbuchung Onlinebanking                      BG/000000107|14200 20010203008 Dirk Rombauts;01.07.2011;01.07.2011;-5,28;EUR
   20027024468;Abbuchung Onlinebanking                      BG/000000107|14200 20010203008 Dirk Rombauts;01.07.2011;01.07.2011;-5,28;EUR
   """
  Then the account with number '20027024468' should contain these entries
    | Booking Date | Account     | Description                          | Payee                               | Value Date | Amount In | Amount Out | Currency | Is New |
    | 2011-07-01   | 20027024468 | Abbuchung Onlinebanking BG/000000107 | 14200 20010203008 Dirk Rombauts     | 2011-07-01 | 0.00      | 5.28       | EUR      | True   |
