using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGCuentas
{
    public class EdadException : Exception
    {
        public EdadException() : base("Edad Incorrecta") { }
        public EdadException(string mensage) : base(mensage) { }
    }
    public class CuentaJoven : Cuenta
    {
        // CONSTANTES
        private const double RETIRAR_LIM = 500;
        private const int EDAD_MIN = 10;
        private const int EDAD_MAX = 26;

        // MIEMBROS PRIVADOS
        private int _edad;

        // CONSTRUCTORES
        public CuentaJoven (string nombre, int anios) : base(nombre)
        {
            Edad = anios;
        }

        public CuentaJoven (string nombre, double cantidad, int anios) : base(nombre, cantidad)
        {
            Edad = anios;
        }

        // PROPIEDADES
        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                // Validacion del value
                if((value < EDAD_MIN) || (value > EDAD_MAX))
                _edad = value;
            }
        }

        // METODOS PUBLICOS
        public override void Retirar(double cantidad)
        {
            // Validar la Cantidad
            if (cantidad > RETIRAR_LIM)
                throw new CantidadException($"Este tipo de cuenta no permite retiradas de " +
                    $"cantidades superiores a {RETIRAR_LIM} Euros");

            base.Retirar(cantidad);
        }

        // METODOS PRIVADOS

    }
}
