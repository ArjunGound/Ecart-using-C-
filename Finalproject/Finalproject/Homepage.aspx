<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="Finalproject.Homepage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #Logintable{
            border: solid;
            border-color: greenyellow;
           
        }   
        #ImageButton1{
            margin-left:100px;

        }   
    </style>
</head>
<body style="background-color:cornflowerblue;">
    
    <form id="form1" runat="server">
    <div> 
        <%--<asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">--%>
       <table id="Logintable">
           <tr>
               <td colspan="3"><b>User Login</b></td>
           </tr>
           <tr>
               <td>UserName</td>
               <td><asp:TextBox ID="txtusername" runat="server"></asp:TextBox></td>
               <td><asp:Label ID="lblusernamevalidation" runat="server" ForeColor="Red"></asp:Label></td>  
           </tr>
            <tr>
               <td>Password</td>
               <td><asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox></td>
               <td><asp:Label ID="lblpasswordvalidation" runat="server" ForeColor="Red"></asp:Label></td>  
           </tr>
           <tr>
               <td>
               <asp:Button ID="loginbutton" runat="server" Text="Login" Width="66px" OnClick="loginbutton_Click" />
               </td>
               <td><asp:Button ID="adminloginbutton" runat="server" Text="Admin Login" Width="138px" OnClick="adminloginbutton_Click" /></td>
               <td> </td>
           </tr>
           <tr>
               <td colspan="3">
                  <asp:Label ID="lblloginmessage" runat="server" ForeColor="Red"/>
               </td>
           </tr>
       </table>
      
             <%--   </asp:View>--%>
           <%-- <asp:View ID="View2" runat="server">--%>
           
            <%--</asp:View>
            </asp:MultiView>--%>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="39px" ImageUrl="~/Images/homebutton png.png" OnClick="ImageButton1_Click"  />
    </div>
    </form>
</body>
</html>
