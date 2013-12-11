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
        /// Adds new course
        /// </summary>
        /// <param name="courseDetail">course name and course description</param>
        public void AddNewCourse(DTO.NewCourse courseDetail)
        {
            DAL.DataAccess course = new DAL.DataAccess();
            course.AddNewCourse(courseDetail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userCourse"></param>
        public void AddUserToCourse(DTO.UserToCourse userCourse)
        {
            DAL.DataAccess userToCourse = new DAL.DataAccess();
            userToCourse.AddUserToCourse(userCourse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<WebSim.DTO.CourseNameAndId> GetCourseName()
        {
            return new WebSim.DAL.DataAccess().GetAllCoursesName();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="delCourse"></param>
        public void RemoveCourse(DTO.CourseID delCourse)
        {
            WebSim.DAL.DataAccess deleteCourse = new DAL.DataAccess();
            deleteCourse.RemoveCourse(delCourse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtoCourse"></param>
        /// <returns></returns>
        public IList<WebSim.DTO.CourseDetail> GetCourseDetail(DTO.CourseID dtoCourse)
        {
            return new WebSim.DAL.DataAccess().GetCoursesDetail(dtoCourse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentid"></param>
        /// <returns></returns>
        public IList<WebSim.DTO.StudentDetail> GetStudentList(WebSim.DTO.StudentIdentification studentid)
        {
            return new WebSim.DAL.DataAccess().GetStudentList(studentid);
        }

        public IList<WebSim.DTO.StudentIdentification> GetUserByCourseId(WebSim.DTO.CourseID courseid)
        {
            return new WebSim.DAL.DataAccess().GetUserByCourse(courseid);
        }
    }
}
