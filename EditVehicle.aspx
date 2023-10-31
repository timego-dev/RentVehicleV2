<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditVehicle.aspx.vb" Inherits="RentAVehicle.EditVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~\Styles\styles.css" />
</head>
<body>
    <div class="header">
        <h2>Edit vehicle</h2>
    </div>
    <div class="content">
        <form id="form1" runat="server">
            <div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Name">Name</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Name" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Type">Type</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Type" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Model">Model</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Model" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Year">Year</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Year" TextMode="Number" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="CostPerDay">Cost Per Day</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="CostPerDay" TextMode="Number" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Availability">Availability</asp:Label>
                    <div>
                        <asp:CheckBox runat="server" ID="Availability" />                
                    </div>
                </div>
                <div>
                    <div>
                        <asp:Button runat="server" OnClick="EditVehicle_Click" Text="Edit" />
                        <a href="VehicleList.aspx">Go back</a>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
