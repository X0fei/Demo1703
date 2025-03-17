using Avalonia.Controls;
using Demo1703.Models;
using System.Collections.Generic;

namespace Demo1703;

public partial class MainWindow : Window
{
    private List<Product> displayList = Utils.Context.products;
    public MainWindow()
    {
        InitializeComponent();
        ProductListBox.ItemsSource = displayList;
    }
}