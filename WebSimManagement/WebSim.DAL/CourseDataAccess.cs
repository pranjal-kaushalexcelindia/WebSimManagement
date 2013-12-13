using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.DAL
{
    /// <summary>
    /// Connects the course related methods with the database
    /// </summary>
    public class CourseDataAccess:BaseDataAccess
    {
        /// <summary>
        /// Add new course to the database
        /// </summary>
        /// <param name="courseDetail">CourseName and the CourseDescription</param>
        public void AddNewCourse(DTO.NewCourse courseDetail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("InsertCourseDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@coursename", courseDetail.coursename);
                    command.Parameters.AddWithValue("@courseDesc", courseDetail.coursedescription);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add users to the course
        /// </summary>
        /// <param name="userCourse">userid and courseid</param>
        public void AddUserToCourse(DTO.UserAndCourse userCourse)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUserToCourse";
                    command.Parameters.AddWithValue("@username", userCourse.userName);
                    command.Parameters.AddWithValue("@coursename", userCourse.courseName);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get the list of all the courses.
        /// </summary>
        /// <returns>List of courses</returns>
        public IList<DTO.CourseNameAndId> GetAllCoursesName()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetCourseName";

                    var reader = command.ExecuteReader();
                    List<DTO.CourseNameAndId> courseList = new List<DTO.CourseNameAndId>();

                    DTO.CourseNameAndId courseDTO;

                    while (reader.Read())
                    {
                        courseDTO = new DTO.CourseNameAndId();
                        courseDTO.courseid = reader["CourseId"].ToString();
                        courseDTO.coursename = reader["CourseName"].ToString();

                        courseList.Add(courseDTO);
                    }
                    return courseList;
                }
            }
        }

        /// <summary>
        /// Remove the course from the database
        /// </summary>
        /// <param name="courseid">Course name</param>
        public void RemoveCourse(DTO.CourseID courseid)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteCourse";
                    command.Parameters.AddWithValue("@courseid", courseid.courseid);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Get the coursename and the course description
        /// </summary>
        /// <param name="dtoCourse">courseid</param>
        /// <returns>course name and course description</returns>
        public IList<DTO.CourseDetail> GetCoursesDetail(DTO.CourseID dtoCourse)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand courseDetailCommand = new SqlCommand("", connection))
                {
                    courseDetailCommand.CommandType = CommandType.StoredProcedure;
                    courseDetailCommand.CommandText = "GetCourses";

                    courseDetailCommand.Parameters.AddWithValue("@courseid", dtoCourse.courseid);

                    var reader = courseDetailCommand.ExecuteReader();

                    List<WebSim.DTO.CourseDetail> dtoDetailList = new List<DTO.CourseDetail>();

                    WebSim.DTO.CourseDetail dtocourseDetail;
                    while (reader.Read())
                    {
                        dtocourseDetail = new WebSim.DTO.CourseDetail();
                        dtocourseDetail.courseid = reader["CourseId"].ToString();
                        dtocourseDetail.coursename = reader["CourseName"].ToString();
                        dtocourseDetail.coursedescription = reader["CourseDescription"].ToString();

                        dtoDetailList.Add(dtocourseDetail);
                    }
                    return dtoDetailList;
                }
            }
        }
    }
}
