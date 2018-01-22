Public Class Form1
    Public toolsondir As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Environment.SetEnvironmentVariable(myVarD, null, EnvironmentVariableTarget.Machine);
        Try
            toolsondir = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine)
        Catch ex As ArgumentNullException
            MessageBox.Show("Toolson System not found", "Toolson Cliant")
            Close()
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            System.Diagnostics.Process.Start(toolsondir + "\\" + TextBox1.Text)
        Catch ex As System.ComponentModel.Win32Exception
            MessageBox.Show("File not found")
        End Try
        TextBox1.Text = ""
    End Sub
End Class
