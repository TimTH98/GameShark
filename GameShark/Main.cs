using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameShark
{
    public partial class Main : Form
    {
        private PictureBox pixtureBox;
        public Main()
        {
            InitializeComponent();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;

            Constructor.Logger.CreateLogRecord("Инициализация главного окна");
        }

        private void MainForm_Load(object sender, EventArgs e) // Событие Load запускается перед отображением формы
        {
            using (var login = new SignIn())
                if (login.ShowDialog(this) != DialogResult.OK) // Открытие дочерней формы и последующая проверка результата
                    Close(); // Если результат не ОК, то главная форма закрывается, не успев открыться.
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void менюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void оGameSharkToolStripMenuItem_Click(object sender, EventArgs e)
        {

            About about = new About();

            about.ShowDialog();
            Constructor.Logger.CreateLogRecord("Открытие окна \"О программе\" ");
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var signIn = new SignIn();

            signIn.Show();
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
            Constructor.Logger.CreateLogRecord("Смена пользователя");
        }

        private void explorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var explorer = new Explorer();

            explorer.Show();
            Constructor.Logger.CreateLogRecord("Открытие \"проводника\"");
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void SignUp_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
