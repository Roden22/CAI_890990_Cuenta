using ProyectoCuenta.Entidades;
using ProyectoCuenta.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCuenta.Formularios
{
    public partial class FormCliente : Form
    {
        ControladorNegocio _ctrlNegocio;
        public FormCliente(Form owner)
        {
            InitializeComponent();
            Owner =  owner;
            _ctrlNegocio = new ControladorNegocio();
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void ActualizarLista()
        {
            listClientes.DataSource = null;
            listClientes.DataSource = _ctrlNegocio.TraerClientes();
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarLista();
        }

        private void ListClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)listClientes.SelectedItem;

                if (cliente != null)
                {
                    TxtNombre.Text = cliente.Nombre;
                    TxtApellido.Text = cliente.Apellido;
                    TxtDni.Text = cliente.Dni.ToString();
                    TxtDireccion.Text = cliente.Direccion;
                    TxtEmail.Text = cliente.Email;
                    TxtTelefono.Text = cliente.Telefono;
                    chkActivo.Checked = cliente.Activo;
                    DateNacimiento.Value = cliente.FechaNac;
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)listClientes.SelectedItem;

                int.TryParse(TxtDni.Text, out int dni); // poner nro...
                cliente.Dni = dni;
                cliente.Nombre = TxtNombre.Text;
                cliente.Apellido = TxtApellido.Text;
                cliente.Direccion = TxtDireccion.Text;
                cliente.Email = TxtEmail.Text;
                cliente.Telefono = TxtTelefono.Text;
                cliente.Activo = chkActivo.Checked;
                cliente.FechaNac = DateNacimiento.Value;

                _ctrlNegocio.EditarCliente(cliente);
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int.TryParse(TxtDni.Text, out int dni); // poner nro...

                Cliente cliente = new Cliente(
                    dni,
                    TxtNombre.Text,
                    TxtApellido.Text,
                    TxtDireccion.Text,
                    TxtEmail.Text,
                    TxtTelefono.Text,
                    DateNacimiento.Value,
                    chkActivo.Checked
                    );

                _ctrlNegocio.AgregarCliente(cliente);
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void FormCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Owner.Show();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)listClientes.SelectedItem;

                _ctrlNegocio.EliminarCliente(cliente);
                ActualizarLista();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void MostrarError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
