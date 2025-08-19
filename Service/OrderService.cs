using POS_LEVEL_01.Helper;
using POS_LEVEL_01.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace POS_LEVEL_01.Service
{
    public class OrderService : ConnectionHelper
    {
        
        
        //insert
        public bool InsertOrder(Order req)
        {
            bool result = false;
            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_INSERT_ORDER";
            cmd.Parameters.AddWithValue("@customer_id",req.customer_id);
            cmd.Parameters.AddWithValue("@required_date",req.required_date);
            cmd.Parameters.AddWithValue("@shipped_date",req.shipped_date);
            cmd.Parameters.AddWithValue("@store_id",req.store_id);
            cmd.Parameters.AddWithValue("@staff_id",UserService.LogonUser.staff_id);
            cmd.Parameters.Add("@order_id",SqlDbType.Int).Direction = ParameterDirection.Output; // output order id back for order_item use
            cmd.Transaction = SqlTransactionHelper.transaction;

            try
            {
                cmd.ExecuteNonQuery();
                req.order_id = Convert.ToInt16(cmd.Parameters["@order_id"].Value);
                result = true;
            }
            catch (Exception ex) {
                MessageHelper.ErrorMessage($"Error {ex.ToString()}");
            }
            return result;
        }
    }
}
