using System.Collections;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Security;

namespace Travel_Agency
{
    class DataBase
    {
        public static string DS = "null", IC = "null", LogSQL="null", PassSQL = "null";
        private SqlConnection connection = new SqlConnection(string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = true;", DS, IC));
        public static DataSet dataSet = new DataSet();

        private DataTable dtAdd_Programs = new DataTable("Add_Programs");
        private DataTable dtAdditions_Services = new DataTable("Additions_Services");
        private DataTable dtCar = new DataTable("Car");
        private DataTable dtCity = new DataTable("City");
        private DataTable dtCombination = new DataTable("Combination");
        private DataTable dtCountry = new DataTable("Country");
        private DataTable dtExcursion = new DataTable("Excursion");
        private DataTable dtFirm = new DataTable("Firm");
        private DataTable dtHotel = new DataTable("Hotel");
        private DataTable dtJob_Staff = new DataTable("Job_Staff");
        private DataTable dtMeals = new DataTable("Meals");
        private DataTable dtNumber = new DataTable("Number");
        private DataTable dtStaff = new DataTable("Staff");
        private DataTable dtType_Sending = new DataTable("Type_Sending");
        private DataTable dtType_Voucher = new DataTable("Type_Voucher");
        private DataTable dtVoucher = new DataTable("Voucher");

        public enum Function { select, insert, update, delete };

        public bool SQL()
        {
            dataSet.Tables.Clear();
            SqlConnection conect = new SqlConnection(string.Format("Data Source = {0}; Initial Catalog = {1}; Integrated Security = false;", DS, IC));
            System.Windows.Controls.PasswordBox txtPwd = new System.Windows.Controls.PasswordBox();
            txtPwd.Password = PassSQL;
            SecureString pwd = txtPwd.SecurePassword;
            pwd.MakeReadOnly();
            SqlCredential cred = new SqlCredential(LogSQL, pwd);
            conect.Credential = cred;
            try
            {
                conect.Open();

                dataSet.Tables.Add(dtAdd_Programs);
                dataSet.Tables.Add(dtAdditions_Services);
                dataSet.Tables.Add(dtCar);
                dataSet.Tables.Add(dtCity);
                dataSet.Tables.Add(dtCombination);
                dataSet.Tables.Add(dtCountry);
                dataSet.Tables.Add(dtExcursion);
                dataSet.Tables.Add(dtFirm);
                dataSet.Tables.Add(dtHotel);
                dataSet.Tables.Add(dtJob_Staff);
                dataSet.Tables.Add(dtMeals);
                dataSet.Tables.Add(dtNumber);
                dataSet.Tables.Add(dtStaff);
                dataSet.Tables.Add(dtType_Sending);
                dataSet.Tables.Add(dtType_Voucher);
                dataSet.Tables.Add(dtVoucher);

                return true;
            }

            catch
            {
                return false;
            }
            finally
            {
                conect.Close();
            }
        }

        public bool connection_Checking()
        {
            dataSet.Tables.Clear();
            try
            {
                connection.Open();

                dataSet.Tables.Add(dtAdd_Programs);
                dataSet.Tables.Add(dtAdditions_Services);
                dataSet.Tables.Add(dtCar);
                dataSet.Tables.Add(dtCity);
                dataSet.Tables.Add(dtCombination);
                dataSet.Tables.Add(dtCountry);
                dataSet.Tables.Add(dtExcursion);
                dataSet.Tables.Add(dtFirm);
                dataSet.Tables.Add(dtHotel);
                dataSet.Tables.Add(dtJob_Staff);
                dataSet.Tables.Add(dtMeals);
                dataSet.Tables.Add(dtNumber);
                dataSet.Tables.Add(dtStaff);
                dataSet.Tables.Add(dtType_Sending);
                dataSet.Tables.Add(dtType_Voucher);
                dataSet.Tables.Add(dtVoucher);

                return true;
            }

            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Метод работы с любым запросом DML SQL
        /// </summary>
        /// <param name="SQLQuery">Обязательный запрос на выборку данных</param>
        /// <param name="TableName">Обязательная результирующая таблица</param>
        /// <param name="function">Вид манипуляции select, insert, update, delete</param>
        /// <param name="valueList">Коллекция передаваемых значений, если select то передать null</param>
        public void DataSetFill(string SQLQuery, string TableName, Function function, ArrayList valueList)
        {
            //Создание экземпляра класса Адаптера - включает в себя свойства и методыв по выборке, добавлению, изменению и удалению данных, в конструкторе данный запрос помещается в свойство SelectCommand
            SqlDataAdapter adapter = new SqlDataAdapter(SQLQuery, connection);
            //Создание экземпляра класса кэш таблицы для выборки объектов из базы данных
            DataTable table = new DataTable();
            //Создание экзмепляра класса обработчика SQL команд, для выборки данных об объектах базы данных
            SqlCommand command = new SqlCommand("", connection);
            try
            {
                connection.Open();
                //Отчистка, в кэше данных, у указанной таблицы, столбцов, для избежания аккамулирования столбцов
                dataSet.Tables[TableName].Columns.Clear();
                //Отчистка, в кэше данных, у указанной таблицы, строк, для избежания аккамулирования строк
                dataSet.Tables[TableName].Rows.Clear();
                //Переключатель на выполнение одного из 4 действий
                switch (function)
                {
                    case Function.select:
                        //Заполнение, в кэше данных, указанной таблицы, запросом на выборку данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.insert:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод и где поля не имеют свойство is_identity 1, то есть не являются PK
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}') and is_identity <> 1", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки запроса на добавление данных в указанную таблицу
                        string insertquery = string.Format("insert into [dbo].[{0}] (", TableName);
                        //Организация цикла, для заполнения названия толбцов в соотвествии с запросом на выборку названий столбцов конкретной таблицы
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            insertquery += string.Format(" [{0}]", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленное поле не последнее в цикле, если да то ставим после названия столбца запятую 
                            if (i < table.Rows.Count - 1)
                                insertquery += ",";
                        }
                        //Дополнение строки запроса на выборку данных, командой values, которая раздеяет область описания столбцов и параметров
                        insertquery += ") values (";
                        //Организация цикла, для заполнения названия параметров к соотвествующим столбцам таблицы, куда будут добавлены данные
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Дополнение запроса новыми параметрами
                            insertquery += string.Format(" @{0}", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленный параметр не последнее в цикле, если да то ставим после названия параметра запятую 
                            if (i < table.Rows.Count - 1)
                                insertquery += ",";
                        }
                        //Дополнение запроса на добавление данных, закрывающей скобкой
                        insertquery += ")";
                        //Присвоение полученного запроса в свойство InsertCommand, через инициализацию нового обработчика SQL корманд
                        adapter.InsertCommand = new SqlCommand(insertquery);
                        //Инициализация свойству InsertCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.InsertCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства InsertCommand, для избежания аккамулирования параметров
                        adapter.InsertCommand.Parameters.Clear();
                        //Организация цикла для присвоения полученного списка значений в параметры запроса на добавление данных
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Добавление, в коллекцию свойства InsertCommand, значений в параметры по его названию
                            adapter.InsertCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[i][0]), valueList[i]);
                        }
                        //Выполнение вложенного запроса на добавление данных
                        adapter.InsertCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.update:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}')", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки для изменения данных в указанной таблице базы данных
                        string updatequery = string.Format("update [dbo].[{0}] set", TableName);
                        //Организация цикла, для дополнения строки изменения базы данных, с учётом того, что цикл начинается не с 0-ой строки (PK), а с неключевых элементов данных
                        for (int i = 1; i <= table.Rows.Count - 1; i++)
                        {
                            //Дполнение запроса на изменение данных, строкой присвоения к полю таблицы, соответствующего параметра
                            updatequery += string.Format(" {0} = @{0}", table.Rows[i][0]);
                            //Проверка на то, является ли перечисленное поле не последнее в цикле, если да то ставим после названия поля запятую
                            if (i < table.Rows.Count - 1)
                                updatequery += ",";
                        }
                        //Дополнение запроса на изменение данных, условием и присвоением в поле первичного ключа соответствующего параметра
                        updatequery += string.Format(" where {0} = @{0}", table.Rows[0][0]);
                        //Присвоение полученного запроса в свойство UpdateCommand, через инициализацию нового обработчика SQL корманд
                        adapter.UpdateCommand = new SqlCommand(updatequery);
                        //Инициализация свойству UpdateCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.UpdateCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства UpdateCommand, для избежания аккамулирования параметров
                        adapter.UpdateCommand.Parameters.Clear();
                        //Организация цикла для присвоения полученного списка значений в параметры запроса на изменение данных
                        for (int i = 0; i <= table.Rows.Count - 1; i++)
                        {
                            //Добавление, в коллекцию свойства UpdateCommand, значений в параметры по его названию
                            adapter.UpdateCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[i][0]), valueList[i]);
                        }
                        //Выполнение вложенного запроса на изменение данных
                        adapter.UpdateCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                    case Function.delete:
                        //Формирование запроса на выборку объектов базы данных, а именно столбцов таблиц, с фильтрацией, где id таблицы равен введённому названию в метод и где поля имеют свойство is_identity 1, то есть являются PK
                        command.CommandText = string.Format("select name from sys.columns where object_id = (select object_id from sys.tables where name = '{0}') and is_identity = 1", TableName);
                        //Заполнение кэш таблицы, реузльтатом выборки обектов из БД
                        table.Load(command.ExecuteReader());
                        //Формирование строки запроса на удаление данных из указанной таблицы базы данных
                        string deletequery = string.Format("delete from [dbo].[{0}] where [{1}] = @{1}", TableName, table.Rows[0][0]);
                        //Присвоение полученного запроса в свойство DeleteCommand, через инициализацию нового обработчика SQL корманд
                        adapter.DeleteCommand = new SqlCommand(deletequery);
                        //Инициализация свойству DeleteCommand, свойству Connection экземпляра класса SQLConnection
                        adapter.DeleteCommand.Connection = connection;
                        //Принудительная отчистка параметров у свойства DeleteCommand, для избежания аккамулирования параметров
                        adapter.DeleteCommand.Parameters.Clear();
                        //Добавление в коллекцию свойства DeleteCommand значения с названием параметра для дальнейшего удаления данных
                        adapter.DeleteCommand.Parameters.AddWithValue(string.Format("@{0}", table.Rows[0][0]), valueList[0]);
                        //Выполнение вложенного запроса на удаление данных
                        adapter.DeleteCommand.ExecuteNonQuery();
                        //Перезапись кэш таблицы, с помощью запроса на выборку данных, для визуального обновления данных
                        adapter.Fill(dataSet.Tables[TableName]);
                        break;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "-");
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
