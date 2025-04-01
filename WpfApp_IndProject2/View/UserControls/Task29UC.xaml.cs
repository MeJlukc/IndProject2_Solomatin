using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task29UC : UserControl
    {
        public Task29UC()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;

                string positiveBinary = TbPositiveNumber.Text.Trim();
                string negativeBinary = TbNegativeNumber.Text.Trim();

                if (string.IsNullOrEmpty(positiveBinary) || !IsPositiveBinary(positiveBinary))
                {
                    MessageBox.Show("Введите корректное положительное двоичное число!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (string.IsNullOrEmpty(negativeBinary) || !IsNegativeBinary(negativeBinary))
                {
                    MessageBox.Show("Введите корректное отрицательное двоичное число (дополнительный код)!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int positiveDecimal = Convert.ToInt32(positiveBinary, 2);
                int negativeDecimal = ConvertFromTwosComplement(negativeBinary);

                int sum = positiveDecimal + negativeDecimal;

                string binaryResult = Convert.ToString(sum, 2);
                string resultType = sum >= 0 ? "Положительное" : "Отрицательное";

                TbBinaryResult.Text = binaryResult;
                TbDecimalResult.Text = sum.ToString();
                TbResultType.Text = resultType;

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вычислениях: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsPositiveBinary(string number)
        {
            return number.Length > 0 &&
                   number.All(c => c == '0' || c == '1') &&
                   !number.StartsWith("0") && number != "0";         
        }

        private bool IsNegativeBinary(string number)
        {
            return number.Length > 0 &&
                   number.All(c => c == '0' || c == '1') &&
                   number.StartsWith("1");
        }

        private int ConvertFromTwosComplement(string binary)
        {
            if (binary[0] == '0')
                return Convert.ToInt32(binary, 2);

            int value = Convert.ToInt32(binary, 2);
            int mask = (1 << binary.Length) - 1;
            return -(~value & mask);
        }
    }
}