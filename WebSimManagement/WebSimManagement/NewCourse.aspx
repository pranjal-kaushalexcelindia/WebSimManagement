<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewCourse.aspx.cs" Inherits="WebSimManagement.NewCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>Add New Course</h3>
        <hr />
    </div>
        <div>
            <table>
                <tr>
                    <td>Course Name</td>
                    <td>:</td>
                    <td><asp:TextBox runat="server" TextMode="SingleLine" ID="txtCourseName"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="FieldValidatorCourseName" ControlToValidate="txtCourseName" ErrorMessage="*  This is required field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Course Description</td>
                    <td>:</td>
                    <td><asp:TextBox runat="server" ID="txtCourseDetail" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="FieldValidatorCourseDetail" ControlToValidate="txtCourseDetail" ErrorMessage="*  This is required field"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <div>
                <asp:Button runat="server" Text="Add" OnClick="AddNewCourse_Click" />
            </div>
        </div>
    </form>
</body>
</html>
