using ProyectoCuenta.Entidades;
using ProyectoCuenta.Entidades.Entidades;
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
    public partial class FormInicio : Form
    {
        private ControladorNegocio _ctrlNegocio;

        public FormInicio()
        {
            InitializeComponent();
            _ctrlNegocio = new ControladorNegocio();
        }

        private void FormInicio_Load(object sender, EventArgs e)
        {
            try
            {
                ActualizarClientes();
                TxtNroCuenta.Enabled = false;
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            

        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            FormCliente fm = new FormCliente(this);
            fm.Show();
            this.Hide();
        }

        private void ActualizarClientes()
        {
            try
            {
                CmbCliente.DataSource = null;
                CmbCliente.DataSource = _ctrlNegocio.TraerClientes();
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void CmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)CmbCliente.SelectedItem;

                if (cliente != null)
                {
                    Cuenta cuenta = _ctrlNegocio.TraerCuenta(cliente.Id);

                    if (cuenta != null)
                    {
                        TxtNroCuenta.Text = cuenta.NroCuenta.ToString();
                        TxtDescripcion.Text = cuenta.Descripcion;
                        TxtSaldo.Text = cuenta.Saldo.ToString();
                        ChkActivo.Checked = cuenta.Activo;
                        LblFechaAlta.Text = cuenta.FechaApertura.ToString();
                        LblFechaModif.Text = cuenta.FechaModificacion.ToString();
                    }
                    else
                    {
                        TxtNroCuenta.Text = string.Empty;
                        TxtDescripcion.Text = string.Empty;
                        TxtSaldo.Text = string.Empty;
                        ChkActivo.Checked = false;
                        LblFechaAlta.Text = string.Empty;
                        LblFechaModif.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
            
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)CmbCliente.SelectedItem;
                _ctrlNegocio.ModificarCuenta(cliente, TxtDescripcion.Text, TxtSaldo.Text, ChkActivo.Checked);
            }
            catch (Exception ex)
            {
                MostrarError(ex.Message);
            }
                
        }


        private void FormInicio_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                ActualizarClientes();
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
