using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversor
{
    public partial class Form1 : Form
    {
        public double tempInicial;
        public double tempFinal;
        public char tipo;
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioF.Checked = false;
                radioF.Enabled = false;
                radioK.Enabled = true;
                radioC.Enabled = true;
                textBox2.Clear();
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("El campo de texto está vacio");
                textBox1.Focus();
            }
            else
            {
                if (radioButton1.Checked)
                {
                    tipo = 'f';

                }
                else if (radioButton2.Checked)
                {
                    tipo = 'c';
                }
                else if(radioButton3.Checked)
                {
                    tipo = 'k';
                }
                try
                {
                    tempInicial = double.Parse(textBox1.Text);
                    switch (tipo)
                    {
                        case 'c':
                            if (radioF.Checked)
                            {
                                tempFinal = ((tempInicial * (1.8)) + 32);
                                textBox2.Text = tempFinal + " °F";
                            }
                            else if (radioK.Checked)
                            {
                                tempFinal = ((tempInicial + 273.15));
                                textBox2.Text = tempFinal + " °K";
                            }
                            break;

                        case 'f':
                            if (radioC.Checked)
                            {
                                tempFinal = (tempInicial - 32) / 1.8;
                                textBox2.Text = tempFinal.ToString("#.####") + " °C";
                            }
                            else if(radioK.Checked)
                            {
                                tempFinal = ((tempInicial - 32) / 1.8) + 273.15;
                                textBox2.Text = tempFinal.ToString("#.####") + " °K";
                            }
                            break;
                        case 'k':
                            if (radioC.Checked)
                            {
                                tempFinal = tempInicial - 273.15;
                                textBox2.Text = tempFinal + " °C";
                            }
                            else if (radioF.Checked)
                            {
                                tempFinal = (1.8 * (tempInicial - 273.15)) + 32;
                                textBox2.Text = tempFinal + " °F";
                            }
                            break;
                    }
                }
                catch (FormatException )
                {
                    MessageBox.Show("El texto introducido es invalido, introduce un numero valido");
                    textBox1.Clear();
                    textBox1.Focus();

                    
                }
                
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioC.Checked = false;
                radioF.Enabled = true;
                radioK.Enabled = true;
                radioC.Enabled = false;
                textBox2.Clear();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioK.Checked = false;
                radioF.Enabled = true;
                radioK.Enabled = false;
                radioC.Enabled = true;
                textBox2.Clear();

            }
        }

        private void radioF_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioC_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioK_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
    }
}
