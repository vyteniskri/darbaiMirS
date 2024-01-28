<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Lab_4.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="TextSize">
            Užkraukite bent vieną pradinių duomenų failą iš aplanko, kad užkrautumėte likusius:<br />
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="BoldText"/>
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="TextSize"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Užkrauti duomenis" CssClass="BoldText" />
            &nbsp;<br />
            <asp:Table ID="Table1" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Skaičius „Siemens“ šaldytuvų, mikrobangų krosnelių ir virdulių modelių, kurį siūlo kiekviena parduotuvė:<br />
            <asp:Table ID="Table2" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Dešimt pigiausių pastatomų šaldytuvų, kurių talpa yra 80 litrų ar didesnė:<br />
            <asp:Table ID="Table3" runat="server" BorderWidth="1px" ForeColor="Black" GridLines="Both" CssClass="Table">
            </asp:Table>
            <br />
            Išspausdinama, ar yra tokių buitinių prietaisų, kuriuos galima įsigyti tik vienoje parduotuvėje:<br />
            <br />
            <asp:Label ID="Label2" runat="server" CssClass="TextSize"></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
