Imports System.IO

Public Class Form1
    Private bestandPad As String = String.Empty ' Dit zorgt ervoor dat bestandPad eerst leeg is
    Private isDataOpgeslagen As Boolean = True ' Houd bij of gegevens zijn opgeslagen

    ' Declaratie van de titel als globale variabele
    Dim muziekstukTitel As String = ""
    Dim datumsGekozen As Boolean = False

    Private Sub lstMuziekstukken_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstMuziekstukken.SelectedIndexChanged
        ' Controleer of er een item is geselecteerd
        If lstMuziekstukken.SelectedItems.Count > 0 Then
            ' Haal de titel van het geselecteerde item
            txtTitel.Text = lstMuziekstukken.SelectedItems(0).Text
        End If
    End Sub

    Private Sub btnVoegDagenToe_Click(sender As Object, e As EventArgs) Handles btnVoegDagenToe.Click
        isDataOpgeslagen = False ' Markeer data als gewijzigd

        ' Validatie voor lege titel
        If txtTitel.Text = "" Then
            MessageBox.Show("Voer eerst een titel in!", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Als de titel is veranderd, zorg ervoor dat de oude titel gewist wordt
        If muziekstukTitel <> txtTitel.Text Then
            muziekstukTitel = txtTitel.Text
            datumsGekozen = False ' Reset de datum keuze
        End If

        ' Haal de geselecteerde dag op van de kalender
        Dim geselecteerdeDag As Date = calOefendagen.SelectionStart

        ' Controleer of dezelfde titel en datum al bestaan in de ListView
        For Each item As ListViewItem In lstMuziekstukken.Items
            If item.Text = muziekstukTitel AndAlso item.SubItems(1).Text = geselecteerdeDag.ToShortDateString() Then
                MessageBox.Show("Deze titel is al toegevoegd voor de geselecteerde datum.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Next

        ' Maak een nieuwe ListViewItem voor de titel en datum
        Dim nieuweItem As New ListViewItem(muziekstukTitel) ' Zet de titel in de eerste kolom
        nieuweItem.SubItems.Add(geselecteerdeDag.ToShortDateString()) ' Zet de datum in de tweede kolom

        ' Voeg het item toe aan de lijst
        lstMuziekstukken.Items.Add(nieuweItem)

        ' Markeer dat er een datum is gekozen
        datumsGekozen = True

        ' Sorteer de items na het toevoegen
        SortListView()

    End Sub

    Private Sub SortListView()
        ' Sorteer de ListView op basis van de titels en vervolgens de datums (SubItems(1))
        Dim items = lstMuziekstukken.Items.Cast(Of ListViewItem)().OrderBy(Function(item) item.Text).ThenBy(Function(item) CType(item.SubItems(1).Text, Date)).ToList()

        lstMuziekstukken.Items.Clear()

        ' Voeg de gesorteerde items terug in de ListView
        For Each item As ListViewItem In items
            lstMuziekstukken.Items.Add(item)
        Next
    End Sub

    Private Sub btnVerwijderItem_Click(sender As Object, e As EventArgs) Handles btnVerwijderItem.Click
        isDataOpgeslagen = False ' Markeer data als gewijzigd

        ' Verwijder het geselecteerde item uit de ListView
        If lstMuziekstukken.SelectedIndices.Count > 0 Then
            lstMuziekstukken.Items.RemoveAt(lstMuziekstukken.SelectedIndices(0))
        Else
            MessageBox.Show("Selecteer eerst een item om te verwijderen.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnAnnuleer_Click(sender As Object, e As EventArgs) Handles btnAnnuleer.Click
        ' Annuleer de invoer
        muziekstukTitel = ""
        txtTitel.Clear()
        datumsGekozen = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Voeg kolommen toe aan de ListView: één voor de titel en één voor de datum
        lstMuziekstukken.View = View.Details  ' Zorg ervoor dat de ListView in de Details-view staat
        lstMuziekstukken.Columns.Add("Titel", 171) ' 200 is de breedte van de kolom
        lstMuziekstukken.Columns.Add("Datum", 80)  ' 100 is de breedte van de datumkolom
    End Sub

    Private Sub btnOpenForm2_Click(sender As Object, e As EventArgs) Handles btnOpenForm2.Click
        ' Maak een nieuw Form2 object
        Dim CalendarViewForm As New CalendarViewForm()

        ' Geef de ListView data van Form1 door naar Form2
        'CalendarViewForm.MuziekstukkenData = lstMuziekstukken.Items

        ' Toon Form2
        CalendarViewForm.Show()
    End Sub

    Private Sub btnPrintList_Click(sender As Object, e As EventArgs) Handles btnPrintList.Click
        ' Maak een nieuwe PrintDialog aan
        Dim printDialog As New PrintDialog()

        ' Stel de printerinstellingen in van het PrintDocument
        printDialog.Document = PrintDocument1

        ' Controleer of de gebruiker een printer heeft gekozen en op 'OK' heeft gedrukt
        If printDialog.ShowDialog() = DialogResult.OK Then
            ' Start het afdrukken naar de geselecteerde printer
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_Print(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Definieer het grafische object en de afdrukinstellingen
        Dim g As Graphics = e.Graphics
        Dim font As New Font("Arial", 10)
        Dim brush As New SolidBrush(Color.Black)
        Dim x As Integer = 50
        Dim y As Integer = 50
        Dim lineHeight As Integer = 20

        ' Voeg een titel toe bovenaan de pagina
        g.DrawString("Oefenschema", New Font("Arial", 14, FontStyle.Bold), brush, x, y)
        y += 30  ' Verhoog de y-positie om ruimte te maken voor de titel

        ' Loop door de ListView items en teken ze op de pagina
        For Each item As ListViewItem In lstMuziekstukken.Items
            g.DrawString(item.Text & " - " & item.SubItems(1).Text, font, brush, x, y)
            y += lineHeight  ' Verhoog de y-positie na elke regel

            ' Als de y-positie het einde van de pagina bereikt, voeg dan een nieuwe pagina toe
            If y > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
        Next

        ' Als we klaar zijn met afdrukken, geef aan dat er geen meer pagina's zijn
        e.HasMorePages = False
    End Sub


    Private Sub btnVerplaatsDagen_Click(sender As Object, e As EventArgs) Handles btnVerplaatsDagen.Click
        ' Controleer of er een item is geselecteerd
        If lstMuziekstukken.SelectedIndices.Count > 0 Then
            ' Verkrijg het geselecteerde item
            Dim geselecteerdItem As ListViewItem = lstMuziekstukken.SelectedItems(0)

            ' Verkrijg de titel en datum van het geselecteerde item
            Dim muziekTitel As String = geselecteerdItem.Text
            Dim oorspronkelijkeDatum As Date = CType(geselecteerdItem.SubItems(1).Text, Date)

            ' Verwijder de tijd uit de geselecteerde datum
            oorspronkelijkeDatum = oorspronkelijkeDatum.Date

            ' Controleer of er een datum geselecteerd is in de DateTimePicker
            Dim gemisteDatum As Date = dtpGemisteDatum.Value.Date ' Verwijder de tijd uit de geselecteerde datum

            ' Vraag de gebruiker hoeveel dagen ze willen verschuiven
            Dim verschuifAantalDagen As Integer
            If Not Integer.TryParse(InputBox("Hoeveel dagen wilt u verschuiven? (bijv. 1 of 2)"), verschuifAantalDagen) Then
                MessageBox.Show("Voer een geldig aantal dagen in om te verschuiven.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Check of de gemiste datum gelijk is aan de oorspronkelijke datum
            If oorspronkelijkeDatum = gemisteDatum Then
                ' Verplaats alle datums voor dit muziekstuk, die gelijk of later zijn dan de gemiste datum
                For Each item As ListViewItem In lstMuziekstukken.Items
                    If item.Text = muziekTitel AndAlso CType(item.SubItems(1).Text, Date).Date >= gemisteDatum Then
                        ' Verschuif de datum met het opgegeven aantal dagen
                        item.SubItems(1).Text = CType(item.SubItems(1).Text, Date).AddDays(verschuifAantalDagen).ToShortDateString()
                    End If
                Next
                MessageBox.Show("De datums zijn verplaatst.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("De ingevoerde datum komt niet overeen met de geselecteerde datum.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Selecteer eerst een item om te verschuiven.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click
        ' Controleer of er al een pad voor het bestand is (bestand is al geopend)
        If String.IsNullOrEmpty(bestandPad) Then
            ' Als er geen pad is, vraag dan om een nieuwe bestandsnaam (Opslaan als)
            btnOpslaanAls.PerformClick()
        Else
            ' Als het bestand al geopend is, sla het bestand dan op met hetzelfde pad
            Using writer As New StreamWriter(bestandPad)
                For Each item As ListViewItem In lstMuziekstukken.Items
                    writer.WriteLine(item.Text & "," & item.SubItems(1).Text)
                Next
            End Using
            MessageBox.Show("Bestand opgeslagen!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
            isDataOpgeslagen = True ' Markeer als opgeslagen
        End If
    End Sub




    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Tekstbestand (*.txt)|*.txt|Alle bestanden (*.*)|*.*"
        openFileDialog.Title = "Bestand openen"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            bestandPad = openFileDialog.FileName
            lstMuziekstukken.Items.Clear()

            Using reader As New StreamReader(bestandPad)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    Dim parts As String() = line.Split(","c)
                    If parts.Length = 2 Then
                        Dim item As New ListViewItem(parts(0))
                        item.SubItems.Add(parts(1))
                        lstMuziekstukken.Items.Add(item)
                    End If
                End While
            End Using

            ' Toon de bestandsnaam in de titelbalk van Form1
            Me.Text = "Muziekstukken Manager - " & Path.GetFileName(bestandPad)
        End If
    End Sub

    Private Sub lstMuziekstukken_ItemChanged(sender As Object, e As EventArgs) Handles lstMuziekstukken.SelectedIndexChanged
        isDataOpgeslagen = False ' Markeer als niet-opgeslagen zodra iets verandert
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not isDataOpgeslagen Then
            ' Toon de waarschuwing dat de gegevens niet zijn opgeslagen
            Dim result As DialogResult = MessageBox.Show("De gegevens zijn niet opgeslagen. Wil je opslaan voordat je afsluit?", "Waarschuwing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                If String.IsNullOrEmpty(bestandPad) Then
                    ' Als er nog geen bestand is, toon de "Save As"-dialoog
                    Dim saveFileDialog As New SaveFileDialog()
                    saveFileDialog.Filter = "Tekstbestand (*.txt)|*.txt|Alle bestanden (*.*)|*.*"
                    saveFileDialog.Title = "Opslaan als"

                    If saveFileDialog.ShowDialog() = DialogResult.OK Then
                        bestandPad = saveFileDialog.FileName
                        Using writer As New StreamWriter(bestandPad)
                            For Each item As ListViewItem In lstMuziekstukken.Items
                                writer.WriteLine(item.Text & "," & item.SubItems(1).Text)
                            Next
                        End Using
                        MessageBox.Show("Bestand opgeslagen!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        isDataOpgeslagen = True ' Markeer als opgeslagen
                    End If
                Else
                    ' Als er al een bestand is, sla het bestand direct op
                    Using writer As New StreamWriter(bestandPad)
                        For Each item As ListViewItem In lstMuziekstukken.Items
                            writer.WriteLine(item.Text & "," & item.SubItems(1).Text)
                        Next
                    End Using
                    MessageBox.Show("Bestand opgeslagen!", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    isDataOpgeslagen = True ' Markeer als opgeslagen
                End If
            ElseIf result = DialogResult.Cancel Then
                ' Als de gebruiker annuleert, stop met afsluiten
                e.Cancel = True
            End If
        End If
    End Sub







    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Controleer of de gegevens zijn opgeslagen
        If Not isDataOpgeslagen Then
            Dim result As DialogResult = MessageBox.Show("De gegevens zijn niet opgeslagen. Wilt u opslaan voordat u afsluit?", "Waarschuwing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                ' Als de gebruiker wil opslaan, roep dan de opslaan functie aan
                btnOpslaan.PerformClick() ' Roep de opslaan knop aan voor het openen van het bestand
            ElseIf result = DialogResult.Cancel Then
                ' Als de gebruiker annuleert, stop met afsluiten
                Return
            End If
        End If

        ' Sluit het formulier af
        Me.Close()
    End Sub



    ' Dit zou in Form1 kunnen zitten, bijvoorbeeld wanneer de gebruiker op een knop klikt
    Private Sub btnUpdateCalendar_Click(sender As Object, e As EventArgs) Handles btnUpdateCalendar.Click
        ' Verkrijg de gegevens van de muziekstukken uit ListView
        Dim muziekstukken As ListView.ListViewItemCollection = lstMuziekstukken.Items

        ' Geef de gegevens door aan CalendarViewForm (zorg ervoor dat CalendarViewForm al open is)
        Dim calendarForm As CalendarViewForm = DirectCast(Application.OpenForms("CalendarViewForm"), CalendarViewForm)
        calendarForm.MuziekstukkenData = muziekstukken

        ' Werk de kalender bij
        calendarForm.UpdateCalendarWithMuziekstukken()
    End Sub



End Class
