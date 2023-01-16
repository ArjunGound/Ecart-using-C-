<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registerpage.aspx.cs" Inherits="Finalproject.Registerpage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table id="Registortable">
                <tr>
                    <td>First Name</td>
                    <td>
                    <asp:TextBox ID="txtfirstname" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorfname" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtfirstname"></asp:RequiredFieldValidator> </td>     
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                    <asp:TextBox ID="txtlastname" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorlname" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtlastname"></asp:RequiredFieldValidator></td>     
                </tr>
                <tr> 
                    <td>Age</td>
                    <td>
                    <asp:TextBox ID="txtage" runat="server"></asp:TextBox></td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorage" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtage"></asp:RequiredFieldValidator>

                  <asp:RangeValidator ID="RangeValidatorage" runat="server" ErrorMessage="Should be in Number 1 to 100"  ForeColor="Red" ControlToValidate="txtage" Display="Dynamic" MaximumValue="100" MinimumValue="1" Type="Integer" ></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td>
                        <asp:DropDownList ID="ddlgender" runat="server" Width="101px" DataValueField="gender" DataTextField="Gender">
                            <asp:ListItem Text="Select" Value="0" />
                            <asp:ListItem Text="Male" Value="1" />
                            <asp:ListItem Text="Female" Value="2" />
                        </asp:DropDownList>
                    </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorgender" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="ddlgender"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                    <td>Gmail</td>
                    <td>
                    <asp:TextBox ID="txtgmail" runat="server"></asp:TextBox></td>
                    <td> 
<asp:RegularExpressionValidator ID="RegularExpressionValidatorgmail" runat="server" ErrorMessage="Invalid Gmail"  ForeColor="Red" ControlToValidate="txtgmail" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidatorgmail" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtgmail" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Username</td>
                    <td>
                    <asp:TextBox ID="txtinsertusername" runat="server"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorusername" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtinsertusername"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><asp:TextBox ID="txtinsertpassword" runat="server" TextMode="Password"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="RequiredFieldValidatorpassword" runat="server" ErrorMessage="RequiredField" Text="*" ForeColor="Red" ControlToValidate="txtinsertpassword"></asp:RequiredFieldValidator> </td>
                </tr>
                <tr>
                    <td>Confirm Password</td>
                    <td><asp:TextBox ID="txtconfrimpassword" runat="server" TextMode="Password"></asp:TextBox> </td>
                    <td> 
               <asp:CompareValidator ID="CompareValidatorpassword" runat="server" ErrorMessage=" Password Not Matched!"  ForeColor="Red" ControlToCompare="txtinsertpassword" ControlToValidate="txtconfrimpassword"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Submitbutton" runat="server" Text="Submit" OnClick="Submitbutton_Click" />
                    </td>
                    <td><asp:Label ID="lblmessage" runat="server"></asp:Label> </td> 
                </tr>
            </table>   
    </div>
    </form>
</body>
</html>
