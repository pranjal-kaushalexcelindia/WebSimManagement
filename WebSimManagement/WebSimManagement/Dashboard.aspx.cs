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
            UserList();
            RolesList();
            CourseNameGridView();
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
            DropDownUserList.DataSource = Membership.GetAllUsers();
            DropDownUserList.DataBind();
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
        ///  Gives the list of all the course name
        /// </summary>
        private void CourseNameGridView()
        {
            IList<WebSim.DTO.CourseNameAndId> courseDto = business.GetCourseName();
            
            GridViewDashboard.DataSource = courseDto;
            GridViewDashboard.DataBind();
            GridViewDashboard.HeaderRow.Cells[3].Text = "Course Name";
            GridViewDashboard.HeaderRow.Cells[2].Visible = false;
        }

        /// <summary>
        /// Logs out the user
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
            string userId = DropDownUserList.SelectedValue.ToString();
            string roleId = DropDownRoleList.SelectedValue.ToString();

            Roles.AddUserToRole(userId, roleId);
        }

        protected void GridViewDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Visible = false;
            }
            
            //GridViewDashboard.Columns[3].Visible = false;
        }
    }
}