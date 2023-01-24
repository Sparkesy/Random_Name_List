using System;
using System.Drawing.Printing;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Class_List
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void button2_Click(object sender, EventArgs e)
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
            //open email send box with contents of name list
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("your email address");
            mail.To.Add("recipient email address");
            mail.Subject = "Class List";
            mail.Body = listBox1.Items.ToString();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("your email address", "your password");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            MessageBox.Show("mail Send");

        }



        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((string)listBox1.SelectedItem);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText((string)listBox1.SelectedItem);

            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string s = Clipboard.GetText();
            string[] lines = s.Split('\n');
            foreach (string ln in lines)
            {
                listBox1.Items.Add(ln.Trim());
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.SelectedItems.Clear();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            // print list box contents
            PrintDocument pd = new PrintDocument();
            pd.Print();
            //print dialog box
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = pd;
            printDialog.UseEXDialog = true;
            if (DialogResult.OK == printDialog.ShowDialog())
            {
                pd.Print();
            }

        }

        private void randomNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // popup with random name chosen from list in a try and catch block to ensure the list is not empty
            try
            {
                Random rnd = new Random();
                int index = rnd.Next(listBox1.Items.Count);
                MessageBox.Show(listBox1.Items[index].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            // open file dialog box
            try
            {
                OpenFileDialog openfile = new OpenFileDialog();
                openfile.Filter = "Text (*.txt)|*.txt ";
                if (openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (var Reminder = new StreamReader(openfile.FileName))
                        while (!Reminder.EndOfStream)
                            listBox1.Items.Add(Reminder.ReadLine());
                }
            }
            catch (Exception ex)
            {
                //message shows error and explains why
                MessageBox.Show("File is empty or in an invalid format");
                MessageBox.Show(ex.Message);
            }
           
            
        }
    }
}
