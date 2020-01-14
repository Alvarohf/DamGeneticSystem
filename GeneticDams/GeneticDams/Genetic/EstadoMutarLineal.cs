using System;
namespace GeneticLibrary
{
    public class EstadoMutarLineal : IEstado
    {
        private readonly double minLat;
        private readonly double minLng;
        private readonly double maxLat;
        private readonly double maxLng;

        public EstadoMutarLineal(double minLat, double minLng, double maxLat, double maxLng)
        {
            this.minLat = minLat;
            this.minLng = minLng;
            this.maxLat = maxLat;
            this.maxLng = maxLng;
        }

        public void Actuar(DNA dna)
        {
            {
                Random rnd = new Random();
                Random coinflip = new Random();
                double limiteLat =maxLat-minLat/20;
                double limiteLng = maxLng - minLng /20;
                if (rnd.NextDouble() < 0.1)//mutar en x
                {
                    int flip = coinflip.Next(1, 3);
                    if (flip == 1)
                    {
                        dna.SetX(Math.Max(dna.GetX() - rnd.NextDouble()* limiteLat,minLat));
                    }
                    else
                    {
                        dna.SetX(Math.Min(dna.GetX() + rnd.NextDouble() * limiteLat,maxLat));
                    }
                }
                if (rnd.NextDouble() < 0.1)
                {
                    int flip = coinflip.Next(1, 3);
                    if (flip == 1)
                    {
                        dna.SetY(Math.Max(dna.GetY() - rnd.NextDouble() * limiteLng,minLng));
                    }
                    else
                    {
                        dna.SetY(Math.Min(dna.GetY() + rnd.NextDouble() * limiteLng,maxLng));
                    }
                }

            }
        }
    }
}