<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtTitel = New System.Windows.Forms.TextBox()
        Me.calOefendagen = New System.Windows.Forms.MonthCalendar()
        Me.btnVoegDagenToe = New System.Windows.Forms.Button()
        Me.btnVerwijderItem = New System.Windows.Forms.Button()
        Me.btnAnnuleer = New System.Windows.Forms.Button()
        Me.lstMuziekstukken = New System.Windows.Forms.ListView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpslaan = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpslaanAls = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOpenForm2 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.btnPrintList = New System.Windows.Forms.Button()
        Me.btnVerplaatsDagen = New System.Windows.Forms.Button()
        Me.dtpGemisteDatum = New System.Windows.Forms.DateTimePicker()
        Me.btnUpdateCalendar = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTitel
        '
        Me.txtTitel.Location = New System.Drawing.Point(196, 40)
        Me.txtTitel.Name = "txtTitel"
        Me.txtTitel.Size = New System.Drawing.Size(171, 20)
        Me.txtTitel.TabIndex = 0
        '
        'calOefendagen
        '
        Me.calOefendagen.Location = New System.Drawing.Point(13, 37)
        Me.calOefendagen.Name = "calOefendagen"
        Me.calOefendagen.TabIndex = 4
        '
        'btnVoegDagenToe
        '
        Me.btnVoegDagenToe.Location = New System.Drawing.Point(196, 66)
        Me.btnVoegDagenToe.Name = "btnVoegDagenToe"
        Me.btnVoegDagenToe.Size = New System.Drawing.Size(75, 23)
        Me.btnVoegDagenToe.TabIndex = 5
        Me.btnVoegDagenToe.Text = "Add Day"
        Me.btnVoegDagenToe.UseVisualStyleBackColor = True
        '
        'btnVerwijderItem
        '
        Me.btnVerwijderItem.Location = New System.Drawing.Point(533, 95)
        Me.btnVerwijderItem.Name = "btnVerwijderItem"
        Me.btnVerwijderItem.Size = New System.Drawing.Size(75, 23)
        Me.btnVerwijderItem.TabIndex = 7
        Me.btnVerwijderItem.Text = "Verwijder Item"
        Me.btnVerwijderItem.UseVisualStyleBackColor = True
        '
        'btnAnnuleer
        '
        Me.btnAnnuleer.Location = New System.Drawing.Point(277, 66)
        Me.btnAnnuleer.Name = "btnAnnuleer"
        Me.btnAnnuleer.Size = New System.Drawing.Size(75, 23)
        Me.btnAnnuleer.TabIndex = 9
        Me.btnAnnuleer.Text = "Clear Field"
        Me.btnAnnuleer.UseVisualStyleBackColor = True
        '
        'lstMuziekstukken
        '
        Me.lstMuziekstukken.FullRowSelect = True
        Me.lstMuziekstukken.GridLines = True
        Me.lstMuziekstukken.HideSelection = False
        Me.lstMuziekstukken.Location = New System.Drawing.Point(623, 40)
        Me.lstMuziekstukken.Name = "lstMuziekstukken"
        Me.lstMuziekstukken.Size = New System.Drawing.Size(271, 600)
        Me.lstMuziekstukken.TabIndex = 10
        Me.lstMuziekstukken.UseCompatibleStateImageBehavior = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(922, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnOpen, Me.btnOpslaan, Me.btnOpslaanAls, Me.btnExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'btnOpen
        '
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(114, 22)
        Me.btnOpen.Text = "Open"
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(114, 22)
        Me.btnOpslaan.Text = "Save"
        '
        'btnOpslaanAls
        '
        Me.btnOpslaanAls.Name = "btnOpslaanAls"
        Me.btnOpslaanAls.Size = New System.Drawing.Size(114, 22)
        Me.btnOpslaanAls.Text = "Save As"
        '
        'btnExit
        '
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(114, 22)
        Me.btnExit.Text = "Exit"
        '
        'btnOpenForm2
        '
        Me.btnOpenForm2.Location = New System.Drawing.Point(196, 176)
        Me.btnOpenForm2.Name = "btnOpenForm2"
        Me.btnOpenForm2.Size = New System.Drawing.Size(75, 23)
        Me.btnOpenForm2.TabIndex = 12
        Me.btnOpenForm2.Text = "Kalender"
        Me.btnOpenForm2.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'btnPrintList
        '
        Me.btnPrintList.Location = New System.Drawing.Point(533, 124)
        Me.btnPrintList.Name = "btnPrintList"
        Me.btnPrintList.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintList.TabIndex = 13
        Me.btnPrintList.Text = "Print List"
        Me.btnPrintList.UseVisualStyleBackColor = True
        '
        'btnVerplaatsDagen
        '
        Me.btnVerplaatsDagen.Location = New System.Drawing.Point(533, 66)
        Me.btnVerplaatsDagen.Name = "btnVerplaatsDagen"
        Me.btnVerplaatsDagen.Size = New System.Drawing.Size(75, 23)
        Me.btnVerplaatsDagen.TabIndex = 14
        Me.btnVerplaatsDagen.Text = "Move Dates"
        Me.btnVerplaatsDagen.UseVisualStyleBackColor = True
        '
        'dtpGemisteDatum
        '
        Me.dtpGemisteDatum.Location = New System.Drawing.Point(425, 40)
        Me.dtpGemisteDatum.Name = "dtpGemisteDatum"
        Me.dtpGemisteDatum.Size = New System.Drawing.Size(183, 20)
        Me.dtpGemisteDatum.TabIndex = 15
        '
        'btnUpdateCalendar
        '
        Me.btnUpdateCalendar.Location = New System.Drawing.Point(197, 147)
        Me.btnUpdateCalendar.Name = "btnUpdateCalendar"
        Me.btnUpdateCalendar.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdateCalendar.TabIndex = 16
        Me.btnUpdateCalendar.Text = "Update Calendar"
        Me.btnUpdateCalendar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 649)
        Me.Controls.Add(Me.btnUpdateCalendar)
        Me.Controls.Add(Me.dtpGemisteDatum)
        Me.Controls.Add(Me.btnVerplaatsDagen)
        Me.Controls.Add(Me.btnPrintList)
        Me.Controls.Add(Me.btnOpenForm2)
        Me.Controls.Add(Me.lstMuziekstukken)
        Me.Controls.Add(Me.btnAnnuleer)
        Me.Controls.Add(Me.btnVerwijderItem)
        Me.Controls.Add(Me.btnVoegDagenToe)
        Me.Controls.Add(Me.calOefendagen)
        Me.Controls.Add(Me.txtTitel)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Oefenschema"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTitel As TextBox
    Friend WithEvents calOefendagen As MonthCalendar
    Friend WithEvents btnVoegDagenToe As Button
    Friend WithEvents btnVerwijderItem As Button
    Friend WithEvents btnAnnuleer As Button
    Friend WithEvents lstMuziekstukken As ListView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnOpslaanAls As ToolStripMenuItem
    Friend WithEvents btnOpen As ToolStripMenuItem
    Friend WithEvents btnOpenForm2 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents btnPrintList As Button
    Friend WithEvents btnVerplaatsDagen As Button
    Friend WithEvents dtpGemisteDatum As DateTimePicker
    Friend WithEvents btnOpslaan As ToolStripMenuItem
    Friend WithEvents btnExit As ToolStripMenuItem
    Friend WithEvents btnUpdateCalendar As Button
End Class
