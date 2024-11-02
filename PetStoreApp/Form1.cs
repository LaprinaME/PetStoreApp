using System;
using System.Drawing;
using System.Windows.Forms;

namespace PetStoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Настраиваем кнопку авторизации
            button1.Text = "Авторизация";
            button1.Location = new Point(50, 50);
            button1.Size = new Size(200, 40);
            button1.Click += button1_Click;

            // Настраиваем кнопку регистрации
            button2.Text = "Регистрация";
            button2.Location = new Point(50, 100);
            button2.Size = new Size(200, 40);
            button2.Click += button2_Click;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Открываем форму авторизации
            LoginForm.Instance.Show();
            LoginForm.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Открываем форму регистрации
            RegisterForm.Instance.Show();
            RegisterForm.Instance.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Центрируем кнопки
            CenterButtons();
        }

        private void CenterButtons()
        {
            button1.Location = new Point(
                (this.ClientSize.Width - button1.Width) / 2,
                (this.ClientSize.Height - button1.Height) / 2 - 30
            );

            button2.Location = new Point(
                (this.ClientSize.Width - button2.Width) / 2,
                (this.ClientSize.Height - button2.Height) / 2 + 30
            );
        }
    }
}
