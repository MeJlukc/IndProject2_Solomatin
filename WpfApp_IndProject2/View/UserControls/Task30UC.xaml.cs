using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task30UC : UserControl
    {
        public class BinaryResult
        {
            public string DecimalValue { get; set; }
            public string BinaryValue { get; set; }
        }

        public Task30UC()
        {
            InitializeComponent();
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;
                ResultsList.ItemsSource = null;

                string[] numbers = TbDecimalArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length != 3)
                {
                    MessageBox.Show("Введите ровно 3 числа!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                List<BinaryResult> results = new List<BinaryResult>();
                foreach (string numStr in numbers)
                {
                    if (!int.TryParse(numStr, out int number))
                    {
                        MessageBox.Show($"Некорректное число: {numStr}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    results.Add(new BinaryResult
                    {
                        DecimalValue = number.ToString(),
                        BinaryValue = ConvertToBinary(number)
                    });
                }

                ResultsList.ItemsSource = results;
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при преобразовании: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string ConvertToBinary(int number)
        {
            if (number < 0)
            {
                return Convert.ToString(number, 2).PadLeft(8, '1');
            }
            return Convert.ToString(number, 2);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}