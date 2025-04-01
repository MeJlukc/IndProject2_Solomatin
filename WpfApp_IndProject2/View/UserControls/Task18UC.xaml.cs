using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task18UC : UserControl
    {
        public Task18UC()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] numbers = TbInputArray.Text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                if (numbers.Length < 2)
                {
                    MessageBox.Show("Введите минимум 2 числа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int increasingSum = 0;
                int decreasingSum = 0;
                int currentSum = numbers[0];
                bool isIncreasing = false;
                bool isDecreasing = false;

                for (int i = 1; i < numbers.Length; i++)
                {
                    if (numbers[i] > numbers[i - 1])
                    {
                        if (!isIncreasing)
                        {
                            if (isDecreasing)
                            {
                                decreasingSum += currentSum;
                                currentSum = numbers[i - 1];
                            }
                            isIncreasing = true;
                            isDecreasing = false;
                        }
                        currentSum += numbers[i];
                    }
                    else if (numbers[i] < numbers[i - 1])
                    {
                        if (!isDecreasing)
                        {
                            if (isIncreasing)
                            {
                                increasingSum += currentSum;
                                currentSum = numbers[i - 1];
                            }
                            isDecreasing = true;
                            isIncreasing = false;
                        }
                        currentSum += numbers[i];
                    }
                    else
                    {
                        if (isIncreasing) increasingSum += currentSum;
                        if (isDecreasing) decreasingSum += currentSum;
                        currentSum = numbers[i];
                        isIncreasing = false;
                        isDecreasing = false;
                    }
                }

                if (isIncreasing) increasingSum += currentSum;
                if (isDecreasing) decreasingSum += currentSum;

                int difference = increasingSum - decreasingSum;

                TbIncreasingSum.Text = $"Сумма возрастающих участков: {increasingSum}";
                TbDecreasingSum.Text = $"Сумма убывающих участков: {decreasingSum}";
                TbDifference.Text = $"Разность: {difference}";
                SpResult.Visibility = Visibility.Visible;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод! Используйте целые числа, разделенные пробелами.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}