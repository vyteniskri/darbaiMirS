<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Užkraukite nors vieną pradinių duomenų failą iš App_Data/SubData aplanko, kad užsikrautų visi likę.<br />
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Užkrauti pradinius duomenis" />
            <br />
            <br />
            <asp:Table ID="Table1" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both">
            </asp:Table>
            <br />
            <asp:Table ID="Table2" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both">
            </asp:Table>
            <br />
            Įveskite mėnesį.<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="Užkrauti rezultatus" OnClick="Button2_Click" />
            &nbsp;
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Table ID="Table3" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both">
            </asp:Table>
        </div>
    </form>
</body>
</html>
