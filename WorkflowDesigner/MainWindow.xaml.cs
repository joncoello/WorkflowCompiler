using System;
using System.Activities.Core.Presentation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Workflow.Designer {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        
        private MainWindowViewModel _viewModel;
        
        public MainWindow(MainWindowViewModel viewModel) {
            InitializeComponent();

            _viewModel = viewModel;
            this.DataContext = viewModel;

            // Register the metadata
            RegisterMetadata();

        }


        private void RegisterMetadata() {
            DesignerMetadata dm = new DesignerMetadata();
            dm.Register();
        }

        private void cmdRun_Click(object sender, RoutedEventArgs e) {
            _viewModel.RunClicked();
        }

        private void cmdNew_Click(object sender, RoutedEventArgs e) {
            _viewModel.NewClicked();
        }

        private void cmdLoad_Click(object sender, RoutedEventArgs e) {
            _viewModel.LoadClicked();
        }

        private void cmdSave_Click(object sender, RoutedEventArgs e) {
            _viewModel.SaveClicked();
        }

    }
}
