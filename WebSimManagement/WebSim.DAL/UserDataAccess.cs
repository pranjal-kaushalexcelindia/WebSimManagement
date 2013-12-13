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
    /// <summary>
    /// Connect the user related methods to the database
    /// </summary>
    public class UserDataAccess:BaseDataAccess
    {

        /// <summary>
        /// Gives the list of all student
        /// </summary>
        /// <param name="courseid">courseid</param>
        /// <returns>student name and student id</returns>
        public IList<WebSim.DTO.StudentDetail> GetStudentList(DTO.CourseID courseid)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand studentNameCommand = new SqlCommand("", connection))
                {
                    studentNameCommand.CommandType = CommandType.StoredProcedure;

                    studentNameCommand.CommandText = "UserNotInCourse";

                    studentNameCommand.Parameters.AddWithValue("@courseid", courseid.courseid);

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
        /// Add user in the course
        /// </summary>
        /// <param name="userNamecourseId">username and courseid</param>
        public void AddUserInCourse(DTO.UserInCourse userNamecourseId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "AddUsersInCourse";

                    command.Parameters.AddWithValue("@username", userNamecourseId.userName);
                    command.Parameters.AddWithValue("@courseid", userNamecourseId.courseid);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
