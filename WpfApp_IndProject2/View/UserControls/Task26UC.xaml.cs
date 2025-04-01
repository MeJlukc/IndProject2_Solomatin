using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task26UC : UserControl
    {
        private const string BinaryToAdd = "1010";
        private readonly int DecimalToAdd = Convert.ToInt32(BinaryToAdd, 2);

        public Task26UC()
        {
            InitializeComponent();
        }

        private void BtnIncrease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] binaryNumbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (binaryNumbers.Length == 0)
                {
                    MessageBox.Show("Введите хотя бы одно число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (string num in binaryNumbers)
                {
                    if (!num.All(c => c == '0' || c == '1'))
                    {
                        MessageBox.Show($"Число '{num}' не является двоичным!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                string[] increasedNumbers = binaryNumbers.Select(num =>
                {
                    int decimalValue = Convert.ToInt32(num, 2);
                    int increasedValue = decimalValue + DecimalToAdd;
                    return Convert.ToString(increasedValue, 2);
                }).ToArray();

                TbOriginalNumbers.Text = $"Исходные числа: {string.Join(" ", binaryNumbers)}";
                TbIncreasedNumbers.Text = $"После увеличения на {BinaryToAdd}: {string.Join(" ", increasedNumbers)}";
                SpResult.Visibility = Visibility.Visible;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Результат превысил максимальное значение!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}