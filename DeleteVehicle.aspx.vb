Imports System.Data.Entity.Migrations
Imports System.Data.SqlClient

Public Class DeleteVehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim id = Request.QueryString("id")
            If Not (id Is Nothing) Then
                Dim vehicles = GetVehicle(id)
                If vehicles.Count = 0 Then
                    Response.Redirect("InvalidVehicleId.aspx")
                End If
            Else
                Response.Redirect("InvalidVehicleId.aspx")
            End If
        End If
    End Sub

    Function GetVehicle(ByVal id As Integer)
        Dim vehicles = New List(Of Vehicle)
        Dim queryString As String = "Select * from Vehicles Where id = " & id & ";"
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

    Protected Sub DeleteVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim id = Request.QueryString("id")

        Using connection As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentAVehicle;Integrated Security=True")
            connection.Open()

            Dim command As New SqlCommand("DeleteVehicle", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Id", id)
            command.ExecuteNonQuery()

            connection.Close()
        End Using

        Session("VehicleDeleted") = 1


        Response.Redirect("VehicleList.aspx")
    End Sub

End Class