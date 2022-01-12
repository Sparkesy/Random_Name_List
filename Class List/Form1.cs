using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Drawing.Printing;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;

namespace Class_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // grab the value supplied
            string newstudent = txtbxStudentName.Text;
            if (newstudent.Length < 2)
            {
                MessageBox.Show("Insufficient length for a student name",
                    "Add Name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                // kill the method here.
                return;
            }
            // add the name to the listbox
            listBox1.Items.Add(newstudent);
            // clear the textbox
            txtbxStudentName.Clear();
            // make sure that the textbox gets focus back
            txtbxStudentName.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //check for selection
            if (listBox1.SelectedItem != null)
            {
                // remove from names list the currently selected name
                listBox1.Items.Remove(listBox1.SelectedItem);
                //o selection show error message
            }
            else
            {
                MessageBox.Show("No selection has been made",
                "Remove name",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // check if any names currently listed
            if (listBox1.Items.Count > 0)
            {
                listBox1.Items.Clear();
            }
            // names loaded show error message
            else
                MessageBox.Show("No students have been entered",
                "Clear names",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void button2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // check the key pressed
            if (e.KeyChar == (char)13)
                button2.PerformClick();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var Savingfileas = new SaveFileDialog();
            Savingfileas.Filter = "Text (*.txt)|*.txt ";
            if (Savingfileas.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                using (var Reminder = new StreamWriter(Savingfileas.FileName, false))
                    foreach (var item in listBox1.Items)
                        Reminder.Write(item.ToString() + Environment.NewLine);
                MessageBox.Show("File has been successfully saved");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
          ///mail_Client emc = new Email_Client();
           //mc.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void randomNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var random = new Random();

            int index = random.Next(0, listBox1.Items.Count);
            MessageBox.Show (listBox1.Items[index].ToString());
        }
    }
}

