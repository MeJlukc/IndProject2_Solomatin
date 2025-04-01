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
    /// Логика взаимодействия для Task3UC.xaml
    /// </summary>
    public partial class Task3UC : UserControl
    {
        #region Исходные данные
        private int[] _array = new int[10];
        #endregion

        public Task3UC()
        {
            InitializeComponent();
            InitializeArrays();
        }

        private void InitializeArrays()
        {
            Random random = new();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(-10, 12);
                TbfirsArray.Text += $" {_array[i]}";
            }
        }

        private void AnswerMethod()
        {
            int maxNumber = _array[0];
            int minNumber = _array[0];

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > maxNumber)
                {
                    maxNumber = _array[i];
                }
            }

            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < minNumber)
                {
                    minNumber = _array[i];
                }
            }
            MessageBox.Show($"Максимальное значение = {maxNumber}\nМинимальное значение = {minNumber}",
                            "Ответ к заданию 3",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);

        }
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            AnswerMethod();
        }
    }
}
