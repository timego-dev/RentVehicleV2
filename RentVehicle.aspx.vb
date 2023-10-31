Imports System.Data.SqlClient

Public Class RentVehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            VehicleDropdown.DataSource = GetVehiclesList()
            VehicleDropdown.DataTextField = "Label"
            VehicleDropdown.DataValueField = "Value"

            VehicleDropdown.DataBind()

            Dim id = Request.QueryString("id")
            If Not (id Is Nothing) Then
                VehicleDropdown.SelectedValue = id
            Else
                VehicleDropdown.SelectedIndex = 0
            End If
        End If
    End Sub

    Function GetVehiclesList()
        Dim vehicles = New List(Of VehicleListOption)
        Dim queryString As String = "Select * from VehicleList"
        Using connection As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentAVehicle;Integrated Security=True")
            connection.Open()
            Dim command As New SqlCommand(queryString, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            Dim DTResults As New DataTable

            DTResults.Load(reader)
            connection.Close()

            For i As Integer = 0 To DTResults.Rows.Count - 1
                Dim row = DTResults.Rows.Item(i)
                Dim vehicle = New VehicleListOption With {
                    .Label = row.Field(Of String)("Label"),
                    .Value = row.Field(Of Integer)("Value")
                }
                vehicles.Add(vehicle)
            Next
            Return vehicles
        End Using
    End Function

    Protected Sub Selection_Change(ByVal sender As Object, ByVal e As System.EventArgs)
        VehicleDropdown.SelectedValue = VehicleDropdown.SelectedItem.Value
    End Sub

    Protected Sub RentVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Using connection As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentAVehicle;Integrated Security=True")
            connection.Open()

            Dim command As New SqlCommand("RentVehicle", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@VehicleId", VehicleDropdown.SelectedItem.Value)
            command.Parameters.AddWithValue("@Name", Name.Text)
            command.Parameters.AddWithValue("@IDNumber", IDNumber.Text)
            command.Parameters.AddWithValue("@Email", Email.Text)
            command.Parameters.AddWithValue("@ValidFrom", ValidFrom.Text)
            command.Parameters.AddWithValue("@NumOfDays", NumOfDays.Text)
            command.ExecuteNonQuery()

            connection.Close()
        End Using

        Session("VehicleRented") = Name.Text

        Response.Redirect("VehicleList.aspx")
    End Sub

End Class