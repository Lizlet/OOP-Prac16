Public Class Form1
    Private grades As New Hashtable
    Private gradeValues As New Hashtable
    Private denominator As Integer = 0
    Private numerator As Integer = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        resetGrades()
        listGrades()
        resetGrades()
        TextBox1.Select()
        TextBox2.Text = "Average:"
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If "abcdefABCDEF".ToCharArray.Contains(TextBox1.Text) Then
            Dim input As String = TextBox1.Text.ToUpper
            grades(input) += 1
            denominator += 1
            numerator += Asc(input) - 65
            Dim x As Integer = Math.Floor(numerator / denominator)
            TextBox2.Text = "Average: " & gradeValues(x)
            ' TextBox2.Text = "Average: " & Chr(i + 65) would save 4 lines of code and
            ' the space needed for the second hashtable
            listGrades()
        End If

        TextBox1.Text = ""
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        resetGrades()
        listGrades()
        For i = 0 To 5
            gradeValues.Add(i, Chr(i + 65))
        Next
    End Sub

    Private Sub resetGrades()
        grades.Clear()
        denominator = 0
        numerator = 0
        For Each c In "ABCDEF".ToCharArray
            grades.Add(c.ToString, 0)
        Next
    End Sub

    Private Sub listGrades()
        With ListBox1.Items
            .Clear()
            For Each k In "ABCDEF".ToCharArray
                .Add(k & ": " & grades(k.ToString()))
            Next
        End With
    End Sub
End Class
