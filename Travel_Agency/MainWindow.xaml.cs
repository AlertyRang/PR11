using Microsoft.Win32;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Переменая для манипуляции с кодом для двухфакторной аунтефикации
        /// </summary>
        public string _codEmail;
        /// <summary>
        /// Переменая для статуса заверщения процессов проверки
        /// </summary>
        public bool GlobalST { get; set; }
        /// <summary>
        /// Переменая для статуса проверки приложения SQL
        /// </summary>
        public bool StatusSQL { get; set; }
        /// <summary>
        /// Переменая для статуса проверки приложения Word
        /// </summary>
        public bool StatusWord { get; set; }
        /// <summary>
        /// Переменая для статуса проверки приложения Exсel
        /// </summary>
        public bool StatusExecl { get; set; }
        /// <summary>
        /// Переменая для статуса пользователя
        /// </summary>
        public bool OK { get; set; }
        /// <summary>
        /// Метод для работы с реестром
        /// </summary>
        private void regGet()
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey key = registry.CreateSubKey("DBSave");
            string[] judi = key.GetValueNames();
            bool ok = false;
            foreach (string yu in judi)
            {
                if (yu == "ID")
                {
                    OK = true;
                    break;
                }
                else { OK = false; }
            }
            foreach (string lu in judi)
            {
                if (lu == "Server")
                {
                    DataBase.DS = key.GetValue(lu).ToString();
                    ok = true;
                }
                else if (lu == "DataBase")
                {
                    DataBase.IC = key.GetValue(lu).ToString();
                    ok = true;
                }
            }
            if (ok == false)
            {
                MessageBox.Show("Подключения было не настроено!", "Ошибка");
                DataBase.DS = "Null";
                DataBase.IC = "Null";
            }
        }
        /// <summary>
        /// Метод для проверки подключения
        /// </summary>
        private void Connect_Cheking()
        {
            /// Обращение к реестру для проверки происходило ли подключение раньше
            regGet();
            /// Вызов класса для работы с БД
            DataBase DataBase = new DataBase();
            /// Из класса вызов метода для проверки подключения
            switch (DataBase.connection_Checking())
            {
                case true:
                    break;
                case false:
                    /// Вывод окна если подключение провалилось
                    ConfigurationWindow configurationWindow = new ConfigurationWindow();
                    configurationWindow.ShowDialog();
                    ///----------------------------------------------------------------
                    break;
            }
        }
        /// <summary>
        /// Метод для проверки установки Microsoft SQl на ПК
        /// </summary>
        private void Programs_SQL_Cheking()
        {
            /// Обращение к реестру HKEY_LOCAL_MACHINE
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft");
            /// Цикл для поиска в HKEY_LOCAL_MACHINE папки с названием нужной программы
            foreach (var subkey_name in key.GetSubKeyNames())
            {
                /// Проверка на совпадения названия папки в HKEY_LOCAL_MACHINE и названия нужной программы
                if (subkey_name == "Microsoft SQL Server")
                {
                    /// Изменение статуса
                    StatusSQL = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Метод для проверки установки Microsoft Word на ПК
        /// </summary>
        private void Programs_Word_Cheking()
        {
            /// Переменная для проверки статуса
            bool Office = false;
            /// Обращение к реестру HKEY_LOCAL_MACHINE
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft");
            /// Цикл для поиска в HKEY_LOCAL_MACHINE папки с названием Office
            foreach (var subkey_name in key.GetSubKeyNames())
            {
                /// Проверка на совпадения названия папки в HKEY_LOCAL_MACHINE и названия нужной папки
                if (subkey_name == "Office")
                {
                    /// Изменение статуса
                    Office = true;
                    /// Обращение к папке, которая нужна была
                    key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office");
                    break;
                }
                /// Изменение статуса при не нахождении папки
                else { StatusWord = false; }
            }
            /// Проверка статуса
            if (Office == true)
            {
                /// Цикл для поиска в Office папки с названием нужной программы
                foreach (var subkey_name in key.GetSubKeyNames())
                {
                    /// Проверка на совпадения названия папки в Office и названия нужной программы
                    if (subkey_name == "Word")
                    {
                        /// Изменение статуса
                        StatusWord = true;
                        break;
                    }
                    /// Изменение статуса при не нахождении программы
                    else { StatusWord = false; }
                }
            }
        }
        /// <summary>
        /// Метод для проверки установки Microsoft Excel на ПК
        /// </summary>
        private void Programs_Excel_Cheking()
        {
            /// Переменная для проверки статуса
            bool Office = false;
            /// Обращение к реестру HKEY_LOCAL_MACHINE
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft");
            /// Цикл для поиска в HKEY_LOCAL_MACHINE папки с названием Office
            foreach (var subkey_name in key.GetSubKeyNames())
            {
                /// Проверка на совпадения названия папки в HKEY_LOCAL_MACHINE и названия нужной папки
                if (subkey_name == "Office")
                {
                    /// Изменение статуса
                    Office = true;
                    /// Обращение к папке, которая нужна была
                    key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Office");
                    break;
                }
                /// Изменение статуса при не нахождении папки
                else { StatusExecl = false; }
            }
            /// Проверка статуса
            if (Office == true)
            {
                /// Цикл для поиска в Office папки с названием нужной программы
                foreach (var subkey_name in key.GetSubKeyNames())
                {
                    /// Проверка на совпадения названия папки в Office и названия нужной программы
                    if (subkey_name == "Excel")
                    {
                        /// Изменение статуса
                        StatusExecl = true;
                        break;
                    }
                    /// Изменение статуса при не нахождении программы
                    else { StatusExecl = false; }
                }
            }
        }
        /// <summary>
        /// Метод при загрузке окна
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /// Вызов метода для проверки подключения
            Connect_Cheking();
            /// Вызов потока для проверки на наличие Microsoft SQl на ПК
            Thread sql = new Thread(new ThreadStart(Programs_SQL_Cheking));
            /// Вызов потока для проверки на наличие Microsoft Word на ПК
            Thread word = new Thread(new ThreadStart(Programs_Word_Cheking));
            /// Вызов потока для проверки на наличие Microsoft Excel на ПК
            Thread excel = new Thread(new ThreadStart(Programs_Excel_Cheking));
            /// Начало потока на наличие Microsoft Word на ПК
            word.Start();
            /// Начало потока на наличие Microsoft Excel на ПК
            excel.Start();
            /// Начало потока на наличие Microsoft SQl на ПК
            sql.Start();
            /// Приостановка метода загрузки окна пока поток на наличие Microsoft Word на ПК не закончился
            word.Join();
            /// Приостановка метода загрузки окна пока поток на наличие Microsoft Excel на ПК не закончился
            excel.Join();
            /// Приостановка метода загрузки окна пока поток на наличие Microsoft SQl на ПК не закончился
            sql.Join();
            /// Проверка на то, что пользователь уже заходил в програму
            if (OK == true)
            {
                /// Открытие окна VoucherWindow
                VoucherWindow vch = new VoucherWindow();
                vch.Show();
                /// Закрытие этого окна
                Close();
            }
            /// Проверка статусов на ошибку
            if (StatusSQL == false | StatusExecl == false | StatusWord == false)
            {
                /// Вывод сообщения при ошибке
                switch (MessageBox.Show("У вас не установлен Microsoft SQL, Microsoft Word, Microsoft Excel или база данных не подходит или база данных иеемт не коректное название!", "Ошибка", MessageBoxButton.OK))
                {
                    case MessageBoxResult.OK:
                        /// Закрытие всей программы при ошибке
                        App.Current.Shutdown();
                        break;
                }
            }
            /// Вызов метода для заставки
            YANIM_DOWN();
            /// Вызов метода для заставки
            BANIM();
        }
        /// <summary>
        /// Метод для заставки
        /// </summary>
        public void YANIM_DOWN()
        {
            /// Появления элемента заставки
            RCT.Visibility = Visibility.Visible;
            /// Вызов класса для работы с анимацией
            DoubleAnimation reganim = new DoubleAnimation();
            /// Настройка значения от
            reganim.From = RCT.ActualHeight;
            /// Настройка значения до
            reganim.To = 0;
            /// Настройка времени анимации
            reganim.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            RCT.BeginAnimation(Rectangle.HeightProperty, reganim);

            /// Настройка значения от
            reganim.From = RCT.ActualWidth;
            /// Настройка значения до
            reganim.To = 0;
            /// Настройка времени анимации
            reganim.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            RCT.BeginAnimation(Rectangle.WidthProperty, reganim);
        }
        /// <summary>
        /// Метод для заставки
        /// </summary>
        public void BANIM()
        {
            /// Запуск анимации
            RCT2.Visibility = Visibility.Visible;
            /// Вызов класса для работы с анимацией
            DoubleAnimation reganim = new DoubleAnimation();
            /// Настройка значения от
            reganim.From = RCT2.ActualHeight;
            /// Настройка значения до
            reganim.To = 0;
            /// Настройка времени анимации
            reganim.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            RCT2.BeginAnimation(Rectangle.HeightProperty, reganim);

            /// Настройка значения от
            reganim.From = RCT2.ActualWidth;
            /// Настройка значения до
            reganim.To = 0;
            /// Настройка времени анимации
            reganim.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            RCT2.BeginAnimation(Rectangle.WidthProperty, reganim);
        }
        /// <summary>
        /// Метод для отправки сообщения с кодом для дфух факторной аунтефикации
        /// </summary>
        private void E_Mail()
        {
            /// Генерация кода
            Random ran = new Random();
            /// Настройка подключения почты
            SmtpClient Smtp = new SmtpClient("smtp.gmail.com", 25);
            /// Настройка с какой почты будет отправляться письмо
            Smtp.Credentials = new NetworkCredential("-", "-");
            /// Настройка включения SSL
            Smtp.EnableSsl = true;
            /// Вызов класса для работы с письмом
            MailMessage Message = new MailMessage();
            /// Письмо от кого
            Message.From = new MailAddress("-");
            /// Письмо кому
            Message.To.Add(new MailAddress(Mail.Text));
            /// Тема письма
            Message.Subject = "Код для авторизации";
            /// Дополнение кода
            _codEmail = ran.Next(1000, 9999) + "F";
            /// Тело письма
            Message.Body = "Код: " + _codEmail;
            /// Отправка письма
            Smtp.Send(Message);
            /// Вывод сообщения об отправки письма
            MessageBox.Show("На вашу почту отправлен код. Если письмо не пришло, прошу посмотреть в папке 'Спам'");
        }
        /// <summary>
        /// Метод для кнопки войти
        /// </summary>
        private void VHD_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с БД
            DataBase data = new DataBase();
            /// Запрос на выборку данных
            data.DataSetFill(string.Format("select * from [dbo].[Staff] where [Login_Staff] = '{0}' and [Password_Staff] = '{1}'", Login.Text, Pass.Password), "Staff", DataBase.Function.select, null);
            /// Проверка на наличие записей в кеш таблице
            if (DataBase.dataSet.Tables["Staff"].Rows.Count != 0)
            {
                /// Вызов класс для работы с реестром HKEY_CURRENT_USER
                RegistryKey registry = Registry.CurrentUser;
                /// Создание или открытие папки с названием DBSave
                RegistryKey key = registry.CreateSubKey("DBSave");
                /// Освобождения поля Логина
                Login.Text = string.Empty;
                /// Освобождения поля Пороля
                Pass.Password = string.Empty;
                /// Создания значения ID со значением первичного ключа пользователя
                key.SetValue("ID", DataBase.dataSet.Tables["Staff"].Rows[0][0].ToString());
                /// Открытие формы для Email
                GR2.Visibility = Visibility.Visible;
            }
            else
            {
                /// Вывод сообщения при ошибке
                MessageBox.Show("Ошибка ввода логина или пароля!", "Ошибка");
            }
        }
        /// <summary>
        /// Метод для кнопки подтвердить в Grid для почты
        /// </summary>
        private void CFMAIL_Click(object sender, RoutedEventArgs e)
        {
            /// Скрытия Grid для почты
            GR2.Visibility = Visibility.Hidden;
            /// Открытие Grid для кода
            GR3.Visibility = Visibility.Visible;
            /// Вызов метода для отправки кода
            E_Mail();
        }
        /// <summary>
        /// Метод для кнопки подтвердить в Grid для кода
        /// </summary>
        private void CFCODE_Click(object sender, RoutedEventArgs e)
        {
            /// Проверка на правильность записаного кода пользователем
            if (_codEmail == CODE.Text)
            {
                /// Открытие окна VoucherWindow при совпадении
                VoucherWindow vch = new VoucherWindow();
                vch.Show();
                /// Закрытие текущего окна
                Close();
            }
            else
            {
                /// Вывод сообщения при ошибки
                MessageBox.Show("Код не верный!", "ОШИБОЧКА");
            }
        }
    }
}
