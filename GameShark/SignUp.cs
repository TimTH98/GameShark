using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace GameShark
{
    public partial class SignUp : Form
    {
        private Users users;
        public string fileName;

        public SignUp()
        {
            InitializeComponent();

            var fileDir = AppDomain.CurrentDomain.BaseDirectory;
            fileName = Path.Combine(fileDir, "users.bin");
            if (File.Exists(fileName))
                using (var fs = File.OpenRead(fileName))
                    users = (Users)new BinaryFormatter().Deserialize(fs);
            else
                users = new Users();

            Constructor.Logger.CreateLogRecord("Инициализация формы регистрации");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == "" || passwordBox.Text == "" || checkPassBox.Text == "")
            {
                MessageBox.Show("Hеобходимо заполнить все поля!", "Ошибка",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    if (passwordBox.Text == checkPassBox.Text)
                    {
                        users.SignupNewUser(loginBox.Text, passwordBox.Text, false);

                        using (var fs = File.OpenWrite(fileName))
                            new BinaryFormatter().Serialize(fs, users);
                    }
                    else throw new Exception("Пароли не совпадают.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Hide();

                Constructor.MB.WindowState = FormWindowState.Normal;
                Constructor.MB.ShowInTaskbar = true;
                Constructor.Logger.CreateLogRecord("Окончание регистрации");
            }
        }
        
        private void checkBox1_Click(object sender, EventArgs e)
        {
            Constructor.Logger.CreateLogRecord("Смена типа аккаунта");
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}