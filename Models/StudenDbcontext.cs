using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CrudAppUsingADO.Models
{
    public class StudenDbcontext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<Student> GetStudents()
        {
            List<Student> StudentList = new List<Student>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_Get_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Student std = new Student();
                std.id = Convert.ToInt32( dr.GetValue(0).ToString());
                std.Name = dr.GetValue(1).ToString();
                std.Gender = dr.GetValue(2).ToString();
                std.Age =Convert.ToInt32( dr.GetValue(3).ToString());
                std.Salary =Convert.ToInt32( dr.GetValue(4).ToString());
                std.City = dr.GetValue(5).ToString();
                StudentList.Add(std);

            }


            return StudentList;
        }
        public bool AddStudent(Student std)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_Add_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name",std.Name);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Age", std.Age);
            cmd.Parameters.AddWithValue("@Salary", std.Salary);
            cmd.Parameters.AddWithValue("@City", std.City);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if(i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStudent(Student std)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_Update_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", std.id);
            cmd.Parameters.AddWithValue("@Name", std.Name);
            cmd.Parameters.AddWithValue("@Gender", std.Gender);
            cmd.Parameters.AddWithValue("@Age", std.Age);
            cmd.Parameters.AddWithValue("@Salary", std.Salary);
            cmd.Parameters.AddWithValue("@City", std.City);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool DeleteStudent(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("sp_Delete_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}