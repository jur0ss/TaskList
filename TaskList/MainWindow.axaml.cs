using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TaskList;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        
        AddTaskButton.Click += AddTaskButton_Click;
        DeleteTaskButton.Click += DeleteTaskButton_Click;
        // SummaryButton.Click += SummaryButton_Click;
    }

    private void AddTaskButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string taskName = (TaskName.Text ?? "").Trim();
        
        string person = (CharacterComboBox.SelectedItem as ListBoxItem)?.Content?.ToString() ?? "";
        
        string priority = "normalne";
        if (Low.IsChecked == true) priority = "niskie";
        else if (High.IsChecked == true) priority = "wysokie";

        string task = $"{person} - {taskName} [{priority}]";

        TaskListBox.Items.Add(task);

        TaskName.Text = "";
    }
    
    private void DeleteTaskButton_Click(object? sender, RoutedEventArgs e)
    {
        if (TaskListBox.SelectedItem != null)
        {
            TaskListBox.Items.Remove(TaskListBox.SelectedItem);
        }
    }
    
    
    
}