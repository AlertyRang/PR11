using System.Windows;
using System.Collections;
using System.Data;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Переменная для сохранения выбранной строки
        /// </summary>
        public DataRowView row { get; set; }
        /// <summary>
        /// Лист для опирированием значениями
        /// </summary>
        ArrayList values = new ArrayList();
        /// <summary>
        /// Переменяя хранящая название таблицы
        /// </summary>
        public string Global { get; set; }
        /// <summary>
        /// Переменая для обозначения какая кнопка была нажата добавить или редактировать
        /// </summary>
        public string Global2 { get; set; }
        /// <summary>
        /// Переменная хранящая команду sql для запроса
        /// </summary>
        public string Global3 { get; set; }
        /// <summary>
        /// Метод для измениния окна под таблицу Add_Programs
        /// </summary>
        private void Add_Programs_Form()
        {
            L_One.Content = "Название:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
        }
        /// <summary>
        /// Метод для измениния окна под таблицу Add_Services
        /// </summary>
        private void Add_Services_Form()
        {
            L_One.Content = "Сумма:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            L_Two.Content = "Вид трапезы:";
            L_Two.IsEnabled = true;
            CB_Two.Visibility = Visibility.Visible;
            L_Four.Content = "Бренд машины:";
            L_Four.IsEnabled = true;
            CB_Four.Visibility = Visibility.Visible;
            L_Five.Content = "Маршруты:";
            L_Five.IsEnabled = true;
            CB_Five.Visibility = Visibility.Visible;

            /// Заполнение ComboBox внешними ключами для таблицы Add_Programs
            // Класс для работы с БД
            DataBase dt = new DataBase();
            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Meals]", "Meals", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Two.ItemsSource = DataBase.dataSet.Tables["Meals"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Two.SelectedValuePath = DataBase.dataSet.Tables["Meals"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Two.DisplayMemberPath = DataBase.dataSet.Tables["Meals"].Columns[1].ColumnName;

            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Car]", "Car", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Four.ItemsSource = DataBase.dataSet.Tables["Car"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Four.SelectedValuePath = DataBase.dataSet.Tables["Car"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Four.DisplayMemberPath = DataBase.dataSet.Tables["Car"].Columns[1].ColumnName;

            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Excursion]", "Excursion", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Five.ItemsSource = DataBase.dataSet.Tables["Excursion"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Five.SelectedValuePath = DataBase.dataSet.Tables["Excursion"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Five.DisplayMemberPath = DataBase.dataSet.Tables["Excursion"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Car
        /// </summary>
        private void Car_Form()
        {
            L_One.Content = "Бренд:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 20;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу City
        /// </summary>
        private void City_Form()
        {
            L_One.Content = "Название:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 50;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Combination
        /// </summary>
        private void Combination_Form()
        {
            L_One.Content = "Должность:";
            L_One.IsEnabled = true;
            CB_One_V2.Visibility = Visibility.Visible;
            L_Two.Content = "Сотрудник:";
            L_Two.IsEnabled = true;
            CB_Two_V2.Visibility = Visibility.Visible;

            /// Заполнение ComboBox внешними ключами для таблицы Combination
            // Класс для работы с БД
            DataBase dt = new DataBase();
            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Job_Staff]", "Job_Staff", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_One_V2.ItemsSource = DataBase.dataSet.Tables["Job_Staff"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_One_V2.SelectedValuePath = DataBase.dataSet.Tables["Job_Staff"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_One_V2.DisplayMemberPath = DataBase.dataSet.Tables["Job_Staff"].Columns[1].ColumnName;

            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Staff]", "Staff", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Two_V2.ItemsSource = DataBase.dataSet.Tables["Staff"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Two_V2.SelectedValuePath = DataBase.dataSet.Tables["Staff"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Two_V2.DisplayMemberPath = DataBase.dataSet.Tables["Staff"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Country
        /// </summary>
        private void Country_Form()
        {
            L_One.Content = "Страна:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 50;
            L_Two.Content = "Город:";
            L_Two.IsEnabled = true;
            CB_Two_V3.Visibility = Visibility.Visible;

            /// Заполнение ComboBox внешними ключами для таблицы Country
            // Класс для работы с БД
            DataBase dt = new DataBase();
            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[City]", "City", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Two_V3.ItemsSource = DataBase.dataSet.Tables["City"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Two_V3.SelectedValuePath = DataBase.dataSet.Tables["City"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Two_V3.DisplayMemberPath = DataBase.dataSet.Tables["City"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Excursion
        /// </summary>
        private void Excursion_Form()
        {
            L_One.Content = "Виды:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 50;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Firm
        /// </summary>
        private void Firm_Form()
        {
            L_One.Content = "Название:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 50;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Hotel
        /// </summary>
        private void Hotel_Form()
        {
            L_One.Content = "Название:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 30;
            L_Two.Content = "Номера:";
            L_Two.IsEnabled = true;
            CB_Two_V4.Visibility = Visibility.Visible;

            /// Заполнение ComboBox внешними ключами для таблицы Hotel
            // Класс для работы с БД
            DataBase dt = new DataBase();
            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Number]", "Number", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Two_V4.ItemsSource = DataBase.dataSet.Tables["Number"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Two_V4.SelectedValuePath = DataBase.dataSet.Tables["Number"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Two_V4.DisplayMemberPath = DataBase.dataSet.Tables["Number"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Job_Staff
        /// </summary>
        private void Job_Staff_Form()
        {
            L_One.Content = "Название:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 50;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Meals
        /// </summary>
        private void Meals_Form()
        {
            L_One.Content = "Тип:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 30;
            L_Two.Content = "Время:";
            L_Two.IsEnabled = true;
            TB_Two.IsEnabled = true;
            TB_Two.MaxLength = 5;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Number
        /// </summary>
        private void Number_Form()
        {
            L_One.Content = "Категория:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 20;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Staff
        /// </summary>
        private void Staff_Form()
        {
            L_One.Content = "Фамилия:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 30;
            L_Two.Content = "Имя:";
            L_Two.IsEnabled = true;
            TB_Two.IsEnabled = true;
            TB_Two.MaxLength = 30;
            L_Three.Content = "Отчество:";
            L_Three.IsEnabled = true;
            TB_Three.IsEnabled = true;
            TB_Three.MaxLength = 30;
            L_Four.Content = "Логин:";
            L_Four.IsEnabled = true;
            TB_Four.IsEnabled = true;
            TB_Four.MaxLength = 32;
            L_Five.Content = "Фирма:";
            L_Five.IsEnabled = true;
            CB_Five_V2.Visibility = Visibility.Visible;

            /// Заполнение ComboBox внешними ключами для таблицы Staff
            // Класс для работы с БД
            DataBase dt = new DataBase();
            // Запрос на выборку данных
            dt.DataSetFill("select * from [dbo].[Firm]", "Firm", DataBase.Function.select, null);
            // Перемещение данных из таблицы в ComboBox
            CB_Five_V2.ItemsSource = DataBase.dataSet.Tables["Firm"].DefaultView;
            // Присваиваение значния элементу ComboBox значение PK ключа
            CB_Five_V2.SelectedValuePath = DataBase.dataSet.Tables["Firm"].Columns[0].ColumnName;
            // Вывод названия элемента в ComboBox
            CB_Five_V2.DisplayMemberPath = DataBase.dataSet.Tables["Firm"].Columns[1].ColumnName;
            ///-------------------------------------------------------------------------------------
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Type_Sending
        /// </summary>
        private void Type_Sending_Form()
        {
            L_One.Content = "Способ:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 20;
        }
        /// <summary>
        /// Метод для измениния онка под таблицу Type_Voucher
        /// </summary>
        private void Type_Voucher_Form()
        {
            L_One.Content = "Тип:";
            L_One.IsEnabled = true;
            TB_One.IsEnabled = true;
            TB_One.MaxLength = 15;
        }

        /// <summary>
        /// Метод взависимости от переменной Global прогружает нужную форму
        /// </summary>
        private void Window(object sender, RoutedEventArgs e)
        {
            switch (Global)
            {
                case "Add_Programs":
                    Add_Programs_Form();
                    break;
                case "Additions_Services":
                    Add_Services_Form();
                    break;
                case "Car":
                    Car_Form();
                    break;
                case "City":
                    City_Form();
                    break;
                case "Combination":
                    Combination_Form();
                    break;
                case "Country":
                    Country_Form();
                    break;
                case "Excursion":
                    Excursion_Form();
                    break;
                case "Firm":
                    Firm_Form();
                    break;
                case "Hotel":
                    Hotel_Form();
                    break;
                case "Job_Staff":
                    Job_Staff_Form();
                    break;
                case "Meals":
                    Meals_Form();
                    break;
                case "Number":
                    Number_Form();
                    break;
                case "Staff":
                    Staff_Form();
                    break;
                case "Type_Sending":
                    Type_Sending_Form();
                    break;
                case "Type_Voucher":
                    Type_Voucher_Form();
                    break;
            }
        }

        /// <summary>
        /// Метод добавления и редактирования БД
        /// </summary>
        private void Add_Data()
        {
            /// Взависимости от значения Global2 выбираеться редактирование или добавление
            if (Global2 == "Add")
            {
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Add_Programs")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Additions_Services")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Проверка поля на выбор значения
                        if (CB_Two.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(CB_Two.SelectedValue);
                            /// Проверка поля на выбор значения
                            if (CB_Four.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Four.SelectedValue);
                                /// Проверка поля на выбор значения
                                if (CB_Five.SelectedValue != null)
                                {
                                    /// Добавление выбраного значения из ComboBox
                                    values.Add(CB_Five.SelectedValue);
                                    /// Вызов класса для работы с БД
                                    DataBase dt = new DataBase();
                                    /// Запрос на добавление данных
                                    dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                                }
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Car")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "City")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Combination")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на выбор значения
                    if (CB_One_V2.SelectedValue != null)
                    {
                        values.Add(CB_One_V2.SelectedValue);
                        /// Проверка поля на выбор значения
                        if (CB_Two_V2.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(CB_Two_V2.SelectedValue);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Country")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Проверка поля на выбор значения
                        if (CB_Two_V3.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(CB_Two_V3.SelectedValue);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Excursion")
                {
                    /// Добавление записанного значения
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Firm")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Hotel")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Проверка поля на выбор значения
                        if (CB_Two_V4.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(CB_Two_V4.SelectedValue);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Job_Staff")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Meals")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_Two.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_Two.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Number")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Staff")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Проверка поля на выбор значения
                        if (CB_Five_V2.SelectedValue != null)
                        {
                            /// Добавление выбраного значения из ComboBox
                            values.Add(CB_Five_V2.SelectedValue);
                            /// Проверка поля на заполненность
                            if (!string.IsNullOrEmpty(TB_Two.Text))
                            {
                                /// Добавление записанного значения
                                values.Add(TB_Two.Text);
                                /// Проверка поля на заполненность
                                if (!string.IsNullOrEmpty(TB_Three.Text))
                                {
                                    /// Добавление записанного значения
                                    values.Add(TB_Three.Text);
                                    /// Проверка поля на заполненность
                                    if (!string.IsNullOrEmpty(TB_Four.Text))
                                    {
                                        /// Добавление записанного значения
                                        values.Add(TB_Four.Text);
                                        /// Записи стандартного пароля
                                        values.Add("Pa$$w0rd");
                                        /// Вызов класса для работы с БД
                                        DataBase dt = new DataBase();
                                        /// Запрос на добавление данных
                                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                                    }
                                }
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Type_Sending")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Type_Voucher")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Проверка поля на заполненность
                    if (!string.IsNullOrEmpty(TB_One.Text))
                    {
                        /// Добавление записанного значения
                        values.Add(TB_One.Text);
                        /// Вызов класса для работы с БД
                        DataBase dt = new DataBase();
                        /// Запрос на добавление данных
                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                    }
                }
            }
            /// Взависимости от значения Global2 выбираеться редактирование или добавление
            if (Global2 == "Red")
            {
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Add_Programs")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Additions_Services")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Проверка поля на выбор значения
                            if (CB_Two.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Two.SelectedValue);
                                /// Проверка поля на выбор значения
                                if (CB_Four.SelectedValue != null)
                                {
                                    /// Добавление выбраного значения из ComboBox
                                    values.Add(CB_Four.SelectedValue);
                                    /// Проверка поля на выбор значения
                                    if (CB_Five.SelectedValue != null)
                                    {
                                        /// Добавление выбраного значения из ComboBox
                                        values.Add(CB_Five.SelectedValue);
                                        /// Вызов класса для работы с БД
                                        DataBase dt = new DataBase();
                                        /// Запрос на добавление данных
                                        dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                                    }
                                }
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Car")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "City")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Combination")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на выбор значения
                        if (CB_One_V2.SelectedValue != null)
                        {
                            values.Add(CB_One_V2.SelectedValue);
                            /// Проверка поля на выбор значения
                            if (CB_Two_V2.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Two_V2.SelectedValue);
                                /// Вызов класса для работы с БД
                                DataBase dt = new DataBase();
                                /// Запрос на добавление данных
                                dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Country")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Проверка поля на выбор значения
                            if (CB_Two_V3.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Two_V3.SelectedValue);
                                /// Вызов класса для работы с БД
                                DataBase dt = new DataBase();
                                /// Запрос на добавление данных
                                dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Excursion")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Firm")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Hotel")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Проверка поля на выбор значения
                            if (CB_Two_V4.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Two_V4.SelectedValue);
                                /// Вызов класса для работы с БД
                                DataBase dt = new DataBase();
                                /// Запрос на добавление данных
                                dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Job_Staff")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Meals")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Проверка поля на заполненность
                            if (!string.IsNullOrEmpty(TB_Two.Text))
                            {
                                /// Добавление записанного значения
                                values.Add(TB_Two.Text);
                                /// Вызов класса для работы с БД
                                DataBase dt = new DataBase();
                                /// Запрос на добавление данных
                                dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Number")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Staff")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Проверка поля на выбор значения
                            if (CB_Five_V2.SelectedValue != null)
                            {
                                /// Добавление выбраного значения из ComboBox
                                values.Add(CB_Five_V2.SelectedValue);
                                /// Проверка поля на заполненность
                                if (!string.IsNullOrEmpty(TB_Two.Text))
                                {
                                    /// Добавление записанного значения
                                    values.Add(TB_Two.Text);
                                    /// Проверка поля на заполненность
                                    if (!string.IsNullOrEmpty(TB_Three.Text))
                                    {
                                        /// Добавление записанного значения
                                        values.Add(TB_Three.Text);
                                        /// Проверка поля на заполненность
                                        if (!string.IsNullOrEmpty(TB_Four.Text))
                                        {
                                            /// Добавление записанного значения
                                            values.Add(TB_Four.Text);
                                            /// Записи стандартного пароля
                                            values.Add("Pa$$w0rd");
                                            /// Вызов класса для работы с БД
                                            DataBase dt = new DataBase();
                                            /// Запрос на добавление данных
                                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Type_Sending")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
                /// Взависимости от переменной Global определяеться нужная таблица
                if (Global == "Type_Voucher")
                {
                    /// Очистка values от скопления данных
                    values.Clear();
                    /// Преверка на наличие значения выбранной строки
                    if (row[0] != null)
                    {
                        /// Добавления значения выбранной строки
                        values.Add(row[0]);
                        /// Проверка поля на заполненность
                        if (!string.IsNullOrEmpty(TB_One.Text))
                        {
                            /// Добавление записанного значения
                            values.Add(TB_One.Text);
                            /// Вызов класса для работы с БД
                            DataBase dt = new DataBase();
                            /// Запрос на добавление данных
                            dt.DataSetFill(Global3, Global, DataBase.Function.insert, values);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Метод для кнопки подтвердить
        /// </summary>
        private void Comf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Add_Data();
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так...");
            }
            finally
            {
                Close();
            }
        }

        /// <summary>
        /// Метод для кнопки отмена
        /// </summary>
        private void Can_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}