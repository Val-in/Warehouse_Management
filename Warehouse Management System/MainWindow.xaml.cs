using System.Windows;

namespace Warehouse_Management_System;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void EmployeeButton_OnClick(object sender, RoutedEventArgs e)
    {
        EmployeeView employeeView = new EmployeeView();
        employeeView.Show();   
        this.Close();
    }
}