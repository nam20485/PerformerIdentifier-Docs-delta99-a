namespace PerformerIdentifier.App.ViewModels;

/// <summary>
/// Main window view model providing application state and commands.
/// </summary>
public partial class MainWindowViewModel : ViewModelBase
{
    /// <summary>
    /// Gets the greeting message displayed in the main window.
    /// </summary>
    public string Greeting { get; } = "Welcome to Performer Identifier!";
}
