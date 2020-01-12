using System;
namespace GeneticLibrary
{
    public class DNA
    {
        private IEstado estado;
        public DNA()
        {
            Random rnd = new Random();
            SetX(rnd.Next(200));
            SetY(rnd.Next(200));
        }
        public DNA(int X, int Y)
        {
            this.SetX(X);
            this.SetY(Y);
        }

        private int x;

        public int GetX()
        {
            return x;
        }

        public void SetX(int value)
        {
            x = value;
        }

        private int y;

        public int GetY()
        {
            return y;
        }

        public void SetY(int value)
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
