<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VehicleList.aspx.vb" Inherits="RentAVehicle.VehicleList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~\Styles\styles.css" />
</head>
<body>
    <p id="vehicleList-successMessage" class="hide">
        <asp:Literal runat="server" ID="SuccessMessage" />
    </p>
    <div class="header">
        <h2>Vehicle List</h2>
        <a href="CreateVehicle.aspx">Create Vehicle</a>
    </div>
    <div class="content">
        <div class="vehicle-list">
            <% For Each item In Me.GetVehiclesList() %>
                <div class="vehicle">
                    <p>Vehicle: <span class="vehicle-name"><%= item.Name %></span></p>
                    <p>Type: <%= item.Type %></p>
                    <p>Model: <%= item.Model %></p>
                    <p>Year: <%= item.Year %></p>
                    <p>CostPerDay: <%= item.CostPerDay %> $</p>
                    <div class="vehicle-actions">
                        <a href="RentVehicle.aspx?id=<%= item.Id %>" class="rent-button">Rent this Vehicle</a>
                        <div>
                            <a href="EditVehicle.aspx?id=<%= item.Id %>"><button type="button">Edit</button></a>
                            <a href="DeleteVehicle.aspx?id=<%= item.Id %>"><button type="button">Delete</button></a>
                        </div>
                    </div>
                </div>
            <% Next %>
        </div>
        </div>
    <script language="JavaScript">
        function jsfunction()
        {
            const message = document.getElementById('vehicleList-successMessage').innerText.trim();
            if (message) {
                alert(message)
            }
        }
        document.onload = jsfunction()
    </script>
</body>
</html>
