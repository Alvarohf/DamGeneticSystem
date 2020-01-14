using System;
namespace GeneticLibrary
{
    public class DNA
    {
        private double x;
        private double y;
        private double fitness = 0;
        private IEstado estado;

        public DNA()
        {
        }
        public DNA(double minLat, double minLng, double maxLat, double maxLng)
        {
            Random rnd = new Random();

            x=(minLat+rnd.NextDouble()*(maxLat-minLat));
            y = (minLng + rnd.NextDouble() * (maxLng-minLng));
        }

        public double GetX()
        {
            return x;
        }

        public void SetX(double value)
        {
            x = value;
        }



        public double GetY()
        {
            return y;
        }

        public void SetY(double value)
        {
            y = value;
        }

        public double Getfitness()
        {
            return fitness;
        }

        public void Setfitness(double value)
        {
            fitness = value;
        }

        public DNA mutarHijo(double minLat, double minLng, double maxLat, double maxLng)
        {
            estado = new EstadoMutarLineal( minLat,  minLng,  maxLat,  maxLng);

            estado.Actuar(this);

            return this;

        }
    }
}
