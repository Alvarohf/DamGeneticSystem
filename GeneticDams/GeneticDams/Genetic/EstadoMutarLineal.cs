using System;
namespace GeneticLibrary
{
    public class EstadoMutarLineal : IEstado
    {
        public void Actuar(DNA dna)
        {
            {
                Random rnd = new Random();
                Random coinflip = new Random();
                if (rnd.NextDouble() < 0.1)//mutar en x
                {
                    int flip = coinflip.Next(1, 3);
                    if (flip == 1)
                    {
                        dna.SetX(dna.GetX() - rnd.NextDouble()*10);
                    }
                    else
                    {
                        dna.SetX(dna.GetX() + rnd.NextDouble() * 10);
                    }
                }
                if (rnd.NextDouble() < 0.1)
                {
                    int flip = coinflip.Next(1, 3);
                    if (flip == 1)
                    {
                        dna.SetY(dna.GetY() - rnd.NextDouble() * 10);
                    }
                    else
                    {
                        dna.SetY(dna.GetY() + rnd.NextDouble() * 10);
                    }
                }

            }
        }
    }
}