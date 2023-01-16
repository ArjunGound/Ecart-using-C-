<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Userhomecartpage.aspx.cs" Inherits="Finalproject.Userhomecartpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
function script2()
  {
  return confirm('This will Remove All Your Cart Items?');
  }
</script>
</head>
<body style="background-color:honeydew">
    <form id="form1" runat="server">
        <div>
            <b style="margin-left:250px">!!!Login User !!!</b>
            <br />
            <asp:Image ID="Image1" runat="server" Height="100px" ImageUrl="~/Images/user logo image.png" BorderColor="#33CC33" BorderStyle="Solid" ToolTip="userlogo" style="margin-left:250px" />
            <br />
           <b style="margin-left:250px"> Welcome </b>
            <asp:Label ID="lblquerystringname" runat="server"></asp:Label>
            <br />
            <b>Select Catogory</b>
            <asp:DropDownList ID="ddlusercartsorting" runat="server" DataValueField="catogory_id" DataTextField="catogory_name" AutoPostBack="True">
                 <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Mobile" Value="1"></asp:ListItem>
                        <asp:ListItem Text="perfumes" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Bags" Value="3"></asp:ListItem>
                </asp:DropDownList>
            <asp:GridView runat="server" ID="gvProducts" AutoGenerateColumns="false" OnSelectedIndexChanged="gvProducts_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="product_name" HeaderText="Product Name" />
                    <asp:BoundField DataField="product_price" HeaderText="Product Price" />
                     <asp:TemplateField HeaderText="AddToCart">
                        <ItemTemplate>
                            <asp:LinkButton Text="Add" ID="lnkSelect" runat="server" CommandName="Select" />
                        </ItemTemplate>

                    </asp:TemplateField>
                    <%-- <asp:HyperLinkField DataNavigateUrlFormatString="~/Usercartpage.aspx?Id={0}" DataNavigateUrlFields="product_id"
            Text="View Details" HeaderText="Details" />--%>                  
                </Columns>
            </asp:GridView>
            <b>ProductName</b><asp:TextBox ID="txtproductname" runat="server" ReadOnly="True"></asp:TextBox>
            <b>ProductPrice</b><asp:TextBox ID="txtproductprice" runat="server" ReadOnly="True"></asp:TextBox>                      
            <br />
            <asp:Button ID="userallproductshownbutton" runat="server" Text="See Cart Products" OnClick="userallproductshownbutton_Click" />
            <asp:GridView ID="gvusercartshown" runat="server">
            </asp:GridView>
             <h4><b>UserCart Products Amount</b></h4>
            <b>TotalPrice</b><asp:TextBox ID="txttotalprice" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Button ID="userrefreshbutton" runat="server" Text="Refresh" OnClick="userrefreshbutton_Click" /> 
          <br />
            <asp:Button ID="deleteproductbutton" runat="server" Text="Remove All Products" OnClick="deleteproductbutton_Click" BackColor="#FF3300" Font-Bold="true"
                OnClientClick="return script2()" />
            <asp:Button ID="userlogoutbutton" runat="server" Text="Logout" OnClick="userlogoutbutton_Click" />
            <br />
            <asp:Label ID="lblfinalamount" runat="server"></asp:Label>           
        </div>
    </form>    
</body>
</html>
