using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task11UC : UserControl
    {
        public Task11UC()
        {
            InitializeComponent();
        }

        private void BtnCount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;
                var numbers = TbNumbers.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (numbers.Length == 0)
                {
                    MessageBox.Show("Введите хотя бы одно число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int evenCount = 0;
                int oddCount = 0;

                foreach (var numStr in numbers)
                {
                    if (!int.TryParse(numStr, out int number))
                    {
                        MessageBox.Show($"Некорректное число: {numStr}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    if (number % 2 == 0)
                        evenCount++;
                    else
                        oddCount++;
                }

                TbEvenCount.Text = $"Четных чисел: {evenCount}";
                TbOddCount.Text = $"Нечетных чисел: {oddCount}";
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}