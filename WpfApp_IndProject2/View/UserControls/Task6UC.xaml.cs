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
    /// Логика взаимодействия для Task6UC.xaml
    /// </summary>
    public partial class Task6UC : UserControl
    {
        #region Исходные данные
        private int[] _array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        #endregion

        public Task6UC()
        {
            InitializeComponent();
            InitializeArray();
        }

        private void InitializeArray()
        {
            for (int i = 0; i < _array.Length; i++)
            {
                TbFirsArray.Text += $" {_array[i]}";
            }
        }

        private int[,] AnswerMatrix(int[] arr)
        {
            int size = (int)Math.Sqrt(arr.Length * 2);
            int[,] matrix = new int[size, size];
            int index = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = arr[index];
                    index++;
                }
            }
            return matrix;
        }
        private void BtnAnswer_Click(object sender, EventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;

            int[,] matrix = AnswerMatrix(_array);

            for (int i = 0;i < matrix.GetLength(0); i++)
            {
                for (int j = 0;j < matrix.GetLength(1); j++)
                {
                    TbSortedArray.Text += $"{matrix[i, j]}\t";
                }
                TbSortedArray.Text += "\n";
            }
        }
    }
}
