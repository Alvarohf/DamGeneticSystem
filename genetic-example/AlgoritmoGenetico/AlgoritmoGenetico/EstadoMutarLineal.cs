using System;

class EstadoMutarLineal : IEstado
{
    public void actuar(DNA dna)
    {
        {
            Random rnd = new Random();
            Random coinflip = new Random();
            if (rnd.NextDouble() < 0.1)//mutar en x
            {
                int flip = coinflip.Next(1, 3);
                if (flip == 1)
                {
                    dna.SetX(dna.GetX() - rnd.Next(10));
                }
                else
                {
                    dna.SetX(dna.GetX() + rnd.Next(10));
                }
            }
            if (rnd.NextDouble() < 0.1)
            {
                int flip = coinflip.Next(1, 3);
                if (flip == 1)
                {
                    dna.SetY(dna.GetY() - rnd.Next(10));
                }
                else
                {
                    dna.SetY(dna.GetY() + rnd.Next(10));
                }
            }

        }
    }
}