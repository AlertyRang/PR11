using System.Windows;

namespace Travel_Agency
{
    /// <summary>
    /// Логика взаимодействия для ConfiguraTion.xaml
    /// </summary>
    public partial class ConfiguraTion : Window
    {
        public ConfiguraTion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для кнопки SQL подключение
        /// </summary>
        private void OS_MON_Click(object sender, RoutedEventArgs e)
        {
            /// Вызов окна ConfigurationWindow
            ConfigurationWindow conf = new ConfigurationWindow();
            conf.ShowDialog();
        }
    }
}
