using HabitTracker.Models;

namespace HabitTracker;

public partial class MainPage : ContentPage
{
    private readonly List<HabitItem> _tasks = new();
    private int _nextId = 1;

    public MainPage()
    {
        InitializeComponent();
        LoadTestData();
        RefreshList();
    }

    // Временная коллекция тестовых задач
    private void LoadTestData()
    {
        string[] titles =
        {
            "Изучить XAML",
            "Выполнить практическую работу",
            "Повторить C#",
            "Подготовить проект"
        };

        foreach (var title in titles)
        {
            _tasks.Add(new HabitItem { Id = _nextId++, Title = title });
        }

        // Одна задача выполнена, чтобы сразу увидеть визуальное отличие
        _tasks[0].IsCompleted = true;
    }

    // Обновление списка с учётом переключателя
    private void RefreshList()
    {
        TasksView.ItemsSource = HideCompletedSwitch.IsToggled
            ? _tasks.Where(t => !t.IsCompleted).ToList()
            : _tasks.ToList();
    }

    // Добавление новой задачи
    private void OnAddClicked(object? sender, EventArgs e)
    {
        var title = TaskEntry.Text?.Trim();
        if (string.IsNullOrEmpty(title))
            return;

        _tasks.Add(new HabitItem { Id = _nextId++, Title = title });
        TaskEntry.Text = string.Empty;
        RefreshList();
    }

    // Переключатель «Скрыть выполненные»
    private void OnHideCompletedToggled(object? sender, ToggledEventArgs e)
    {
        RefreshList();
    }
}