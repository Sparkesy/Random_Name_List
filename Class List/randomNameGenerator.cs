using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_List
{
    public partial class randomNameGenerator : Form
    {
        public randomNameGenerator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            // check for names in the listbox on Main form
            

            if (Main.listBox1.Items.Count > 0)
            {
                // generate a random number
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, Main.listBox1.Items.Count);
                // display the name
                lblRandomName.Text = Main.listBox1.Items[randomIndex].ToString();
            }
            else
            {
                MessageBox.Show("No names in the list",
                    "Random Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
