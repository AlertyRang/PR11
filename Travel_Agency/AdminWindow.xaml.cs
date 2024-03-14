using System.Windows;
using System.Data;
using System.Collections;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Лист для опирированием значениями
        /// </summary>
        ArrayList values = new ArrayList();
        /// <summary>
        /// Переменяя хранящая название таблицы
        /// </summary>
        public string FF { get; set; }
        /// <summary>
        /// Переменная хранящая команду sql для запроса
        /// </summary>
        public string FK { get; set; }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Add_Programs_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Add_Programs";
            FK = "select * from [dbo].[Add_Programs]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Программы";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Additions_Services_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Additions_Services";
            FK = "select * from [dbo].[Additions_Services] inner join [dbo].[Meals] on [Meals_ID] = [ID_Meals] inner join [dbo].[Car] on [Car_ID] = [ID_Car] inner join [dbo].[Excursion] on [Excursion_ID] = [ID_Excursion]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Cумма";
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Visibility = Visibility.Hidden;
            datagrid.Columns[4].Visibility = Visibility.Hidden;
            datagrid.Columns[5].Visibility = Visibility.Hidden;
            datagrid.Columns[6].Header = "Вид трапезы";
            datagrid.Columns[7].Visibility = Visibility.Hidden;
            datagrid.Columns[8].Header = "Бренд машины";
            datagrid.Columns[9].Visibility = Visibility.Hidden;
            datagrid.Columns[10].Header = "Маршруты Экскурсий";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Car_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Car";
            FK = "select * from [dbo].[Car]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Бренд";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void City_Fill(object sender, RoutedEventArgs e)
        {
            FF = "City";
            FK = "select * from [dbo].[City]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Название";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Combination_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Combination";
            FK = "select * from [dbo].[Combination] inner join [dbo].[Job_Staff] on [Job_Staff_ID] = [ID_Job_Staff] inner join [dbo].[Staff] on [Staff_ID] = [ID_Staff]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Visibility = Visibility.Hidden;
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Visibility = Visibility.Hidden;
            datagrid.Columns[4].Header = "Должность";
            datagrid.Columns[5].Visibility = Visibility.Hidden;
            datagrid.Columns[6].Header = "Фамилия";
            datagrid.Columns[7].Visibility = Visibility.Hidden;
            datagrid.Columns[8].Header = "Имя";
            datagrid.Columns[9].Header = "Отчество";
            datagrid.Columns[10].Visibility = Visibility.Hidden;
            datagrid.Columns[11].Visibility = Visibility.Hidden;
            datagrid.Columns[12].Visibility = Visibility.Hidden;
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Country_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Country";
            FK = "select * from [dbo].[Country] inner join [dbo].[City] on [City_ID] = [ID_City]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Страна";
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Visibility = Visibility.Hidden;
            datagrid.Columns[4].Header = "Город";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Excursion_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Excursion";
            FK = "select * from [dbo].[Excursion]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Виды";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Firm_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Firm";
            FK = "select * from [dbo].[Firm]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Название";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Hotel_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Hotel";
            FK = "select * from [dbo].[Hotel] inner join [dbo].[Number] on [Number_ID] = [ID_Number]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Название отелей";
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Visibility = Visibility.Hidden;
            datagrid.Columns[4].Header = "Категория номеров";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Job_Staff_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Job_Staff";
            FK = "select * from [dbo].[Job_Staff]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Название";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Meals_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Meals";
            FK = "select * from [dbo].[Meals]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Тип";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Number_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Number";
            FK = "select * from [dbo].[Number]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Категория";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Staff_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Staff";
            FK = "select * from [dbo].[Staff] inner join [dbo].[Firm] on [Firm_ID] = [ID_Firm]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Фамилия";
            datagrid.Columns[2].Visibility = Visibility.Hidden;
            datagrid.Columns[3].Header = "Имя";
            datagrid.Columns[4].Header = "Отчество";
            datagrid.Columns[5].Header = "Логин";
            datagrid.Columns[6].Visibility = Visibility.Hidden;
            datagrid.Columns[7].Visibility = Visibility.Hidden;
            datagrid.Columns[8].Header = "Фирма";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Type_Sending_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Type_Sending";
            FK = "select * from [dbo].[Type_Sending]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Способ отправки";
            ///----------------------------------------------------------
        }
        /// <summary>
        /// Медот для заполнения DataGrid взависимости от выбранной таблицы
        /// </summary>
        private void Type_Voucher_Fill(object sender, RoutedEventArgs e)
        {
            FF = "Type_Voucher";
            FK = "select * from [dbo].[Type_Voucher]";
            /// Вызов класса для работы с БД
            DataBase dt = new DataBase();
            /// Запрос на выборку данных из БД
            dt.DataSetFill(FK, FF, DataBase.Function.select, null);
            /// Заполнение DataGrid данными
            datagrid.ItemsSource = DataBase.dataSet.Tables[FF].DefaultView;
            /// Редактирование отображения данных в DataGrid
            datagrid.Columns[0].Visibility = Visibility.Hidden;
            datagrid.Columns[1].Header = "Тип";
            ///----------------------------------------------------------
        }

        /// <summary>
        /// Медот для кнопки добавить
        /// </summary>
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов окна Add
            Add add = new Add();
            add.Global = FF;
            add.Global2 = "Add";
            add.Global3 = FK;
            add.ShowDialog();
        }
        /// <summary>
        /// Медот для кнопки изменить
        /// </summary>
        private void RedData_Click(object sender, RoutedEventArgs e)
        {
            /// Заполнение переменной выбранной строкой
            DataRowView rV = (DataRowView)datagrid.SelectedItems[0];
            /// Проверка на пустоту
            if (rV[0] != null)
            {
                /// Вызов окна Add
                Add ad = new Add();
                ad.row = rV;
                ad.Global = FF;
                ad.Global2 = "Red";
                ad.Global3 = FK;
                ad.Title = "Изменить";
                ad.ShowDialog();
            }
        }
        /// <summary>
        /// Медот для кнопки удалить
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
                        dt.DataSetFill(FK, FF, DataBase.Function.delete, values);
                    }
                    else
                    {
                        MessageBox.Show("Выберите что хотите удалить!");
                    }
                    break;
            }
        }
        /// <summary>
        /// Медот для кнопки выйти
        /// </summary>
        private void Exist_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов окна main
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }
        /// <summary>
        /// Медот для кнопки настройки
        /// </summary>
        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов окна ConfiguraTion
            ConfiguraTion cnf = new ConfiguraTion();
            cnf.ShowDialog();
        }
    }
}
