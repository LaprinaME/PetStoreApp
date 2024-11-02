using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class AdminMenu : Form
    {
        public static AdminMenu Instance { get; } = new AdminMenu();
        private string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True;MultipleActiveResultSets=True";
        private SqlDataAdapter adapter;
        private DataSet ds;
        private string sql = "SELECT * FROM Поставки"; // SQL-запрос для загрузки данных о поставках

        public AdminMenu()
        {
            InitializeComponent();
        }

        private async void AdminMenu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'petStoreDataSet5.Клиенты' table. You can move, or remove it, as needed.
            this.клиентыTableAdapter.Fill(this.petStoreDataSet5.Клиенты);
            await LoadDataAsync(); // Загрузка данных при запуске формы
        }

        // Асинхронный метод для загрузки данных из базы в DataGridView
        private async Task LoadDataAsync()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                await Task.Run(() => adapter.Fill(ds));
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string supplierIdInput = Prompt.ShowDialog("ID поставщика:", "Добавление поставки");
            if (string.IsNullOrEmpty(supplierIdInput) || !int.TryParse(supplierIdInput, out int supplierId))
            {
                MessageBox.Show("Некорректный ID поставщика.");
                return;
            }

            string deliveryDateInput = Prompt.ShowDialog("Дата поставки (yyyy-mm-dd):", "Добавление поставки");
            if (string.IsNullOrEmpty(deliveryDateInput)) return;

            if (!DateTime.TryParse(deliveryDateInput, out DateTime deliveryDate))
            {
                MessageBox.Show("Некорректная дата поставки.");
                return;
            }

            string invoiceNumber = Prompt.ShowDialog("Номер накладной:", "Добавление поставки");
            if (string.IsNullOrEmpty(invoiceNumber)) return;

            await AddSupplyAsync(supplierId, deliveryDate, invoiceNumber);
            await LoadDataAsync(); // Обновляем данные после добавления
        }

        // Асинхронный метод для добавления новой поставки без id
        private async Task AddSupplyAsync(int supplierId, DateTime deliveryDate, string invoiceNumber)
        {
            string insertSql = @"
    INSERT INTO Поставки (Поставщик_id, Дата_поставки, Номер_накладной) 
    VALUES (@supplierId, @deliveryDate, @invoiceNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@supplierId", supplierId);
                    insertCommand.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                    insertCommand.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                    int numberOfInsertedRows = await insertCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Добавлено объектов: {numberOfInsertedRows}");
                }
            }
        }


        // button2 — удаление выбранной поставки
        private async void button2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value; // ID поставки в первом столбце

                string deleteSql = "DELETE FROM Поставки WHERE Id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@id", id);
                        await deleteCommand.ExecuteNonQueryAsync();
                    }
                }

                await LoadDataAsync(); // Обновляем данные после удаления
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите поставку для удаления.");
            }
        }

        // button3 — сохранение изменений в базе данных
        private async void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                adapter = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                await Task.Run(() => adapter.Update(ds));
            }
            MessageBox.Show("Изменения сохранены.");
        }

        // button4 — обновление выбранной поставки
        private async void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value; // ID поставки в первом столбце

                string supplierIdInput = Prompt.ShowDialog("ID поставщика:", "Обновление поставки");
                if (string.IsNullOrEmpty(supplierIdInput) || !int.TryParse(supplierIdInput, out int supplierId))
                {
                    MessageBox.Show("Некорректный ID поставщика.");
                    return;
                }

                string deliveryDateInput = Prompt.ShowDialog("Дата поставки (yyyy-mm-dd):", "Обновление поставки");
                if (string.IsNullOrEmpty(deliveryDateInput) || !DateTime.TryParse(deliveryDateInput, out DateTime deliveryDate))
                {
                    MessageBox.Show("Некорректная дата поставки.");
                    return;
                }

                string invoiceNumber = Prompt.ShowDialog("Номер накладной:", "Обновление поставки");
                if (string.IsNullOrEmpty(invoiceNumber)) return;

                await UpdateSupplyAsync(id, supplierId, deliveryDate, invoiceNumber);
                await LoadDataAsync(); // Обновляем данные после изменения
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите поставку для обновления.");
            }
        }

        // Асинхронный метод для обновления поставки
        private async Task UpdateSupplyAsync(int id, int supplierId, DateTime deliveryDate, string invoiceNumber)
        {
            string updateSql = @"
            UPDATE Поставки 
            SET Поставщик_id = @supplierId, Дата_поставки = @deliveryDate, Номер_накладной = @invoiceNumber 
            WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand updateCommand = new SqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("@supplierId", supplierId);
                    updateCommand.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                    updateCommand.Parameters.AddWithValue("@invoiceNumber", invoiceNumber);
                    updateCommand.Parameters.AddWithValue("@id", id);
                    await updateCommand.ExecuteNonQueryAsync();
                }
            }
        }

        public class Prompt : Form
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 300,
                    Text = caption
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(textLabel);
                prompt.ShowDialog();
                return textBox.Text;
            }
        }

    }
}
