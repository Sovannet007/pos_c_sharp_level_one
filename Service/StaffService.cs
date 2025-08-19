using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS_LEVEL_01.Service
{
    public class StaffService : ConnectionHelper
    {

        //get all staff data
        public List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();

            string query = "SELECT " +
                            "sf.*," +
                            "sm.first_name +' '+sm.last_name AS manager_name ," +
                            "st.store_name " +
                            "FROM sales.staffs sf " +
                            "LEFT JOIN sales.staffs sm ON sf.manager_id = sm.staff_id " +
                            "LEFT JOIN sales.stores st ON sf.store_id = st.store_id;";
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
                staffs.Add(staff);
            }
            dr.Close();
            CloseConnection();
            return staffs;
        }

        //get one brand data
        public List<Brand> GetBrand(int id)
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


        // insert brand data
        public bool Insert(Brand request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_INSERT_BRAND";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@brand_name", request.brand_name);
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

        //update brand data
        public bool Update(Brand request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_UPDATE_BRAND";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@brand_id", request.brand_id);
            cmd.Parameters.AddWithValue("@brand_name", request.brand_name);
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

        //delete brand
        public bool Delete(Brand request)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_DELETE_BRAND";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@brand_id", request.brand_id);
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
