using POS_LEVEL_01.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS_LEVEL_01.Helper;

namespace POS_LEVEL_01.Service
{
    public class UserService
    {

        public static User LogonUser = new User();

        public static bool Login(User user)
        {
            bool result = false;

            string query = "select * from tbl_user where username=@username and password=@pwd and is_active=1";
            SqlCommand cmd = new SqlCommand(query, ConnectionHelper.GetConnection());

            cmd.Parameters.AddWithValue("@username",user.username);
            cmd.Parameters.AddWithValue("@pwd", user.password);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                LogonUser.id = Convert.ToInt16(dr["id"]);
                LogonUser.username = dr["username"].ToString();
                LogonUser.password = dr["password"].ToString();
                LogonUser.full_name = dr["fullname"].ToString();
                LogonUser.is_active = Convert.ToBoolean(dr["is_active"]);
                LogonUser.staff_id = Convert.ToInt16(dr["staff_id"]);
                result = true;
            }
            dr.Close();
            return result;
        }
    }
}
