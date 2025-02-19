Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class CalendarViewForm
    ' Voeg een property toe om de gegevens van Form1 te ontvangen
    Public Property MuziekstukkenData As ListView.ListViewItemCollection
    Private currentDate As DateTime ' Huidige maand bijhouden
    Private bmp As Bitmap ' Voor het opslaan van de schermafbeelding

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        currentDate = DateTime.Now ' Zet de huidige maand
        AddMonthLabel(currentDate)
        AddDayLabelsToTopRow()
        LoadCalendar(currentDate)
    End Sub

    Public Sub AddDayLabelsToTopRow()
        Dim daysOfWeek As String() = {"Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"}
        For i As Integer = 0 To 6
            Dim dayLabel As Label = CType(tblCalendar.GetControlFromPosition(i, 0), Label)
            If dayLabel Is Nothing Then
                dayLabel = New Label()
                tblCalendar.Controls.Add(dayLabel, i, 0)
            End If
            dayLabel.Text = daysOfWeek(i)
            dayLabel.TextAlign = ContentAlignment.MiddleCenter
            dayLabel.Dock = DockStyle.Fill
            dayLabel.Font = New System.Drawing.Font("Arial", 12, FontStyle.Bold)
            dayLabel.BackColor = Color.LightGray
        Next
    End Sub

    Private Sub AddMonthLabel(currentDate As DateTime)
        lblMonth.Text = currentDate.ToString("MMMM yyyy")
        lblMonth.Font = New System.Drawing.Font("Arial", 14, FontStyle.Bold)
    End Sub

    Private Sub LoadCalendar(targetDate As DateTime)
        tblCalendar.Controls.Clear()
        AddDayLabelsToTopRow()

        Dim firstDayOfMonth As New DateTime(targetDate.Year, targetDate.Month, 1)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(targetDate.Year, targetDate.Month)
        Dim startDay As Integer = CInt(firstDayOfMonth.DayOfWeek)
        Dim row As Integer = 1
        Dim col As Integer = startDay

        ' Dagen van vorige maand
        Dim prevMonthLastDay As Integer = DateTime.DaysInMonth(targetDate.Year, targetDate.Month - 1)
        For i As Integer = startDay - 1 To 0 Step -1
            Dim dayLabel As New Label With {
                .Text = (prevMonthLastDay - (startDay - 1 - i)).ToString(),
                .TextAlign = ContentAlignment.TopLeft,
                .Dock = DockStyle.Fill,
                .Font = New System.Drawing.Font("Arial", 8, FontStyle.Regular),
                .BorderStyle = BorderStyle.FixedSingle,
                .ForeColor = Color.Gray
            }
            tblCalendar.Controls.Add(dayLabel, i, row)
        Next

        ' Huidige maand
        For day As Integer = 1 To daysInMonth
            Dim dayLabel As New Label With {
                .Text = day.ToString(),
                .TextAlign = ContentAlignment.TopLeft,
                .Dock = DockStyle.Fill,
                .Font = New System.Drawing.Font("Arial", 8, FontStyle.Regular),
                .BorderStyle = BorderStyle.FixedSingle,
                .BackColor = Color.White
            }
            tblCalendar.Controls.Add(dayLabel, col, row)
            col += 1
            If col > 6 Then
                col = 0
                row += 1
            End If
        Next

        ' Dagen van volgende maand
        Dim nextMonthDay As Integer = 1
        While col <= 6
            Dim dayLabel As New Label With {
                .Text = nextMonthDay.ToString(),
                .TextAlign = ContentAlignment.TopLeft,
                .Dock = DockStyle.Fill,
                .Font = New System.Drawing.Font("Arial", 10, FontStyle.Regular),
                .BorderStyle = BorderStyle.FixedSingle,
                .ForeColor = Color.Gray
            }
            tblCalendar.Controls.Add(dayLabel, col, row)
            col += 1
            nextMonthDay += 1
        End While
    End Sub

    ' Event handler voor het afdrukken naar PDF
    Private Sub btnPrintKalender_Click(sender As Object, e As EventArgs) Handles btnPrintKalender.Click
        ' Sla de inhoud van tblCalendar als een afbeelding op
        CaptureCalendarScreen()

        ' PDF-bestand opslaan in de gewenste locatie
        Dim output As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "calendar.pdf")
        ' Aanroep om PDF-bestand te genereren
        GeneratePDF(output)
    End Sub

    ' Methode om de inhoud van tblCalendar op te slaan als een afbeelding
    Private Sub CaptureCalendarScreen()
        Dim formBounds As System.Drawing.Rectangle = tblCalendar.Bounds
        bmp = New Bitmap(formBounds.Width, formBounds.Height)
        tblCalendar.DrawToBitmap(bmp, New System.Drawing.Rectangle(0, 0, formBounds.Width, formBounds.Height))
    End Sub

    ' Methode om de PDF te genereren met iTextSharp
    Private Sub GeneratePDF(outputPath As String)
        ' Maak een nieuw document in liggende modus
        Dim doc As New iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 40, 40, 40, 40)
        ' Schrijf het document naar een bestand
        PdfWriter.GetInstance(doc, New FileStream(outputPath, FileMode.Create))
        doc.Open()

        ' Voeg de maandnaam toe aan het document
        doc.Add(New iTextSharp.text.Paragraph(lblMonth.Text, New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD)))
        doc.Add(New iTextSharp.text.Paragraph(" "))

        ' Voeg de afbeelding toe aan het document
        If bmp IsNot Nothing Then
            Dim image As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Png)
            image.ScalePercent(60) ' Pas deze waarde aan om de schaal te vergroten (bijv. 150% van de originele grootte)
            image.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(image)
        End If

        ' Sluit het document
        doc.Close()

        MessageBox.Show("PDF succesvol gegenereerd op: " & outputPath)
    End Sub


    Private Sub btnPreviousMonth_Click(sender As Object, e As EventArgs) Handles btnPreviousMonth.Click
        currentDate = currentDate.AddMonths(-1)
        AddMonthLabel(currentDate)
        LoadCalendar(currentDate)
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        currentDate = currentDate.AddMonths(1)
        AddMonthLabel(currentDate)
        LoadCalendar(currentDate)
    End Sub

    Public Sub UpdateCalendarWithMuziekstukken()
        LoadCalendar(currentDate)
        For row As Integer = 1 To tblCalendar.RowCount - 1
            For col As Integer = 0 To 6
                Dim dayLabel As Label = CType(tblCalendar.GetControlFromPosition(col, row), Label)
                If dayLabel IsNot Nothing Then
                    Dim dayInt As Integer
                    If Integer.TryParse(dayLabel.Text, dayInt) Then
                        For Each item As ListViewItem In MuziekstukkenData
                            Dim muziekDatum As DateTime = DateTime.Parse(item.SubItems(1).Text)
                            If muziekDatum.Day = dayInt AndAlso muziekDatum.Month = currentDate.Month AndAlso muziekDatum.Year = currentDate.Year Then
                                dayLabel.Text &= Environment.NewLine & item.Text
                            End If
                        Next
                    End If
                End If
            Next
        Next
    End Sub
End Class
