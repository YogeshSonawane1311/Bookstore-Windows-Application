using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookStoreEntry
{
    public partial class CatalogForm : Form
    {
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-BKK8JKE\\SQLEXPRESS;Initial Catalog=bookstore;Integrated Security=True;Encrypt=False");
        static SqlCommand scmd;
        static SqlDataAdapter sda;
        static DataTable dt;

        public CatalogForm()
        {
            InitializeComponent();
        }

        private void CatalogForm_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            string query = "SELECT * FROM Books";
            sda = new SqlDataAdapter(query, conn);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridViewBooks.DataSource = dt;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Books (Title, Author, Genre, Price, PublicationDate) VALUES (@Title, @Author, @Genre, @Price, @PublicationDate)";
            conn.Open();
            scmd = new SqlCommand(query, conn);

            // Adding parameters
            scmd.Parameters.AddWithValue("@Title", txtTitle.Text);
            scmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
            scmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
            scmd.Parameters.AddWithValue("@Price", nudPrice.Value);
            scmd.Parameters.AddWithValue("@PublicationDate", dtpPublicationDate.Value);

            scmd.ExecuteNonQuery();
            conn.Close();

            LoadBooks();
        }

        private void btnUpdateBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["ID"].Value);
                string query = "UPDATE Books SET Title=@Title, Author=@Author, Genre=@Genre, Price=@Price, PublicationDate=@PublicationDate WHERE ID=@ID";
                conn.Open();
                scmd = new SqlCommand(query, conn);

                // Adding parameters
                scmd.Parameters.AddWithValue("@ID", id);
                scmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                scmd.Parameters.AddWithValue("@Author", txtAuthor.Text);
                scmd.Parameters.AddWithValue("@Genre", txtGenre.Text);
                scmd.Parameters.AddWithValue("@Price", nudPrice.Value);
                scmd.Parameters.AddWithValue("@PublicationDate", dtpPublicationDate.Value);

                scmd.ExecuteNonQuery();
                conn.Close();

                LoadBooks();
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewBooks.SelectedRows[0].Cells["ID"].Value);
                string query = "DELETE FROM Books WHERE ID=@ID";
                conn.Open();
                scmd = new SqlCommand(query, conn);
                scmd.Parameters.AddWithValue("@ID", id);
                scmd.ExecuteNonQuery();
                conn.Close();

                LoadBooks();
            }
        }

        private void dataGridViewBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                txtTitle.Text = dataGridViewBooks.SelectedRows[0].Cells["Title"].Value.ToString();
                txtAuthor.Text = dataGridViewBooks.SelectedRows[0].Cells["Author"].Value.ToString();
                txtGenre.Text = dataGridViewBooks.SelectedRows[0].Cells["Genre"].Value.ToString();
                nudPrice.Value = Convert.ToDecimal(dataGridViewBooks.SelectedRows[0].Cells["Price"].Value);
                dtpPublicationDate.Value = Convert.ToDateTime(dataGridViewBooks.SelectedRows[0].Cells["PublicationDate"].Value);
            }
        }
    }
}
