
Imports System.Data
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient


Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim conect As String = "Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;"
        Dim query As String = "SELECT * FROM LoginInfo1 WHERE Username=@username AND password=@password;"

        Dim connection As New SqlConnection(conect)


        connection.Open()
        ' Your SQL commands here
        Dim cmd As New SqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@username", txtUsr.Text)
        cmd.Parameters.AddWithValue("@password", txtPass.Text)

        'Check for string exists in our data base
        'If value does'nt exist in database this function returns nothing If exists then returns string
        Dim result As Object = cmd.ExecuteScalar()


        'Check for string exists If values does'nt exist in database this 
        If result Is Nothing Then
            MessageBox.Show("login failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information.Error)
        Else
            MessageBox.Show("login succesfull", "information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If



        connection.Close()



    End Sub

    Private Sub txtUsr_TextChanged(sender As Object, e As EventArgs) Handles txtUsr.TextChanged

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtPass_TextChanged(sender As Object, e As EventArgs) Handles txtPass.TextChanged

    End Sub

    Private Sub textUser_Click(sender As Object, e As EventArgs) Handles textUser.Click

    End Sub

    Private Sub textPass_Click(sender As Object, e As EventArgs) Handles textPass.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
