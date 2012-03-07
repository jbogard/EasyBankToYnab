Feature: Import of credit cart account statements
  In order to update my list of transactions
  As a user
  I want to import CSV files from EasyBank

Scenario: Import credit cart account statements
  Given I have an account with number '20000134083'
  When I import these statements
       """
       20000134083;Manipulationsentgelt#USD 7,35#55432861179000422081119;29.06.2011;28.06.2011;-0,05;EUR                  
       20000134083;Amazon Services-Kindle 866-321-8851#USD 7,35#55432861179000422081119;29.06.2011;28.06.2011;-5,18;EUR   
       20000134083;SONY ONLINE SERVICES INTERNET#95505511177040364736255;28.06.2011;24.06.2011;-15,00;EUR                 
       20000134083;Manipulationsentgelt#USD 7,20#55432861172000042272210;24.06.2011;21.06.2011;-0,05;EUR                  
       20000134083;Amazon Services-Kindle 866-321-8851#USD 7,20#55432861172000042272210;24.06.2011;21.06.2011;-5,03;EUR   
       20000134083;ORANGE AUSTRIA WIEN#75494041172005182779231;24.06.2011;20.06.2011;-5,00;EUR                            
       20000134083;Manipulationsentgelt#USD 23,31#55432861169000494943859;21.06.2011;18.06.2011;-0,16;EUR                 
       20000134083;Amazon Services-Kindle 866-321-8851#USD 23,31#55432861169000494943859;21.06.2011;18.06.2011;-16,47;EUR 
       20000134083;OESTERR.BUNDESBAHNEN WIEN#05460651169061800530249;20.06.2011;17.06.2011;-16,00;EUR                     
       20000134083;Manipulationsentgelt#GBP 70,96#55504431167083109723160;20.06.2011;16.06.2011;-0,81;EUR                 
       20000134083;FORGE WORLD NOTTINGHAM#GBP 70,96#55504431167083109723160;20.06.2011;16.06.2011;-80,57;EUR              
       """
  Then the account with number '20000134083' should contain these entries
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
