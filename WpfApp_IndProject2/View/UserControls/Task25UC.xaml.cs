using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task25UC : UserControl
    {
        public Task25UC()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
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

                int originalSum = binaryNumbers.Sum(num => Convert.ToInt32(num, 2));

                string firstNum = binaryNumbers[0];
                string[] shiftedArray = new string[binaryNumbers.Length];
                Array.Copy(binaryNumbers, 1, shiftedArray, 0, binaryNumbers.Length - 1);
                shiftedArray[shiftedArray.Length - 1] = firstNum;

                int shiftedSum = shiftedArray.Sum(num => Convert.ToInt32(num, 2));

                TbOriginalArray.Text = $"Исходный массив: {string.Join(" ", binaryNumbers)}";
                TbShiftedArray.Text = $"После сдвига: {string.Join(" ", shiftedArray)}";
                TbOriginalSum.Text = $"Сумма исходного: {originalSum} (двоичная: {Convert.ToString(originalSum, 2)})";
                TbShiftedSum.Text = $"Сумма после сдвига: {shiftedSum} (двоичная: {Convert.ToString(shiftedSum, 2)})";

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}