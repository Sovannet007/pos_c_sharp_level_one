using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_LEVEL_01.Helper
{
    public class BindComboBox
    {
        public static void BindData(ComboBox comboBox,String query)
        {
            SqlCommand cmd = new SqlCommand(query,ConnectionHelper.GetConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox.DataSource = dt;
            comboBox.ValueMember = dt.Columns[0].ColumnName;
            comboBox.DisplayMember = dt.Columns[1].ColumnName;
        }
    }
}
