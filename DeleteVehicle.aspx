<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DeleteVehicle.aspx.vb" Inherits="RentAVehicle.DeleteVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~\Styles\styles.css" />
</head>
<body>
    <div class="header">
        <h2>Delete vehicle</h2>
    </div>
    <div class="content">
        <form id="form1" runat="server">
            <p class="form-field">
                Are you sure you want to delete this vehicle?
            </p>
            <div>
                <asp:Button runat="server" OnClick="DeleteVehicle_Click" Text="Delete" />
                <a href="VehicleList.aspx">Go back</a>
            </div>
        </form>
    </div>
</body>
</html>
