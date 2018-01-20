using System.Windows.Forms;

using SweetKompasPlugin.Model;

namespace SweetKompasPlugin
{
    public partial class MainForm : Form
    {
        private KompasWrapper _kompasWrapper = new KompasWrapper();

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
