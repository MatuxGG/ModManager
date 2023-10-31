using System.IO.Compression;

namespace ReleaseMaker
{
    public partial class ReleaseMaker : Form
    {
        public ReleaseMaker()
        {
            InitializeComponent();

            string dest = @"../../../../../Output/ModManager.zip";
            if (File.Exists(dest))
            {
                File.Delete(dest);
            }
            ZipFile.CreateFromDirectory(@"../../../../../ModManager6/bin/Debug/net6.0-windows", dest);
        }
    }
}