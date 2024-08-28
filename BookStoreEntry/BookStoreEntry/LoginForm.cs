using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookStoreEntry
{
    public partial class LoginForm : Form
    {
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BKK8JKE\\SQLEXPRESS;Initial Catalog=bookstore;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            RegisterationForm register = new RegisterationForm();
            register.ShowDialog();
            this.Close();
        }

        
        bool Autheticate()
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))
                
                return false;
            else return true;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (!Autheticate())
            {
                MessageBox.Show("Do not keep any text box blank");
                return;
            }

            // Assuming authentication is done here
            string query = "SELECT COUNT(1) FROM admininfo WHERE username=@username AND passcode=@passcode";
            conn.Open();
            scmd = new SqlCommand(query, conn);
            scmd.Parameters.AddWithValue("@username", txtusername.Text);
            scmd.Parameters.AddWithValue("@passcode", txtpassword.Text);

            int count = Convert.ToInt32(scmd.ExecuteScalar());
            conn.Close();

            if (count == 1)
            {
                // Open Catalog Form after successful login
                CatalogForm catalog = new CatalogForm();
                catalog.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
