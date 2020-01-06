using System;

public class DNA
{
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
        Random rnd = new Random();
        Random coinflip = new Random();
        if (rnd.NextDouble() < 0.1)//mutar en x
        {
            int flip = coinflip.Next(1, 3);
            if (flip == 1)
            {
                this.SetX(GetX() - rnd.Next(10));
            }
            else
            {
                this.SetX(GetX() + rnd.Next(10));
            }
        }
        if (rnd.NextDouble() < 0.1)
        {
            int flip = coinflip.Next(1, 3);
            if (flip == 1)
            {
                this.SetY(GetY() - rnd.Next(10));
            }
            else
            {
                this.SetY(GetY() + rnd.Next(10));
            }
        }

        return this;

    }
}
