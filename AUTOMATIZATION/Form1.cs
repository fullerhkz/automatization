using AUTOMATIZATION.Classes;
using System.Windows.Forms;

namespace AUTOMATIZATION
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ComandReceiver.CreateFileWatcher(@"D:\OneDrive\Google\");
        }
    }
}
    

