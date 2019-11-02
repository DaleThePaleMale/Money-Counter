using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Money_Counter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Earned { get; private set; }
        public int Spent { get; private set; }

        int[] sequence = { 1, 5, 10, 50, 100, 500 };

        public MainWindow()
        {
            InitializeComponent();
            ConstructGrids();
            ConstructButtons();
        }

        void ConstructGrids()
        {
            foreach (int seq in sequence)
            {
                EarnedButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                SpentButtonsGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            foreach (ColumnDefinition columnDefinition in EarnedButtonsGrid.ColumnDefinitions)
                columnDefinition.Width = new GridLength(0.5, GridUnitType.Star);
            foreach (ColumnDefinition columnDefinition in SpentButtonsGrid.ColumnDefinitions)
                columnDefinition.Width = new GridLength(0.5, GridUnitType.Star);

            EarnedButtonsGrid.RowDefinitions.Add(new RowDefinition());
            EarnedButtonsGrid.RowDefinitions.Add(new RowDefinition());
            foreach (RowDefinition rowDefinition in EarnedButtonsGrid.RowDefinitions)
                rowDefinition.Height = new GridLength(0.5, GridUnitType.Star);
            SpentButtonsGrid.RowDefinitions.Add(new RowDefinition());
            SpentButtonsGrid.RowDefinitions.Add(new RowDefinition());
            foreach (RowDefinition rowDefinition in SpentButtonsGrid.RowDefinitions)
                rowDefinition.Height = new GridLength(0.5, GridUnitType.Star);
        }

        void ConstructButtons()
        {
            int col = 0, row = 0;
            foreach (int seq in sequence)
            {
                AddSubtractButton addSubtractButton = new AddSubtractButton(seq);
                addSubtractButton.Click += (sender, args) => AddSubtractEarned(addSubtractButton.Value);
                Grid.SetColumn(addSubtractButton, col);
                Grid.SetRow(addSubtractButton, row);
                EarnedButtonsGrid.Children.Add(addSubtractButton);
                col++;
            }
            col = 0;
            row++;
            foreach (int seq in sequence)
            {
                AddSubtractButton addSubtractButton = new AddSubtractButton(-seq);
                addSubtractButton.Click += (sender, args) => AddSubtractEarned(addSubtractButton.Value);
                Grid.SetColumn(addSubtractButton, col);
                Grid.SetRow(addSubtractButton, row);
                EarnedButtonsGrid.Children.Add(addSubtractButton);
                col++;
            }
            col = 0;
            row = 0;
            foreach (int seq in sequence)
            {
                AddSubtractButton addSubtractButton = new AddSubtractButton(seq);
                addSubtractButton.Click += (sender, args) => AddSubtractSpent(addSubtractButton.Value);
                Grid.SetColumn(addSubtractButton, col);
                Grid.SetRow(addSubtractButton, row);
                SpentButtonsGrid.Children.Add(addSubtractButton);
                col++;
            }
            col = 0;
            row++;
            foreach (int seq in sequence)
            {
                AddSubtractButton addSubtractButton = new AddSubtractButton(-seq);
                addSubtractButton.Click += (sender, args) => AddSubtractSpent(addSubtractButton.Value);
                Grid.SetColumn(addSubtractButton, col);
                Grid.SetRow(addSubtractButton, row);
                SpentButtonsGrid.Children.Add(addSubtractButton);
                col++;
            }
        }

        public void AddSubtractEarned(int value)
        {
            Earned += value;
            AmountEarned.Content = "$" + Earned.ToString();
        }

        public void AddSubtractSpent(int value)
        {
            Spent += value;
            AmountSpent.Content = "$" + Spent.ToString();
        }

        class AddSubtractButton : Button
        {
            public int Value { get; private set; }

            public AddSubtractButton(int value)
            {
                this.Value = value;
                if (value > 0)
                    this.Content = "+$" + value.ToString();
                else
                    this.Content = "-$" + Math.Abs(value).ToString();

                Height = 20;
                Width = 40;
            }
        }
    }
}