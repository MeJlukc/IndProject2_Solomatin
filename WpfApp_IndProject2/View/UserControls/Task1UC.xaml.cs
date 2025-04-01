using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp_IndProject2.View.UserControls
{
    /// <summary>
    /// Логика взаимодействия для Task1UC.xaml
    /// </summary>
    public partial class Task1UC : UserControl
    {
        #region
        private int[] _firstArray = new int[10];
        #endregion
        public Task1UC()
        {
            InitializeComponent();
            InitializeArrays();
        }
        private void InitializeArrays()
        {
            Random random = new();
            for (int i = 0; i < _firstArray.Length; i++)
            {
                _firstArray[i] = random.Next(-10, 12);
                TbFirsArray.Text += $" {_firstArray[i]}";
            }
        }

        private void ВtnGetNewArray_Click(object sender, RoutedEventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;
            _firstArray = Array.FindAll(_firstArray, (f) => f >= 0);
            Array.Sort(_firstArray);

            for (int i = 0; i < _firstArray.Length; i++)
            {
                TbNewArray.Text += $" {_firstArray[i]}";
            }
        }

    }
}
