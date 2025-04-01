using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task28UC : UserControl
    {
        public Task28UC()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;

                string[] binaryArray = TbBinaryArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (binaryArray.Length == 0)
                {
                    MessageBox.Show("Введите двоичные числа в массив!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (string num in binaryArray)
                {
                    if (!IsBinary(num))
                    {
                        MessageBox.Show($"Число '{num}' не является двоичным!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                string binaryD = TbBinaryD.Text.Trim();

                if (string.IsNullOrEmpty(binaryD) || !IsBinary(binaryD))
                {
                    MessageBox.Show("Введите корректное двоичное число D!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int decimalD = Convert.ToInt32(binaryD, 2);

                var farthest = binaryArray
                    .Select((binary, index) => new
                    {
                        Binary = binary,
                        Decimal = Convert.ToInt32(binary, 2),
                        Index = index,
                        Distance = Math.Abs(Convert.ToInt32(binary, 2) - decimalD)
                    })
                    .OrderByDescending(x => x.Distance)
                    .First();

                TbResultBinary.Text = farthest.Binary;
                TbResultDecimal.Text = farthest.Decimal.ToString();
                TbResultPosition.Text = (farthest.Index + 1).ToString();
                TbResultDistance.Text = farthest.Distance.ToString();

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsBinary(string number)
        {
            return number.All(c => c == '0' || c == '1');
        }
    }
}