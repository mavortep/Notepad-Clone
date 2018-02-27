using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public static string findText;
        public int d;
        public static Boolean matchCase;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (.txt)|*.txt";
            ofd.Title = "Open a file";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                richTextBox2.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (.txt)|*.txt";
            sfd.Title = "Save file";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName);
                sw.Write(richTextBox2.Text);
                sw.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectAll();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox2.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.SelectionFont = fd.Font;
            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.BackColor = cd.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Basic Notepad \nVersion 1.0.0 \nCreated by Marina Petrova");
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.WordWrap = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.WordWrap = false;
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                richTextBox2.ForeColor = cd.Color;
            }
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.Text += Convert.ToString(DateTime.Now);
        }

        private void styleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.SelectionAlignment = HorizontalAlignment.Left;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.SelectionAlignment = HorizontalAlignment.Right;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.SelectedText = "";
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                selectAllToolStripMenuItem.Enabled = true;
            }
            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                selectAllToolStripMenuItem.Enabled = false;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find find = new Find();
            find.ShowDialog();

            if (findText != "")
            {
                d = richTextBox2.Find(findText);
            }
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (findText != "")
            {
                if (matchCase)
                {
                    d = richTextBox2.Find(findText, (d + 1), richTextBox2.Text.Length, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    d = richTextBox2.Find(findText, (d + 1), richTextBox2.Text.Length, RichTextBoxFinds.None);
                }

            }
        }
    }
}
