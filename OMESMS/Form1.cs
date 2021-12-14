using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OMESMS
{
    public partial class LogIn : Form

    {
      
        
        public LogIn()
        {
           
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
           
             SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\OMESMS\DB1\sedb.mdf;Integrated Security=True;Connect Timeout=30");
             string query = "select * from USERINFO where USEREMAIL = '" + textBoxMail.Text.Trim() + "' and PASS = '" + textBoxPass.Text.Trim() + "'";

             SqlDataAdapter sda = new SqlDataAdapter(query, con);

             DataTable dtbl = new DataTable();

             sda.Fill(dtbl);

             if (dtbl.Rows.Count == 1)
             {
                 Form3 a = new Form3();
                 this.Hide();
                 a.Show();
             }

             else
             {
                MessageBox.Show("Invalid username or password!");
               
             }
            
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            SignUp s1 = new SignUp();
            s1.Show();
            s1.Tag = this;
            Hide();

        }
    }
}
