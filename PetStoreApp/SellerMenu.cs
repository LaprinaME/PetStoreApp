using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class SellerMenu : Form
    {
        private DataSet ds;
        private SqlDataAdapter adapter;
        private SqlCommandBuilder commandBuilder;
        private string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True;TrustServerCertificate=True";
        private string sql = "SELECT * FROM Товары";

        public SellerMenu()
        {
            InitializeComponent();

            // Настройки DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            // Загрузка данных при инициализации формы
            LoadData();
        }

        // Метод для загрузки данных из базы в DataGridView
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // button1 — добавление новой строки
        private void button1_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }

        // button2 — удаление выбранной строки
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить выбранный товар?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            var артикул = row.Cells["Артикул"].Value;

                            // Удаляем товар
                            DeleteProduct(артикул.ToString());
                        }
                    }
                    LoadData(); // Обновляем данные после удаления
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.");
            }
        }

        // Метод для удаления товара
        private void DeleteProduct(string артикул)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Удаляем записи в связанных таблицах, если необходимо
                    SqlCommand deleteFavoritesCmd = new SqlCommand(
                        "DELETE FROM Избранные_товары WHERE Товар_Артикул = @Артикул", connection, transaction);
                    deleteFavoritesCmd.Parameters.AddWithValue("@Артикул", артикул);
                    deleteFavoritesCmd.ExecuteNonQuery();

                    // Здесь вы можете добавить дополнительные команды удаления для других связанных таблиц

                    // Удаляем товар
                    SqlCommand deleteProductCmd = new SqlCommand(
                        "DELETE FROM Товары WHERE Артикул = @Артикул", connection, transaction);
                    deleteProductCmd.Parameters.AddWithValue("@Артикул", артикул);
                    deleteProductCmd.ExecuteNonQuery();

                    // Подтверждаем транзакцию
                    transaction.Commit();
                    MessageBox.Show("Товар успешно удален.");
                }
                catch (Exception ex)
                {
                    // Откатываем транзакцию в случае ошибки
                    transaction.Rollback();
                    MessageBox.Show($"Ошибка при удалении товара: {ex.Message}");
                }
            }
        }

        // button3 — сохранение изменений в базе данных
        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(ds);
            }
            MessageBox.Show("Изменения сохранены.");
        }

        // Обработчик события загрузки формы SellerMenu
        private void SellerMenu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Здесь можно добавить необходимую логику обработки нажатий на ячейки DataGridView.
        }
    }
}
