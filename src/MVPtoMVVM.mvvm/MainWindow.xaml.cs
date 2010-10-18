using System.Windows;
using MVPtoMVVM.mvvm.viewmodels;
using StructureMap;

namespace MVPtoMVVM.mvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = ObjectFactory.GetInstance<MainWindowViewModel>();
        }

        public MainWindowViewModel ViewModel
        {
            get { return (MainWindowViewModel) DataContext; }
            set { DataContext = value; }
        }
    }
}