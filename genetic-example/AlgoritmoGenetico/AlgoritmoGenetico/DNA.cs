using System;

public class DNA
{
    public DNA()
    {
        Random rnd = new Random();
        X = rnd.Next(200);
        Y = rnd.Next(200);
    }
    public DNA(int X, int Y)
    {
        this.X = X;
        this.Y = Y;
    }
    public int X { get; set; }
    public int Y { get; set; }
    public double fitness { get; set; } = 0;
    public DNA mutarHijo()
    {
        Random rnd = new Random();
        Random coinflip = new Random();
        if (rnd.NextDouble() < 0.1)//mutar en x
        {
            int flip = coinflip.Next(1, 3);
            if (flip == 1)
            {
                this.X = X - rnd.Next(10);
            }
            else
            {
                this.X = X + rnd.Next(10);
            }
        }
        if (rnd.NextDouble() < 0.1)
        {
            int flip = coinflip.Next(1, 3);
            if (flip == 1)
            {
                this.Y = Y - rnd.Next(10);
            }
            else
            {
                this.Y = Y + rnd.Next(10);
            }
        }

        return this;

    }
}
