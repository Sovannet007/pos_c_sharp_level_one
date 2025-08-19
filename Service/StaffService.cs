using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace POS_LEVEL_01.Service
{
    public class StaffService : ConnectionHelper
    {

        //get all staff data
        public List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();

            string query = @"
                            SELECT sf.staff_id,
                                   sf.first_name,
                                   sf.last_name,
                                   sf.email,
                                   sf.phone,
                                   sf.active,
                                   sf.store_id,
                                   sf.manager_id,
                                   sm.first_name + ' ' + sm.last_name AS manager_name,
                                   st.store_name
                            FROM sales.staffs sf
                            LEFT JOIN sales.staffs sm ON sf.manager_id = sm.staff_id
                            LEFT JOIN sales.stores st ON sf.store_id = st.store_id;";
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Staff staff = new Staff();
                staff.staff_id = Convert.ToInt16(dr["staff_id"]);
                staff.first_name = dr["first_name"].ToString();
                staff.last_name = dr["last_name"].ToString();
                staff.email = dr["email"].ToString();
                staff.phone = dr["phone"].ToString();
                staff.active=dr["active"].ToString() == "1" ? "Active" : "Inactive";
                staff.store_name = dr["store_name"].ToString();
                staff.manager_name = dr["manager_name"].ToString();


                // Add IDs
                staff.store_id = dr["store_id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["store_id"]);
                staff.manager_id = dr["manager_id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["manager_id"]);
                staffs.Add(staff);
            }
            dr.Close();
            CloseConnection();
            return staffs;
        }

        //get one staff data
        public List<Brand> GetStaff(int id)
        {
            List<Brand> brands = new List<Brand>();

            string query = "SELECT * FROM sales.staffs WHERE brand_id=@brand_id";
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.AddWithValue("@brand_id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Brand brand = new Brand();
                brand.brand_name = dr["brand_name"].ToString();
                brands.Add(brand);
            }
            dr.Close();
            CloseConnection();
            return brands;
        }


        // insert staff data
        public bool Insert(Staff request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_INSERT_STAFF";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@first_name ", request.first_name);
            cmd.Parameters.AddWithValue("@last_name ", request.last_name);
            cmd.Parameters.AddWithValue("@email ", request.email);
            cmd.Parameters.AddWithValue("@phone ", request.phone);
            cmd.Parameters.AddWithValue("@active ", Convert.ToInt16(request.active));
            cmd.Parameters.AddWithValue("@store_id ", request.store_id);
            cmd.Parameters.AddWithValue("@manager_id  ", request.manager_id);
            cmd.Transaction = SqlTransactionHelper.transaction;

            try
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.ToString());
            }
            return result;
        }

        //update staff data
        public bool Update(Staff request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_UPDATE_STAFF";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@staff_id ", request.staff_id);
            cmd.Parameters.AddWithValue("@first_name ", request.first_name);
            cmd.Parameters.AddWithValue("@last_name ", request.last_name);
            cmd.Parameters.AddWithValue("@email ", request.email);
            cmd.Parameters.AddWithValue("@phone ", request.phone);
            cmd.Parameters.AddWithValue("@active ",Convert.ToInt16(request.active));
            // ✅ Store ID from ComboBox
            cmd.Parameters.AddWithValue("@store_id", Convert.ToInt32(request.store_id));
            // ✅ Manager ID from ComboBox
            cmd.Parameters.AddWithValue("@manager_id", Convert.ToInt32(request.manager_id));
            cmd.Transaction = SqlTransactionHelper.transaction;

            try
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.ToString());
            }
            return result;
        }

        //delete staff
        public bool Delete(Staff request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_DELETE_STAFF";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@staff_id", request.staff_id);
            cmd.Transaction = SqlTransactionHelper.transaction;

            try
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage(ex.ToString());
            }
            return result;
        }
    }
}
