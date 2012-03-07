Feature: Import of unknown account creates account
  In order to associate my statements with an account
  As a user
  I want accounts to be created when a statement of a previously unknown account is imported

Scenario: Create New Account
  Given I have an empty list of accounts
  When I import these statements
   """
   20027024468;Abbuchung Onlinebanking                      BG/000000107#14200 20010203008 Dirk Rombauts;01.07.2011;01.07.2011;-5,28;EUR
   """
  Then the list of accounts should contain '20027024468'
