using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class LoginForm : Form
    {
        private static LoginForm instance;

        public static LoginForm Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new LoginForm();
                }
                return instance;
            }
        }

        public LoginForm() // Убедитесь, что конструктор является public
        {
            InitializeComponent();
            this.Text = "Вход в систему";
            this.Size = new Size(400, 250);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Дополнительные настройки могут быть добавлены здесь
        }

        // Кнопка для входа
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string connectionString = @"Data Source=DESKTOP-DFJ77GS;Initial Catalog=PetStore;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Код_роли FROM Аккаунты WHERE Логин = @login AND Пароль = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        var roleCode = command.ExecuteScalar();

                        if (roleCode != null)
                        {
                            Form nextForm = GetNextFormByRole(roleCode.ToString());
                            if (nextForm != null)
                            {
                                nextForm.Show();
                                this.Hide();
                            }
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

        private Form GetNextFormByRole(string roleCode)
        {
            switch (roleCode)
            {
                case "1":
                    return CustomerMenu.Instance;
                case "2":
                    return AdminMenu.Instance;
                case "3":
                    return SellerMenu.Instance;
                default:
                    MessageBox.Show("Неизвестный код роли", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
            }
        }
    }
}
