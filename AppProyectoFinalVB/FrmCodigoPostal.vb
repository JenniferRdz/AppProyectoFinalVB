Imports System
Imports System.Diagnostics
Imports DocumentFormat.OpenXml
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Row = DocumentFormat.OpenXml.Spreadsheet.Row
Imports Cell = DocumentFormat.OpenXml.Spreadsheet.Cell
Imports DocumentFormat.OpenXml.Wordprocessing
Imports Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph
Imports Run = DocumentFormat.OpenXml.Wordprocessing.Run
Imports Text = DocumentFormat.OpenXml.Wordprocessing.Text
Imports Document = iTextSharp.text.Document
Imports Table = DocumentFormat.OpenXml.Wordprocessing.Table
Imports System.Collections.Generic
Imports System.Windows.Forms.DataVisualization.Charting

Public Class FrmCodigoPostal
    Inherits Form

    Private maximizado As Boolean

    Public Sub New()
        InitializeComponent()
        lstvDatos.View = System.Windows.Forms.View.Details
        maximizado = False
    End Sub
    Private Sub btnGuardarInterop_Click(sender As Object, e As EventArgs) Handles btnGuardarInterop.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Crea una instancia de la aplicación Excel
            Dim excelApp = New Microsoft.Office.Interop.Excel.Application()

            ' Crea un nuevo libro de Excel
            Dim workbook = excelApp.Workbooks.Add()

            ' Crea una hoja de Excel
            Dim worksheet As Microsoft.Office.Interop.Excel.Worksheet = DirectCast(workbook.Worksheets(1), Microsoft.Office.Interop.Excel.Worksheet)

            ' Exporta el contenido del ListView a la hoja de Excel
            For i As Integer = 0 To lstvDatos.Columns.Count - 1
                worksheet.Cells(1, i + 1) = lstvDatos.Columns(i).Text
            Next

            For i As Integer = 0 To lstvDatos.Items.Count - 1
                For j As Integer = 0 To lstvDatos.Columns.Count - 1
                    worksheet.Cells(i + 2, j + 1) = lstvDatos.Items(i).SubItems(j).Text
                Next
            Next

            ' Guarda el archivo de Excel
            workbook.SaveAs(saveFileDialog.FileName)

            ' Cierra el archivo y la aplicación Excel
            workbook.Close()
            excelApp.Quit()
        End If
    End Sub

    Private Sub btnGuardarOpenXml_Click(sender As Object, e As EventArgs) Handles btnGuardarOpenXml.Click
        Dim sfd As New SaveFileDialog()
        sfd.Filter = "Excel files (.xlsx)|.xlsx|All files (.)|."
        If sfd.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        If sfd.FileName <> "" Then
            Dim document As SpreadsheetDocument = SpreadsheetDocument.Create(sfd.FileName, SpreadsheetDocumentType.Workbook)
            ' Agregar una hoja de trabajo
            Dim workbookPart As WorkbookPart = document.AddWorkbookPart()
            workbookPart.Workbook = New DocumentFormat.OpenXml.Spreadsheet.Workbook()
            Dim worksheetPart As WorksheetPart = workbookPart.AddNewPart(Of WorksheetPart)()
            worksheetPart.Worksheet = New DocumentFormat.OpenXml.Spreadsheet.Worksheet(New SheetData())
            Dim sheets As DocumentFormat.OpenXml.Spreadsheet.Sheets = workbookPart.Workbook.AppendChild(New DocumentFormat.OpenXml.Spreadsheet.Sheets())
            Dim sheet As New Sheet() With {.Id = workbookPart.GetIdOfPart(worksheetPart), .SheetId = 1, .Name = "ListView"}
            sheets.Append(sheet)

            ' Obtener la colección de celdas
            Dim sheetData As SheetData = worksheetPart.Worksheet.GetFirstChild(Of SheetData)()

            ' Recorrer las columnas y filas de la ListView
            For i As Integer = 0 To lstvDatos.Columns.Count - 1
                ' Crear una fila para los encabezados
                If i = 0 Then
                    Dim row As New Row() With {.RowIndex = 1}
                    sheetData.Append(row)
                End If
                ' Obtener el encabezado de la columna
                Dim headerText As String = lstvDatos.Columns(i).Text
                ' Crear una celda para el encabezado
                Dim headerCell As New Cell() With {
            .CellReference = GetColumnName(i + 1) & "1",
            .DataType = CellValues.String,
            .CellValue = New CellValue(headerText)
        }
                ' Agregar la celda al final de la fila
                Dim headerRow As Row = DirectCast(sheetData.ChildElements.GetItem(0), Row)
                headerRow.AppendChild(headerCell)

                ' Recorrer las filas de la columna
                For j As Integer = 0 To lstvDatos.Items.Count - 1
                    ' Crear una fila para los datos
                    If i = 0 Then
                        Dim row As New Row() With {.RowIndex = CType(j + 2, UInteger)}
                        sheetData.Append(row)
                    End If
                    ' Obtener el valor del dato
                    Dim dataText As String = lstvDatos.Items(j).SubItems(i).Text
                    ' Crear una celda para el dato
                    Dim dataCell As New Cell() With {
                .CellReference = GetColumnName(i + 1) & (j + 2),
                .DataType = CellValues.String,
                .CellValue = New CellValue(dataText)
            }
                    ' Agregar la celda al final de la fila
                    Dim dataRow As Row = DirectCast(sheetData.ChildElements.GetItem(j + 1), Row)
                    dataRow.AppendChild(dataCell)
                Next
            Next
            ' Guardar y cerrar el documento
            workbookPart.Workbook.Save()
            document.Close()
            Process.Start(sfd.FileName)
        End If
    End Sub

    Private Sub btnGuardarPDF_Click(sender As Object, e As EventArgs) Handles btnGuardarPDF.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf"
        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Código para guardar en PDF utilizando una biblioteca de terceros como iTextSharp o PDFSharp.
            ' Asegúrate de agregar la referencia y los using necesarios para la biblioteca de tu elección.
            ' Aquí se muestra un ejemplo utilizando iTextSharp:

            ' Crea un nuevo documento PDF
            Dim document As New Document()

            ' Crea un escritor PDF para el documento y lo vincula al archivo de destino
            Dim writer As PdfWriter = PdfWriter.GetInstance(document, New FileStream(saveFileDialog.FileName, FileMode.Create))

            ' Abre el documento para escritura
            document.Open()

            ' Agrega el contenido del ListView al documento PDF
            Dim table As New PdfPTable(lstvDatos.Columns.Count)

            ' Agrega los encabezados de columna al documento
            For Each column As ColumnHeader In lstvDatos.Columns
                Dim cell As New PdfPCell(New Phrase(column.Text))
                table.AddCell(cell)
            Next

            ' Agrega los datos de las filas al documento
            For Each item As ListViewItem In lstvDatos.Items
                For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                    Dim cell As New PdfPCell(New Phrase(subItem.Text))
                    table.AddCell(cell)
                Next
            Next

            ' Agrega la tabla al documento
            document.Add(table)

            ' Cierra el documento
            document.Close()

            ' Abre el archivo PDF resultante
            Process.Start(saveFileDialog.FileName)
        End If
    End Sub
    Private Function GetColumnName(ByVal index As Integer) As String
        Dim dividend As Integer = index
        Dim columnName As String = String.Empty
        Dim modulo As Integer

        While dividend > 0
            modulo = (dividend - 1) Mod 26
            columnName = Convert.ToChar(65 + modulo).ToString() & columnName
            dividend = CInt((dividend - modulo) / 26)
        End While

        Return columnName
    End Function

    Private Sub btnGuardarWord_Click(sender As Object, e As EventArgs) Handles btnGuardarWord.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos de Word (*.docx)|*.docx"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Crea un nuevo documento de Word
            Dim document As New Document()

            ' Crea un escritor de Word para el documento y lo vincula al archivo de destino
            Using writer As WordprocessingDocument = WordprocessingDocument.Create(saveFileDialog.FileName, WordprocessingDocumentType.Document)
                ' Agrega un cuerpo al documento
                Dim mainPart As MainDocumentPart = writer.AddMainDocumentPart()
                mainPart.Document = New DocumentFormat.OpenXml.Wordprocessing.Document()
                Dim body As Body = mainPart.Document.AppendChild(New Body())

                ' Crea una tabla
                Dim table As New Table()

                ' Crea la primera fila como encabezados de columna
                Dim headerRow As New TableRow()
                For Each column As ColumnHeader In lstvDatos.Columns
                    Dim headerCell As New TableCell(New Paragraph(New Run(New Text(column.Text))))
                    headerRow.Append(headerCell)
                Next
                table.Append(headerRow)

                ' Agrega los datos de las filas al documento
                For Each item As ListViewItem In lstvDatos.Items
                    Dim dataRow As New TableRow()
                    For Each subItem As ListViewItem.ListViewSubItem In item.SubItems
                        Dim dataCell As New TableCell(New Paragraph(New Run(New Text(subItem.Text))))
                        dataRow.Append(dataCell)
                    Next
                    table.Append(dataRow)
                Next

                ' Agrega la tabla al cuerpo del documento
                body.Append(table)
            End Using

            ' Abre el archivo de Word resultante
            Process.Start(saveFileDialog.FileName)
        End If

    End Sub

    Private Sub btnGuardarCSV_Click(sender As Object, e As EventArgs) Handles btnGuardarCSV.Click
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Archivos CSV (*.csv)|*.csv"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ' Obtener el carácter de separación ingresado por el usuario
            Dim separador As Char = ObtenerCaracterSeparador()

            ' Crear el contenido CSV a partir de los datos del ListView
            Dim contenidoCSV As New StringBuilder()

            ' Agregar los encabezados de columna al contenido CSV
            For i As Integer = 0 To lstvDatos.Columns.Count - 1
                contenidoCSV.Append(lstvDatos.Columns(i).Text)
                If i < lstvDatos.Columns.Count - 1 Then
                    contenidoCSV.Append(separador)
                End If
            Next
            contenidoCSV.AppendLine()

            ' Agregar los datos de las filas al contenido CSV
            For Each item As ListViewItem In lstvDatos.Items
                For i As Integer = 0 To item.SubItems.Count - 1
                    contenidoCSV.Append(item.SubItems(i).Text)
                    If i < item.SubItems.Count - 1 Then
                        contenidoCSV.Append(separador)
                    End If
                Next
                contenidoCSV.AppendLine()
            Next

            ' Guardar el contenido CSV en el archivo
            File.WriteAllText(saveFileDialog.FileName, contenidoCSV.ToString())

            ' Mostrar un mensaje de éxito al usuario
            MessageBox.Show("Archivo guardado exitosamente.", "Guardar CSV", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Function ObtenerCaracterSeparador() As Char
        If Not String.IsNullOrWhiteSpace(txtCaracterSeparador.Text) Then
            Return txtCaracterSeparador.Text(0)
        Else
            Return ","
        End If
    End Function

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim dialogo As New OpenFileDialog()
        If dialogo.ShowDialog() <> DialogResult.OK Then
            Return
        End If

        lstvDatos.Clear()
        Dim rutaArchivo As String = dialogo.FileName
        Dim sr As New StreamReader(rutaArchivo, Encoding.GetEncoding(1252))
        Dim columnas As String = sr.ReadLine()
        Dim columna As String() = columnas.Split("|"c)
        For i As Integer = 0 To columna.Length - 1
            lstvDatos.Columns.Add(columna(i))
        Next

        Dim renglon As String
        Dim contadorCodigosPostales As New Dictionary(Of String, Integer)()
        Dim datosCodigosPostales As New Dictionary(Of String, Dictionary(Of String, List(Of String)))()

        While (InlineAssignHelper(renglon, sr.ReadLine())) IsNot Nothing
            Dim datos As String() = renglon.Split("|"c)
            Dim item As New ListViewItem(datos(0))
            For i As Integer = 1 To datos.Length - 1
                item.SubItems.Add(datos(i))
            Next
            lstvDatos.Items.Add(item)

            Dim codigoPostal As String = datos(0)
            Dim colonia As String = datos(1)
            Dim ciudad As String = datos(5)

            ' Agregar el código postal al TreeView si no está presente
            If Not datosCodigosPostales.ContainsKey(codigoPostal) Then
                datosCodigosPostales.Add(codigoPostal, New Dictionary(Of String, List(Of String))())
            End If

            ' Agregar la colonia a la lista de colonias del código postal si no está presente
            If Not datosCodigosPostales(codigoPostal).ContainsKey(colonia) Then
                datosCodigosPostales(codigoPostal).Add(colonia, New List(Of String)())
            End If

            ' Agregar la ciudad a la lista de ciudades del código postal si no está presente
            If Not datosCodigosPostales(codigoPostal)(colonia).Contains(ciudad) Then
                datosCodigosPostales(codigoPostal)(colonia).Add(ciudad)
            End If

            ' Contar el número de apariciones de cada código postal
            If contadorCodigosPostales.ContainsKey(codigoPostal) Then
                contadorCodigosPostales(codigoPostal) += 1
            Else
                contadorCodigosPostales(codigoPostal) = 1
            End If
        End While

        sr.Close()

        ' Limpiar el TreeView
        TreeView1.Nodes.Clear()

        ' Agregar los códigos postales, colonias y ciudades al TreeView
        For Each codigoPostal In datosCodigosPostales
            Dim nodoCodigoPostal As TreeNode = TreeView1.Nodes.Add(codigoPostal.Key)

            For Each colonia In codigoPostal.Value
                Dim nodoColonia As TreeNode = nodoCodigoPostal.Nodes.Add(colonia.Key)

                For Each ciudad In colonia.Value
                    nodoColonia.Nodes.Add(ciudad)
                Next
            Next
        Next

        chartGrafica.Series(0).Points.Clear()
        For Each codigoPostal In contadorCodigosPostales
            chartGrafica.Series(0).Points.AddXY(codigoPostal.Key, codigoPostal.Value)
        Next
    End Sub

    Private Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function


    Private Sub chartGrafica_Click(sender As Object, e As EventArgs) Handles chartGrafica.Click
        If maximizado Then
            chartGrafica.Location = New System.Drawing.Point(436, 12)
            chartGrafica.Height = 240
            chartGrafica.Width = 320
            TreeView1.Visible = True
            btnCargar.Visible = True
            lstvDatos.Visible = True
            btnGuardarCSV.Visible = True
            btnGuardarInterop.Visible = True
            btnGuardarOpenXml.Visible = True
            btnGuardarPDF.Visible = True
            btnGuardarWord.Visible = True
            txtCaracterSeparador.Visible = True
        Else
            chartGrafica.Location = New System.Drawing.Point(0, 0)
            chartGrafica.Height = Me.Height
            chartGrafica.Width = Me.Width
            TreeView1.Visible = False
            btnCargar.Visible = False
            lstvDatos.Visible = False
            btnGuardarCSV.Visible = False
            btnGuardarInterop.Visible = False
            btnGuardarOpenXml.Visible = False
            btnGuardarPDF.Visible = False
            btnGuardarWord.Visible = False
            txtCaracterSeparador.Visible = False
        End If
        maximizado = Not maximizado
    End Sub
End Class