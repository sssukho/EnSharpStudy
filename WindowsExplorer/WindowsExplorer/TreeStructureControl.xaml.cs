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

        public TreeStructureControl()
        {
            InitializeComponent();
            InitializeTree();
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
            /*
            TreeViewItem item = (TreeViewItem)sender;
            item.Items.Clear();
            string itemPath;

            DirectoryInfo directoryInfo = new DirectoryInfo(itemPath);

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                if (directory.Attributes.ToString().Contains("Directory") && !directory.Attributes.ToString().Contains("Hidden"))
                {
                    TreeViewItem treeViewItem = new TreeViewItem
                    {
                        Header = directory.ToString().Substring(directory.ToString().LastIndexOf("\\") + 1),
                        Tag = directory.ToString(),
                        FontWeight = FontWeights.Normal
                    };
                    item.Items.Add(treeViewItem);
                    treeViewItem.Expanded += FolderExpanded;
                }
            }*/



            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string directory in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = directory.Substring(directory.LastIndexOf("\\") + 1);
                        subitem.Tag = directory;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(FolderExpanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }
    }
}
