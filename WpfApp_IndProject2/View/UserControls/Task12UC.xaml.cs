using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp_IndProject2.View.UserControls
{
    public partial class Task12UC : UserControl
    {
        public Task12UC()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SpResult.Visibility = Visibility.Collapsed;
                var lines = TbMatrix.Text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Введите матрицу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int count = 0;
                string positions = "";
                int rowNum = 1;

                foreach (var line in lines)
                {
                    var numbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    int colNum = 1;

                    foreach (var numStr in numbers)
                    {
                        if (numStr == "7")
                        {
                            count++;
                            positions += $"Строка {rowNum}, Колонка {colNum}\n";
                        }
                        colNum++;
                    }
                    rowNum++;
                }

                TbResult.Text = count > 0
                    ? $"Найдено {count} вхождений числа 7:\n{positions}"
                    : "Число 7 не найдено в матрице";

                SpResult.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}