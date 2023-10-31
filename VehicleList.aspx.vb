Imports System.Data.SqlClient

Public Class VehicleList
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session.Item("VehicleCreated") IsNot Nothing Then
            SuccessMessage.Text = "Vehicle Created Successfully"
            Session("VehicleCreated") = Nothing
        End If
        If Session.Item("VehicleRented") IsNot Nothing Then
            SuccessMessage.Text = "Vehicle Rented Successfully"
            Session("VehicleRented") = Nothing
        End If
        If Session.Item("VehicleEdited") IsNot Nothing Then
            SuccessMessage.Text = "Vehicle Edited Successfully"
            Session("VehicleEdited") = Nothing
        End If
        If Session.Item("VehicleDeleted") IsNot Nothing Then
            SuccessMessage.Text = "Vehicle Deleted Successfully"
            Session("VehicleDeleted") = Nothing
        End If
    End Sub

    Function GetVehiclesList()
        Dim vehicles = New List(Of Vehicle)
        Dim queryString As String = "Select * from AvailableVehicles"
        Using connection As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentAVehicle;Integrated Security=True")
            connection.Open()
            Dim command As New SqlCommand(queryString, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            Dim DTResults As New DataTable

            DTResults.Load(reader)
            connection.Close()

            For i As Integer = 0 To DTResults.Rows.Count - 1
                Dim row = DTResults.Rows.Item(i)
                Dim vehicle = New Vehicle With {
                    .Id = row.Field(Of Integer)("Id"),
                    .Name = row.Field(Of String)("Name"),
                    .Type = row.Field(Of String)("Type"),
                    .Model = row.Field(Of String)("Model"),
                    .Year = row.Field(Of String)("Year"),
                    .CostPerDay = row.Field(Of Integer)("CostPerDay"),
                    .Availability = True
                }
                vehicles.Add(vehicle)
            Next
            Return vehicles
        End Using
    End Function

End Class