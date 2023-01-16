<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Guestwelcomepage.aspx.cs" Inherits="Finalproject.Guestwelcomepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color:cornsilk">
    <form id="form1" runat="server">
    <div>
        <h3 style="margin-left:250px"><b>!!! Welcome To Shopping Website !!!</b></h3>
        <asp:Button ID="loginbutton" runat="server" Text="Login" OnClick="loginbutton_Click" />
        <asp:Button ID="registorbutton" runat="server" Text="Register" OnClick="registorbutton_Click" />
          <h2><b>Product Details</b></h2>
                <b>Select Catogory</b>
                <asp:DropDownList ID="ddlguestfliter" runat="server" DataValueField="catogory_id" DataTextField="catogory_name" AutoPostBack="True">
                     <asp:ListItem Text="SelectAll" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Mobile" Value="1"></asp:ListItem>
                        <asp:ListItem Text="perfumes" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Bags" Value="3"></asp:ListItem>
                </asp:DropDownList>
        <asp:GridView ID="gvguest" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
        <h3 style="color:gray"><b>Please Login to buy product</b></h3>
    </div>
    </form>
</body>
</html>
