using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Bateria MiBateria = new Bateria(false,(int)80,2);
            MirarConex ChivatoCable = new MirarConex();
            MirarXciento ChivatoXciento = new MirarXciento();


            MiBateria.AniadirObserver(ChivatoCable);
            MiBateria.AniadirObserver(ChivatoXciento);

            MiBateria.AbrirPhotoshop();
            MiBateria.Conectar();
            MiBateria.Desconectar();
            MiBateria.Conectar();
            MiBateria.Desconectar();
            MiBateria.AbrirPhotoshop();
            MiBateria.Jugar();
            MiBateria.Conectar();

            Console.ReadKey();
        }
    }
}
