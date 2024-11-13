<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab1.aspx.cs" Inherits="Lab1.Lab1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Schemos dydis: "></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table2" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            </asp:Table>
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
            </asp:Table>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Skaičiuoti" />
        </div>
    </form>
</body>
</html>
