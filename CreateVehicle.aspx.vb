Imports System.Data.SqlClient

Public Class CreateVehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub CreateVehicle_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Using connection As New SqlConnection("Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RentAVehicle;Integrated Security=True")
            connection.Open()

            Dim command As New SqlCommand("CreateVehicle", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@Name", Name.Text)
            command.Parameters.AddWithValue("@Type", Type.Text)
            command.Parameters.AddWithValue("@Model", Model.Text)
            command.Parameters.AddWithValue("@Year", Year.Text)
            command.Parameters.AddWithValue("@CostPerDay", CostPerDay.Text)
            command.Parameters.AddWithValue("@Availability", Availability.Checked)
            command.ExecuteNonQuery()

            connection.Close()
        End Using

        Session("VehicleCreated") = Name.Text

        Response.Redirect("VehicleList.aspx")
    End Sub

End Class