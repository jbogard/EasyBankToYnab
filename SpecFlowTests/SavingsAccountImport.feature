Feature: Import of savings account statements
  In order to update my list of transactions
  As a user
  I want to import CSV files from EasyBank

Background: 
  Given the following statements
   | Id | Statement                                                                                                                                   |
   | 1  | 20027024468;Abbuchung Onlinebanking                      BG/000000107#14200 20010203008 Dirk Rombauts;02.07.2011;01.07.2011;-5,28;EUR       |
   | 2  | 20027024468;Abbuchung Onlinebanking                      BG/000000106#14200 20010203008 Dirk Rombauts;29.06.2011;28.06.2011;-1.250,00;EUR   |
   | 3  | 20027024468;Abbuchung Onlinebanking                      BG/000000105#14200 20010203008 Dirk Rombauts;15.06.2011;14.06.2011;-500,00;EUR     |
   | 4  | 20027024468;Gutschrift Dauerauftrag                      BG/000000104#14200 20010203008 Mag Dirk Rombauts;02.06.2011;01.06.2011;+250,00;EUR |
   | 5  | 20027024468;Gutschrift Dauerauftrag                      BG/000000103#14200 20010203008 Mag Dirk Rombauts;03.05.2011;02.05.2011;+250,00;EUR |
   | 6  | 20027024468;Gutschrift Dauerauftrag                      BG/000000102#14200 20010203008 Mag Dirk Rombauts;02.04.2011;01.04.2011;+250,00;EUR |

  And these expected entries
    | Id | Booking Date | Account     | Description                          | Payee                               | Value Date | Amount In | Amount Out | Currency | Is New |
    | 1  | 2011-07-02   | 20027024468 | Abbuchung Onlinebanking BG/000000107 | 14200 20010203008 Dirk Rombauts     | 2011-07-01 | 0.00      | 5.28       | EUR      | True   |
    | 2  | 2011-06-29   | 20027024468 | Abbuchung Onlinebanking BG/000000106 | 14200 20010203008 Dirk Rombauts     | 2011-06-28 | 0.00      | 1250       | EUR      | True   |
    | 3  | 2011-06-15   | 20027024468 | Abbuchung Onlinebanking BG/000000105 | 14200 20010203008 Dirk Rombauts     | 2011-06-14 | 0.00      | 500        | EUR      | True   |
    | 4  | 2011-06-02   | 20027024468 | Gutschrift Dauerauftrag BG/000000104 | 14200 20010203008 Mag Dirk Rombauts | 2011-06-01 | 250       | 0          | EUR      | True   |
    | 5  | 2011-05-03   | 20027024468 | Gutschrift Dauerauftrag BG/000000103 | 14200 20010203008 Mag Dirk Rombauts | 2011-05-02 | 250.00    | 0          | EUR      | True   |
    | 6  | 2011-04-02   | 20027024468 | Gutschrift Dauerauftrag BG/000000102 | 14200 20010203008 Mag Dirk Rombauts | 2011-04-01 | 250.00    | 0          | EUR      | True   |


Scenario Outline: Import savings account statements
  Given I have an account with number '20027024468'
  When I import statement '<statement>'
  Then that account should contain entry '<entry>'

  Examples: 
       | statement | entry |
       | 1         | 1     |
       | 2         | 2     |
       | 3         | 3     |
       | 4         | 4     |
       | 5         | 5     |
       | 6         | 6     |
