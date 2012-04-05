Feature: Export of credit card account entries
  In order to update my list of transactions
  As a user
  I want to export my entries to YNAB

Scenario: Export credit card account entries
  Given I have an account with number '20000134083'
  And the following entries in the account with number '20000134083'
  | Booking Date | Account     | Description                       | Payee                               | Value Date | Amount In | Amount Out | Currency | Is New |
  | 2011-06-29   | 20000134083 | USD 7,35 55432861179000422081119  | Manipulationsentgelt                | 2011-06-28 | 0.00      | 0.05       | EUR      | True   |
  | 2011-06-29   | 20000134083 | USD 7,35 55432861179000422081119  | Amazon Services-Kindle 866-321-8851 | 2011-06-28 | 0.00      | 5.18       | EUR      | True   |
  | 2011-06-28   | 20000134083 | 95505511177040364736255           | SONY ONLINE SERVICES INTERNET       | 2011-06-24 | 0.00      | 15.00      | EUR      | True   |
  | 2011-06-24   | 20000134083 | USD 7,20 55432861172000042272210  | Manipulationsentgelt                | 2011-06-21 | 0.00      | 0.05       | EUR      | True   |
  | 2011-06-24   | 20000134083 | USD 7,20 55432861172000042272210  | Amazon Services-Kindle 866-321-8851 | 2011-06-21 | 0.00      | 5.03       | EUR      | True   |
  | 2011-06-24   | 20000134083 | 75494041172005182779231           | ORANGE AUSTRIA WIEN                 | 2011-06-20 | 0.00      | 5          | EUR      | True   |
  | 2011-06-21   | 20000134083 | USD 23,31 55432861169000494943859 | Manipulationsentgelt                | 2011-06-18 | 0.00      | 0.16       | EUR      | True   |
  | 2011-06-21   | 20000134083 | USD 23,31 55432861169000494943859 | Amazon Services-Kindle 866-321-8851 | 2011-06-18 | 0.00      | 16.47      | EUR      | True   |
  | 2011-06-20   | 20000134083 | 05460651169061800530249           | OESTERR.BUNDESBAHNEN WIEN           | 2011-06-17 | 0.00      | 16         | EUR      | True   |
  | 2011-06-20   | 20000134083 | GBP 70,96 55504431167083109723160 | Manipulationsentgelt                | 2011-06-16 | 0.00      | 0.81       | EUR      | True   |
  | 2011-06-20   | 20000134083 | GBP 70,96 55504431167083109723160 | FORGE WORLD NOTTINGHAM              | 2011-06-16 | 0.00      | 80.57      | EUR      | True   |
  When I export all new entries from the account with number '20000134083'
  Then the result should be
  """
  Date,Category,Payee,Memo,Outflow,Inflow                                                                       
  28.06.2011,Import Statements,Manipulationsentgelt,USD 7-35 55432861179000422081119,0.05,0.00                  
  28.06.2011,Import Statements,Amazon Services-Kindle 866-321-8851,USD 7-35 55432861179000422081119,5.18,0.00   
  24.06.2011,Import Statements,SONY ONLINE SERVICES INTERNET,95505511177040364736255,15.00,0.00                 
  21.06.2011,Import Statements,Manipulationsentgelt,USD 7-20 55432861172000042272210,0.05,0.00                  
  21.06.2011,Import Statements,Amazon Services-Kindle 866-321-8851,USD 7-20 55432861172000042272210,5.03,0.00   
  20.06.2011,Import Statements,ORANGE AUSTRIA WIEN,75494041172005182779231,5.00,0.00                            
  18.06.2011,Import Statements,Manipulationsentgelt,USD 23-31 55432861169000494943859,0.16,0.00                 
  18.06.2011,Import Statements,Amazon Services-Kindle 866-321-8851,USD 23-31 55432861169000494943859,16.47,0.00 
  17.06.2011,Import Statements,OESTERR.BUNDESBAHNEN WIEN,05460651169061800530249,16.00,0.00                     
  16.06.2011,Import Statements,Manipulationsentgelt,GBP 70-96 55504431167083109723160,0.81,0.00                 
  16.06.2011,Import Statements,FORGE WORLD NOTTINGHAM,GBP 70-96 55504431167083109723160,80.57,0.00              
  """