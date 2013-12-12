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

        </div><br />

        <div>
            Role Name : <asp:TextBox runat="server" ID="txtRoleName"></asp:TextBox>
            <asp:Button runat="server" Text="Add Role" OnClick="AddRole_click" />
            <br />
        </div><br />
        <div>
            Add User to Course :
            <div style="display:inline;margin-left:20px;">
        <asp:DropDownList ID="DropDownListUser" runat="server">
            <asp:ListItem Text="--Select User--" Value=""></asp:ListItem>
        </asp:DropDownList>
                </div>
            <div style="display:inline;margin-left:20px;">
            <asp:DropDownList ID="DropDownListCourse" runat="server" DataValueField="CourseName">
                <asp:ListItem Text="--Select Course--" Value=""></asp:ListItem>
            </asp:DropDownList>
                </div>
        </div>
        <div style="margin-top:20px;">
        <asp:Button ID="Button1" runat="server" OnClick="AddUserAndCourse_Click" Text="Add User to Course" />
            </div>
        <br />
        <br />
        <div>
            <div style="display: inline-block;">
                Add Users To Role :
            <div style="display: inline; margin-left: 20px;">
                <asp:DropDownList ID="DropDownUserList" runat="server">
                    <asp:ListItem Text="--Select Users--" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
                <div style="display: inline; margin-left: 20px;">
                    <asp:DropDownList ID="DropDownRoleList" runat="server">
                        <asp:ListItem Text="--Select Role--" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="margin-top:10px;">
                    <asp:Button runat="server" Text="Add" OnClick="AddUserToRole_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
