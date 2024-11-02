using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class CustomerMenu : Form
    {
        public static CustomerMenu Instance { get; } = new CustomerMenu();
        private DataSet ds;
        private SqlDataAdapter adapter;
        private string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True;MultipleActiveResultSets=True";
        private string sql = "SELECT * FROM Заказы";

        public CustomerMenu()
        {
            InitializeComponent();
        }

        private async void CustomerMenu_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
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

        // button1 — добавление нового заказа
        private async void button1_Click(object sender, EventArgs e)
        {
            string idInput = Prompt.ShowDialog("ID заказа:", "Добавление заказа");
            if (string.IsNullOrEmpty(idInput) || !int.TryParse(idInput, out int id))
            {
                MessageBox.Show("Некорректный ID заказа.");
                return;
            }

            string client = Prompt.ShowDialog("Клиент:", "Добавление заказа");
            if (string.IsNullOrEmpty(client)) return;

            string orderDateInput = Prompt.ShowDialog("Дата заказа (yyyy-mm-dd):", "Добавление заказа");
            if (string.IsNullOrEmpty(orderDateInput)) return;

            if (!DateTime.TryParse(orderDateInput, out DateTime orderDate))
            {
                MessageBox.Show("Некорректная дата заказа.");
                return;
            }

            string deliveryDateInput = Prompt.ShowDialog("Дата доставки (yyyy-mm-dd):", "Добавление заказа");
            if (string.IsNullOrEmpty(deliveryDateInput)) return;

            if (!DateTime.TryParse(deliveryDateInput, out DateTime deliveryDate))
            {
                MessageBox.Show("Некорректная дата доставки.");
                return;
            }

            string orderContent = Prompt.ShowDialog("Состав заказа:", "Добавление заказа");
            if (string.IsNullOrEmpty(orderContent)) return;

            await AddOrderAsync(id, client, orderDate, deliveryDate, orderContent);
            await LoadDataAsync(); // Обновляем данные после добавления
        }

        // Асинхронный метод для добавления нового заказа
        private async Task AddOrderAsync(int id, string client, DateTime orderDate, DateTime deliveryDate, string orderContent)
        {
            string insertSql = @"
    INSERT INTO Заказы (Id, Клиент, [Дата заказа], [Дата доставки], [Состав заказа]) 
    VALUES (@id, @client, @orderDate, @deliveryDate, @orderContent)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@id", id);
                    insertCommand.Parameters.AddWithValue("@client", client);
                    insertCommand.Parameters.AddWithValue("@orderDate", orderDate);
                    insertCommand.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                    insertCommand.Parameters.AddWithValue("@orderContent", orderContent);
                    int numberOfInsertedRows = await insertCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Добавлено объектов: {numberOfInsertedRows}");
                }
            }
        }

        // button2 — удаление выбранного заказа
        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value; // Предполагаем, что ID заказа в первом столбце

                string deleteSql = "DELETE FROM Заказы WHERE Id = @id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@id", id);
                        int numberOfDeletedRows = await deleteCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"Удалено объектов: {numberOfDeletedRows}");
                    }
                }

                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для удаления.");
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

        // button4 — обновление выбранного заказа
        private async void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int)dataGridView1.SelectedRows[0].Cells[0].Value; // Предполагаем, что ID заказа в первом столбце

                string client = Prompt.ShowDialog("Клиент:", "Обновление заказа");
                if (string.IsNullOrEmpty(client)) return;

                string orderDateInput = Prompt.ShowDialog("Дата заказа (yyyy-mm-dd):", "Обновление заказа");
                if (string.IsNullOrEmpty(orderDateInput)) return;

                if (!DateTime.TryParse(orderDateInput, out DateTime orderDate))
                {
                    MessageBox.Show("Некорректная дата заказа.");
                    return;
                }

                string deliveryDateInput = Prompt.ShowDialog("Дата доставки (yyyy-mm-dd):", "Обновление заказа");
                if (string.IsNullOrEmpty(deliveryDateInput)) return;

                if (!DateTime.TryParse(deliveryDateInput, out DateTime deliveryDate))
                {
                    MessageBox.Show("Некорректная дата доставки.");
                    return;
                }

                string orderContent = Prompt.ShowDialog("Состав заказа:", "Обновление заказа");
                if (string.IsNullOrEmpty(orderContent)) return;

                await UpdateOrderAsync(id, client, orderDate, deliveryDate, orderContent);
                await LoadDataAsync(); // Обновляем данные после изменения
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заказ для обновления.");
            }
        }

        // Асинхронный метод для обновления заказа
        private async Task UpdateOrderAsync(int id, string client, DateTime orderDate, DateTime deliveryDate, string orderContent)
        {
            string updateSql = @"
            UPDATE Заказы 
            SET Клиент = @client, [Дата заказа] = @orderDate, [Дата доставки] = @deliveryDate, [Состав заказа] = @orderContent 
            WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand updateCommand = new SqlCommand(updateSql, connection))
                {
                    updateCommand.Parameters.AddWithValue("@client", client);
                    updateCommand.Parameters.AddWithValue("@orderDate", orderDate);
                    updateCommand.Parameters.AddWithValue("@deliveryDate", deliveryDate);
                    updateCommand.Parameters.AddWithValue("@orderContent", orderContent);
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
