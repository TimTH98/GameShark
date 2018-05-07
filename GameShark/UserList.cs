using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GameShark
{
    // Пользователь
    [Serializable]
    class User
    {
        public string Login;
        public string Password;
        public bool Mode; //Флаг типа аккаунта
        public List<string> GameList;

        public User(string login, string password, bool mode)
        {
            Login = login;
            Password = GetMD5.encrypt(password);
            Mode = mode;
        }
    }
        
    [Serializable] 
    class Users : List<User> // Список пользователей
    {
        public void SignupNewUser(string login, string password, bool mode)
        {   // Регистрация нового пользвателя
            Add(new User("admin", "admin", true));

            if (this.Any(u => u.Login == login))
                throw new Exception("Пользователь с данным именем уже существует.");

            Add(new User(login, password, false));
        }

        public bool Entry(string login, string password, bool mode)
        {   //ищем юзера по логину
            var user = this.LastOrDefault(k => k.Login == login); 
            if (user == null)
            {
                MessageBox.Show("Пользователь не найден.", "Ошибка",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            else if (user.Password != GetMD5.encrypt(password)) //проверяем пароль
            {
                MessageBox.Show("Неверный пароль.");
                return false;
            }
            else return true;
        }
    }
}