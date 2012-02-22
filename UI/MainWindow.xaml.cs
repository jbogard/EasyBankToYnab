using System;
using System.Windows;
using QuestMaster.EasyBankRepository.Domain.EasyBankRepository;

namespace QuestMaster.EasyBankRepository.UI
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

    private void UpdateDataContext(MainFormViewModel value)
    {
      MainFormViewModel viewModel = this.ViewModel;
      if (!object.ReferenceEquals(viewModel, null))
      {
        viewModel.Exit -= this.ViewModelExit;
      }
      base.DataContext = value;
      MainFormViewModel objA = this.ViewModel;
      if (!object.ReferenceEquals(objA, null))
      {
        objA.Exit += this.ViewModelExit;
      }
    }

    private void ViewModelExit(object sender, EventArgs e)
    {
      base.Close();
    }

    public MainFormViewModel ViewModel
    {
      get
      {
        return this.DataContext as MainFormViewModel;
      }

      set
      {
        this.UpdateDataContext(value);
      }
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      var viewModel = this.ViewModel;

      if (viewModel != null)
      {
        viewModel.LoadDataContextFromDefaultPath();
      }
    }
  }
}
