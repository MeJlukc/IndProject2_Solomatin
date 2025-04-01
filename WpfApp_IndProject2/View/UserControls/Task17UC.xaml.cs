using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task17UC : UserControl
    {
        public Task17UC()
        {
            InitializeComponent();
        }

        private void BtnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string binaryNumber = TbBinaryNumber.Text.Trim();

                if (string.IsNullOrEmpty(binaryNumber))
                {
                    MessageBox.Show("Введите двоичное число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!binaryNumber.All(c => c == '0' || c == '1'))
                {
                    MessageBox.Show("Число должно содержать только 0 и 1!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                char lastChar = binaryNumber[binaryNumber.Length - 1];
                string shiftedNumber = lastChar + binaryNumber.Substring(0, binaryNumber.Length - 1);

                int originalDecimal = Convert.ToInt32(binaryNumber, 2);
                int shiftedDecimal = Convert.ToInt32(shiftedNumber, 2);
                int sumDecimal = originalDecimal + shiftedDecimal;
                string sumBinary = Convert.ToString(sumDecimal, 2);

                TbOriginalNumber.Text = $"Исходное число: {binaryNumber} (в десятичной: {originalDecimal})";
                TbShiftedNumber.Text = $"После сдвига: {shiftedNumber} (в десятичной: {shiftedDecimal})";
                TbDecimalSum.Text = $"Сумма (десятичная): {sumDecimal}";
                TbBinarySum.Text = $"Сумма (двоичная): {sumBinary}";

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}