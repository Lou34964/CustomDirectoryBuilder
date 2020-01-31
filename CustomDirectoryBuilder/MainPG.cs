using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomDirectoryBuilder
{
    public partial class MainPG : Form
    {
        public MainPG()
        {
            InitializeComponent();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Custom Directory Builder\n\nThis app is designed to allow you to create diectories(Folders) with " +
                "special characters such as \".Hidden\". putting a '.' at the beginning of a folder name will make the folder hidden to indexers" +
                "\n\nfirst thing you need to do is enter the parent disrectory - this is the directory that the custom directory/folder will reside" +
                "in.\n\nSecond is to enter the custom name you wish to use.\n\nThen press go and walla you now have a folder with your custom name.");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    GV.ParentPath = dialog.SelectedPath.ToString();
                    tbParentDirectory.Text = GV.ParentPath + @"\";
                }
            }
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            
            if(tbNewFolderName.Text == "")
            {
                MessageBox.Show("You must enter a Directory/Folder name.");
            }
            else
            {
                GV.ChildFolder = tbNewFolderName.Text + @"\";
                Directory.CreateDirectory(Path.Combine(GV.ParentPath, GV.ChildFolder));
                Process.Start(GV.ParentPath);
            }
        }
    }
}
