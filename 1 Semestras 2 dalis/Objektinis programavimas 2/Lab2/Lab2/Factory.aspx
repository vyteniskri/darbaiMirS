<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factory.aspx.cs" Inherits="Lab2.Factory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TextSize">
            Pradinių duomenų failas apie darbininkus:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="BoldText" />
            <br />
            <br />
            Pradinių duomenų failas apie dalis:<br />
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="BoldText" />
            <br />
            <br />
&nbsp;<asp:Button ID="Button1" runat="server" Text="Užkrauti pradinius duomenis" OnClick="Button1_Click" CssClass="BoldText" />
            <br />
            <br />
            Pradiniai darbininkų duomenys:<br />
            <asp:Table ID="Table1" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Pradiniai dalių duomenys:<asp:Table ID="Table2" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Skaičiuoti" CssClass="BoldText" />
            <br />
            <br />
            Daugiausiai uždirbęs darbininkas:<br />
            <asp:Table ID="Table3" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Tik vieno pavadinimo detales gaminusių darbininkų sąrašas:<br />
            <asp:Table ID="Table4" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Įveskite pagamintų vienetų skaičių S:
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Įveskite įkainio skaičių K:
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Sudarytas naujas duomenų rinkinys pagal požymius S ir K:<asp:Table ID="Table5" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
        </div>
    </form>
</body>
</html>
