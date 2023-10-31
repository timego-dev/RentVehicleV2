Imports System.ComponentModel.DataAnnotations.Schema

Public Class Contract
    Public Property Id As Integer
    <ForeignKey("User")>
    Public Property UserId As Integer
    <ForeignKey("Vehicle")>
    Public Property VehicleId As Integer
    Public Property CostPerDay As Integer
    Public Property ValidFrom As Date
    Public Property NumOfDays As Integer
    Public Property User As User
    Public Property Vehicle As Vehicle
End Class
