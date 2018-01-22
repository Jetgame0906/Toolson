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
End Class
