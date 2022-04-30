﻿Imports System.Data.SqlClient

Public Class Doctor
    Dim con As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\wwwsd\Documents\HospitalMngmntSystem(VB.net).mdf;Integrated Security=True;Connect Timeout=30")
    Private Sub Doctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Display()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        con.Open()
        Dim query As String
        query = ("INSERT INTO DoctorTbl VALUES('" + TextBox1.Text + "' , '" + TextBox2.Text + "' , '" + TextBox6.Text + "' , '" + ComboBox1.SelectedItem.ToString + "' , '" + TextBox5.Text + "' , '" + TextBox3.Text + "' ,'" + TextBox4.Text + "' )")
        Dim cmd As SqlCommand
        cmd = New SqlCommand(query, con)
        cmd.ExecuteNonQuery()
        MsgBox("New Doctor added successfully!!!")
        con.Close()
        Display()
    End Sub

    Private Sub Display()
        con.Open()
        Dim sql = "SELECT * FROM DoctorTbl"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, con)
        Dim builder As SqlCommandBuilder
        builder = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TextBox1.Text = "") Then
            MsgBox("Enter the DoctorID that you need to delete... ")
        Else
            con.Open()
            Dim query As String
            query = ("DELETE FROM DoctorTbl WHERE DoctorID = " + TextBox1.Text + "")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Doctor is successfully deleted...")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox5.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "") Then
            MsgBox("please fill all the fields...")
        Else
            con.Open()
            Dim query As String
            query = ("UPDATE DoctorTbl SET DoctorName= '" + TextBox2.Text + "' , Experience = '" + TextBox6.Text + "' ,Gender = '" + ComboBox1.SelectedItem.ToString() + "' , Specialization = '" + TextBox5.Text + "' , Password = '" + TextBox3.Text + "' ,Phone = '" + TextBox4.Text + "' WHERE DoctorID = '" + TextBox1.Text + "' ")
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, con)
            cmd.ExecuteNonQuery()
            MsgBox("Doctor updated successfully!!!")
            con.Close()
            Display()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Receptionist.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Pharmacist.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        db4.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Hide()
        Login.Show()
    End Sub
End Class