using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.Business
{
    public class Business
    {
        /// <summary>
        /// Adds new course to the database
        /// </summary>
        /// <param name="courseDetail">course name and course description</param>
        public void AddNewCourse(DTO.NewCourse courseDetail)
        {
            DAL.DataAccess course = new DAL.DataAccess();
            course.AddNewCourse(courseDetail);
        }

        /// <summary>
        /// Add user to the course
        /// </summary>
        /// <param name="userCourse">course name and course id</param>
        public void AddUserToCourse(DTO.UserAndCourse userCourse)
        {
            DAL.DataAccess userToCourse = new DAL.DataAccess();
            userToCourse.AddUserToCourse(userCourse);
        }

        /// <summary>
        /// Give the name and id of the course
        /// </summary>
        /// <returns>course name and course id</returns>
        public IList<WebSim.DTO.CourseNameAndId> GetCourseName()
        {
            return new WebSim.DAL.DataAccess().GetAllCoursesName();
        }

        /// <summary>
        /// Remove course from the database
        /// </summary>
        /// <param name="delCourse">contains the course id</param>
        public void RemoveCourse(DTO.CourseID delCourse)
        {
            WebSim.DAL.DataAccess deleteCourse = new DAL.DataAccess();
            deleteCourse.RemoveCourse(delCourse);
        }

        /// <summary>
        /// Get details of the course
        /// </summary>
        /// <param name="dtoCourse">course id</param>
        /// <returns>course name ,course description</returns>
        public IList<WebSim.DTO.CourseDetail> GetCourseDetail(DTO.CourseID dtoCourse)
        {
            return new WebSim.DAL.DataAccess().GetCoursesDetail(dtoCourse);
        }

        /// <summary>
        /// Get the list of all the student
        /// </summary>
        /// <param name="courseid">user id</param>
        /// <returns>student name and student is</returns>
        public IList<WebSim.DTO.StudentDetail> GetStudentList(WebSim.DTO.CourseID courseid)
        {
            return new WebSim.DAL.DataAccess().GetStudentList(courseid);
        }

        /// <summary>
        /// Add users in the course list
        /// </summary>
        /// <param name="userNamecourseId">username and courseid</param>
        public void AddUserInCourse(DTO.UserInCourse userNamecourseId)
        {
            DAL.DataAccess addUserToCourse = new DAL.DataAccess();
            addUserToCourse.AddUserInCourse(userNamecourseId);
        }
    }
}
