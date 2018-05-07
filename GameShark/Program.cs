using System;
using System.Threading;
using System.Windows.Forms;

namespace GameShark
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var thread = new Thread(new ThreadStart(Constructor.Logger.LoggingAsync));
            thread.Start();
            Constructor.MB = new Main();
            var autorize = new SignIn();
            autorize.Show();
            Application.Run(Constructor.MB);
            thread.Abort();
        }
    }
}
