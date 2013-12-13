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
            <div style="display: inline-block; margin-left: 40px; width: 700px;">
                <h2>
                    <asp:LoginName runat="server" />
                </h2>
            </div>
            <div style="display: inline;">
                <asp:Button runat="server" Text="Reset Password" PostBackUrl="ResetPassword.aspx" />
            </div>
            <div style="display: inline;">
                <asp:Button runat="server" Text="Log Out" OnClick="LogOut_Click" />
            </div>
        </div>
        <hr />

        <div id="dashboardCourseNameGridView">

            <asp:GridView ID="GridViewDashboard" runat="server" DataKeyNames="CourseId" AutoGenerateColumns="true" OnRowDataBound="GridViewDashboard_RowDataBound" Style="margin-left: 10px">
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
                            <asp:LinkButton ID="LinkItemDelete" runat="server" Text="Delete" OnClick="DeleteCourse_Click" CommandArgument='<%# Eval("courseid","{0}") %>' Style="height: 26px"  />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <br />
            <asp:Button ID="btn_AddNewCourse" runat="server" PostBackUrl="/NewCourse.aspx" Text="Add New Course" />
            <br />
            <br />
        </div>
        <div>
            <div>
                <br />
                <asp:Label runat="server" ID="lbl_RoleName" Text="Role Name :"></asp:Label>
                <asp:TextBox runat="server" ID="txt_RoleName"></asp:TextBox>
                <asp:Button runat="server" Text="Add Role" ID="btn_RoleName" OnClick="AddRole_click" />
                <br />
            </div>
            <br />
            <div>
                <asp:Label runat="server" Text="Add User to Course :" ID="lbl_AddUserToCourse"></asp:Label>
            <div style="display: inline; margin-left: 20px;">
                <asp:DropDownList ID="DropDownListUser" runat="server">
                    <asp:ListItem Text="--Select User--" Value=""></asp:ListItem>
                </asp:DropDownList>
            </div>
                <div style="display: inline; margin-left: 20px;">
                    <asp:DropDownList ID="DropDownListCourse" runat="server" DataValueField="CourseName">
                        <asp:ListItem Text="--Select Course--" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div style="margin-top: 20px;">
                <asp:Button ID="btn_AddUserToCourse" runat="server" OnClick="AddUserAndCourse_Click" Text="Add User to Course" />
            </div>
            <br />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
            <br />
            <div>
                <div style="display: inline-block;">
                    <asp:Label runat="server" Text="Add Users To Role :" ID="lbl_AddUsersToRole"></asp:Label>
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
                    <div style="margin-top: 10px;">
                        <asp:Button runat="server" ID="btn_AddUserToTole" Text="Add User To Role" OnClick="AddUserToRole_Click" />
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
