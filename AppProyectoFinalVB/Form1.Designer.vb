<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnCodigoPostal = New System.Windows.Forms.Button()
        Me.btnPDolar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCodigoPostal
        '
        Me.btnCodigoPostal.Location = New System.Drawing.Point(408, 136)
        Me.btnCodigoPostal.Name = "btnCodigoPostal"
        Me.btnCodigoPostal.Size = New System.Drawing.Size(148, 76)
        Me.btnCodigoPostal.TabIndex = 0
        Me.btnCodigoPostal.Text = "Codigo Postal"
        Me.btnCodigoPostal.UseVisualStyleBackColor = True
        '
        'btnPDolar
        '
        Me.btnPDolar.Location = New System.Drawing.Point(177, 136)
        Me.btnPDolar.Name = "btnPDolar"
        Me.btnPDolar.Size = New System.Drawing.Size(148, 76)
        Me.btnPDolar.TabIndex = 1
        Me.btnPDolar.Text = "Precio del dolar"
        Me.btnPDolar.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnPDolar)
        Me.Controls.Add(Me.btnCodigoPostal)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCodigoPostal As Button
    Friend WithEvents btnPDolar As Button
End Class
