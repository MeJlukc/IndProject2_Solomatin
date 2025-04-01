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
    /// Логика взаимодействия для Task5UC.xaml
    /// </summary>
    public partial class Task5UC : UserControl
    {
        #region Исходные данные
        private int[,] _array = new int[4, 4];
        #endregion

        public Task5UC()
        {
            InitializeComponent();
            InitializeArray();
        }

        private void InitializeArray()
        {
            Random random = new();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _array[i, j] = random.Next(10, 100);
                    TbFirsArray.Text += $"{_array[i, j]}\t";
                }
                TbFirsArray.Text += "\n";
            }
        }

        private void AnswerMatrix(int[,] matrix)
        {
            int n = (int)Math.Sqrt(matrix.Length);

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    TbSortedArray.Text += $"{matrix[i, j]}\t";
                }
                TbSortedArray.Text += "\n";
            }
        }
        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;
            AnswerMatrix(_array);
        }
    }
}
