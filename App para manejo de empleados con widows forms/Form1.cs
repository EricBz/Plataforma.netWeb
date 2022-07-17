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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string buscar = textBox1.Text;
                if (buscar != "")
                {
                    Conexion conexion = new Conexion();
                    dataGridView1.DataSource = conexion.FiltrarEmpleado(buscar);
                    dataGridView1.Columns[0].Visible = false;

                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encuentra ningún empleado");
                        Cargar();
                    }
                }
                else { MessageBox.Show("Por favor ingrese un dato válido."); 
                        Cargar(); }
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No se pudo realizar la busqueda; " + ex); 
            }

        }

        private void Cargar ()
        {
            try
            {
                //Genero una funcion para poder cargar siempre que la llame, desde aca oculto la columna id.
                Conexion conexion = new Conexion();
                dataGridView1.DataSource = conexion.ListarEmpleados();
                dataGridView1.Columns[0].Visible = false;
            }
            catch  (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 segundoForm = new Form2();
            segundoForm.ShowDialog();
            Cargar();
            //Llamo a la funcion cargar, para que luego de agregar se cargue el contenido de la BD.
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (dataGridView1.SelectedRows.Count > 0)
                {//Para modificar empleados
                    

                    Empleado e1;
                    e1 = (Empleado)dataGridView1.CurrentRow.DataBoundItem;
                    int valodecasado()
                    {
                        switch (e1.Casado)
                        {
                            case true:
                                return 0;
                            case false:
                                return 1;
                            default:
                                return 1;
                        }
                    }
                    string IdEmp = e1.Id.ToString();
                    Form3 tercerForm = new Form3(IdEmp);
                    tercerForm.textBox1.Text = e1.NombreCompleto;
                    tercerForm.textBox2.Text = e1.DNI;
                    tercerForm.textBox3.Text = e1.Edad.ToString();
                    tercerForm.textBox4.Text = e1.Salario.ToString();
                    tercerForm.comboBox1.SelectedIndex = valodecasado();
                    tercerForm.ShowDialog();
                    Cargar();
                }
                else
                    MessageBox.Show("Seleccione una fila por favor");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion1 = new Conexion();
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string Prod = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    conexion1.EliminarProd(int.Parse(Prod));
                    MessageBox.Show("Eliminado correctamente");
                    Cargar();
                }
                else
                    MessageBox.Show("Seleccione una fila por favor");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
      
        }
    }
}
