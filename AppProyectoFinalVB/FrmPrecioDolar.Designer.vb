<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrecioDolar
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
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.lbInicio = New System.Windows.Forms.Label()
        Me.lbFinal = New System.Windows.Forms.Label()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(455, 100)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(300, 300)
        Me.Chart1.TabIndex = 0
        Me.Chart1.Text = "Chart1"
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 100)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(412, 278)
        Me.TreeView1.TabIndex = 1
        '
        'btnConsultar
        '
        Me.btnConsultar.Location = New System.Drawing.Point(12, 31)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(109, 50)
        Me.btnConsultar.TabIndex = 2
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.UseVisualStyleBackColor = True
        '
        'lbInicio
        '
        Me.lbInicio.AutoSize = True
        Me.lbInicio.Location = New System.Drawing.Point(176, 31)
        Me.lbInicio.Name = "lbInicio"
        Me.lbInicio.Size = New System.Drawing.Size(79, 16)
        Me.lbInicio.TabIndex = 3
        Me.lbInicio.Text = "Fecha Inicio"
        '
        'lbFinal
        '
        Me.lbFinal.AutoSize = True
        Me.lbFinal.Location = New System.Drawing.Point(176, 65)
        Me.lbFinal.Name = "lbFinal"
        Me.lbFinal.Size = New System.Drawing.Size(77, 16)
        Me.lbFinal.TabIndex = 4
        Me.lbFinal.Text = "Fecha Final"
        '
        'dtpDesde
        '
        Me.dtpDesde.Location = New System.Drawing.Point(280, 31)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(200, 22)
        Me.dtpDesde.TabIndex = 5
        '
        'dtpHasta
        '
        Me.dtpHasta.Location = New System.Drawing.Point(280, 65)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(200, 22)
        Me.dtpHasta.TabIndex = 6
        '
        'FrmPrecioDolar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Controls.Add(Me.lbFinal)
        Me.Controls.Add(Me.lbInicio)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "FrmPrecioDolar"
        Me.Text = "FrmPrecioDolar"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents btnConsultar As Button
    Friend WithEvents lbInicio As Label
    Friend WithEvents lbFinal As Label
    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHasta As DateTimePicker
End Class
