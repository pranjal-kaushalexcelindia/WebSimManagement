<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="WebSimManagement.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link href="Scripts/CSS/CustomCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginContainer">
            <div>
                <img alt="LogIn" class="auto-style1" src="Images/login.png" title="LogIn" /><br />
            </div>
            <table>
                <tr>
                    <td>Username</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtUsername" TextMode="SingleLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="FieldValidatorUsername" ControlToValidate="txtUsername" ErrorMessage="*  This is required field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>:</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="FieldValidatorPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="*  This is required field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div style="margin-left: 73px;">
                <asp:CheckBox runat="server" ID="rememberMe" />Remember Me<br />
            </div>
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
            <br /><a href="RegisterUser.aspx">Register here</a>
            <div class="buttonLogin">
                <asp:Button runat="server" OnClick="Login_Click" Text="Log In" />
                <%--<div style="margin-left: 30px; display: inline;">
                    <asp:Button runat="server" OnClick="LoginCancel_Click" Text="Cancel" />
                </div>--%>
            </div>
        </div>
    </form>
</body>
</html>
