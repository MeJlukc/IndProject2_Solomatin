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
    /// Логика взаимодействия для Task7UC.xaml
    /// </summary>
    public partial class Task7UC : UserControl
    {
        #region Исходные данные
        private int[] _array = new int[16];
        #endregion

        public Task7UC()
        {
            InitializeComponent();
            InitializeArrays();
        }

        private void InitializeArrays()
        {
            Random random = new();

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(1, 10);
                TbFirsArray.Text += $" {_array[i]}";
            }
        }

        private void BtnAnswer_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;

            Array.Sort(_array);
            int[,] matrix = new int[4, 4];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = _array[i * matrix.GetLength(1) + j];
                }
            }
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    TbSortedArray.Text += $"{matrix[i, j]}\t";
                }
                TbSortedArray.Text += "\n";
            }
        }
    }
}
