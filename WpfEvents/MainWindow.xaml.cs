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

namespace WpfEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnEvent1.Click += Btn_DynamicClick;

            for (int i = 0; i < 10; i++)
            {
                Button dynamicButton = new Button
                {
                    Name = $"btnDynamic{i+1}",
                    Content = $"Dynamic Button {i+1}",
                    Height = 50,
                };
                dynamicButton.Click += Btn_DynamicClick;
                spButtons.Children.Add(dynamicButton);
            }
            
        }

        private void BtnEvent1_Click(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Add($"{((Button)sender).Name} Clicked.");

        }

        private void Btn_DynamicClick(object sender, RoutedEventArgs e)
        {
            lstMessages.Items.Add($"{((Button)sender).Name} Dynamically Clicked.");
        }
    }
}
