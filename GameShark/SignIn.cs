using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace GameShark
{
    public partial class SignIn : Form
    {
        private Users users;
        public string fileName;

        public SignIn()
        {
            InitializeComponent();

            var fileDir = AppDomain.CurrentDomain.BaseDirectory;
            fileName = Path.Combine(fileDir, "users.bin");

            if (File.Exists(fileName))
                using (var fs = File.OpenRead(fileName))
                    users = (Users)new BinaryFormatter().Deserialize(fs);
            else
                users = new Users();

            Constructor.Logger.CreateLogRecord("Инициализация формы авторизации");
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            var signUp = new SignUp();

            Hide();
            signUp.ShowDialog();

            Constructor.Logger.CreateLogRecord("Открытие окна регистрации");
        }


        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Hеобходимо заполнить все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (users.Entry(loginBox.Text, passwordBox.Text, false) == true)
                {
                    Hide();

                    Constructor.MB.WindowState = FormWindowState.Normal;
                    Constructor.MB.ShowInTaskbar = true;
                    
                    Constructor.Logger.CreateLogRecord("Вход");
                    //Close();
                }
            }
        }
    }
}
