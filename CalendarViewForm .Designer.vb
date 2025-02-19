<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CalendarViewForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.tblCalendar = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMonth = New System.Windows.Forms.Label()
        Me.btnPrintKalender = New System.Windows.Forms.Button()
        Me.btnPreviousMonth = New System.Windows.Forms.Button()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.SuspendLayout()
        '
        'tblCalendar
        '
        Me.tblCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.tblCalendar.ColumnCount = 7
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.tblCalendar.Location = New System.Drawing.Point(12, 39)
        Me.tblCalendar.Name = "tblCalendar"
        Me.tblCalendar.RowCount = 6
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblCalendar.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblCalendar.Size = New System.Drawing.Size(1308, 758)
        Me.tblCalendar.TabIndex = 0
        '
        'lblMonth
        '
        Me.lblMonth.AutoSize = True
        Me.lblMonth.Location = New System.Drawing.Point(347, 9)
        Me.lblMonth.Name = "lblMonth"
        Me.lblMonth.Size = New System.Drawing.Size(39, 13)
        Me.lblMonth.TabIndex = 1
        Me.lblMonth.Text = "Label1"
        '
        'btnPrintKalender
        '
        Me.btnPrintKalender.Location = New System.Drawing.Point(13, 9)
        Me.btnPrintKalender.Name = "btnPrintKalender"
        Me.btnPrintKalender.Size = New System.Drawing.Size(75, 23)
        Me.btnPrintKalender.TabIndex = 2
        Me.btnPrintKalender.Text = "Print"
        Me.btnPrintKalender.UseVisualStyleBackColor = True
        '
        'btnPreviousMonth
        '
        Me.btnPreviousMonth.Location = New System.Drawing.Point(221, 9)
        Me.btnPreviousMonth.Name = "btnPreviousMonth"
        Me.btnPreviousMonth.Size = New System.Drawing.Size(104, 23)
        Me.btnPreviousMonth.TabIndex = 3
        Me.btnPreviousMonth.Text = "Previous Month"
        Me.btnPreviousMonth.UseVisualStyleBackColor = True
        '
        'btnNextMonth
        '
        Me.btnNextMonth.Location = New System.Drawing.Point(495, 9)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(98, 23)
        Me.btnNextMonth.TabIndex = 4
        Me.btnNextMonth.Text = "Next Month"
        Me.btnNextMonth.UseVisualStyleBackColor = True
        '
        'CalendarViewForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1332, 809)
        Me.Controls.Add(Me.btnNextMonth)
        Me.Controls.Add(Me.btnPreviousMonth)
        Me.Controls.Add(Me.btnPrintKalender)
        Me.Controls.Add(Me.lblMonth)
        Me.Controls.Add(Me.tblCalendar)
        Me.Name = "CalendarViewForm"
        Me.Text = "CalendarViewForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tblCalendar As TableLayoutPanel
    Friend WithEvents lblMonth As Label
    Friend WithEvents btnPrintKalender As Button
    Friend WithEvents btnPreviousMonth As Button
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
