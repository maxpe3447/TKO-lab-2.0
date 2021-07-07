using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TKO_lab
{
    public partial class MainForm : Form
    {

		private byte task1 = 1, task2 = 1;
        public MainForm()
        {
            InitializeComponent();

        }

		private Rezistor CheckTermoStatus()
		{
			switch (task1)
			{
				case 1:
					return new Rezistor(1.166); //Si
					
				case 2:
					return new Rezistor(0.74); //Ge
					
				case 3:
					return new Rezistor(0.165); //PbSe
					
				case 4:
					return new Rezistor(0.19); //PbTe
					
				case 5:
					return new Rezistor(0.81); //GaSb
					
				case 6:
					return new Rezistor(0.43); //InAs
					
				case 7:
					return new Rezistor(0.235); //InSb
					
				case 8:
					return new Rezistor(0.29); //PbS
					
				case 9:
					return new Rezistor(0.19); //PbTe
					
				case 10:
					return new Rezistor(0.3); //SnTe
			}
			return new Rezistor();
		}

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 3;
		}

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 4;
		}

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 5;
		}

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 6;
		}

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 7;
		}

        private void groupBox1Task_Enter(object sender, EventArgs e)
        {
			richTextBox1.Clear();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 8;
		}

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 9;
		}

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
			task1 = 10;
		}

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 1;
		}

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 2;
		}

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 3;
		}

        private void radioButton14_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 4;
		}

        private void radioButton15_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 5;
		}

        private void radioButton16_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 6;
		}

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 7;
		}

        private void radioButton18_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 8;
		}

        private void radioButton19_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 9;
		}

        private void radioButton20_CheckedChanged(object sender, EventArgs e)
        {
			task2 = 10;
		}

		Metalls CheckMetalStatus()
		{
			switch (task1)
			{
				case 1:
					return new Metalls(0.000000017, 0.0043); // Cuprum
					
				case 2:
					return new Metalls(0.000000028, 0.0042); // Al
					
				case 3:
					return new Metalls(0.0000011, 0.0001); // Ni
					
				case 4:
					return new Metalls(0.0000011, 0.0001); // NiCh
					
				case 5:
					return new Metalls(0.00000012, 0.0043); // Steel
					
				case 6:
					return new Metalls(0.000000055, 0.0048); // Steel
					
				case 7:
					return new Metalls(0.000000055, 0.0048); // Cuprum
					
				case 8:
					return new Metalls(0.000000055, 0.0048); // Cuprum
					
				case 9:
					return new Metalls(0.000000028, 0.0042); // Al
					
				case 10:
					return new Metalls(0.0000011, 0.0001); // NiCh
					
			}
			return new Metalls();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			GadjetForm gForm = new GadjetForm();
			gForm.Show();
			
			gForm.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

			gForm.lInfo.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			if (IsCalc.IsCalcResult)
            {
				gForm.lInfo.Text = $"t = {Convert.ToString(IsCalc.Term)}                  Warm\n\nR = {IsCalc.R.ToString("0.000")}";
            }
            else
            {
				gForm.lInfo.Text = "No Info";
            }
		}
		struct IsCalc
		{
			public static bool IsCalcResult { get; set; }
			public static byte Term { get; set; }
			public static double R { get; set; }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
			MainForm.ActiveForm.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("https://github.com/maxpe3447/TKO-lab-2.0");
        }

        private void bCalc_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.ForeColor = Color.Black;

            label1.ForeColor = Color.Black;

            Rezistor rez = CheckTermoStatus();
            Metalls metal = CheckMetalStatus();

            Phizics obj = new Phizics(rez, metal, numericUpDown1.Value, numericUpDown2.Value);

            if (task1 != 0 && task2 != 0 && numericUpDown1.Value != 0 && numericUpDown2.Value != 0)
            {
				IsCalc.IsCalcResult = true;
				IsCalc.Term = obj.Term[0];
				IsCalc.R = obj.R_arr[0];
                richTextBox1.AppendText("\t" + " \t\tЗавдання 1" + "\tЗаdдання 2\n\n\t T" + " \t\tR(mOm)" + "\t\tR(kOm)\n");

                for (int i = 0; i < 14; i++)
                {
                    if (task2 == 3 || task2 == 4 || task2 == 7 || task2 == 9)
                        richTextBox1.AppendText("\t" + Convert.ToString(obj.Term[i]) + "\t\t" + obj.R_arr[i].ToString("0.000") + "\t\t" + obj.R_termo[i].ToString("0.000000") + "\n");
                    else
                        richTextBox1.AppendText("\t" + Convert.ToString(obj.Term[i]) + "\t\t" + obj.R_arr[i].ToString("0.000") + "\t\t" + obj.R_termo[i].ToString("0.000") + "\n");

                }

                richTextBox1.AppendText("\n\t\t" + ("\u03C1") + "o = " + obj.get_ro().ToString("0.000000000") + "\t\tEg = " + Convert.ToString(obj.get_close_zone()) + "(eB)\n\t\t\t\t\tR0 = " + (obj.RZeroTermo).ToString("0.000") + "(Om)");
            }
            else
            {
                richTextBox1.ForeColor = Color.Red;
                richTextBox1.Text = ("\n\t\t\tERROR!!");
                label1.ForeColor = Color.Red;

                MessageBox.Show("Оберіть варінт за заповніть данні!", "Fatal Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
