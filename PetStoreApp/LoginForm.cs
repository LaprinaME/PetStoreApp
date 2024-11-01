using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Вход в систему";
            this.Size = new Size(400, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Фиксированный размер
            this.MaximizeBox = false; // Убираем кнопку максимизации
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Дополнительные настройки могут быть добавлены здесь
        }

        // Обработчик для ввода логина
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Здесь можно добавить логику, если необходимо
        }

        // Кнопка для входа
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем введенные данные
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Подключение к базе данных
            string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Запрос для получения кода роли пользователя
                    string query = "SELECT Код_роли FROM Аккаунты WHERE Логин = @login AND Пароль = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        var roleCode = command.ExecuteScalar();

                        if (roleCode != null)
                        {
                            MessageBox.Show("Успешный вход", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Переход на соответствующую форму в зависимости от кода роли
                            Form nextForm;

                            switch (roleCode.ToString())
                            {
                                case "1": // Код для покупателя
                                    nextForm = new CustomerMenu();
                                    break;
                                case "2": // Код для администратора
                                    nextForm = new AdminMenu();
                                    break;
                                case "3": // Код для продавца
                                    nextForm = new SellerMenu();
                                    break;
                                default:
                                    MessageBox.Show("Неизвестный код роли", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                            }

                            nextForm.Show();
                            this.Hide(); // Скрыть текущую форму
                        }
                        else
                        {
                            MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обработчик для ввода пароля
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Здесь можно добавить логику, если необходимо
        }
    }
}
