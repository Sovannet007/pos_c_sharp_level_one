using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_LEVEL_01.Service
{
    public class BrandService : ConnectionHelper
    {
        string table = "production.brands";
        
        //get all brands data
        public List<Brand> GetBrands()
        {
            List<Brand> brands = new List<Brand>();
            
            string query = "SELECT * FROM "+table; 
            SqlCommand cmd = new SqlCommand(query,GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read()) {
                Brand brand = new Brand(); 
                brand.brand_id = Convert.ToInt16(dr["brand_id"]);
                brand.brand_name = dr["brand_name"].ToString();
                brands.Add(brand); 
            }
            dr.Close();
            CloseConnection();
            return brands;
        }

        //get one brand data
        public List<Brand> GetBrand(int id)
        {
            List<Brand> brands = new List<Brand>();

            string query = "SELECT * FROM" + table +"WHERE brand_id=@brand_id";
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
        public bool Insert(Brand request) {
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
