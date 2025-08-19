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
    public class CategoryServie : ConnectionHelper
    {
        string table = "production.categories";

        //get all categories data
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            string query = "SELECT * FROM " + table;
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Category category = new Category();
                category.category_id = Convert.ToInt16(dr["category_id"]);
                category.category_name = dr["category_name"].ToString();
                categories.Add(category);
            }
            dr.Close();
            CloseConnection();
            return categories;
        }

        //get one category data
        public List<Category> GetCategory(int id)
        {
            List<Category> categories = new List<Category>();

            string query = "SELECT * FROM" + table + "WHERE category_id=@category_id";
            SqlCommand cmd = new SqlCommand(query, GetConnection());
            cmd.Parameters.AddWithValue("@category_id", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Category category = new Category();
                category.category_name = dr["category_name"].ToString();
                categories.Add(category);
            }
            dr.Close();
            CloseConnection();
            return categories;
        }


        // insert category data
        public bool Insert(Category req)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "insert into production.categories(category_name) values(@category_name)";
            cmd.Parameters.AddWithValue("@category_name", req.category_name);
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

        //update category data
        public bool Update(Category req)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "update production.categories set category_name=@category_name where category_id=@category_id"; 
            cmd.Parameters.AddWithValue("@category_id", req.category_id);
            cmd.Parameters.AddWithValue("@category_name", req.category_name);
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

        //delete category
        public bool Delete(Category req)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "delete from production.categories where category_id=@category_id";
            cmd.Parameters.AddWithValue("@category_id", req.category_id);
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
