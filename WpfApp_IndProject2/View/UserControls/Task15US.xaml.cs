using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task15UC : UserControl
    {
        public Task15UC()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = TbInputArray.Text.Trim();
                string[] binaryNumbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (binaryNumbers.Length == 0)
                {
                    MessageBox.Show("Пожалуйста, введите хотя бы одно двоичное число.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                foreach (string num in binaryNumbers)
                {
                    if (!num.All(c => c == '0' || c == '1'))
                    {
                        MessageBox.Show($"Число '{num}' не является двоичным.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                TbOriginalArray.Text = string.Join(" ", binaryNumbers);
                SpOriginalArray.Visibility = Visibility.Visible;

                int minIndex = 0, maxIndex = 0;
                int minValue = int.MaxValue, maxValue = int.MinValue;

                for (int i = 0; i < binaryNumbers.Length; i++)
                {
                    int currentValue = Convert.ToInt32(binaryNumbers[i], 2);

                    if (currentValue < minValue)
                    {
                        minValue = currentValue;
                        minIndex = i;
                    }

                    if (currentValue > maxValue)
                    {
                        maxValue = currentValue;
                        maxIndex = i;
                    }
                }

                if (binaryNumbers.Length > 1)
                {
                    string temp = binaryNumbers[minIndex];
                    binaryNumbers[minIndex] = binaryNumbers[maxIndex];
                    binaryNumbers[maxIndex] = temp;
                }

                TbModifiedArray.Text = string.Join(" ", binaryNumbers);
                SpModifiedArray.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}