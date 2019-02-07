using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public interface IBateria
    {
        void AniadirObserver(IObservador alcahuete);
        void BorrarObserver(IObservador alcahuete);
        void Notificar();
    }

    public interface IObservador
    {
        void Update(Bateria pila);
    }

    public class Bateria : IBateria
    {

        private bool _Conectado { get; set; }
        private int _Conversion { get; set; }
        private int _Porciento { get; set; }
        private List<IObservador> ListaObservadores;

        public bool Conectado {
            get { return this._Conectado;}
            set { this._Conectado = value; }
        }

        public int Conversion {
            get { return this._Conversion;}
            set {
                this._Conversion = 0;
                if (value > 0) { this._Conversion = value; } 
            }
        }

        public int Porciento {
            get {return this._Porciento;}
            set{
                this._Porciento = 0;
                if (value > 0) { this._Porciento = value; }
            }
        }

        
        public Bateria(bool conn, int xciento, int conversion) {
            this.Conectado = conn;
            this.Conversion = conversion;
            this.Porciento = 0;
            if (xciento > 0) {
                if (xciento > 100) { xciento = 100; }
                this.Porciento = xciento;
            }
            this.ListaObservadores = new List<IObservador>();
        }

        public Bateria(bool conn, int xciento)
        {
            this.Conectado = conn;
            this.Conversion = 1;
            this.Porciento = xciento;
        }

        public void Conectar() {
            this._Conectado = true;
            Notificar();
        }

        public void Desconectar()
        {
            this._Conectado = false;
            Notificar();
        }

        // funciones de consumo de bateria
        public void AbrirPhotoshop()
        {
            this._Porciento = (int)this._Porciento - 5;
            if (this._Porciento < 0) { this._Porciento = 0; }
            Notificar();
        }
        public void Jugar()
        {
            this._Porciento = (int)this._Porciento - 15;
            if (this._Porciento < 0) { this._Porciento = 0; }
            Notificar();
        }

        public void AniadirObserver(IObservador alcahuete)  {
            ListaObservadores.Add(alcahuete);
        }

        public void BorrarObserver(IObservador alcahuete) {
            ListaObservadores.Remove(alcahuete);
        }

        public void Notificar(){
            foreach (IObservador alcahuete in ListaObservadores) {
                alcahuete.Update(this);
            }
        }
    }


    public class MirarConex : IObservador
    {
        public MirarConex() {
            // ea, constructor vacio
        }

        public void Update(Bateria pila)
        {
            if (pila.Conectado)
            {
                Console.WriteLine("Batería en proceso de carga");
            }
            else {
                Console.WriteLine("Fuente de energía: Batería");
            }
        }

    }

    public class MirarXciento : IObservador
    {
        public MirarXciento() {
            // ea, constructor vacio
        }

        public void Update(Bateria pila)
        {
            int horas =0; 
            int minutos =0 ;

            minutos = (int)pila.Porciento * pila.Conversion;

            if (minutos > 60) {
                horas = (int) (minutos / 60);
                minutos = minutos - (horas * 60);
            }

            Console.WriteLine("Ahora queda {0} %, aproximadamente {1} horas y {2} minutos", pila.Porciento,horas,minutos );
        }
    }




}
