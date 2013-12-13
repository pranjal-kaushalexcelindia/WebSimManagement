using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.Business
{
    /// <summary>
    /// Bussiness layer for the Course related methods
    /// </summary>
    public class CourseBusiness
    {
        /// <summary>
        /// Adds new course to the database
        /// </summary>
        /// <param name="courseDetail">course name and course description</param>
        public void AddNewCourse(DTO.NewCourse courseDetail)
        {
            DAL.CourseDataAccess course = new DAL.CourseDataAccess();
            course.AddNewCourse(courseDetail);
        }

        /// <summary>
        /// Give the name and id of the course
        /// </summary>
        /// <returns>course name and course id</returns>
        public IList<WebSim.DTO.CourseNameAndId> GetCourseName()
        {
            return new WebSim.DAL.CourseDataAccess().GetAllCoursesName();
        }

        /// <summary>
        /// Remove course from the database
        /// </summary>
        /// <param name="delCourse">contains the course id</param>
        public void RemoveCourse(DTO.CourseID delCourse)
        {
            WebSim.DAL.CourseDataAccess deleteCourse = new DAL.CourseDataAccess();
            deleteCourse.RemoveCourse(delCourse);
        }

        /// <summary>
        /// Get details of the course
        /// </summary>
        /// <param name="dtoCourse">course id</param>
        /// <returns>course name ,course description</returns>
        public IList<WebSim.DTO.CourseDetail> GetCourseDetail(DTO.CourseID dtoCourse)
        {
            return new WebSim.DAL.CourseDataAccess().GetCoursesDetail(dtoCourse);
        }

        /// <summary>
        /// Add users in the course list
        /// </summary>
        /// <param name="userNamecourseId">username and courseid</param>
        public void AddUserInCourse(DTO.UserInCourse userNamecourseId)
        {
            DAL.UserDataAccess addUserToCourse = new DAL.UserDataAccess();
            addUserToCourse.AddUserInCourse(userNamecourseId);
        }
    }
}
