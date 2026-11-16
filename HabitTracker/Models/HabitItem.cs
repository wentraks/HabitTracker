using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HabitTracker.Models;

public class HabitItem : INotifyPropertyChanged
{
    private bool _isCompleted;

    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (_isCompleted == value) return;
            _isCompleted = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}