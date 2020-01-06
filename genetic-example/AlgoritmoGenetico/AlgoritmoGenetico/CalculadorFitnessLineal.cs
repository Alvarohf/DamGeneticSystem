using System;

class CalculadorFitnessLineal : ICalculadorFitness
{
    private int[] target = { 3, 42 };


    public double CalcularFitness(DNA dna)
    {
        double fit = (double)1.0 / Math.Max((Math.Abs(target[0] - dna.GetX()) + (Math.Abs(target[1] - dna.GetY()))), 1);

        return fit;
    }
}