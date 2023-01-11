using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using System.Speech.Recognition;
using System.Globalization;
using System.Speech.Synthesis;
using System.IO;
using System.Drawing.Printing;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Windows.Controls;
using System.Runtime.InteropServices;

namespace text_redaction
{
    public partial class IDE_CODING : Form
    {
        private string Open_Files;
        private object rtb;

        SpeechSynthesizer speech;

        public IDE_CODING()
        {
           
            InitializeComponent();
           
            speech = new SpeechSynthesizer();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(this.Text);
                sw.Write(fastColoredTextBox1.Text);
                sw.Close();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка сохранения!!!");
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "all (*.*) |*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, fastColoredTextBox1.Text);
                Open_Files = saveFile.FileName;
            }
        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();

            if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp)
            {
                of.Filter = "C# File|*.cs|Any File|*.*";
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.PHP)
            {
                of.Filter = "PHP File|*.php|Any File|*.*";
            }
            else if(fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML)
            {
                of.Filter = "HTML File|*.html|Any File|*.*";
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.JS)
            {
                of.Filter = "JS File|*.js|Any File|*.*";
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.Custom)
            {
                of.Filter = "Kotlin File|*.kotlin|Any File|*.*";
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.SQL)
            {
                of.Filter = "SQL File|*.sql|Any File|*.*";
            }
            else
            {
                of.Filter = "Any File|*.*";
            }

            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);
                fastColoredTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                this.Text = of.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            fastColoredTextBox1.BackColor = Color.Black;
            fastColoredTextBox1.ForeColor = Color.Wheat;
        }

        private void джедайскаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.GreenYellow;
            fastColoredTextBox1.BackColor = Color.GreenYellow;
            fastColoredTextBox1.ForeColor = Color.DarkRed;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if (font.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Font = font.Font;
            }
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text += DateTime.Now;
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Text = "";
        }

        private void открыьВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = true;
            word.WindowState = WdWindowState.wdWindowStateNormal;
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Paragraph paragraph = doc.Paragraphs.Add();
            paragraph.Range.Text = fastColoredTextBox1.Text;
            doc.SaveAs2("test.doc");
            System.Diagnostics.Process.Start("test.doc");
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/424Nkita-Csharsfta4");
        }

        private void заднийФонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.BackColor = cd.Color;
            }
        }

        private void паузаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Text != "")
            {
                speech.SpeakAsync(fastColoredTextBox1.Text);
            }
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Text != "")
            {
                speech.SpeakAsync(fastColoredTextBox1.Text);
            }
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (speech.State == SynthesizerState.Speaking)
            {
                speech.Pause();
            }
        }

        private void текстЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.ForeColor = cd.Color;
            }
        }

        private void bыбратьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.SelectAll();
        }

        private void обрезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Cut();
        }

        private void скопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void вставитьТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void IDE_CODING_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            fastColoredTextBox1.Redo();
        }

        private void поставитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = new Bitmap(@"C:\Users\tvc\Downloads\123.jpg");

        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
        }

        private void javaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
        }

        private void kotlinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
        }

        private void скомпилироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.HTML) //Если ЯП html
            {
                HTMLCOMPILIN h = new HTMLCOMPILIN(fastColoredTextBox1.Text);
                h.Show();
            }
            else if (fastColoredTextBox1.Language == FastColoredTextBoxNS.Language.CSharp) //Если ЯП c#
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Executable File|*.exe";
                string OutPath = "?.exe";
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    OutPath = sf.FileName;
                }
                //compile code:
                //create c# code compiler
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                //create new parameters for compilation and add references(libs) to compiled app
                CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
                //is compiled code will be executable?(.exe)
                parameters.GenerateExecutable = true;
                //output path
                parameters.OutputAssembly = OutPath;
                //code sources to compile
                string[] sources = { fastColoredTextBox1.Text };
                //results of compilation
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);

                //if has errors
                if (results.Errors.Count > 0)
                {
                    string errsText = "";
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        errsText = "(" + CompErr.ErrorNumber +
                                    ")Line " + CompErr.Line +
                                    ",Column " + CompErr.Column +
                                    ":" + CompErr.ErrorText + "" +
                                    Environment.NewLine;
                    }
                    //show error message
                    MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //run compiled app
                    System.Diagnostics.Process.Start(OutPath);
                }
            }
            else
            {
                MessageBox.Show("Cannot run this file");
            }
        }

      

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string openPath = folderBrowserDialog.SelectedPath;
                MessageBox.Show(openPath);
            }
        }

        private void консольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocConsole();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
    }
}
