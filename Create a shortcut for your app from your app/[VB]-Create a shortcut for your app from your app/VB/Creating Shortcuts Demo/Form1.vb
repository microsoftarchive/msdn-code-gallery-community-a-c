'After starting your new project go to the VB menu and click (Project) then click (Add Refference...)
'When the window opens click the (Com) tab and scroll down and doubleclick (Windows Scripting Host Object Model).

Imports IWshRuntimeLibrary

Public Class Form1
    'Adds the applications AssemblyName to the Desktops path and adds the .lnk extension used for shortcuts
    Private DesktopPathName As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), My.Application.Info.AssemblyName & ".lnk")

    'Adds the applications AssemblyName to the Startup folder path and adds the .lnk extension used for shortcuts
    Private StartupPathName As String = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), My.Application.Info.AssemblyName & ".lnk")

    'Used to stop the CheckBoxes CheckedChanged events from calling the CreateShortcut sub when the form is
    'loading and setting the Checkboxes states to true if the shortcuts exist.
    Private Loading As Boolean = True

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Sets the Desktop checkbox checked state to true if the desktop shortcut exists
        CheckBox1.Checked = IO.File.Exists(DesktopPathName)

        'Sets the Startup Folder checkbox checked state to true if the Startup folder shortcut exists
        CheckBox2.Checked = IO.File.Exists(StartupPathName)

        'The checkboxes checked states have been set so set Loading to false to allow the CreateShortcut sub to be called now
        Loading = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not Loading Then
            If CheckBox1.Checked Then
                CreateShortcut(DesktopPathName, True) 'Create a shortcut on the desktop
            Else
                CreateShortcut(DesktopPathName, False) 'Remove the shortcut from the desktop
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If Not Loading Then
            If CheckBox2.Checked Then
                CreateShortcut(StartupPathName, True) 'Create a shortcut in the startup folder
            Else
                CreateShortcut(StartupPathName, False) 'Remove the shortcut in the startup folder
            End If
        End If
    End Sub

    ''' <summary>Creates or removes a shortcut for this application at the specified pathname.</summary>
    ''' <param name="shortcutPathName">The path where the shortcut is to be created or removed from including the (.lnk) extension.</param>
    ''' <param name="create">True to create a shortcut or False to remove the shortcut.</param>
    Private Sub CreateShortcut(ByVal shortcutPathName As String, ByVal create As Boolean)
        If create Then
            Try
                Dim shortcutTarget As String = System.IO.Path.Combine(Application.StartupPath, My.Application.Info.AssemblyName & ".exe")
                Dim myShell As New WshShell()
                Dim myShortcut As WshShortcut = CType(myShell.CreateShortcut(shortcutPathName), WshShortcut)
                myShortcut.TargetPath = shortcutTarget 'The exe file this shortcut executes when double clicked
                myShortcut.IconLocation = shortcutTarget & ",0" 'Sets the icon of the shortcut to the exe`s icon
                myShortcut.WorkingDirectory = Application.StartupPath 'The working directory for the exe
                myShortcut.Arguments = "" 'The arguments used when executing the exe
                myShortcut.Save() 'Creates the shortcut
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            Try
                If IO.File.Exists(shortcutPathName) Then IO.File.Delete(shortcutPathName)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub
End Class
