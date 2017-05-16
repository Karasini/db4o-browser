using Db4objects.Db4o;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace db4o_browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IObjectContainer db;

        public MainWindow()
        {
            InitializeComponent();
            InitEvents();
        }

        private void InitEvents()
        {
            openFile.Click += (s, e) =>
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == true)
                {
                    try
                    {
                        db = Db4oEmbedded.OpenFile(openFile.FileName);
                        IObjectSet objectsList = db.QueryByExample(null);
                        foreach (var item in objectsList)
                        {
                            treeView.Items.Add(item);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
        }
    }
}
