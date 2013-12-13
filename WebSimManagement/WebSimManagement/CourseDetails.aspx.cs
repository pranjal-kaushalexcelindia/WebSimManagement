using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSimManagement
{
    public partial class CourseDetails : System.Web.UI.Page
    {
        private string queryString;

        protected void Page_Load(object sender, EventArgs e)
        {
            queryString = Request.QueryString["Course"];
            if (User.IsInRole("STUDENT"))
            {
                UserIsStudent();
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    ListView_Student();
                }
            }
            GridView_CourseList();   
        }

        private void UserIsStudent()
        {
            lblMessageGridView.Visible = false;
            lblMessage.Visible = false;
            lbl_StudentList.Visible = false;
            lbl_AddStudentList.Visible = false;
            StudentList.Visible = false;
            btn_AddStudent.Visible = false;
            btn_RemoveStudent.Visible = false;
            SelectedStudentList.Visible = false;
            btn_AddStudentList.Visible = false;
        }

        /// <summary>
        /// Sets the student list for the subject
        /// </summary>
        private void ListView_Student()
        {
            WebSim.Business.UserBusiness userBuiCourse = new WebSim.Business.UserBusiness();

            WebSim.DTO.CourseID courseid = new WebSim.DTO.CourseID();
            courseid.courseid = queryString;
            IList<WebSim.DTO.StudentDetail> studDetail = userBuiCourse.GetStudentList(courseid);

            // adding student name to the list
            foreach (var item in studDetail)
            {


                StudentList.Items.Add(new ListItem(item.userName,item.studentId.ToString()));


            }
        }

        /// <summary>
        /// Get the GridView List of the courses details using the query string
        /// </summary>
        private void GridView_CourseList()
        {
            try
            {
                WebSim.DTO.CourseID dtoCourse = new WebSim.DTO.CourseID();
                WebSim.Business.CourseBusiness courseBuiCourse = new WebSim.Business.CourseBusiness();

                dtoCourse.courseid = queryString;

                IList<WebSim.DTO.CourseDetail> courseDetails = courseBuiCourse.GetCourseDetail(dtoCourse);

                GridViewCourseDetail.DataSource = courseDetails;
                GridViewCourseDetail.DataBind();
                //TODO: move the UI strings to resource file.
                //Why??
                GridViewCourseDetail.HeaderRow.Cells[1].Text = "Course Name";
                GridViewCourseDetail.HeaderRow.Cells[2].Text = "Course Description";
                GridViewCourseDetail.HeaderRow.Cells[0].Visible = false;
            }
            catch (NullReferenceException)
            {
                lblMessageGridView.Text = "Invalid course.";
            }
        }

        /// <summary>
        /// This will add the selected student to the Add Student List
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddStudentToList_click(object sender, EventArgs e)
        {
              try
                {

                  //TODO: Study about controls viewstate

                    // When no student is selected from the list
                    if (StudentList.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Select correct list.";
                    }
                    else
                    {
                        // Adding the selected student to another list
                        foreach (ListItem list in StudentList.Items)
                        {
                            if (list.Selected)
                            {
                                SelectedStudentList.Items.Add(list);
                            }
                        }

                        // Removing the selected student from the Student List
                        for (int count = 0; count <= StudentList.Items.Count; count++)
                        {
                            if (StudentList.SelectedItem.Selected)
                                StudentList.Items.Remove(StudentList.SelectedItem);
                        }
                    }
                }
                catch (NullReferenceException)
                {
                    lblMessage.Text = "Select a name.";
                }
            
        }

        /// <summary>
        /// This will remove the selected student from the Add Student List and add it back to the Student List
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void RemoveSelectedStudent_click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    // When no student is selected
                    if (SelectedStudentList.SelectedIndex == -1)
                    {
                        lblMessage.Text = "Select correct list.";
                    }
                    else
                    {
                        // Adds the selected student to the Student List
                        foreach (ListItem list in SelectedStudentList.Items)
                        {
                            if (list.Selected)
                            {
                                StudentList.Items.Add(list);
                            }
                        }
                        
                        //TODO: how to run fxcop along with your vs project.

                        // Removes the selected student from the Add Student List
                        for (int count = 0; count <= SelectedStudentList.Items.Count; count++)
                        {
                            if (SelectedStudentList.SelectedItem.Selected)
                                SelectedStudentList.Items.Remove(SelectedStudentList.SelectedItem);
                        }
                    }
                }
                catch (NullReferenceException ex)
                {

                    //Add logging of exception

                    lblMessage.Text = "";
                }
            }
        }

        /// <summary>
        /// Adds the list of stundent to the database.
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddStudentListToDB(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // If the user travels through the url to this page
                if (queryString == null)
                {
                    lblMessage.Text = "Invalid course.";
                }
                else
                {
                    // If no student is selected.
                    if (SelectedStudentList.SelectedValue == "")
                    {
                        lblMessage.Text = "Select any student";
                    }
                    else
                    {
                        WebSim.DTO.UserInCourse userNamecourseId = new WebSim.DTO.UserInCourse();
                        WebSim.Business.UserBusiness courseBuiCourse = new WebSim.Business.UserBusiness();

                        userNamecourseId.userName = SelectedStudentList.SelectedValue.ToString();
                        userNamecourseId.courseid = queryString;

                        courseBuiCourse.AddUserInCourse(userNamecourseId);
                    }

                }
            }
        }

        protected void GridViewCourseDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        /// <summary>
        /// Removing the authentication of the user
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void LogOutCourseDetail_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Response.Cookies["Teacher"].Expires.AddDays(-1);
            Response.Redirect("UserLogin.aspx");
        }
    }
}