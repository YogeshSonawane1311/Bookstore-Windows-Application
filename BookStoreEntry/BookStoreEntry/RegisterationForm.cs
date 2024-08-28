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
namespace BookStoreEntry
{
    public partial class RegisterationForm : Form
    {
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BKK8JKE\\SQLEXPRESS;Initial Catalog=bookstore;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public RegisterationForm()
        {
            InitializeComponent();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (!Autheticate())
            {
                MessageBox.Show("Do not keep any text box blank");
                return;
            }
            string query = "INSERT INTO admininfo VALUES(@username, @passcode,@_name,@gender,@dob)";
            conn.Open();
            scmd = new SqlCommand(query,conn);

            //adding parameter
            scmd.Parameters.Add("@username",SqlDbType.VarChar);
            scmd.Parameters["@username"].Value =txtUsername.Text;

            scmd.Parameters.Add("@passcode", SqlDbType.VarChar);
            scmd.Parameters["@passcode"].Value=txtpassword.Text;

            
            scmd.Parameters.Add("@_name", SqlDbType.VarChar);
            scmd.Parameters["@_name"].Value = txtname.Text;

            
            scmd.Parameters.Add("@gender", SqlDbType.VarChar);
            scmd.Parameters["@gender"].Value=gender.Text;
            scmd.Parameters.Add("@dob", SqlDbType.Date);
            scmd.Parameters["@dob"].Value=dateTimePicker.Text;
            
            scmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Registeration Successfully");
        }
        bool Autheticate()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text)||
                string.IsNullOrWhiteSpace(txtname.Text))
                return false;
            else return true;
        }

        private void RegisterationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
