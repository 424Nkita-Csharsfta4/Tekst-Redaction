using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace text_redaction
{
    public partial class HTMLCOMPILIN : Form
    {
        public HTMLCOMPILIN( string file)
        {
            InitializeComponent();
            webBrowser1.DocumentText = file;
            webBrowser2.DocumentText = file;
        }

        private void HTMLCOMPILIN_Load(object sender, EventArgs e)
        {

        }
    }
}
