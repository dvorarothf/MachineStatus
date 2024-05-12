using System;
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
using System.Windows.Shapes;

namespace MachineStatusApp
{
    /// <summary>
    /// Interaction logic for MachineStatusView.xaml
    /// </summary>
    public partial class MachineStatusView : Window
    {
        public MachineStatusView()
        {
            InitializeComponent();
            var vm = new MachineStatusViewModel();
            vm.Init();
            DataContext = vm;
        }
    }
}
