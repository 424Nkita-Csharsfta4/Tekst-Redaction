using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using Microsoft.CSharp.RuntimeBinder;
using Microsoft.Office.Interop.Word;
using System.Speech.Recognition;
using System.Globalization;
using System.Speech.Synthesis;

namespace text_redaction
{
    public partial class Text_redactor : Form
    {
        private string Open_Files;
        private object rtb;

        SpeechSynthesizer speech;

        public Text_redactor()
        {
            InitializeComponent();
            speech = new SpeechSynthesizer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Text_redactor_Load(object sender, EventArgs e)
        {

        }

        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.Wheat;
        }

        private void джедайскаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.GreenYellow;
            richTextBox1.BackColor = Color.GreenYellow;
            richTextBox1.ForeColor = Color.DarkRed;
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            if(font.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = font.Font;
            }
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "all (*.*) | *.*";
            if(fileDialog.ShowDialog()== DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(fileDialog.FileName);
                Open_Files = fileDialog.FileName;
            }

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "all (*.*) |*.*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFile.FileName, richTextBox1.Text);
                Open_Files = saveFile.FileName;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Open_Files, richTextBox1.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Ошибка сохранения!!!");
            }
        }

        private void открыьВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var word = new Microsoft.Office.Interop.Word.Application();
            word.Visible = true;
            word.WindowState = WdWindowState.wdWindowStateNormal;
            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();
            Microsoft.Office.Interop.Word.Paragraph paragraph = doc.Paragraphs.Add();
            paragraph.Range.Text = richTextBox1.Text;
            doc.SaveAs2("test.doc");
            System.Diagnostics.Process.Start("test.doc");

        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/424Nkita-Csharsfta4");
        }

        private void подчеркнутьТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.Text != "")
            {
                speech.SpeakAsync(richTextBox1.Text);
            }
        }

        private void паузаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(speech.State == SynthesizerState.Speaking)
            {
                speech.Pause();
            }
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(speech.State == SynthesizerState.Paused)
            {
                speech.Resume();
            }
        }

        private void заднийФонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = cd.Color;
            }
        }

        private void текстЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = cd.Color;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void кодитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDE_CODING _CODING = new IDE_CODING();
            _CODING.Show();
            Text_redactor text_Redactor = new Text_redactor();
            this.Width = 0;
            this.Height = 0;

        }

        private void fastColoredTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
