﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Search = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Link = New System.Windows.Forms.Label()
        Me.Write = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Search
        '
        Me.Search.Location = New System.Drawing.Point(41, 27)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(120, 23)
        Me.Search.TabIndex = 0
        Me.Search.Text = "Suche"
        Me.Search.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(169, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Gefunden unter:"
        '
        'Link
        '
        Me.Link.AutoSize = True
        Me.Link.Location = New System.Drawing.Point(253, 33)
        Me.Link.MaximumSize = New System.Drawing.Size(300, 0)
        Me.Link.Name = "Link"
        Me.Link.Size = New System.Drawing.Size(0, 13)
        Me.Link.TabIndex = 2
        '
        'Write
        '
        Me.Write.Location = New System.Drawing.Point(41, 74)
        Me.Write.Name = "Write"
        Me.Write.Size = New System.Drawing.Size(120, 23)
        Me.Write.TabIndex = 3
        Me.Write.Text = "Im System eintragen"
        Me.Write.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 121)
        Me.Controls.Add(Me.Write)
        Me.Controls.Add(Me.Link)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Search)
        Me.Name = "Form1"
        Me.Text = "Suchautomat für DiffMerge"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Search As Windows.Forms.Button
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Link As Windows.Forms.Label
    Friend WithEvents Write As Windows.Forms.Button
End Class
