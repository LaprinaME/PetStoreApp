using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class RegisterForm : Form
    {
        private static RegisterForm instance;

        public static RegisterForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new RegisterForm();
                }
                return instance;
            }
        }

        private RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Здесь можно инициализировать данные, если потребуется
        }

        private void textBox1_TextChanged(object sender, EventArgs e) // Ввод логина
        {
            // Логика обработки текста логина, если нужно
        }

        private void textBox2_TextChanged(object sender, EventArgs e) // Ввод пароля
        {
            // Логика обработки текста пароля, если нужно
        }

        private void textBox3_TextChanged(object sender, EventArgs e) // Ввод кода роли
        {
            // Логика обработки текста кода роли, если нужно
        }

        private void button1_Click(object sender, EventArgs e) // Кнопка регистрации
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string roleCode = textBox3.Text;

            // Подключение к базе данных
            string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Проверка существования логина
                    string checkQuery = "SELECT COUNT(*) FROM Аккаунты WHERE Логин = @login";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@login", login);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Логин уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Вставка нового аккаунта
                    string insertQuery = "INSERT INTO Аккаунты (Логин, Пароль, Код_роли) VALUES (@login, @password, @roleCode)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@login", login);
                        insertCommand.Parameters.AddWithValue("@password", password);
                        insertCommand.Parameters.AddWithValue("@roleCode", roleCode);

                        int result = insertCommand.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Регистрация успешна", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Переход на соответствующую форму в зависимости от кода роли
                            Form nextForm = GetNextForm(roleCode);
                            if (nextForm != null)
                            {
                                nextForm.Show();
                                this.Hide(); // Скрыть текущую форму
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private Form GetNextForm(string roleCode)
        {
            switch (roleCode)
            {
                case "1": // Код для покупателя
                    return new CustomerMenu();
                case "2": // Код для администратора
                    return new CustomerMenu();
                case "3": // Код для продавца
                    return new SellerMenu();
                default:
                    MessageBox.Show("Неизвестный код роли", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Логика обработки, если нужно
        }
    }
}
