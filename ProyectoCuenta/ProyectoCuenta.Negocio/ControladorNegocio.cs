using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCuenta.Entidades;
using ProyectoCuenta.Datos;
using ProyectoCuenta.Entidades.Entidades;

namespace ProyectoCuenta.Negocio
{
    public class ControladorNegocio
    {
        // ATRIBUTOS
        private List<Cliente> _clientes;
        private ClienteMapper _clienteMapper;
        private CuentaMapper _cuentaMapper;

        // PROPIEDADES
        public List<Cliente> Clientes { get => _clientes; }

        // MÉTODOS
        public ControladorNegocio()
        {
            _clienteMapper = new ClienteMapper();
            _cuentaMapper = new CuentaMapper();
        }

        public List<Cliente> TraerClientes()
        {
            _clientes = _clienteMapper.TraerTodos();
            return _clientes;
        }

        public void AgregarCliente(Cliente cliente)
        {
            _clienteMapper.Agregar(cliente);
        }

        public void EditarCliente(Cliente cliente)
        {
            _clienteMapper.Editar(cliente);
        }

        public void EliminarCliente(Cliente cliente)
        {
            _clienteMapper.Eliminar(cliente);
        }

        public Cuenta TraerCuenta(int idCliente)
        {
            Cuenta cuenta = _cuentaMapper.Traer(idCliente);
            return cuenta;
        }

        public void ModificarCuenta(Cliente cliente, string descripcion, string saldo, bool activo)
        {
            if (!float.TryParse(saldo, out float saldof))
            {
                throw new ArgumentException("El saldo debe ser un número.");
            }

            Cuenta cuenta = TraerCuenta(cliente.Id);

            if(cuenta == null)
            {
                // Creo nueva cuenta
                cuenta = new Cuenta(descripcion, saldof, activo, cliente.Id);
            }
            else
            {
                // Modifico la cuenta
                cuenta.Descripcion = descripcion;
                cuenta.Saldo = saldof;
                cuenta.Activo = activo;
                cuenta.FechaModificacion = DateTime.Now;
            }
            _cuentaMapper.CrearOModificar(cuenta);

            cuenta = TraerCuenta(cuenta.IdCliente); // porque si no no se graba el saldo en la creación
            cuenta.Saldo = saldof;
            _cuentaMapper.CrearOModificar(cuenta); 
        }
    }
}
