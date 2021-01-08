using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NotepadApp
{
    
public partial class Form1 : Form
    {
      //  int t = 0;
      int no_result = 0;
    public bool IsNew { get; set; } = true;
      
    public Form1()
    {
            InitializeComponent();
         
    }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            IsNew = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                 IsNew = false;
            }
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                IsNew = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem.Enabled = richTextBox1.Text.Length > 0 ? true : false;           
            cutToolStripMenuItem.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
            copyToolStripMenuItem.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
            pasteToolStripMenuItem.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
            deleteToolStripMenuItem.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
       //     pasteToolStripMenuItem.Enabled = true;
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
           // pasteToolStripMenuItem.Enabled = true;
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
          if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            richTextBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
                  DateTime a = DateTime.Now;
            //   richTextBox1.Text = a.ToString("hh:mm tt MM/dd/yyyy");
            //      richTextBox1.Text = DateTime.Now.ToLongDateString();
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a.ToString("hh:mm tt MM/dd/yyyy"));
        }

       // bool t;
        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color c = Color.Black;
            // richTextBox1.SelectionColor = c;
            //richTextBox1.SelectedText = Environment.SelectedText;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                richTextBox1.BackColor = c;
            }
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = f.Font;
            }
        }

        private void fontColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Color c = Color.Black;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                richTextBox1.SelectionColor = c;
            }
        }
        //   public bool check { get; set; } = false;
        private void statusBar_CheckedChanged(object sender, EventArgs e)
        {
            status.Visible = statusBar.Checked;
            status_Click(sender, e);
        }
        private void status_Click(object sender, EventArgs e)
        {
            
            richTextBox1_SelectionChanged(sender, e);

        }
        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
           
            int pos = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(pos) + 1;
            int col = pos - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            status.Text = "Ln " + line + ", Col " + col;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoToolStripMenuItem1.Enabled = richTextBox1.Text.Length > 0 ? true : false;
            cutToolStripMenuItem1.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
            copyToolStripMenuItem1.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
            pastelToolStripMenuItem1.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Text);
            deleteToolStripMenuItem1.Enabled = richTextBox1.SelectedText.Length > 0 ? true : false;
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            IsNew = true;
        }

        private void oPenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                IsNew = false;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (IsNew)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                File.WriteAllText(openFileDialog1.FileName, richTextBox1.Text);
            }
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text);
                IsNew = false;
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pastelToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                richTextBox1.Paste();
        }
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void timeDateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DateTime a = DateTime.Now;
            //   richTextBox1.Text = a.ToString("hh:mm tt MM/dd/yyyy");
            //      richTextBox1.Text = DateTime.Now.ToLongDateString();
            richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, a.ToString("hh:mm tt MM/dd/yyyy"));
        }

        private void backgroundToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Color c = Color.Black;
            // richTextBox1.SelectionColor = c;
            //richTextBox1.SelectedText = Environment.SelectedText;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                richTextBox1.BackColor = c;
            }
        }

        private void fontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = f.Font;
            }
        }

        private void fontColorToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Color c = Color.Black;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                c = colorDialog1.Color;
                richTextBox1.SelectionColor = c;
            }
        }

        private void statusBarToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            status.Visible = statusBarToolStripMenuItem.Checked;
            statusBarToolStripMenuItem_Click(sender, e);
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1_SelectionChanged(sender, e);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //not gonna lie i dont remember copy and paste this funxtion from internet...i have no idea where it came from lol

        private void findToolStripMenuItem_Click(string searchText, int searchStart, int searchEnd)
        {
                // Initialize the return value to false by default.
                int returnValue = -1;

                // Ensure that a search string and a valid starting point are specified.
                if (searchText.Length > 0 && searchStart >= 0)
                {
                    // Ensure that a valid ending value is provided.
                    if (searchEnd > searchStart || searchEnd == -1)
                    {
                        // Obtain the location of the search string in richTextBox1.
                        int indexToText = richTextBox1.Find(searchText, searchStart, searchEnd, RichTextBoxFinds.MatchCase);
                        // Determine whether the text was found in richTextBox1.
                        if (indexToText >= 0)
                        {
                            // Return the index to the specified search text.
                            returnValue = indexToText;
                        }
                    }
                }
        }
                    
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //i got this function from youtube
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.TextLength - textBox1.TextLength; i++)
            {
                string x = "";
                for (int j = 0; j < textBox1.TextLength; j++)
                {
                    if (textBox1.Text[j] == richTextBox1.Text[i + j])
                        x += richTextBox1.Text[i + j] + "";
                    else x = "";
                }

                if (x == textBox1.Text)
                {
                    
                        richTextBox1.SelectAll();
                        //  richTextBox1.SelectionBackColor = Color.White;
                        richTextBox1.Select(i, textBox1.TextLength);
                        richTextBox1.SelectionBackColor = Color.LightBlue;
                        no_result++;
                    //break;
                 
                }

              
                //  else
                //    {
                //       IsNew = false;
                //       MessageBox.Show("No result");
                //       break;
                //    }
            }
            if (no_result == 0)
            {
                MessageBox.Show("No result");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           richTextBox1.SelectAll();      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < richTextBox1.TextLength - textBox2.TextLength; i++)
            {
                string x = "";
                for (int j = 0; j < textBox2.TextLength; j++)
                {
                    if (textBox2.Text[j] == richTextBox1.Text[i + j])
                        x += richTextBox1.Text[i + j] + "";
                    else x = "";
                }
                if (x == textBox2.Text)
                {
                    richTextBox1.SelectAll();
                    //  richTextBox1.SelectionBackColor = Color.White;
                    richTextBox1.Select(i, textBox2.TextLength);
                    richTextBox1.SelectionBackColor = Color.LightBlue;
                    no_result++;
                    //break;
                }

            //    if (no_result <= 0)
            //    {
             //       MessageBox.Show("No result");
            //        break;
             //   }
            }
            if (no_result == 0)
            {
                MessageBox.Show("No result");
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // richTextBox1.Clear();
            richTextBox1.Text = richTextBox1.Text.Replace(richTextBox1.SelectedText, textBox3.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           // richTextBox1.SelectAll();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            this.CheckKeyword("private", Color.Blue, 0);
            this.CheckKeyword("while", Color.Blue, 0);
                this.CheckKeyword("if", Color.Purple, 0);
                this.CheckKeyword("void ", Color.Purple, 0);
                 this.CheckKeyword("int", Color.Blue, 0);
            this.CheckKeyword("bool", Color.Blue, 0);
            this.CheckKeyword("string", Color.Blue, 0);
            this.CheckKeyword("partial", Color.Blue, 0);
            this.CheckKeyword("using", Color.DarkBlue, 0);
            this.CheckKeyword("namespace", Color.Blue, 0);
            this.CheckKeyword("public", Color.Blue, 0);
         //   this.CheckKeyword("get", Color.Blue, 0);
        //    this.CheckKeyword("MessageBox", Color.Green, 0);
        //    this.CheckKeyword("Show", Color.LightYellow, 0);
            this.CheckKeyword("else", Color.Purple, 0);
            this.CheckKeyword("for", Color.Purple, 0);
            this.CheckKeyword("new", Color.Blue, 0);
            this.CheckKeyword("object", Color.Blue, 0);
            this.CheckKeyword("word", Color.Cyan, 0);
            this.CheckKeyword("this", Color.Blue, 0);
            this.CheckKeyword("EventArgs", Color.ForestGreen, 0);
            //   this.CheckKeyword("e", Color.Cyan, 0);
            //   this.CheckKeyword("ChechkKeyword", Color.Yellow, 0);
            //   this.CheckKeyword("Color", Color.Green, 0);
            this.CheckKeyword("class", Color.Purple, 0);

        }

        private void CheckKeyword(string word, Color color, int startIndex)
        {
            if (this.richTextBox1.Text.Contains(word))
            {
                int index = -1;
                int selectStart = this.richTextBox1.SelectionStart;

                while ((index = this.richTextBox1.Text.IndexOf(word, (index + 1))) != -1)
                {
                    this.richTextBox1.Select((index + startIndex), word.Length);
                    this.richTextBox1.SelectionColor = color;
                    this.richTextBox1.Select(selectStart, 0);
                    this.richTextBox1.SelectionColor = Color.Black;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  englishToolStripMenuItem.Items.Add("English");
           // comboBox1.Items.Add("Spanish");
         //   comboBox1.Items.Add("French");
          //  comboBox1.SelectedIndex = 0;
        }

        private void commentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
