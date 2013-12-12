using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSimManagement
{
    public partial class Dashboard : System.Web.UI.Page
    {
        WebSim.Business.Business business = new WebSim.Business.Business();
        private string courseid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Get the course list to the gridview as well as to the dropdownlist
                CourseList();

                // Gets the username list for the role and course dropdown list
                UserList();

                RolesList();
            }
        }

        /// <summary>
        /// Get the list of all the course
        /// </summary>
        private void CourseList()
        {
            IList<WebSim.DTO.CourseNameAndId> courseDTO = business.GetCourseName();
            
            // Add the coursename to the dropdownlist
            DropDownListCourse.DataSource = courseDTO;
            DropDownListCourse.DataBind();

            // Add the coursename to the gridview
            GridViewDashboard.DataSource = courseDTO;
            GridViewDashboard.DataBind();

            // Renaming the header and hiding the course id column
            GridViewDashboard.HeaderRow.Cells[3].Text = "Course Name";
            GridViewDashboard.HeaderRow.Cells[2].Visible = false;
        }

        /// <summary>
        /// Gives the roles list
        /// </summary>
        private void RolesList()
        {
            DropDownRoleList.DataSource = Roles.GetAllRoles();
            DropDownRoleList.DataBind();
        }

        /// <summary>
        /// Gives the Course List
        /// </summary>
        private void UserList()
        {
            // get user list for adding role to the user
            DropDownUserList.DataSource = Membership.GetAllUsers();
            DropDownUserList.DataBind();

            // get user list for adding user to the course
            DropDownListUser.DataSource = Membership.GetAllUsers();
            DropDownListUser.DataBind();
        }

        /// <summary>
        /// add user and the course to a table in the database
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddUserAndCourse_Click(object sender, EventArgs e)
        {
            WebSim.DTO.UserAndCourse userInCourse = new WebSim.DTO.UserAndCourse();
            
            userInCourse.userName = DropDownListUser.SelectedValue.ToString();
            userInCourse.courseName = DropDownListCourse.SelectedValue.ToString();

            business.AddUserToCourse(userInCourse);
        }

        /// <summary>
        /// Delete the course from the database
        /// </summary>
        /// <param name="sender">The link button is the sender object</param>
        /// <param name="e">The event argument for the link click</param>
        protected void DeleteCourse_Click(object sender, EventArgs e)
        {
            WebSim.DTO.CourseID courseid = new WebSim.DTO.CourseID();
            string coursename = ((LinkButton)sender).CommandArgument.ToString();

            business.RemoveCourse(courseid);
        }

        /// <summary>
        /// Get the detail of the item selected
        /// </summary>
        /// <param name="sender">The link button is the sender object</param>
        /// <param name="e">The event argument for the link click</param>
        protected void GetDetailLinkItem_Click(object sender, EventArgs e)
        {
            courseid = ((LinkButton)sender).CommandArgument.ToString();
            Response.Redirect("CourseDetails.aspx?Course=" + this.courseid + "");
        }

        /// <summary>
        /// Removing the authentication of the user
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void LogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Response.Cookies["Teacher"].Expires.AddDays(-1);
            Response.Redirect("UserLogin.aspx");
        }

        /// <summary>
        /// This will add new role in the database
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddRole_click(object sender, EventArgs e)
        {
            try
            {
                Roles.CreateRole(txtRoleName.Text.ToUpper().Trim());
                txtRoleName.Text = string.Empty;
            }
            catch (ArgumentException)
            {
                Response.Redirect("CourseDetails.aspx");
            }
        }

        /// <summary>
        /// Add role to user
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddUserToRole_Click(object sender, EventArgs e)
        {
            string userName = DropDownUserList.SelectedValue.ToString();
            string rolenName = DropDownRoleList.SelectedValue.ToString();

            Roles.AddUserToRole(userName, rolenName);
        }

        /// <summary>
        /// It hides the datarow of the id column
        /// </summary>
        /// <param name="sender">The bound data is the sender object</param>
        /// <param name="e">The GridViewRow event arugument for the bound data</param>
        protected void GridViewDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
            }
        }
    }
}