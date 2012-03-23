using System;
using System.Windows;

namespace QuestMaster.EasyBankToYnab.UI
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    public MainFormViewModel ViewModel
    {
      get { return this.DataContext as MainFormViewModel; }
      set { this.DataContext = value; }
    }

    private void ViewModelExit(object sender, EventArgs e)
    {
      this.Close();
    }

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
      var viewModel = this.ViewModel;

      if (viewModel != null)
      {
        viewModel.LoadDataContextFromDefaultPath();
      }
    }

    private void WindowDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      MainFormViewModel oldViewModel = e.OldValue as MainFormViewModel;
      if (!ReferenceEquals(oldViewModel, null))
      {
        oldViewModel.Exit -= this.ViewModelExit;
      }

      MainFormViewModel newViewModel = e.NewValue as MainFormViewModel;
      if (!ReferenceEquals(newViewModel, null))
      {
        newViewModel.Exit += this.ViewModelExit;
      }
    }
  }
}
