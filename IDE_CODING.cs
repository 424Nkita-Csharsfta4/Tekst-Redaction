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
using static System.Console;
using ComponentFactory.Krypton.Toolkit;
namespace text_redaction
{
    public partial class IDE_CODING : KryptonForm
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
            fastColoredTextBox1.Text = "//C# " +
                "\nConsole.WriteLine('Hello weld');";
        }

        private void pHPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
            fastColoredTextBox1.Text = "//Php" +
                "\n<?php" +
                "\necho 'Привет мир!';" +
                "\n?>";
        }

        private void javaScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
            fastColoredTextBox1.Text = "//JavaScript" +
                "\nconsole.log('Hello world!');";
        }

        private void kotlinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Custom;
            fastColoredTextBox1.Text = "//Kotlin"+
                "\nfun main() {" +
                "\nprintln('Hello world!')" +
                "\n}";
        }

        private void hTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
            fastColoredTextBox1.Text = 
                "<!DOCTYPE html>" +
                "\n<html>" +
                "  \n<head>" +
                "  \n<meta charset = 'utf-8' >" +
                "  \n<title>Тестовая страница</title>" +
                "  \n</head>" +
                "  \n<body>" +
                "  \n<div>"+
                "  \n<p>Приветсвую тебя в мире веба</p>"+
                "  \n<img src = 'https://i.ytimg.com/vi/WQCGnUTOjNk/maxresdefault.jpg'>" +
                 "  \n</div>" +
                "  \n<style>" +
                "  \nimg{" +
                "  \nwidth:700px;" +
                "  \nborder:1px solid #1e1e1e;" +
                "  \n}"+
                "   \ndiv{" +
                "    \ndisplay:flex;" +
                "     \ngap:2em;" +
                "     \n}" +
                "  \n</style>"+
                "  \n</body>" +
                "\n</html> ";
        }

        private void sQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.SQL;
            fastColoredTextBox1.Text = "IF EXISTS (SELECT name FROM sysobjects WHERE name = 'hello')" +
                "\nDROP PROCEDURE hello; ";
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
                //компилируем код:
                //создаем компилятор кода С#
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                // создаем новые параметры для компиляции и добавляем ссылки (libs) в скомпилированное приложение
                CompilerParameters parameters = new CompilerParameters(new string[] { "System.dll" });
                //будет ли скомпилированный код исполняемым?(.exe)
                parameters.GenerateExecutable = true;
                //выходной путь
                parameters.OutputAssembly = OutPath;
                // исходники кода для компиляции
                string[] sources = { fastColoredTextBox1.Text };
                //результаты компиляции
                CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sources);

                //если есть ошибки
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
                    //показать сообщение об ошибке
                    MessageBox.Show(errsText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // запускаем скомпилированное приложение
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


        //Dragn Drop
        //Перетаскивание файлов
        void panel1_DragDrop(object sender, DragEventArgs e)
        {
            

            label1.Text = "Перетащити файлы сюда";
            
            List<string> paths = new List<string>();//Для многочисленого сброса
                                                    //Папок и показ всех файлов
            foreach (string obj in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                if (Directory.Exists(obj))
                {
                    paths.AddRange(Directory.GetFiles(obj, "*.*\n", SearchOption.AllDirectories));
                    //Ваши_Файлы.Text = string.Join("\r\n", paths);

                }
                else
                {
                    paths.Add(obj);
                    label1.Text = string.Join("\r\n", paths);
                }
            }
            MessageBox.Show("Все в норме файлы скинулись ৻(  •̀ ᗜ •́  ৻)");
                                                                                  
        }

        void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                label1.Text = "Отпусти мышку";
                e.Effect = DragDropEffects.Copy;
            }
        }

         void panel1_DragLeave(object sender, EventArgs e)
        {
            label1.Text = "Перетащити файлы сюда";
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ваши_Файлы_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
