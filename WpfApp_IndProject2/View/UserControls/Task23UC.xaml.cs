using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task23UC : UserControl
    {
        public Task23UC()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
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

                int start = Math.Min(minIndex, maxIndex);
                int end = Math.Max(minIndex, maxIndex);
                int countBetween = end - start - 1;

                TbMaxMinInfo.Text = $"Max: {binaryNumbers[maxIndex]} (позиция {maxIndex + 1})\n" +
                                    $"Min: {binaryNumbers[minIndex]} (позиция {minIndex + 1})";

                if (countBetween > 0)
                {
                    TbCountBetween.Text = $"Количество между ними: {countBetween}";
                }
                else if (countBetween == 0)
                {
                    TbCountBetween.Text = "Между ними нет элементов (стоят рядом)";
                }
                else
                {
                    TbCountBetween.Text = "Это один и тот же элемент";
                }

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}