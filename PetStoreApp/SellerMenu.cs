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

namespace PetStoreApp
{
    public partial class SellerMenu : Form
    {
        /// Строка подключения с параметром TrustServerCertificate=True
        private string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True;TrustServerCertificate=True";
        public SellerMenu()
        {
            InitializeComponent();
        }

        private void SellerMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'petStoreDataSet1.Товары' table. You can move, or remove it, as needed.
            this.товарыTableAdapter1.Fill(this.petStoreDataSet1.Товары);
            // TODO: This line of code loads data into the 'petStoreDataSet.Товары' table. You can move, or remove it, as needed.
            this.товарыTableAdapter.Fill(this.petStoreDataSet.Товары);
            LoadProducts();
        }

        // Метод для загрузки товаров в DataGridView
        private void LoadProducts()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Товары";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable productsTable = new DataTable();
                adapter.Fill(productsTable);
                dataGridView1.DataSource = productsTable;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Обработка клика в ячейке DataGridView
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Код для обработки нажатия кнопки
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
