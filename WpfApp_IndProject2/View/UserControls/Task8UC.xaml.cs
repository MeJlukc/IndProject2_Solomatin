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
    /// Логика взаимодействия для Task8UC.xaml
    /// </summary>
    public partial class Task8UC : UserControl
    {
        #region Исходные данные
        private double[] _array = new double[16];
        #endregion

        public Task8UC()
        {
            InitializeComponent();
            InitializeArrays();
        }

        private void InitializeArrays()
        {
            Random random = new();

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = Math.Round(random.NextDouble(), 1);
                TbFirsArray.Text += $" {_array[i]}";
            }
        }

        static int RoundToInt(double x)
        {
            return (int)(x + 0.5);
        }

        private int MaxAbs(int[] arr)
        {
            int maxAbs = Math.Abs(arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) > maxAbs)
                {
                    maxAbs = Math.Abs(arr[i]);
                }
            }
            return maxAbs;
        }
        private void BtnAnswer_Click(object sender, RoutedEventArgs e)
        {
            SpNewArray.Visibility = Visibility.Visible;
            SpMax.Visibility = Visibility.Visible;

            int[] arrInt = new int[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                arrInt[i] = RoundToInt(_array[i]);
            }

            int maxAbs = MaxAbs(arrInt);

            TbSortedArray.Text = "";
            for (int i = 0; i < arrInt.Length; i++)
            {
                TbSortedArray.Text += $" {arrInt[i]}";
            }

            TbMax.Text = $"{maxAbs}";
        }
    }
}
