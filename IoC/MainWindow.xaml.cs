using IoC.Views;
using System;
using System.Windows;

namespace IoC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void ShowWindow(Type windowType)
        {
            var window = Activator.CreateInstance(windowType);
            if (window is Window targetWindow)
                targetWindow.ShowDialog();
        }
        private void Learn01(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(Learn001));
        }

        private void Learn02(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(Learn002));
        }

        private void Learn03(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(Learn003));
        }

        private void Learn04(object sender, RoutedEventArgs e)
        {
            ShowWindow(typeof(Learn004));
        }
    }
}
