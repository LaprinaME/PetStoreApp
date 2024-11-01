using Microsoft.Identity.Client;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class SellerMenu : Form
    {
        public static SellerMenu Instance { get; } = new SellerMenu();
        private DataSet ds;
        private SqlDataAdapter adapter;
        private string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True;TrustServerCertificate=True";
        private string sql = "SELECT * FROM Товары";

        public SellerMenu()
        {
            InitializeComponent();

            // Настройки DataGridView
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            // Загрузка данных при инициализации формы
            LoadDataAsync(); // Запускаем загрузку данных
        }

        // Асинхронный метод для загрузки данных из базы в DataGridView
        private async Task LoadDataAsync() // Изменено на Task
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                adapter = new SqlDataAdapter(sql, connection);
                ds = new DataSet();
                await Task.Run(() => adapter.Fill(ds)); // Заполняем DataSet в отдельном потоке
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        // button1 — добавление новой строки 
        private async void button1_Click(object sender, EventArgs e)
        {
            // Ввод данных о новом товаре
            string articleInput = Prompt.ShowDialog("Введите артикул товара:", "Добавление товара");
            if (string.IsNullOrEmpty(articleInput)) return;

            int article;
            if (!int.TryParse(articleInput, out article))
            {
                MessageBox.Show("Некорректный артикул.");
                return;
            }

            string name = Prompt.ShowDialog("Введите название товара:", "Добавление товара");
            if (string.IsNullOrEmpty(name)) return;

            string category = Prompt.ShowDialog("Введите категорию товара:", "Добавление товара");
            if (string.IsNullOrEmpty(category)) return;

            string brand = Prompt.ShowDialog("Введите бренд товара:", "Добавление товара");
            if (string.IsNullOrEmpty(brand)) return;

            string animal = Prompt.ShowDialog("Введите тип животного:", "Добавление товара");
            if (string.IsNullOrEmpty(animal)) return;

            string description = Prompt.ShowDialog("Введите описание товара:", "Добавление товара");
            if (string.IsNullOrEmpty(description)) return;

            string composition = Prompt.ShowDialog("Введите состав товара:", "Добавление товара");
            if (string.IsNullOrEmpty(composition)) return;

            string unit = Prompt.ShowDialog("Введите единицу измерения:", "Добавление товара");
            if (string.IsNullOrEmpty(unit)) return;

            decimal price;
            if (!decimal.TryParse(Prompt.ShowDialog("Введите стоимость товара:", "Добавление товара"), out price))
            {
                MessageBox.Show("Некорректная стоимость.");
                return;
            }

            int quantity;
            if (!int.TryParse(Prompt.ShowDialog("Введите количество на складе:", "Добавление товара"), out quantity))
            {
                MessageBox.Show("Некорректное количество.");
                return;
            }

            await AddProductAsync(article, name, category, brand, animal, description, composition, unit, price, quantity);
            await LoadDataAsync(); // Обновляем данные после добавления
        }

        // Асинхронный метод для добавления нового товара
        private async Task AddProductAsync(int article, string name, string category, string brand, string animal, string description, string composition, string unit, decimal price, int quantity)
        {
            string insertSql = @"
            INSERT INTO Товары (Артикул, Название, Категория, Бренд, Животное, Описание, Состав, Единица, Стоимость, Количество_на_складе) 
            VALUES (@article, @name, @category, @brand, @animal, @description, @composition, @unit, @price, @quantity)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                {
                    insertCommand.Parameters.AddWithValue("@article", article);
                    insertCommand.Parameters.AddWithValue("@name", name);
                    insertCommand.Parameters.AddWithValue("@category", category);
                    insertCommand.Parameters.AddWithValue("@brand", brand);
                    insertCommand.Parameters.AddWithValue("@animal", animal);
                    insertCommand.Parameters.AddWithValue("@description", description);
                    insertCommand.Parameters.AddWithValue("@composition", composition);
                    insertCommand.Parameters.AddWithValue("@unit", unit);
                    insertCommand.Parameters.AddWithValue("@price", price);
                    insertCommand.Parameters.AddWithValue("@quantity", quantity);
                    int numberOfInsertedRows = await insertCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Добавлено объектов: {numberOfInsertedRows}");
                }
            }
        }

        // button2 — удаление выбранной строки
        private async void button2_Click(object sender, EventArgs e)
        {
            // Проверяем, выбрана ли строка в DataGridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем артикул выбранного товара (предполагаем, что он находится в первом столбце)
                int article = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                // Запрос на удаление товара по артикулу
                string deleteSql = "DELETE FROM Товары WHERE Артикул = @article";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@article", article);
                        int numberOfDeletedRows = await deleteCommand.ExecuteNonQueryAsync();
                        Console.WriteLine($"Удалено объектов: {numberOfDeletedRows}");
                    }
                }

                // Обновляем данные после удаления
                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для удаления.");
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

        // Обработчик события загрузки формы SellerMenu
        private async void SellerMenu_Load(object sender, EventArgs e) // Сделан асинхронным
        {
            await LoadDataAsync();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Здесь можно добавить необходимую логику обработки нажатий на ячейки DataGridView.
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            // Запрашиваем новые данные у пользователя для каждого параметра
            string newName = Prompt.ShowDialog("Введите название товара:", "Обновление товара");
            if (string.IsNullOrEmpty(newName)) return;

            string newCategory = Prompt.ShowDialog("Введите категорию товара:", "Обновление товара");
            if (string.IsNullOrEmpty(newCategory)) return;

            string newBrand = Prompt.ShowDialog("Введите бренд товара:", "Обновление товара");
            if (string.IsNullOrEmpty(newBrand)) return;

            string newAnimal = Prompt.ShowDialog("Введите животное:", "Обновление товара");
            if (string.IsNullOrEmpty(newAnimal)) return;

            string newDescription = Prompt.ShowDialog("Введите описание товара:", "Обновление товара");
            if (string.IsNullOrEmpty(newDescription)) return;

            string newComposition = Prompt.ShowDialog("Введите состав товара:", "Обновление товара");
            if (string.IsNullOrEmpty(newComposition)) return;

            string newUnit = Prompt.ShowDialog("Введите единицу измерения:", "Обновление товара");
            if (string.IsNullOrEmpty(newUnit)) return;

            decimal newPrice;
            if (!decimal.TryParse(Prompt.ShowDialog("Введите стоимость товара:", "Обновление товара"), out newPrice))
            {
                MessageBox.Show("Некорректная стоимость.");
                return;
            }

            int newQuantity;
            if (!int.TryParse(Prompt.ShowDialog("Введите количество на складе:", "Обновление товара"), out newQuantity))
            {
                MessageBox.Show("Некорректное количество.");
                return;
            }

            // SQL-запрос для обновления всех параметров, кроме артикула
            string updateSql = @"
            UPDATE Товары 
            SET Название = @newName, Категория = @newCategory, Бренд = @newBrand, 
                Животное = @newAnimal, Описание = @newDescription, Состав = @newComposition, 
                Единица = @newUnit, Стоимость = @newPrice, Количество_на_складе = @newQuantity 
            WHERE Артикул = @article";

            // Получаем артикул выбранного товара
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int article = (int)dataGridView1.SelectedRows[0].Cells[0].Value;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    using (SqlCommand updateCommand = new SqlCommand(updateSql, connection))
                    {
                        // Добавляем параметры к SQL-запросу
                        updateCommand.Parameters.AddWithValue("@newName", newName);
                        updateCommand.Parameters.AddWithValue("@newCategory", newCategory);
                        updateCommand.Parameters.AddWithValue("@newBrand", newBrand);
                        updateCommand.Parameters.AddWithValue("@newAnimal", newAnimal);
                        updateCommand.Parameters.AddWithValue("@newDescription", newDescription);
                        updateCommand.Parameters.AddWithValue("@newComposition", newComposition);
                        updateCommand.Parameters.AddWithValue("@newUnit", newUnit);
                        updateCommand.Parameters.AddWithValue("@newPrice", newPrice);
                        updateCommand.Parameters.AddWithValue("@newQuantity", newQuantity);
                        updateCommand.Parameters.AddWithValue("@article", article);
                        await updateCommand.ExecuteNonQueryAsync();
                    }
                }

                // Обновляем данные после изменения
                await LoadDataAsync();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите товар для обновления.");
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
