using System;
namespace GeneticLibrary
{
    public class DNA
    {
        private IEstado estado;
        public DNA()
        {
            Random rnd = new Random();
            SetX(rnd.Next(60));
            SetY(rnd.Next(60));
        }
        public DNA(double X, double Y)
        {
            this.SetX(X);
            this.SetY(Y);
        }

        private double x;

        public double GetX()
        {
            return x;
        }

        public void SetX(double value)
        {
            x = value;
        }

        private double y;

        public double GetY()
        {
            return y;
        }

        public void SetY(double value)
        {
            y = value;
        }

        private double fitness = 0;

        public double Getfitness()
        {
            return fitness;
        }

        public void Setfitness(double value)
        {
            fitness = value;
        }

        public DNA mutarHijo()
        {
            estado = new EstadoMutarLineal();

            estado.Actuar(this);

            return this;

        }
    }
}
