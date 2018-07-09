# fattura24-VB.NET
Sorgente VB.NET per connettersi a Fattura24

Utilizzo:

A. Per effettuare il test
Fatturazione_elettronica(“test”, Nothing)

B. Per inviare i dati della fattura
Dim StringFattura = "<Fattura24>" & _
                                  "<Document>" & _
                                      "<DocumentType>I</DocumentType>" & _
                                      "<CustomerName>Mario Rossi</CustomerName>" & _
                                      "<CustomerAddress>Via Alberti 8</CustomerAddress>" & _
                                      "<CustomerPostcode>06122</CustomerPostcode>" & _
                                      "<CustomerCity>Perugia</CustomerCity>" & _
                                      "<CustomerProvince>PG</CustomerProvince>" & _
                                      "<CustomerCountry></CustomerCountry>" & _
                                      "<CustomerFiscalCode>MARROS66C44G217W</CustomerFiscalCode>" & _
                                      "<CustomerVatCode>03912377542</CustomerVatCode>" & _
                                      "<CustomerCellPhone>335123456789</CustomerCellPhone>" & _
                                      "<CustomerEmail>info@rossi.it</CustomerEmail>" & _
                                      "<DeliveryName>Mario Rossi</DeliveryName>" & _
                                      "<DeliveryAddress>Via Alberti 8</DeliveryAddress>" & _
                                      "<DeliveryPostcode>06122</DeliveryPostcode>" & _
                                      "<DeliveryCity>Perugia</DeliveryCity>" & _
                                      "<DeliveryProvince>PG</DeliveryProvince>" & _
                                      "<DeliveryCountry></DeliveryCountry>" & _
                                      "<Object>Oggetto del documento</Object>" & _
                                      "<TotalWithoutTax>900.00</TotalWithoutTax>" & _
                                      "<PaymentMethodName>Banca Popolare di.....</PaymentMethodName>" & _
                                      "<PaymentMethodDescription>IBAN: IT02L1234512345123456789012</PaymentMethodDescription>" & _
                                      "<VatAmount>198.00</VatAmount>" & _
                                      "<Total>1098.00</Total>" & _
                                      "<FootNotes>Vi ringraziamo per la preferenza accordataci</FootNotes>" & _
                                      "<SendEmail>true</SendEmail>" & _
                                      "<UpdateStorage>1</UpdateStorage>" & _
                                      "<F24OrderId>12345</F24OrderId>" & _
                                      "<IdTemplate>123</IdTemplate>" & _
                                      "<CustomField1></CustomField1>" & _
                                      "<CustomField2></CustomField2>" & _
                                      "<Payments>" & _
                                          "<Payment>" & _
                                              "<Date>2016-02-23</Date>" & _
                                              "<Amount>2135</Amount>" & _
                                              "<Paid>true</Paid>" & _
                                          "</Payment>" & _
                                      "</Payments>" & _
                                      "<Rows>" & _
                                          "<Row>" & _
                                              "<Code>0001</Code>" & _
                                              "<Description>PULIZIA NUM. DUE FINESTRE A DUE ANTE E DUE MANI DI SMALTO ALL’ACQUA COMPRESI IMBOTTI E CASSETTONI AVVOLGIBILI</Description>" & _
                                              "<Qty>2</Qty>" & _
                                              "<Um></Um>" & _
                                              "<Price>200.00</Price>" & _
                                              "<Discounts></Discounts>" & _
                                              "<VatCode>22</VatCode>" & _
                                              "<VatDescription>IVA 22%</VatDescription>" & _
                                          "</Row>" & _
                                          "<Row>" & _
                                              "<Code>0002</Code>" & _
                                              "<Description>PULIZIA  NUM. DUE FINESTRONI A DUE ANTE E DUE MANI DI SMALTO ALL’ACQUA COMPRESI IMBOTTI E CASSETTONI AVVOLGIBILI</Description>" & _
                                              "<Qty>2</Qty>" & _
                                              "<Um></Um>" & _
                                              "<Price>250.00</Price>" & _
                                              "<Discounts></Discounts>" & _
                                              "<VatCode>22</VatCode>" & _
                                              "<VatDescription>IVA 22%</VatDescription>" & _
                                          "</Row>" & _
                                      "</Rows>" & _
                                  "</Document>" & _
                              "</Fattura24>" 
Fatturazione_elettronica(“crea”, StringFattura)
