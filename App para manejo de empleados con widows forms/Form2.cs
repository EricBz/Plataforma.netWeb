using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_FINAL_Benitez_Eric
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool Casado()
                {
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            return true;
                        case 1:
                            return false;
                        default:
                            return false;
                    }
                }
                Conexion conexion = new Conexion();
                Empleado nuevo = new Empleado();

                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && comboBox1.SelectedIndex != -1)
                {
                    nuevo.NombreCompleto = textBox1.Text;
                    nuevo.DNI = textBox2.Text;
                    nuevo.Edad = Int32.Parse(textBox3.Text);
                    nuevo.Casado = Casado();
                    nuevo.Salario = decimal.Parse(textBox4.Text);

                    conexion.Agregar(nuevo);
                    MessageBox.Show("Agregado exitosamente.");
                    Close();
                }
                else MessageBox.Show("Complete todos los campos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
