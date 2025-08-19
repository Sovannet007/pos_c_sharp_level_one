using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_LEVEL_01.Helper
{
    public class MessageHelper
    {

        // success message function
        // use static keyword for call class direct by not create object
        public static void SuccessMessage (string message="Success")
        {
            MessageBox.Show(message,"System",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        // error message function
        public static void ErrorMessage(string message = "Error")
        {
            MessageBox.Show(message, "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // warning message function
        public static void WarningMessage(string message = "Warning")
        {
            MessageBox.Show(message, "System", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // confirm message function
        public static bool ConfirmMessage(string message = "Are you sure?")
        {
            if(MessageBox.Show(message, "System", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) 
                return true;
            
            return false;
        }

    }
}
