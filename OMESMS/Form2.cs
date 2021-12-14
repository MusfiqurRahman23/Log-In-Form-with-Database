using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Reflection;



namespace OMESMS
{ 
    public partial class SignUp : Form {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\source\repos\OMESMS\DB1\sedb.mdf;Integrated Security=True;Connect Timeout=30");
    
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn f1 = new LogIn();
            f1.Show();
            f1.Tag = this;
            Hide();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO USERINFO VALUES ('" + textBoxName.Text.Trim() + "', '" + textBoxAddress.Text.Trim() + "', '" + textBoxemail.Text.Trim() + "', '" + textBoxPass.Text.Trim() + "' , '" + textBoxPhoneNumber.Text.Trim() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxemail.Text = "";
            textBoxPass.Text = "";
            textBoxPhoneNumber.Text = "";
            disp_data();
            MessageBox.Show("Insertion successful!");

        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from USERINFO";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            //dataGridView1.DataSource = dt;
            con.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxPass.PasswordChar == '*')
            {
                button1.BringToFront();
                textBoxPass.PasswordChar = '\0';
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text) == true)
            {
                textBoxName.Focus();
                errorProviderName.SetError(this.textBoxName, " Name can not be empty!");
            }
            else
            {
                errorProviderName.Clear();
            }
        }

        private void textBoxemail_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxemail.Text, pattern) == false)
            {
                textBoxemail.Focus();
                errorProviderEmail.SetError(this.textBoxemail, "Invalid Email");
            }
            else
            {
                errorProviderEmail.Clear();
            }
            if (string.IsNullOrEmpty(textBoxemail.Text) == true)
            {
                textBoxemail.Focus();
                errorProviderEmail2.SetError(this.textBoxemail, "Email can not be empty!");
            }
            else
            {
                errorProviderEmail2.Clear();
            }
        }
    }
}
