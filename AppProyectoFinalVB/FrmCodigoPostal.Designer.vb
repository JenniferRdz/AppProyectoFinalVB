<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCodigoPostal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.lstvDatos = New System.Windows.Forms.ListView()
        Me.chartGrafica = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.btnGuardarInterop = New System.Windows.Forms.Button()
        Me.btnGuardarOpenXml = New System.Windows.Forms.Button()
        Me.btnGuardarPDF = New System.Windows.Forms.Button()
        Me.btnGuardarWord = New System.Windows.Forms.Button()
        Me.btnGuardarCSV = New System.Windows.Forms.Button()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.txtCaracterSeparador = New System.Windows.Forms.TextBox()
        CType(Me.chartGrafica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(35, 414)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(671, 227)
        Me.TreeView1.TabIndex = 5
        '
        'lstvDatos
        '
        Me.lstvDatos.HideSelection = False
        Me.lstvDatos.Location = New System.Drawing.Point(35, 116)
        Me.lstvDatos.Name = "lstvDatos"
        Me.lstvDatos.Size = New System.Drawing.Size(671, 278)
        Me.lstvDatos.TabIndex = 4
        Me.lstvDatos.UseCompatibleStateImageBehavior = False
        '
        'chartGrafica
        '
        ChartArea1.Name = "ChartArea1"
        Me.chartGrafica.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.chartGrafica.Legends.Add(Legend1)
        Me.chartGrafica.Location = New System.Drawing.Point(726, 116)
        Me.chartGrafica.Name = "chartGrafica"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.chartGrafica.Series.Add(Series1)
        Me.chartGrafica.Size = New System.Drawing.Size(403, 341)
        Me.chartGrafica.TabIndex = 3
        Me.chartGrafica.Text = "Chart1"
        '
        'btnGuardarInterop
        '
        Me.btnGuardarInterop.Location = New System.Drawing.Point(38, 28)
        Me.btnGuardarInterop.Name = "btnGuardarInterop"
        Me.btnGuardarInterop.Size = New System.Drawing.Size(118, 64)
        Me.btnGuardarInterop.TabIndex = 6
        Me.btnGuardarInterop.Text = "Guardar en Interop"
        Me.btnGuardarInterop.UseVisualStyleBackColor = True
        '
        'btnGuardarOpenXml
        '
        Me.btnGuardarOpenXml.Location = New System.Drawing.Point(173, 28)
        Me.btnGuardarOpenXml.Name = "btnGuardarOpenXml"
        Me.btnGuardarOpenXml.Size = New System.Drawing.Size(118, 64)
        Me.btnGuardarOpenXml.TabIndex = 7
        Me.btnGuardarOpenXml.Text = "Guardar con OpenXml"
        Me.btnGuardarOpenXml.UseVisualStyleBackColor = True
        '
        'btnGuardarPDF
        '
        Me.btnGuardarPDF.Location = New System.Drawing.Point(314, 28)
        Me.btnGuardarPDF.Name = "btnGuardarPDF"
        Me.btnGuardarPDF.Size = New System.Drawing.Size(118, 64)
        Me.btnGuardarPDF.TabIndex = 8
        Me.btnGuardarPDF.Text = "Guardar en PDF"
        Me.btnGuardarPDF.UseVisualStyleBackColor = True
        '
        'btnGuardarWord
        '
        Me.btnGuardarWord.Location = New System.Drawing.Point(450, 28)
        Me.btnGuardarWord.Name = "btnGuardarWord"
        Me.btnGuardarWord.Size = New System.Drawing.Size(118, 64)
        Me.btnGuardarWord.TabIndex = 9
        Me.btnGuardarWord.Text = "Guardar en Word"
        Me.btnGuardarWord.UseVisualStyleBackColor = True
        '
        'btnGuardarCSV
        '
        Me.btnGuardarCSV.Location = New System.Drawing.Point(588, 28)
        Me.btnGuardarCSV.Name = "btnGuardarCSV"
        Me.btnGuardarCSV.Size = New System.Drawing.Size(118, 64)
        Me.btnGuardarCSV.TabIndex = 10
        Me.btnGuardarCSV.Text = "Guardar CSV"
        Me.btnGuardarCSV.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(745, 465)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(118, 64)
        Me.btnCargar.TabIndex = 11
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'txtCaracterSeparador
        '
        Me.txtCaracterSeparador.Location = New System.Drawing.Point(726, 49)
        Me.txtCaracterSeparador.Name = "txtCaracterSeparador"
        Me.txtCaracterSeparador.Size = New System.Drawing.Size(100, 22)
        Me.txtCaracterSeparador.TabIndex = 12
        '
        'FrmCodigoPostal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1141, 681)
        Me.Controls.Add(Me.txtCaracterSeparador)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.btnGuardarCSV)
        Me.Controls.Add(Me.btnGuardarWord)
        Me.Controls.Add(Me.btnGuardarPDF)
        Me.Controls.Add(Me.btnGuardarOpenXml)
        Me.Controls.Add(Me.btnGuardarInterop)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.lstvDatos)
        Me.Controls.Add(Me.chartGrafica)
        Me.Name = "FrmCodigoPostal"
        Me.Text = "FrmCodigoPostal"
        CType(Me.chartGrafica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents lstvDatos As ListView
    Friend WithEvents chartGrafica As DataVisualization.Charting.Chart
    Friend WithEvents btnGuardarInterop As Button
    Friend WithEvents btnGuardarOpenXml As Button
    Friend WithEvents btnGuardarPDF As Button
    Friend WithEvents btnGuardarWord As Button
    Friend WithEvents btnGuardarCSV As Button
    Friend WithEvents btnCargar As Button
    Friend WithEvents txtCaracterSeparador As TextBox
End Class
