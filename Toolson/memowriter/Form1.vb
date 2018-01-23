Public Class Form1
    Public toolsondir As String
    Public Savedtext As String = ""
    Public Filepath As String = ""
    Public UDocPath As String
    Public readarg As New ProcessStartInfo()

    Private Sub EnableRTLLayoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnableRTLLayoutToolStripMenuItem.Click
        If textForm.RightToLeft = RightToLeft.No Then
            textForm.RightToLeft = RightToLeft.Yes
            EnableRTLLayoutToolStripMenuItem.Text = "Disable RTL Layout"
        ElseIf textForm.RightToLeft = RightToLeft.Yes Then
            textForm.RightToLeft = RightToLeft.No
            EnableRTLLayoutToolStripMenuItem.Text = "Enable RTL Layout"
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        textForm.RightToLeft = RightToLeft.No
        Try
            toolsondir = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine)
        Catch ex As ArgumentNullException
            MessageBox.Show("Toolson System not found", "Toolson Cliant")
            Close()
        End Try
        readarg.FileName = toolsondir + "\\readconf.exe"
        readarg.UseShellExecute = False
        readarg.RedirectStandardOutput = True
        readarg.CreateNoWindow = True

        'Read Info
        Dim readinf As New Process()
        readinf.StartInfo = readarg
        readinf.StartInfo.Arguments = "read grobal documentdir"
        readinf.Start()
        UDocPath = readinf.StandardOutput.ReadToEnd()
        readinf.WaitForExit()
        readinf.Close()
    End Sub

    Private Sub FontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FontToolStripMenuItem.Click
        Dim fontselect As New FontDialog()

        fontselect.Font = textForm.Font
        fontselect.Color = textForm.ForeColor
        fontselect.MaxSize = 72
        fontselect.MinSize = 8
        fontselect.FontMustExist = True
        fontselect.AllowVerticalFonts = False
        fontselect.ShowColor = True
        fontselect.ShowEffects = True
        fontselect.FixedPitchOnly = False
        fontselect.AllowVectorFonts = True

        If fontselect.ShowDialog() <> DialogResult.Cancel Then
            textForm.Font = fontselect.Font
            textForm.ForeColor = fontselect.Color
        End If
    End Sub

    Private Sub QuitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitToolStripMenuItem.Click
        If Not textForm.Text = Savedtext Then
            Dim result As DialogResult = MessageBox.Show("File was changed\nSave that?", "MemoWriter", MessageBoxButtons.YesNoCancel)
            If result = DialogResult.Yes Then
                SaveToolStripMenuItem_Click(New Object, New EventArgs)
                Close()
            ElseIf result = DialogResult.No Then
                Close()
            ElseIf result = DialogResult.Cancel Then
                Exit Sub
            End If
        End If
        Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        If Filepath = "" Then
            SaveAsToolStripMenuItem_Click(New Object, New EventArgs)
        Else
            IO.File.WriteAllText(Filepath, textForm.Text, System.Text.Encoding.GetEncoding("utf-8"))
            Savedtext = textForm.Text
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog()

        sfd.FileName = "NewMemo.mwt"
        sfd.InitialDirectory = UDocPath
        sfd.Filter = "MemoWriterTextFile(*.mwt)|*.mwt|TextFile(*.txt)|*.txt|Any(*.*)|*.*"
        sfd.FilterIndex = 1
        sfd.Title = "Save as"
        sfd.RestoreDirectory = True
        sfd.OverwritePrompt = True
        sfd.CheckPathExists = True

        If sfd.ShowDialog() = DialogResult.OK Then
            IO.File.WriteAllText(sfd.FileName, textForm.Text, System.Text.Encoding.GetEncoding("utf-8"))
            Filepath = sfd.FileName
            Savedtext = textForm.Text
        End If
    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim ofd As New OpenFileDialog()

        ofd.FileName = ""
        ofd.InitialDirectory = UDocPath
        ofd.Filter = "MemoWriterTextFile(*.mwt)|*.mwt|TextFile(*.txt)|*.txt|Any(*.*)|*.*"
        ofd.FilterIndex = 1
        ofd.Title = "Open File"
        ofd.RestoreDirectory = True
        ofd.CheckFileExists = True
        ofd.CheckPathExists = True

        If ofd.ShowDialog() = DialogResult.OK Then
            textForm.Text = IO.File.ReadAllText(ofd.FileName, System.Text.Encoding.GetEncoding("utf-8"))
            Filepath = ofd.FileName
        End If
    End Sub
End Class
