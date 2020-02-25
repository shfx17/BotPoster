Imports System.Net

Public Class Form1
    Dim i As Integer = 1

    Private Sub ScriptError()
        WebBrowser1.ScriptErrorsSuppressed = True
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)


    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        WebBrowser1.Navigate("http://www.forumbudowlane.pl/ucp.php")
        ScriptError()
        Timer2.Start()
    End Sub

    Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        WebBrowser1.Document.GetElementById("username").SetAttribute("value", "NICK_SPECIAL")
        WebBrowser1.Document.GetElementById("password").SetAttribute("value", "PASSWORD_SPECIAL")
        ScriptError()
        Timer3.Start()
    End Sub

    Private Sub Timer3_Tick(sender As System.Object, e As System.EventArgs) Handles Timer3.Tick
        Timer3.Stop()
        Dim all As HtmlElementCollection = WebBrowser1.Document.All
        For Each Web As HtmlElement In all

            If Web.GetAttribute("value") = "Zaloguj się" Then
                Web.InvokeMember("click")
            End If
        Next
        ScriptError()
        Timer4.Start()
        Label3.Text = "Loged!"
        Label3.ForeColor = Color.Green
    End Sub

    Private Sub Timer4_Tick(sender As System.Object, e As System.EventArgs) Handles Timer4.Tick
        Timer4.Stop()
        WebBrowser1.Navigate("http://www.forumbudowlane.pl/posting.php?mode=post&f=41")
        ScriptError()
        Timer6.Start()
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim IPHost As IPHostEntry = Dns.GetHostByName(Dns.GetHostName())
            Label1.Text = IPHost.AddressList(0).ToString()
        Catch ex As Exception
            MsgBox("Error")
        End Try
        Timer5.Start()

    End Sub

    Private Sub Timer5_Tick(sender As System.Object, e As System.EventArgs) Handles Timer5.Tick
        Timer5.Stop()
        If (Label1.Text = "192.168.56.1") Then
        Else
            MsgBox("Zly adres IP")
            Me.Close()
        End If

    End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        WebBrowser1.Navigate("http://www.forumbudowlane.pl/ucp.php?mode=logout&sid=31458e31f45cb846af21dc37abeca4f2")

        ScriptError()
    End Sub

    Private Sub Timer6_Tick(sender As System.Object, e As System.EventArgs) Handles Timer6.Tick
        Timer6.Stop()
        Dim fileReaderTitle As String
        Dim fileReaderDescription As String

        If (Not (i = 102)) Then
            fileReaderTitle = My.Computer.FileSystem.ReadAllText("c:\vb\" & i & "\title.txt")


            fileReaderDescription = My.Computer.FileSystem.ReadAllText("c:\vb\" & i & "\description.txt")

            WebBrowser1.Document.GetElementById("subject").SetAttribute("value", fileReaderTitle)
            WebBrowser1.Document.GetElementById("message").SetAttribute("value", fileReaderDescription)


            Timer7.Start()
        Else
            MsgBox("Bot zakończył dodawanie postów!")
        End If


    End Sub

    Private Sub Timer7_Tick(sender As System.Object, e As System.EventArgs) Handles Timer7.Tick
        Timer7.Stop()
        Dim all As HtmlElementCollection = WebBrowser1.Document.All
        For Each Web As HtmlElement In all

            If Web.GetAttribute("value") = "Wyślij" Then
                Web.InvokeMember("click")
                Timer9.Start()
            End If
        Next



    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        WebBrowser1.Navigate("http://www.forumbudowlane.pl/ucp.php?i=ucp_profile&mode=reg_details")

        ScriptError()
        Label3.Text = "Checking..."
        Label3.ForeColor = Color.Black
        Timer8.Start()
    End Sub

    Private Sub Timer8_Tick(sender As System.Object, e As System.EventArgs) Handles Timer8.Tick
        Timer8.Stop()
        Dim all As HtmlElementCollection = WebBrowser1.Document.All
        For Each Web As HtmlElement In all

            If Web.GetAttribute("value") = "Zaloguj się" Then
                Label3.Text = "Not loged!"
                Label3.ForeColor = Color.Red
            End If

            If Web.GetAttribute("value") = "Wyczyść" Then
                Label3.Text = "Loged!"
                Label3.ForeColor = Color.Green
            End If
        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim x As Integer = 4

        If (Not (x = 4)) Then
            MsgBox("LICZBA ROZNA OD 4")
        Else
            MsgBox("Liczba to 4")
        End If


    End Sub

    Private Sub Timer9_Tick(sender As System.Object, e As System.EventArgs) Handles Timer9.Tick
        Timer9.Stop()
        WebBrowser1.Navigate("http://www.forumbudowlane.pl/posting.php?mode=post&f=41")
        i = i + 1
        ScriptError()
        Timer6.Start()

    End Sub
End Class