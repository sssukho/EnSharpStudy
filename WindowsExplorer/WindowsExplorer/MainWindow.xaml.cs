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
using System.Windows.Navigation;


namespace WindowsExplorer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        AddressControl addressControl;
        TreeStructureControl treeStructureControl;
        ContentControl contentControl;

        public MainWindow()
        {
            InitializeComponent();
            addressControl = new AddressControl();
            contentControl = new ContentControl();
            treeStructureControl = new TreeStructureControl(contentControl, addressControl);
            InitializeView();
        }

        public void InitializeView()
        {
            Address.Children.Add(addressControl);
            IconContent.Children.Add(contentControl);
            TreeStructure.Children.Add(treeStructureControl);
        }
    }
}
