<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterUser.aspx.cs" Inherits="WebSimManagement.RegisterUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register User</title>
    <link href="Scripts/CSS/CustomCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="registerContainer">
            <div>
                <asp:Image runat="server" ImageUrl="~/Images/registernow.jpg" Width="440px" Height="120px" />
            </div>
            <div>
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </div>
            <div id="loginTable">
                <table>
                    <tr>
                        <td>Username</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtUsername"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldUsername" ControlToValidate="txtUsername" ErrorMessage="*  This is a required field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Password</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*  This is a required field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Confirm Password</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword" ErrorMessage="*  This is a required field"></asp:RequiredFieldValidator>

                        </td>
                    </tr>
                    <tr>
                        <td>Email-Id</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail" TextMode="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="FieldValidatorEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*  This is a required field"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <asp:CompareValidator ID="passwordCompareValidator" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="*  Password and Confirm password must match"></asp:CompareValidator>
                <div class="buttonRegister">
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Register" OnClick="RegisterUser_Click" /></td>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
