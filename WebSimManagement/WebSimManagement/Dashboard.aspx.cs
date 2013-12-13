using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSimManagement
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Dashboard : System.Web.UI.Page
    {

        #region Private Members
        
        /// <summary>
        /// 
        /// </summary>
        private string courseid;
        
        /// <summary>
        /// 
        /// </summary>
        private int usersInRole = 0;


        /// <summary>
        /// 
        /// </summary>
        private void InitializeControls()
        {
            lbl_RoleName.Visible = false;
            txt_RoleName.Visible = false;
            btn_RoleName.Visible = false;
            btn_AddNewCourse.Visible = false;
            lbl_AddUserToCourse.Visible = false;
            DropDownListUser.Visible = false;
            DropDownListCourse.Visible = false;
            btn_AddUserToCourse.Visible = false;
            lblMessage.Visible = false;
            lbl_AddUsersToRole.Visible = false;
            DropDownUserList.Visible = false;
            DropDownRoleList.Visible = false;
            btn_AddUserToTole.Visible = false;
            GridViewDashboard.Columns.RemoveAt(1);
        }

        /// <summary>
        /// Get the list of all the course
        /// </summary>
        private void CourseList()
        {
            WebSim.Business.CourseBusiness courseNameList = new WebSim.Business.CourseBusiness();

            IList<WebSim.DTO.CourseNameAndId> courseDTO = courseNameList.GetCourseName();

            // Add the coursename to the dropdownlist
            DropDownListCourse.DataSource = courseDTO;
            DropDownListCourse.DataBind();

            // Add the coursename to the gridview
            GridViewDashboard.DataSource = courseDTO;
            GridViewDashboard.DataBind();

            // Renaming the header and hiding the course id column

            if (User.IsInRole("STUDENT"))
            {
                GridViewDashboard.HeaderRow.Cells[2].Text = "Course Name";
                GridViewDashboard.HeaderRow.Cells[1].Visible = false;
            }
            else
            {
                GridViewDashboard.HeaderRow.Cells[3].Text = "Course Name";
                GridViewDashboard.HeaderRow.Cells[2].Visible = false;
            }
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

        #endregion
        

        #region Protected Event methods
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("STUDENT"))
            {
                InitializeControls();
            }
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
        /// add user and the course to a table in the database
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddUserAndCourse_Click(object sender, EventArgs e)
        {
            WebSim.DTO.UserAndCourse userInCourse = new WebSim.DTO.UserAndCourse();
            WebSim.Business.UserBusiness addUserAndCourse = new WebSim.Business.UserBusiness();
            
            userInCourse.userName = DropDownListUser.SelectedValue.ToString();
            userInCourse.courseName = DropDownListCourse.SelectedValue.ToString();

            addUserAndCourse.AddUserToCourse(userInCourse);
        }

        /// <summary>
        /// Delete the course from the database
        /// </summary>
        /// <param name="sender">The link button is the sender object</param>
        /// <param name="e">The event argument for the link click</param>
        protected void DeleteCourse_Click(object sender, EventArgs e)
        {
            WebSim.DTO.CourseID courseid = new WebSim.DTO.CourseID();
            string courseID = ((LinkButton)sender).CommandArgument.ToString();

            courseid.courseid = courseID;

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
                    if (Roles.RoleExists(txt_RoleName.Text))
                        lblMessage.Text = "The role name is already present.";
                    else
                        Roles.CreateRole(txt_RoleName.Text.ToUpper().Trim());
                    txt_RoleName.Text = string.Empty;
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
            string roleName = DropDownRoleList.SelectedValue.ToString();
            string[] roles = Roles.GetRolesForUser(userName);
            try
            {
                foreach (string role in roles)
                {
                    usersInRole += 1;
                }
                if (usersInRole == 0)
                    Roles.AddUserToRole(userName, roleName);
                else
                    lblMessage.Text = "Any user cannot have 2 roles.";
            }
            catch (Exception)
            {
                lblMessage.Text = "The user is already in the role.";
            }
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
        #endregion

    }
}