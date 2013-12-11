﻿using System;
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
        WebSim.Business.Business userBuiCourse = new WebSim.Business.Business();
        private Guid UserId;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridViewCourseList();

            StudentListView();
        }

        /// <summary>
        /// Sets the student list for the subject
        /// </summary>
        private void StudentListView()
        {
            MembershipUserCollection user = Membership.GetAllUsers();
            StudentList.DataSourceObject = user;
            StudentList.DataBind();

            //WebSim.DTO.CourseID dtocourseid = new WebSim.DTO.CourseID();

            //dtocourseid.courseid = Request.QueryString["Course"];
            //IList<WebSim.DTO.StudentIdentification> studentID = userBuiCourse.GetUserByCourseId(dtocourseid);
           
            //foreach (var item in studentID)
            //{
            //    UserId = Guid.Parse(studentID.ToString());
            //    MembershipUser userid = Membership.GetUser(UserId);
            //    StudentList.DataSource = userid;
            //    StudentList.DataBind();
            //}
        }

        /// <summary>
        /// Get the GridView List of the courses details using the query string
        /// </summary>
        private void GridViewCourseList()
        {
            WebSim.DTO.CourseID dtoCourse = new WebSim.DTO.CourseID();
            dtoCourse.courseid = Request.QueryString["Course"];
            IList<WebSim.DTO.CourseDetail> courseDetails = userBuiCourse.GetCourseDetail(dtoCourse);
            GridViewCourseDetail.DataSource = courseDetails;
            GridViewCourseDetail.DataBind();

            GridViewCourseDetail.HeaderRow.Cells[1].Text = "Course Name";
            GridViewCourseDetail.HeaderRow.Cells[2].Text = "Course Description";
            GridViewCourseDetail.HeaderRow.Cells[0].Visible = false;
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
                // When no student is selected
                if (StudentList.SelectedIndex == -1)
                {
                    lblMessage.Text = "Select correct student.";
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

            try
            {
                // When no student is selected
                if (SelectedStudentList.SelectedIndex == -1)
                {
                    lblMessage.Text = "Select correct student.";
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

                    // Removes the selected student from the Add Student List
                    for (int count = 0; count <= SelectedStudentList.Items.Count; count++)
                    {
                        if(SelectedStudentList.SelectedItem.Selected)
                        SelectedStudentList.Items.Remove(SelectedStudentList.SelectedItem);
                    }
                }
            }
            catch (NullReferenceException)
            {
                lblMessage.Text = "Select a student.";
            }

        }

        /// <summary>
        /// Adds the list of stundent to the database.
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddStudentListToDB(object sender, EventArgs e)
        {
            WebSim.DTO.UserToCourse userToCourse = new WebSim.DTO.UserToCourse();

            userToCourse.userId = SelectedStudentList.Items.ToString();
            
           // userToCourse.courseId = 

            userBuiCourse.AddUserToCourse(userToCourse);
        }

        protected void GridViewCourseDetail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
            }
        }
    }
}