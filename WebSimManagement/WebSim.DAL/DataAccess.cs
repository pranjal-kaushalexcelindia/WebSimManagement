using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSim.DAL
{
    public class DataAccess
    {
        // Static conneection string
        private static string connectionString = ConfigurationManager.ConnectionStrings["Websim_Database_ConnectionString"].ConnectionString;
       
        /// <summary>
        /// Add new course to the database
        /// </summary>
        /// <param name="courseDetail">CourseName and the CourseDescription</param>
        public void AddNewCourse(DTO.NewCourse courseDetail)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "InsertCourseDetails";
                    command.Parameters.AddWithValue("@coursename", courseDetail.coursename);
                    command.Parameters.AddWithValue("@courseDesc", courseDetail.coursedescription);
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add users in courses
        /// </summary>
        /// <param name="userCourse">userid and courseid</param>
        public void AddUserToCourse(DTO.UserToCourse userCourse)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                /////////////////////// first check the userid and course id are present in the database then add values to the database
                using (var command = new SqlCommand("INSERT INTO User_Course_Mapping(UserId,CourseId) VALUES(@userId,@courseId) ", connection))
                {
                    command.Parameters.AddWithValue("@userId",userCourse.userId);
                    command.Parameters.AddWithValue("@courseId", userCourse.courseId);
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
                    command.CommandText = "GetCoursesName";

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
        /// This will remove the course from the database
        /// </summary>
        /// <param name="courseid">Course name</param>
        public void RemoveCourse(DTO.CourseID courseid)
        {
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteCourse";
                    command.Parameters.AddWithValue("@courseid", courseid);
                    command.ExecuteNonQuery();
                }
            }
        }

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

        /// <summary>
        /// Gives the list of all student
        /// </summary>
        /// <param name="studentid">string format student id</param>
        /// <returns></returns>
        public IList<WebSim.DTO.StudentDetail> GetStudentList(DTO.StudentIdentification studentid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand studentNameCommand = new SqlCommand("", connection))
                {
                    studentNameCommand.CommandType = CommandType.StoredProcedure;

                    /// Create a SP that take student id as userID and returns the username,userId
                    studentNameCommand.CommandText = "SPNAME";

                    studentNameCommand.Parameters.AddWithValue("VALUE", studentid.studentId);

                    var reader = studentNameCommand.ExecuteReader();

                    List<WebSim.DTO.StudentDetail> studName = new List<DTO.StudentDetail>();

                    WebSim.DTO.StudentDetail dtostudentId;
                    while (reader.Read())
                    {
                        dtostudentId = new WebSim.DTO.StudentDetail();
                        dtostudentId.studentId = reader["UserId"].ToString();
                        dtostudentId.name = reader["UserName"].ToString();

                        studName.Add(dtostudentId);
                    }
                    return studName;
                }
            }
        }

        /// <summary>
        /// Get userid by giving the courseid as input
        /// </summary>
        /// <param name="courseid">courseid</param>
        /// <returns>return the userid</returns>
        public IList<WebSim.DTO.StudentIdentification> GetUserByCourse(WebSim.DTO.CourseID courseid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetUserByCourse";

                    command.Parameters.AddWithValue("@courseid", courseid.courseid);

                    var reader = command.ExecuteReader();

                    List<WebSim.DTO.StudentIdentification> studentname = new List<WebSim.DTO.StudentIdentification>();
                   
                    WebSim.DTO.StudentIdentification dtoStudent;

                    while (reader.Read())
                    {
                        dtoStudent = new DTO.StudentIdentification();
                        dtoStudent.studentId = reader["UserId"].ToString();

                        studentname.Add(dtoStudent);
                    }
                    return studentname;
                }
            }
        }
    }
}
