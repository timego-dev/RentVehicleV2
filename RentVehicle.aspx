<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RentVehicle.aspx.vb" Inherits="RentAVehicle.RentVehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~\Styles\styles.css" />
</head>
<body>
    <div class="header">
        <h2>Rent a vehicle</h2>
    </div>
    <div class="content">
        <form id="form1" runat="server">
            <div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="VehicleDropdown">Vehicle</asp:Label>
                    <div>
                        <asp:DropDownList ID="VehicleDropdown"
                                AutoPostBack="True"
                                OnSelectedIndexChanged="Selection_Change"
                                runat="server" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Name">Name</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Name" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="IDNumber">ID Number</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="IDNumber" TextMode="Number" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="Email">Email</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="Email" TextMode="Email" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="ValidFrom">Rent From</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="ValidFrom" TextMode="Date" />                
                    </div>
                </div>
                <div class="form-field">
                    <asp:Label runat="server" AssociatedControlID="NumOfDays">For Number of Days</asp:Label>
                    <div>
                        <asp:TextBox runat="server" ID="NumOfDays" TextMode="Number" />                
                    </div>
                </div>
                <div>
                    <div>
                        <asp:Button runat="server" OnClick="RentVehicle_Click" Text="Rent" />
                        <a href="VehicleList.aspx">Go back</a>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
