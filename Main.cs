using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StringGeneratorV4
{
    public partial class Main : Form
    {
        Size normalSize = new Size(414, 64);
        Size optionsSize = new Size(414, 199);

        bool toggleOptions = false;

        int length;
        int seed;

        bool customChars;

        public Main()
        {
            InitializeComponent();
        }

        string GenerateString(int length, int seed, string characters, bool custom)
        {
            Random random = new Random(seed);
            string result = null;

            textBox1.Font = new Font(this.Font, FontStyle.Regular);

            if (custom)
            {
                for (int i = 1; i <= length; )
                {
                    result += characters[random.Next(0, characters.Length)];
                    i++;
                }

                return result;
            }
            else
                switch (characters)
                {
                    case "100":
                        for (int i = 1; i <= length; )
                        {
                            result += (char)(random.Next(97, 123));
                            i++;
                        }
                        return result;

                    case "010":
                        for (int i = 1; i <= length; )
                        {
                            result += (char)(random.Next(65, 91));
                            i++;
                        }
                        return result;

                    case "001":
                        for (int i = 1; i <= length; )
                        {
                            result += (char)(random.Next(48, 58));
                            i++;
                        }
                        return result;

                    case "110":
                        for (int i = 1; i <= length; )
                        {
                            char r = (char)random.Next(65, 123);

                            if (r < 91 || r > 96)
                            {
                                result += r;
                                i++;
                            }
                        }
                        return result;

                    case "101":
                        for (int i = 1; i <= length; )
                        {
                            char r = (char)random.Next(48, 123);

                            if (r < 58 || r > 96)
                            {
                                result += r;
                                i++;
                            }
                        }
                        return result;
                    case "011":
                        for (int i = 1; i <= length; )
                        {
                            char r = (char)random.Next(48, 91);

                            if (r < 58 || r > 64)
                            {
                                result += r;
                                i++;
                            }
                        }
                        return result;

                    case "111":
                        for (int i = 1; i <= length; )
                        {
                            char r = (char)random.Next(48, 123);

                            if (r < 58 || (r > 64 && r < 90) || r > 96)
                            {
                                result += r;
                                i++;
                            }
                        }
                        return result;

                    case "E0":
                        textBox1.Font = new Font(this.Font, FontStyle.Bold);
                        return "ERROR - No character use options are checked";

                    case "E1":
                        textBox1.Font = new Font(this.Font, FontStyle.Bold);
                        return "ERROR - The 'Custom characters' field is empty";

                    default:
                        return null;
                }
        }

        string GCTU()
        {
            string result = null;

            if (!checkBox5.Checked)
            {
                result += checkBox1.Checked ? "1" : "0";
                result += checkBox2.Checked ? "1" : "0";
                result += checkBox3.Checked ? "1" : "0";

                if (result == "000")
                    return "E0";
                else return result;
            }
            else
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    result = textBox2.Text;
                    return result;
                }
                else
                {
                    customChars = false;
                    return "E1";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            length = (int)numericUpDown2.Value;
            seed = checkBox6.Checked ? (int)numericUpDown1.Value : Environment.TickCount;
            customChars = checkBox5.Checked;

            textBox1.Text = GenerateString(length, seed, GCTU(), customChars);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main.ActiveForm.Size = toggleOptions ? normalSize : optionsSize;
            
            toggleOptions = !toggleOptions;

            label1.Visible = toggleOptions;
            numericUpDown1.Visible = toggleOptions;
            numericUpDown2.Visible = toggleOptions;
            textBox2.Visible = toggleOptions;
            checkBox1.Visible = toggleOptions;
            checkBox2.Visible = toggleOptions;
            checkBox3.Visible = toggleOptions;
            checkBox5.Visible = toggleOptions;
            checkBox6.Visible = toggleOptions;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Enabled = checkBox2.Enabled = checkBox3.Enabled = !checkBox5.Checked;
            textBox2.Enabled = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = checkBox6.Checked;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
