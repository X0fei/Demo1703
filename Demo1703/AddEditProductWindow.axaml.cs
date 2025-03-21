using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo1703.Context;
using Demo1703.Models;
using System;
using System.Collections.Generic;

namespace Demo1703;

public partial class AddEditProductWindow : Window
{
    public AddEditProductWindow()
    {
        InitializeComponent();
        Title = "Мастер Пол — Добавление товара";
        Article.Text = ArticleGeneration();
        TypeComboBox.ItemsSource = Utils.Context.productTypes;
        AddEditProductButton.Content = "Добавить товар";
    }

    public AddEditProductWindow(int id)
    {
        InitializeComponent();
        Title = "Мастер Пол — Редактирование товара";
        TypeComboBox.ItemsSource = Utils.Context.productTypes;
        AddEditProductButton.Content = "Отредакировать товар";
    }

    private string ArticleGeneration()
    {
        Random random = new Random();
        bool wrongArticle = false;
        int article;

        do
        {
            article = random.Next();
            foreach (Product product in Utils.Context.products)
            {
                int productArticle = 0;
                int.TryParse(product.Article, out productArticle);
                if (article == productArticle)
                {
                    wrongArticle = true;
                    break;
                }
            }
        }
        while (wrongArticle);

        return Convert.ToString(article);
    }

    private void AddEditProductButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (MinimalCost.Value != null && TypeComboBox.SelectedIndex != null && Name.Text != null)
        {
            Product product = new Product()
            {
                Article = Article.Text,
                Name = Name.Text,
                Type = TypeComboBox.SelectedIndex + 1,
                MinimalCost = (decimal)MinimalCost.Value
            };
            using (var context = new User18Context())
            {
                context.Add(product);
                context.SaveChanges();
            }
            Utils.Context.products = new List<Product>(Utils.Context.DbContext.Products);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
        else
        {

        }
    }
}