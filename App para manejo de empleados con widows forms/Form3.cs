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
    public partial class Form3 : Form
    {
        private readonly string recibiid;
        public Form3(string IdEmp)
        {
            InitializeComponent();
            recibiid = IdEmp;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool Casado()
                {
                    switch (comboBox1.SelectedIndex.ToString())
                    {
                        case "0":
                            return true;
                        case "1":
                            return false;
                        default:
                            return false;
                    }
                }
                Conexion conexion3 = new Conexion();
                Empleado nuevo3 = new Empleado();
                if (textBox1.Text.Length != 0 && textBox2.Text.Length != 0 && textBox3.Text.Length != 0 && textBox4.Text.Length != 0 && comboBox1.SelectedIndex != -1)
                {
                    nuevo3.Id = int.Parse(recibiid);
                    nuevo3.NombreCompleto = textBox1.Text;
                    nuevo3.DNI = textBox2.Text;
                    nuevo3.Edad = int.Parse(textBox3.Text);
                    nuevo3.Casado = Casado();
                    nuevo3.Salario = decimal.Parse(textBox4.Text);
                    conexion3.ModificarEmpleado(nuevo3);
                    MessageBox.Show("Modificado exitosamente.");
                    Close();
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El empleado no pudo modificarse correctamente debido a: " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

       
    }
}
