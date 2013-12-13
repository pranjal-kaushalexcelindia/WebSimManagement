using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.Business
{
    /// <summary>
    /// Bussiness layer for the User related methods
    /// </summary>
    public class UserBusiness
    {
        /// <summary>
        /// Add user to the course
        /// </summary>
        /// <param name="userCourse">course name and course id</param>
        public void AddUserToCourse(DTO.UserAndCourse userCourse)
        {
            DAL.CourseDataAccess userToCourse = new DAL.CourseDataAccess();
            userToCourse.AddUserToCourse(userCourse);
        }
        
        /// <summary>
        /// Get the list of all the student
        /// </summary>
        /// <param name="courseid">user id</param>
        /// <returns>student name and student is</returns>
        public IList<WebSim.DTO.StudentDetail> GetStudentList(WebSim.DTO.CourseID courseid)
        {
            return new WebSim.DAL.UserDataAccess().GetStudentList(courseid);
        }
    }
}
