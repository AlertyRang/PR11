using System;
using System.Windows;
using DataGrid = System.Windows.Controls.DataGrid;
using MessageBox = System.Windows.MessageBox;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Media.Animation;
using Microsoft.Win32;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для VoucherWindow.xaml
    /// </summary>
    public partial class VoucherWindow : Window
    {
        public VoucherWindow()
        {
            InitializeComponent();
            /// Настройка фильтра при работе с файлами системы
            openDilaog.Filter = "Microsoft Excel|*.xlsx|Все файлы|*.*";
            /// Настройка события при нажатие OK при работе с файлами системы
            openDilaog.FileOk += OpenDilaog_FileOk;
        }
        /// <summary>
        /// Переменная хранящая команду SQL
        /// </summary>
        public static string qVoucher = "select * from [dbo].[Voucher] inner join [dbo].[Additions_Services] on [Add_Service_ID] = [ID_Add_Service] inner join [dbo].[Type_Sending] on [Sending_ID] = [ID_Sending] inner join [dbo].[Add_Programs] on [Add_Programs_ID] = [ID_Add_Programs] inner join [dbo].[Hotel] on [Hotel_ID] = [ID_Hotel] inner join [dbo].[Type_Voucher] on [Type_Voucher_ID] = [ID_Type_Voucher] inner join [dbo].[Country] on [Country_ID] = [ID_Country]";
        /// <summary>
        /// Переменная хранящая название таблицы
        /// </summary>
        public static string tblVoucher = "Voucher";
        /// <summary>
        /// Лист для оперирования данными
        /// </summary>
        ArrayList values = new ArrayList();
        /// <summary>
        /// Класс для работы с файлами системы
        /// </summary>
        OpenFileDialog openDilaog = new OpenFileDialog();
        /// <summary>
        /// Переменная хранящая путь к выбраному файлу в системе
        /// </summary>
        string File_Path = string.Empty;
        /// <summary>
        /// Метод при загрузке окна
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Вызов класса для работы с БД
                DataBase dt = new DataBase();
                /// Запрос на выборку данных
                dt.DataSetFill(qVoucher, tblVoucher, DataBase.Function.select, null);
                /// Помещение данных БД в DataGrid
                datagrid.ItemsSource = DataBase.dataSet.Tables[tblVoucher].DefaultView;
            }
            catch (SqlException ex)
            {
                /// Вывод при ошибке
                MessageBox.Show(ex.Message);
            }
            /// Настройка отображения данных в DataGrid--------
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Описание";
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Visibility = Visibility.Hidden;
            datagrid.Columns[4].Visibility = Visibility.Hidden;
            datagrid.Columns[5].Visibility = Visibility.Hidden;
            datagrid.Columns[6].Visibility = Visibility.Hidden;
            datagrid.Columns[7].Visibility = Visibility.Hidden;
            datagrid.Columns[8].Header = "Стоимость путевки";
            datagrid.Columns[9].Header = "Дата отправления";
            datagrid.Columns[10].Visibility = Visibility.Hidden;
            datagrid.Columns[11].Header = "Стоимость доп. услуг";
            datagrid.Columns[12].Visibility = Visibility.Hidden;
            datagrid.Columns[13].Visibility = Visibility.Hidden;
            datagrid.Columns[14].Visibility = Visibility.Hidden;
            datagrid.Columns[15].Visibility = Visibility.Hidden;
            datagrid.Columns[16].Header = "Способ отправления";
            datagrid.Columns[17].Visibility = Visibility.Hidden;
            datagrid.Columns[18].Header = "Доп. программа";
            datagrid.Columns[19].Visibility = Visibility.Hidden;
            datagrid.Columns[20].Header = "Отель";
            datagrid.Columns[21].Visibility = Visibility.Hidden;
            datagrid.Columns[22].Visibility = Visibility.Hidden;
            datagrid.Columns[23].Header = "Тип путевки";
            datagrid.Columns[24].Visibility = Visibility.Hidden;
            datagrid.Columns[25].Header = "Страна";
            datagrid.Columns[26].Visibility = Visibility.Hidden;
            ///-------------------------------------------------
            /// Заполнение ComboBox внешними ключами для таблицы Voucher
            // Вызов класса для работы с БД
            DataBase dty = new DataBase();
            // Запрос на выборку данных из БД
            dty.DataSetFill("select * from [dbo].[Additions_Services]", "Additions_Services", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            AddServ.ItemsSource = DataBase.dataSet.Tables["Additions_Services"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            AddServ.SelectedValuePath = DataBase.dataSet.Tables["Additions_Services"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            AddServ.DisplayMemberPath = DataBase.dataSet.Tables["Additions_Services"].Columns[1].ColumnName;
            // Запрос на выборку данных из БД
            dty.DataSetFill("select * from [dbo].[Type_Sending]", "Type_Sending", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            Sending.ItemsSource = DataBase.dataSet.Tables["Type_Sending"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            Sending.SelectedValuePath = DataBase.dataSet.Tables["Type_Sending"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            Sending.DisplayMemberPath = DataBase.dataSet.Tables["Type_Sending"].Columns[1].ColumnName;
            // Запрос на выборку данных из БД
            dty.DataSetFill("select * from [dbo].[Add_Programs]", "Add_Programs", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            AddPrograms.ItemsSource = DataBase.dataSet.Tables["Add_Programs"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            AddPrograms.SelectedValuePath = DataBase.dataSet.Tables["Add_Programs"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            AddPrograms.DisplayMemberPath = DataBase.dataSet.Tables["Add_Programs"].Columns[1].ColumnName;
            // Запрос на выборку данных из БД
            dty.DataSetFill("select * from [dbo].[Hotel]", "Hotel", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            Hotel.ItemsSource = DataBase.dataSet.Tables["Hotel"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            Hotel.SelectedValuePath = DataBase.dataSet.Tables["Hotel"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            Hotel.DisplayMemberPath = DataBase.dataSet.Tables["Hotel"].Columns[1].ColumnName;
            // Запрос на выборку данных из БД
            dty.DataSetFill("select * from [dbo].[Type_Voucher]", "Type_Voucher", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            TVoucher.ItemsSource = DataBase.dataSet.Tables["Type_Voucher"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            TVoucher.SelectedValuePath = DataBase.dataSet.Tables["Type_Voucher"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            TVoucher.DisplayMemberPath = DataBase.dataSet.Tables["Type_Voucher"].Columns[1].ColumnName;
            // Вывод названия элемента в ComboBox
            dty.DataSetFill("select * from [dbo].[Country]", "Country", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            Country.ItemsSource = DataBase.dataSet.Tables["Country"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            Country.SelectedValuePath = DataBase.dataSet.Tables["Country"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            Country.DisplayMemberPath = DataBase.dataSet.Tables["Country"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод добавления данных
        /// </summary>
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            /// Очистка values от скопления данных
            values.Clear();
            /// Проверка поля на заполненность
            if (!string.IsNullOrEmpty(Description.Text))
            {
                /// Добавление записанного значения
                values.Add(Description.Text);
                /// Проверка поля на выбор значения
                if (AddServ.SelectedValue != null)
                {
                    /// Добавление выбраного значения из ComboBox
                    values.Add(AddServ.SelectedValue);
                    /// Проверка поля на выбор значения
                    if (Sending.SelectedValue != null)
                    {
                        /// Добавление выбраного значения из ComboBox
                        values.Add(Sending.SelectedValue);
                        /// Проверка поля на выбор значения
                        if (AddPrograms.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(AddPrograms.SelectedValue);
                            /// Проверка поля на выбор значения
                            if (Hotel.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(Hotel.SelectedValue);
                                /// Проверка поля на выбор значения
                                if (TVoucher.SelectedValue != null)
                                {
                                    /// Добавление выбраного значения из ComboBox
                                    values.Add(TVoucher.SelectedValue);
                                    /// Проверка поля на выбор значения
                                    if (Country.SelectedValue != null)
                                    {
                                        /// Добавление выбраного значения из ComboBox
                                        values.Add(Country.SelectedValue);
                                        /// Проверка поля на заполненность
                                        if (!string.IsNullOrEmpty(Coust.Text))
                                        {
                                            /// Добавление записанного значения
                                            values.Add(Coust.Text);
                                            /// Проверка поля на выбор значения
                                            if (DateP.SelectedDate != null)
                                            {
                                                /// Добавление выбраного значения из DataPicker
                                                values.Add(DateP.SelectedDate);
                                                /// Вызов класса для работы с БД
                                                DataBase dt = new DataBase();
                                                /// Запрос на добавление данных
                                                dt.DataSetFill(qVoucher, tblVoucher, DataBase.Function.insert, values);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Метод редактирования данных
        /// </summary>
        private void RedData_Click(object sender, RoutedEventArgs e)
        {
            /// Переменная для сохранения выбранной строки
            DataRowView rV = (DataRowView)datagrid.SelectedItems[0];
            /// Очистка values от скопления данных
            values.Clear();
            /// Преверка на наличие значения выбранной строки
            if (rV[0] != null)
            {
                /// Добавления значения выбранной строки
                values.Add(rV[0]);
                /// Проверка поля на заполненность
                if (!string.IsNullOrEmpty(Description.Text))
                {
                    /// Добавление записанного значения
                    values.Add(Description.Text);
                    /// Проверка поля на выбор значения
                    if (AddServ.SelectedValue != null)
                    {
                        /// Добавление выбраного значения из ComboBox
                        values.Add(AddServ.SelectedValue);
                        /// Проверка поля на выбор значения
                        if (Sending.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(Sending.SelectedValue);
                            /// Проверка поля на выбор значения
                            if (AddPrograms.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(AddPrograms.SelectedValue);
                                /// Проверка поля на выбор значения
                                if (Hotel.SelectedValue != null)
                                {
                                    /// Добавление выбраного значения из ComboBox
                                    values.Add(Hotel.SelectedValue);
                                    /// Проверка поля на выбор значения
                                    if (TVoucher.SelectedValue != null)
                                    {
                                        /// Добавление выбраного значения из ComboBox
                                        values.Add(TVoucher.SelectedValue);
                                        /// Проверка поля на выбор значения
                                        if (Country.SelectedValue != null)
                                        {
                                            /// Добавление выбраного значения из ComboBox
                                            values.Add(Country.SelectedValue);
                                            /// Проверка поля на заполненность
                                            if (!string.IsNullOrEmpty(Coust.Text))
                                            {
                                                /// Добавление записанного значения
                                                values.Add(Coust.Text);
                                                /// Проверка поля на выбор значения
                                                if (DateP.SelectedDate != null)
                                                {
                                                    /// Добавление выбраного значения из DataPicker
                                                    values.Add(DateP.SelectedDate);
                                                    /// Вызов класса для работы с БД
                                                    DataBase dt = new DataBase();
                                                    /// Запрос на добавление данных
                                                    dt.DataSetFill(qVoucher, tblVoucher, DataBase.Function.update, values);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Метод удаления данных
        /// </summary>
        private void DeleteData_Click(object sender, RoutedEventArgs e)
        {
            /// Вывод сообщения для подтверждения удаления
            switch (MessageBox.Show("Удалить выбранную запись?", "УДАЛИТЕЛЬ", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    /// Заполнение переменной выбранной строкой
                    DataRowView rV = (DataRowView)datagrid.SelectedItems[0];
                    /// Проверка на пустоту
                    if (rV[0] != null)
                    {
                        /// Очистка values от скопления данных
                        values.Clear();
                        /// Добавления значения выбранной строки в values
                        values.Add(rV[0]);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на удаление данных из БД
                        dt.DataSetFill(qVoucher, tblVoucher, DataBase.Function.delete, values);
                    }
                    else
                    {
                        /// Вывод сообщения при ошибке
                        MessageBox.Show("Выберите что хотите удалить!");
                    }
                    break;
            }
        }
        /// <summary>
        /// Анимация скрытия DataGrid при нажатие на кнопку Импорт
        /// </summary>
        private void ImportExport_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с анимацией
            ThicknessAnimation thickness = new ThicknessAnimation();
            /// Настройка значения от
            thickness.From = datagrid.Margin;
            /// Настройка значения до
            thickness.To = new Thickness(115, -250, 124.6, 452);
            /// Настройка значения скорости анимации
            thickness.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            datagrid.BeginAnimation(DataGrid.MarginProperty, thickness);
            /// Отображения кнопки Закрыть
            ZIMPEXP.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Анимация открытия DataGrid при нажатие на кнопку Закрыть
        /// </summary>
        private void ZIMPEXP_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с анимацией
            ThicknessAnimation thickness = new ThicknessAnimation();
            /// Настройка значения от
            thickness.From = datagrid.Margin;
            /// Настройка значения до
            thickness.To = new Thickness(115, 0, 124.6, 202);
            /// Настройка значения до
            thickness.Duration = TimeSpan.FromSeconds(4);
            /// Запуск анимации
            datagrid.BeginAnimation(DataGrid.MarginProperty, thickness);
            /// Скрытие кнопки Закрыть
            ZIMPEXP.Visibility = Visibility.Hidden;
        }
        /// <summary>
        /// Открытия диалогового окна для работы с файлами системы при нажатии на троеточие
        /// </summary>
        private void OPD_F_Click(object sender, RoutedEventArgs e)
        {
            /// Открытия диалогового окна для работы с файлами систем
            openDilaog.ShowDialog();
        }
        /// <summary>
        /// Событие при нажатие OK в диалоговом окне для работы с файлами системы
        /// </summary>
        private void OpenDilaog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            /// Сохранение в переменную пути к выбранному файлу
            File_Path = openDilaog.FileName;
        }
        /// <summary>
        /// Метод при нажатии на кнопку Выйти
        /// </summary>
        private void Exist_Click(object sender, RoutedEventArgs e)
        {
            /// Закрытия всего приложения
            App.Current.Shutdown();
        }
        /// <summary>
        /// Метод при нажатии на кнопку Авторизация
        /// </summary>
        private void Auto_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов класса для работы с реестром HKEY_CURRENT_USER
            RegistryKey registry = Registry.CurrentUser;
            /// Открытие или создание папки в HKEY_CURRENT_USER папки с названием DBSave
            RegistryKey key = registry.CreateSubKey("DBSave");
            try
            {
                /// Удаления значения ID
                key.DeleteValue("ID");
            }
            finally
            {
                /// Открытие окна MainWindow
                MainWindow main = new MainWindow();
                main.Show();
                /// Закрытие текущего окна
                Close();
            }
        }
        /// <summary>
        /// Метод при нажатии на кнопку Настройки
        /// </summary>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            /// Открытия окна ConfiguraTion
            ConfiguraTion fg = new ConfiguraTion();
            fg.ShowDialog();
        }
    }
}
