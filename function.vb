Public Function Fatturazione_elettronica(ByVal azione As String, ByVal xml As String)

        Dim api_url As String = “https://www.app.fattura24.com/api/v0.3”

        Dim efatt_api_key = “YOUR_KEY”

        Select Case azione
            Case "test"
                api_url = api_url + "/TestKey"
            Case "crea"
                api_url = api_url + "/SaveDocument"
        End Select

        Debug.WriteLine("api_url: " + api_url)

        ' Create a request using a URL that can receive a post. 
        Dim request As WebRequest = WebRequest.Create(api_url)

        ' Set the Method property of the request to POST.
        request.Method = "POST"

       ' Create POST data and convert it to a byte array.
         Dim postdata As String
        postdata = "apiKey=" & efatt_api_key


        Select Case azione
            Case "crea"

                Dim xml_encoded = WebUtility.UrlEncode(xml)
                postdata = postdata & "&xml=" & xml_encoded

        End Select

        
        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postdata)
        

        ' Set the ContentType property of the WebRequest.
        request.ContentType = "application/x-www-form-urlencoded"

        ' Set the ContentLength property of the WebRequest.

        request.ContentLength = System.Text.Encoding.UTF8.GetBytes(postdata).Length


        ' Get the request stream.
        Dim dataStream As Stream = request.GetRequestStream()

        ' Write the data to the request stream.
        dataStream.Write(byteArray, 0, byteArray.Length)

        ' Close the Stream object.
        dataStream.Close()

        ' Get the response.
        Dim response As WebResponse = request.GetResponse()

        ' Display the status.
        Debug.WriteLine("status: " + CType(response, HttpWebResponse).StatusDescription)

        ' Get the stream containing content returned by the server.
        dataStream = response.GetResponseStream()

        ' Open the stream using a StreamReader for easy access.
        Dim reader As New StreamReader(dataStream)

        ' Read the content.
        Dim responseFromServer As String = reader.ReadToEnd()

        ' Display the content.
        Debug.WriteLine("responseFromServer: " + responseFromServer)


        Dim ResponseText As String

        Select Case azione
            Case "test"

                Dim Tags As List(Of String) = Get_HTMLTag("description", responseFromServer)

                'You can loop through the list to view all of the results
                For Each Tag As String In Tags
                    MsgBox(Tag)
                Next


            Case "crea"

                Dim MyDoc As New System.Xml.XmlDocument
                MyDoc.LoadXml(responseFromServer)
                ResponseText = MyDoc.SelectSingleNode("//root/description").InnerText
                Dim docId = MyDoc.SelectSingleNode("//root/docId").InnerText
                Dim docNumber = MyDoc.SelectSingleNode("//root/docNumber").InnerText
                MsgBox(ResponseText & ": " & docId & ", nr: " & docNumber)

        End Select

        ' Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()




    End Function

'Questa funzione è necessaria perché VB.NET dà errore quando trova caratteri accentati nella risposta di Fattura24
    Private Function Get_HTMLTag(ByVal TagName As String, ByVal HTML As String) As List(Of String)
        Dim lMatch As New List(Of String) 'Get the results in a List of strings

        'RegexOptions.IgnoreCase allows case mismatch e.g. if TagName="title" results can include "title", "Title", "TITLE" etc.
        'RegexOptions.Singleline allows .* to see past CarriageReturn characters 
        Dim Tag As New Regex("(?<=<" & TagName & ">).*(?=<\/" & TagName & ">)", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
        For Each rMatch As Match In Tag.Matches(HTML)
            lMatch.Add(rMatch.Value)
        Next

        Return lMatch
    End Function
