using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSim.Business;

namespace WebSimManagement
{
    public partial class NewCourse : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This will add new course to the database.
        /// </summary>
        /// <param name="sender">The button is the sender object</param>
        /// <param name="e">The event argument for the button click event</param>
        protected void AddNewCourse_Click(object sender, EventArgs e)
        {
            WebSim.DTO.NewCourse courseData = new WebSim.DTO.NewCourse();
            UserBusiness course = new UserBusiness();

            courseData.coursename = txtCourseName.Text;
            courseData.coursedescription = txtCourseDetail.Text;
            
            course.AddNewCourse(courseData);

            txtCourseName.Text = string.Empty;
            txtCourseDetail.Text = string.Empty;
            Response.Redirect("Dashboard.aspx");
        }
    }
}