using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Media;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WindowsExplorer
{
    /// <summary>
    /// TreeStructureControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TreeStructureControl : UserControl
    {
        public TreeStructureControl()
        {
            InitializeComponent();
            InitializeView();
        }

        public void InitializeView()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            
            foreach (DriveInfo drive in allDrives)
            {
                if(drive.IsReady)
                {
                    TreeViewItem treeViewItem = new TreeViewItem
                    {
                        Header = drive,
                        Tag = drive
                    };
                    treeView.Items.Add(treeViewItem);
                    treeViewItem.FontWeight = FontWeights.Normal;

                    treeViewItem.Expanded += new RoutedEventHandler(FolderExpanded);
                }
            }
        }

        public void FolderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            
            item.Items.Clear();
            foreach (string directory in Directory.GetDirectories(item.Tag.ToString()))
            {
                TreeViewItem subitem = new TreeViewItem();
                subitem.Header = directory.Substring(directory.LastIndexOf("\\") + 1);
                subitem.Tag = directory;
                subitem.FontWeight = FontWeights.Normal;
                subitem.Expanded += new RoutedEventHandler(TreeViewItemSelected);
                item.Items.Add(subitem);
            }

        }

        public void TreeViewItemSelected(object sender, RoutedEventArgs e)
        {

        }
    }
}
