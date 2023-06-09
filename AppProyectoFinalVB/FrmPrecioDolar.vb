Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FrmPrecioDolar
    Inherits Form
    Private maximizado As Boolean

    Public Sub New()
        InitializeComponent()
        maximizado = False
    End Sub
    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim fechaDesde As String = dtpDesde.Value.ToString("yyyy-MM-dd")
        Dim fechaHasta As String = dtpHasta.Value.ToString("yyyy-MM-dd")
        Dim response As Response = read(fechaDesde, fechaHasta)
        If response IsNot Nothing Then
            ConsultarDatos(response)
            GraficarDatos(response)
        End If
    End Sub
    Private Sub ConsultarDatos(ByVal response As Response)
        Dim serie As Serie = response.seriesResponse.Series(0)
        TreeView1.Nodes.Clear()

        Dim rootNode As New TreeNode(serie.Title)
        TreeView1.Nodes.Add(rootNode)

        For Each dataSerie As DataSerie In serie.Data
            If dataSerie.Data.Equals("N/E") Then Continue For

            Dim node As New TreeNode()
            node.Text = "Fecha: " & dataSerie.Fecha & " - Precio: " & dataSerie.Data
            rootNode.Nodes.Add(node)
        Next

        TreeView1.ExpandAll()
    End Sub

    Private Sub GraficarDatos(ByVal response As Response)
        Chart1.Series.Clear()
        Dim serie As Serie = response.seriesResponse.Series(0)
        Dim series As Series = Chart1.Series.Add(serie.Title)
        series.ChartType = SeriesChartType.Line

        For Each dataSerie As DataSerie In serie.Data
            If dataSerie.Data.Equals("N/E") Then Continue For
            Dim precio As Double = Convert.ToDouble(dataSerie.Data)
            Dim fecha As DateTime = DateTime.Parse(dataSerie.Fecha)
            series.Points.AddXY(fecha, precio)
        Next
    End Sub
    Private Shared Function Read(ByVal fechaDesde As String, ByVal fechaHasta As String) As Response
        Try
            Dim url As String = "https://www.banxico.org.mx/SieAPIRest/service/v1/series/SF43718/datos/" & fechaDesde & "/" & fechaHasta
            Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
            request.Accept = "application/json"
            request.Headers("Bmx-Token") = "69260904c3e398685c78e54928e7129fb21c7f79443e3c8b59e5c91f8319ef47"
            Dim response As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)
            If response.StatusCode <> HttpStatusCode.OK Then
                Throw New Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription))
            End If
            Dim jsonSerializer As New DataContractJsonSerializer(GetType(Response))
            Dim objResponse As Object = jsonSerializer.ReadObject(response.GetResponseStream())
            Dim jsonResponse As Response = TryCast(objResponse, Response)
            Return jsonResponse
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

        Return Nothing
    End Function

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles Chart1.Click
        If maximizado Then
            Chart1.Location = New System.Drawing.Point(436, 12)
            Chart1.Height = 240
            Chart1.Width = 320
            TreeView1.Visible = True
            lbInicio.Visible = True
            lbFinal.Visible = True
            dtpDesde.Visible = True
            dtpHasta.Visible = True
            btnConsultar.Visible = True
        Else
            Chart1.Location = New System.Drawing.Point(0, 0)
            Chart1.Height = Me.Height
            Chart1.Width = Me.Width
            TreeView1.Visible = False
            lbInicio.Visible = False
            lbFinal.Visible = False
            dtpDesde.Visible = False
            dtpHasta.Visible = False
            btnConsultar.Visible = False
        End If
        maximizado = Not maximizado
    End Sub
End Class