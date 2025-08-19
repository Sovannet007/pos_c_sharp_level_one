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
    public class OrderItemService : ConnectionHelper
    {

        //insert 
        public bool InsertOrder(OrderItem req)
        {
            bool result = false;

            SqlCommand cmd = GetConnection().CreateCommand();
            cmd.CommandText = "SP_INSERT_ORDER_ITEM";
            cmd.Parameters.AddWithValue("@order_id",req.order_id);
            cmd.Parameters.AddWithValue("@product_id",req.order_id);
            cmd.Parameters.AddWithValue("@quantity",req.quantity);
            cmd.Parameters.AddWithValue("@list_price",req.list_price);
            cmd.Parameters.AddWithValue("@discount",req.discount);

            try
            {
                cmd.ExecuteNonQuery();
                MessageHelper.SuccessMessage("Order item creaded!");
            }
            catch (Exception ex)
            {
                MessageHelper.ErrorMessage($"Error {ex.ToString()}");
            }

            return result;
        }
    }
}
