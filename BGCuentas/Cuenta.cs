using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGCuentas
{
    // EXCEPCIONES PERSONALIZADAS - PUBLICAS
    public class TitularException : Exception
    {
        public TitularException() : base("Error: Titular Incorrecto") { }
        public TitularException(string mensage) : base(mensage) { }
    }

    public class CuentaSinSaldoException : Exception 
    {
        public CuentaSinSaldoException() : base("Error: Cuenta sin saldo") { }
        public CuentaSinSaldoException(string mensage) : base(mensage) { }
    }
    public class CantidadException : Exception
    {
        public CantidadException() : base("Error: Cuenta sin saldo") { }
        public CantidadException(string mensage) : base(mensage) { }
    }
    public class Cuenta
    {
        // CONSTANTES PUBLICO / PRIVADAS
        private const int LONGITUD_MIN = 5;
        private const int LONGITUD_MAX = 50;
        private const double SALDO_INI = 0;

        // MIEMBROS PRIVADOS
        protected string _titular;
        protected double _saldo;

        // CONSTRUCTORES
        public Cuenta(string nombre)
        {
            Titular = nombre;                                                                                                                                                                   
            _saldo = SALDO_INI;
        }

        public Cuenta(string nombre, double cantidad) : this (nombre)
        {
            Ingresar(cantidad);
        }

        // PROPIEDADES
        public string Titular
        {
            get { return _titular; }
            set 
            {
                // Establecimiento de Valor por defecto

                // Validacion
                if ((value.Length < LONGITUD_MIN) || (value.Length > LONGITUD_MAX))
                    throw new TitularException();

                _titular = value;
            }
        }

        public double Saldo
        {
            get 
            {
                // Validacion
                if (_saldo == SALDO_INI)
                    throw new CuentaSinSaldoException();
                return _saldo; 
            }
        }

        // METODOS PUBLICOS
        public void Ingresar (double cantidad)
        {
            // Validar la Cantidad
            try
            {
                ValidarCantidad(cantidad);
            }
            catch(CantidadException error)
            {
                throw new CantidadException("Cantidad a Ingresar Incorrecta");
            }

            _saldo += cantidad;
        }

        public virtual void Retirar (double cantidad)
        {
            // Validar la Cantidad
            try
            {
                ValidarCantidad(cantidad);
            }
            catch (CantidadException error)
            {
                throw new CantidadException("Cantidad a Retirar Incorrecta");
            }

            // Comprobar si hay saldo suficiente
            if (cantidad > Saldo)
                throw new CantidadException("No hay suficiente saldo");

            _saldo -= cantidad;
        }

        // METODOS PRIVADOS
        private void ValidarCantidad(double valor)
        {
            if(valor < SALDO_INI)
                throw new CantidadException();
        }

    }
}
