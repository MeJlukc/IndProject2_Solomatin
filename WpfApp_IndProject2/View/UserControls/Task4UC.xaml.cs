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
    /// Логика взаимодействия для Task4UC.xaml
    /// </summary>
    public partial class Task4UC : UserControl
    {
        #region Исходные данные
        private int[] _array = new int[16];
        #endregion

        public Task4UC()
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

        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;
            int[,] newArray = new int[4, 4];

            for (int i = 0; i < 16; i++)
            {
                newArray[i / 4, i % 4] = _array[i]; // Исправлено на i % 4 для правильного заполнения матрицы
            }

            ToSortedArray.Text = ""; // Очистка текстового поля перед выводом нового массива
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ToSortedArray.Text += $"{newArray[i, j]}\t"; // Исправлено на \t для табуляции
                }
                ToSortedArray.Text += "\n";
            }
        }
    }
}
