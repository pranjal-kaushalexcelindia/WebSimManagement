<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="WebSimManagement.CourseDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Details</title>
    <link href="Scripts/CSS/CustomCSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="CourseDetailGridView">
            <div>
                <h2 style="display:inline-block;width:870px;">Course Detail</h2>
                <div style="display:inline;">
                    <asp:Button ID="Button1" runat="server" Text="Log Out" OnClick="LogOutCourseDetail_Click" />
                </div>
                <hr />
            </div>
            

            <asp:GridView ID="GridViewCourseDetail" runat="server" AutoGenerateColumns="true" OnRowDataBound="GridViewCourseDetail_RowDataBound">
            </asp:GridView>
        </div>
        <br />
        <div>
            <asp:Label runat="server" ID="lblMessageGridView"></asp:Label>
        </div>
        <div>
            <hr />
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
            <br />
            <br />
            <div>

                <div style="width: 100px; display: inline;">
                    <asp:Label runat="server">Student List</asp:Label>
                </div>
                <div style="display: inline; margin-left: 230px;">Add Student List</div>
            </div>
            <br />
            <div style="display: inline-block;">
                <asp:ListBox ID="StudentList" Height="150" Width="100" SelectionMode="Multiple" runat="server" DataTextField="UserName" DataValueField="UserId"></asp:ListBox>
            </div>

            <div style="display: inline-block; margin: 50px;">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnAddStudent" OnClick="AddStudentToList_click" runat="server" Text="ADD >>" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnRemoveStudent" runat="server" Text="Remove <<" OnClick="RemoveSelectedStudent_click" />
                        </td>
                    </tr>
                </table>
            </div>

            <div style="display: inline-block;">
                <asp:ListBox ID="SelectedStudentList" SelectionMode="Multiple" Height="150" Width="100" runat="server"></asp:ListBox>
            </div>

            <div style="margin: 30px 290px;">
                <asp:Button runat="server" Text="Add Student List" OnClick="AddStudentListToDB" />
            </div>
        </div>
    </form>
</body>
</html>
