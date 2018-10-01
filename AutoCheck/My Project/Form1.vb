Imports System.Collections.Generic
Imports System.IO
Imports Microsoft.Win32



Public Class Form1
    Public Path1 As IEnumerable(Of DirectoryInfo)
    Public FolderResult As ICollection(Of DirectoryInfo)
    Public FileResult As ICollection(Of DirectoryInfo)
    Public Result As String
    Public Temp As String
    Public exists As Boolean
    Public rootpath As String = "C:\"
    Public ReadOnly txtPattern As Object = "sgdm.exe"
    Public ParentKeyHive As RegistryHive
    Public SubKeyName As String
    Public ValueName As String
    Public Value As Object

    Private Sub Search_Click(sender As Object, e As EventArgs) Handles Search.Click
        Dim folders As New List(Of DirectoryInfo)
        Dim files As New List(Of FileInfo)
        Dim rootDirs = {New DirectoryInfo(rootpath)}    'rootDirs enthält hier nur 1 Directory
        CollectFilesAndFolders(rootDirs, folders, files, txtPattern)
        'Collect-Ergebnisse verwenden
        Cursor = Windows.Forms.Cursors.Default
        Result = files(0).DirectoryName
        Link.Text = Result
        'MsgBox("Das Programm wurde gefunden unter:" & vbCr & Result, vbOKOnly)
    End Sub


    Sub File_Exist()
        If IO.File.Exists(Temp) Then
        End If
    End Sub

    Private Sub CollectFilesAndFolders(ByVal rootDirs As IEnumerable(Of DirectoryInfo),
      ByVal folderCollector As ICollection(Of DirectoryInfo),
      ByVal fileCollector As ICollection(Of FileInfo),
      Optional ByVal pattern As String = "*.*")
        'rekursive anonyme Methode
        Dim recurse As Action(Of IEnumerable(Of DirectoryInfo)) =
           Sub(dirs As IEnumerable(Of DirectoryInfo))
               Cursor = Windows.Forms.Cursors.WaitCursor
               For Each dirinf In dirs
                   Dim files As IEnumerable(Of FileInfo)
                   Try
                       files = dirinf.EnumerateFiles(pattern)
                   Catch ex As UnauthorizedAccessException
                       'für manche Directories hat das Prog keine Rechte
                       Continue For
                   End Try
                   For Each fileInf In files
                       fileCollector.Add(fileInf)
                   Next
                   folderCollector.Add(dirinf)
                   'selbst-aufruf
                   recurse(dirinf.EnumerateDirectories)
               Next
           End Sub
        'anonyme Methode aufrufen
        recurse(rootDirs)
    End Sub

    Public Function WriteToRegistry() As Boolean
        'DEMO USAGE
        'Dim bAns As Boolean
        'Debug.WriteLine("Registry Write Successful: " & bAns)
        'bAns = WriteToRegistry(RegistryHive.LocalMachine, "SOFTWARE\MyCompany\MyProgram\", "ProgramHasRunBefore", "Y")

        Dim objSubKey As RegistryKey
        Dim sException As String
        Dim objParentKey As RegistryKey
        Dim bAns As Boolean


        Try

            Select Case ParentKeyHive
                Case RegistryHive.LocalMachine
                    objParentKey = Registry.ClassesRoot
                Case RegistryHive.CurrentConfig
                    objParentKey = Registry.CurrentConfig
                Case RegistryHive.CurrentUser
                    objParentKey = Registry.CurrentUser
                Case RegistryHive.DynData
                    objParentKey = Registry.DynData
                Case RegistryHive.LocalMachine
                    objParentKey = Registry.LocalMachine
                Case RegistryHive.PerformanceData
                    objParentKey = Registry.PerformanceData
                Case RegistryHive.Users
                    objParentKey = Registry.Users

            End Select


            'Open 
            objSubKey = objParentKey.OpenSubKey(SubKeyName, True, Security.AccessControl.RegistryRights.FullControl)
            'create if doesn't exist
            If objSubKey Is Nothing Then
                objSubKey = objParentKey.CreateSubKey(SubKeyName, True)
            End If


            objSubKey.SetValue(ValueName, Value, RegistryValueKind.String)
            bAns = True
        Catch ex As Exception
            bAns = False

        End Try

        Return True

    End Function

    Private Sub Write_Click(sender As Object, e As EventArgs) Handles Write.Click

        SubKeyName = "SYSTEM\ControlSet001\Control\Session Manager\Environment"
        ValueName = "DiffMerge"
        Value = Result
        ParentKeyHive = RegistryHive.LocalMachine
        Call WriteToRegistry()
    End Sub
End Class