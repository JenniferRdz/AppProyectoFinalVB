Public Class Form1
    Private Sub btnCodigoPostal_Click(sender As Object, e As EventArgs) Handles btnCodigoPostal.Click
        Dim frm As New FrmCodigoPostal()
        frm.ShowDialog()
    End Sub

    Private Sub btnPDolar_Click(sender As Object, e As EventArgs) Handles btnPDolar.Click
        Dim frm As New FrmPrecioDolar()
        frm.ShowDialog()
    End Sub
End Class
