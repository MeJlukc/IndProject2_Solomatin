using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task13UC : UserControl
    {
        public Task13UC()
        {
            InitializeComponent();
        }

        private void BtnFindMax_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;
                MaxResultsList.ItemsSource = null;

                var lines = TbMatrix.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Введите матрицу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var matrix = new List<List<double>>();
                foreach (var line in lines)
                {
                    var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var row = new List<double>();

                    foreach (var numStr in numbers)
                    {
                        if (!double.TryParse(numStr, out double number))
                        {
                            MessageBox.Show($"Некорректное число: {numStr}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        row.Add(number);
                    }
                    matrix.Add(row);
                }

                if (matrix.Any(row => row.Count != matrix[0].Count))
                {
                    MessageBox.Show("Все строки должны иметь одинаковую длину!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var results = new List<string>();
                for (int col = 0; col < matrix[0].Count; col++)
                {
                    double max = matrix[0][col];
                    for (int row = 1; row < matrix.Count; row++)
                    {
                        if (matrix[row][col] > max)
                            max = matrix[row][col];
                    }
                    results.Add($"Столбец {col + 1}: Максимум = {max}");
                }

                MaxResultsList.ItemsSource = results;
                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}