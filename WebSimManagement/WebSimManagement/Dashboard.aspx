<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebSimManagement.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link href="Scripts/CSS/CustomCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="display:inline-block;margin-left:40px;width:700px;">
                <h2>
                    <asp:LoginName runat="server" />
                </h2>
            </div>
            <div style="display:inline;">
                <asp:Button runat="server" Text="Reset Password" PostBackUrl="ResetPassword.aspx" />
            </div>
            <div style="display: inline;">
                <asp:Button runat="server" Text="Log Out" OnClick="LogOut_Click" />
            </div>
        </div>
        <hr />

        <div id="dashboardCourseNameGridView">

            <asp:GridView ID="GridViewDashboard" runat="server"  DataKeyNames="CourseId" AutoGenerateColumns="true" OnRowDataBound="GridViewDashboard_RowDataBound" style="margin-left:10px" >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkItemGetDetails" runat="server" Text="Detail" OnClick="GetDetailLinkItem_Click" CommandArgument='<%# Eval("courseid","{0}") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkItemDelete" runat="server" Text="Delete" OnClick="DeleteCourse_Click" CommandArgument='<%# Eval("courseid","{0}") %>' style="height: 26px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="AddNewCourse_Click" runat="server" PostBackUrl="/NewCourse.aspx" Text="Add New Course" />

        </div>

        <div>
            Role Name : <asp:TextBox runat="server" ID="txtRoleName"></asp:TextBox>
            <asp:Button runat="server" Text="Add Role" OnClick="AddRole_click" />
        </div>
        <br />
        <div>
        <div style="display:inline-block;">
            Add Users To Role
            <asp:DropDownList ID="DropDownUserList" runat="server">
                <asp:ListItem Text="--Select Users--" Value=""></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="display:inline;">
        <asp:DropDownList ID="DropDownRoleList" runat="server">
            <asp:ListItem Text="--Select Roles--" Value=""></asp:ListItem>
        </asp:DropDownList>
            </div>
            <div>
                <asp:Button runat="server" Text="Add" OnClick="AddUserToRole_Click" />
            </div>
            </div>
    </form>
</body>
</html>
