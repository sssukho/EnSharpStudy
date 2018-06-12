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
using System.IO;


namespace WindowsExplorer
{
    /// <summary>
    /// TreeStructureControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TreeStructureControl : UserControl
    {
        private object dummyNode = null;
        ContentControl contentControl;
        AddressControl addressControl;

        public TreeStructureControl(ContentControl contentControl, AddressControl addressControl)
        {
            InitializeComponent();
            InitializeTree();
            this.contentControl = contentControl;
            this.addressControl = addressControl;
        }

        public void InitializeTree()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady)
                {
                    TreeViewItem treeViewItem = new TreeViewItem();
                    treeViewItem.Header = drive;
                    treeViewItem.Tag = drive;
                    treeViewItem.FontWeight = FontWeights.Normal;
                    treeViewItem.Items.Add(dummyNode);
                    treeViewItem.Expanded += new RoutedEventHandler(FolderExpanded);
                    treeView.Items.Add(treeViewItem);
                }
            }
        }

        public void FolderExpanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            //contentControl.currentPath = item.Tag.ToString();
            string currentPath = item.Tag.ToString();

            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                DirectoryInfo directoryInfo = new DirectoryInfo(item.Tag.ToString());
                
                foreach(DirectoryInfo directory in directoryInfo.GetDirectories())
                {
                    if(directory.Attributes.ToString().Contains("Directory") && !directory.Attributes.ToString().Contains("Hidden"))
                    {
                        TreeViewItem subItem = new TreeViewItem();
                        subItem.Header = directory.Name;
                        subItem.Tag = directory.FullName;
                        subItem.FontWeight = FontWeights.Normal;
                        subItem.Items.Add(dummyNode);
                        subItem.Expanded += new RoutedEventHandler(FolderExpanded);
                        item.Items.Add(subItem);
                    }
                }
                contentControl.SetIcon(currentPath);
            }
        }
    }
}
