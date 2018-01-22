Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        WebBrowser1.Navigate("file:///" + System.IO.Path.GetFullPath("License.html"))
        'WebBrowser1.Document.Body.InnerHtml = System.IO.File.ReadAllText("License.html", System.Text.Encoding.GetEncoding("utf-8"))
    End Sub
End Class
