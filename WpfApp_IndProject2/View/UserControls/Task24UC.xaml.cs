using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task24UC : UserControl
    {
        public Task24UC()
        {
            InitializeComponent();
        }

        private void BtnShift_Click(object sender, RoutedEventArgs e)
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

                string lastNum = binaryNumbers[binaryNumbers.Length - 1];
                string[] shiftedArray = new string[binaryNumbers.Length];
                Array.Copy(binaryNumbers, 0, shiftedArray, 1, binaryNumbers.Length - 1);
                shiftedArray[0] = lastNum;

                TbOriginal.Text = $"Исходный массив: {string.Join(" ", binaryNumbers)}";
                TbShifted.Text = $"После сдвига: {string.Join(" ", shiftedArray)}";
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}