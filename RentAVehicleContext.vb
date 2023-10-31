Imports System.Data.Entity

Namespace Data

    Public Class RentAVehicleContext
        Inherits DbContext

        Public Sub New()
            MyBase.New("name=RentAVehicle")
        End Sub

        Public Property Vehicle As System.Data.Entity.DbSet(Of Vehicle)
        Public Property Contract As System.Data.Entity.DbSet(Of Contract)
        Public Property User As System.Data.Entity.DbSet(Of User)
    End Class

End Namespace
