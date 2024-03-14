using System;
using System.Windows;
using Microsoft.Win32;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для ConfigurationWindow.xaml
    /// </summary>
    public partial class ConfigurationWindow : Window
    {
        public ConfigurationWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Переменная для сохранения выбранного контента в TreeView
        /// </summary>
        public string CHK;
        /// <summary>
        /// Метод для работы с реестром
        /// </summary>
        private void Reestr(string ds, string ic, string logsql, string passsql)
        {
            /// Переменая для работы с реестром HKEY_CURRENT_USER
            RegistryKey registry = Registry.CurrentUser;
            /// Переменная для создания или открытия, если есть папки с названием DBSave
            RegistryKey key = registry.CreateSubKey("DBSave");
            try
            {
                /// Переменная для создания значения с названием Server
                key.SetValue("Server", ds);
                /// Переменная для создания значения с названием DataBase
                key.SetValue("DataBase", ic);
                /// Переменная для создания значения с названием Log
                key.SetValue("Log", logsql);
                /// Переменная для создания значения с названием Pass
                key.SetValue("Pass", passsql);
            }
            catch (Exception ex)
            {
                /// Вывод сообщения при ошибки
                MessageBox.Show(ex.Message);
            }
            finally
            {
                /// Присвоение переменной DS к значению Server
                DataBase.DS = key.GetValue("Server").ToString();
                /// Присвоение переменной IC к значению DataBase
                DataBase.IC = key.GetValue("DataBase").ToString();
                /// Присвоение переменной LogSQL к значению Log
                DataBase.LogSQL = key.GetValue("Log").ToString();
                /// Присвоение переменной PassSQL к значению Pass
                DataBase.PassSQL = key.GetValue("Pass").ToString();
            }
        }

        /// <summary>
        /// Метод при закрузке окна
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /// Переменая для обозначения состояния
            bool ok = false;
            /// Переменая для обозначения состояния
            bool ok2 = false;
            /// Переменая для выгрузки значения
            string jk = null;
            /// Переменая для выгрузки значения
            string jk2 = null;
            /// Переменая для работы с реестром HKEY_CURRENT_USER
            RegistryKey registry = Registry.CurrentUser;
            /// Заполнение матрицы названиями папок в HKEY_CURRENT_USER
            string[] gh = registry.GetSubKeyNames();
            /// Цикл для поиска в HKEY_CURRENT_USER папки DBSave
            foreach (string h in gh)
            {
                if (h == "DBSave")
                {
                    ok = true;
                    jk = "DBSave";
                    break;
                }
                else { ok = false; }
            }
            /// Проверка состояния
            if (ok == true)
            {
                /// Открытия папки DBSave
                RegistryKey key = registry.OpenSubKey(jk);
                /// Заполнение матрицы названиями значений в папке DBSave
                gh = key.GetValueNames();
                /// Цикл для поиска в DBSave значения Server
                foreach (string j in gh)
                {
                    if (j == "Server")
                    {
                        ok2 = true;
                        jk2 = "Server";
                        break;
                    }
                    else { ok2 = false; }
                }
                /// Проверка состояния
                if (ok2 == true)
                {
                    /// Добление RadioButton в TreeView
                    RadioButton item = new RadioButton();
                    item.Content = key.GetValue(jk2).ToString();
                    item.Checked += item_Checked;
                    CHK = Convert.ToString(item.Content);
                    Vbr.Items.Add(item);
                    /// ----------------------------------------
                }
            }
        }

        /// <summary>
        /// Метод при выборе items в TreeView
        /// </summary>
        private void item_Checked(object sender, RoutedEventArgs e)
        {
            /// Вписивание выбраного значения в TexBox
            DBSL.Text = CHK;
        }
        /// <summary>
        /// Метод получения списка баз данных на сервере
        /// </summary>
        private void GetDB_Click(object sender, RoutedEventArgs e)
        {
            /// Строка подключения к серверу SQL
            SqlConnection connect = new SqlConnection(string.Format("Data Source = {0}; Initial Catalog = master; Integrated Security = true;", DBSL.Text));
            /// Кеш таблица для выгрузки данных
            DataTable data = new DataTable();
            /// SQL команда для получения списка баз данных на сервере
            SqlCommand command = new SqlCommand("select name from sys.databases", connect);
            try
            {
                /// Открытие подключения
                connect.Open();
                /// Выгрузка в кеш таблицу вывода команды
                data.Load(command.ExecuteReader());
                /// Цикл для заполнения ComboBox названиями баз данных на сервере
                foreach (DataRow dt in data.Rows)
                {
                    if (!DBL.Items.Contains(dt[0]))
                    {
                        DBL.Items.Add(dt[0]);
                    }
                }
                /// Доступ к нопки
                DBConnect.IsEnabled = true;
            }
            catch (SqlException ex)
            {
                /// Ввыод сообщения при ошибке
                MessageBox.Show(ex.Message);
            }
            finally
            {
                /// Закрытия подключения
                connect.Close();
            }
        }
        /// <summary>
        /// Метод для проверки подключения
        /// </summary>
        private void DBConnect_Click(object sender, RoutedEventArgs e)
        {
            /// Отправка данных в реестр
            Reestr(DBSL.Text, DBL.Text, NM.Text, PW.Password);
            /// Вызов класса для работы с БД
            DataBase fg = new DataBase();
            /// Проверки подленности взависимость от выбора значения в ComboBox
            if (LIZSQL.IsSelected == true)
            {
                /// Вызов метода из класса для проверки подключения по SQL
                if (fg.SQL() == true)
                {
                    /// Вывод сообщения при успехе
                    MessageBox.Show("Подключение упсешно!");
                    /// Вызов окна AdminWindow
                    AdminWindow adm = new AdminWindow();
                    adm.Show();
                    Close();
                }
                else
                {
                    /// Вывод сообщения при ошибки
                    MessageBox.Show("Ошибка подключения!");
                }
            }
            if (LIZWIN.IsSelected == true)
            {
                /// Вызов метода из класса для проверки подключения по Windows
                if (fg.connection_Checking() == true)
                {
                    /// Вывод сообщения при успехе
                    MessageBox.Show("Подключение упсешно!");
                    /// Закрытие окна
                    Close();
                }
                else
                {
                    /// Вывод сообщения при ошибки
                    MessageBox.Show("Ошибка подключения!");
                }
            }
        }
        /// <summary>
        /// Метод для кнопки отмена
        /// </summary>
        private void DBCancel_Click(object sender, RoutedEventArgs e)
        {
            /// Закрытие окна
            Close();
        }
        /// <summary>
        /// Метод для анимации при выборе проверки подленности по SQL
        /// </summary>
        private void LIZSQL_Selected(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с анимацией
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            /// Проверка на то, что анимация еще не происходила
            if (NM.ActualHeight == 0 && PW.ActualHeight == 0 && LB_L.ActualHeight == 0 && LB_P.ActualHeight == 0)
            {
                /// Настрока значения от
                buttonAnimation.From = NM.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 24;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                NM.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = PW.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 24;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                PW.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = LB_L.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 27;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                LB_L.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = LB_P.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 25;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                LB_P.BeginAnimation(Button.HeightProperty, buttonAnimation);
            }
        }
        /// <summary>
        /// Метод для анимации при выборе проверки подленности по Windows
        /// </summary>
        private void LIZWIN_Selected(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с анимацией
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            /// Проверка на то, что анимация происходила
            if (NM.ActualHeight != 0 && PW.ActualHeight != 0 && LB_L.ActualHeight != 0 && LB_P.ActualHeight != 0)
            {
                /// Настрока значения от
                buttonAnimation.From = NM.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 0;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                NM.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = PW.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 0;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                PW.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = LB_L.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 0;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                LB_L.BeginAnimation(Button.HeightProperty, buttonAnimation);

                /// Настрока значения от
                buttonAnimation.From = LB_P.ActualHeight;
                /// Настрока значения до
                buttonAnimation.To = 0;
                /// Настрока значения скорости
                buttonAnimation.Duration = TimeSpan.FromSeconds(1);
                /// Наяало анимации
                LB_P.BeginAnimation(Button.HeightProperty, buttonAnimation);
            }
        }
        /// <summary>
        /// Метод при закрытии окна
        /// </summary>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /// Вызов класса для работы с БД
            DataBase fg = new DataBase();
            /// Проверки подленности взависимость от выбора значения в ComboBox
            if (LIZSQL.IsSelected == true)
            {
                /// Вызов метода из класса для проверки подключения по SQL
                switch (fg.SQL())
                {
                    case false:
                        /// Вывод сообщения, если подключение не настроенно, но пользователь закрыввает программу
                        switch (MessageBox.Show("Подключение не настроено! Завершить работу приложения?", "Настройка подключения", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                        {
                            case MessageBoxResult.Yes:
                                e.Cancel = false;
                                App.Current.Shutdown();
                                break;
                            case MessageBoxResult.No:
                                e.Cancel = true;
                                break;
                        }
                        break;
                }
            }
            else
            {
                /// Вызов метода из класса для проверки подключения по Windows
                switch (fg.connection_Checking())
                {
                    case false:
                        /// Вывод сообщения, если подключение не настроенно, но пользователь закрыввает программу
                        switch (MessageBox.Show("Подключение не настроено! Завершить работу приложения?", "Настройка подключения", MessageBoxButton.YesNo, MessageBoxImage.Warning))
                        {
                            case MessageBoxResult.Yes:
                                e.Cancel = false;
                                App.Current.Shutdown();
                                break;
                            case MessageBoxResult.No:
                                e.Cancel = true;
                                break;
                        }
                        break;
                }
            }
        }
    }
}