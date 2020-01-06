using System;

class CalculadorFitnessExponencial : Decorator
{
    //para heredar el constructor
    public CalculadorFitnessExponencial(CalculadorFitnessLineal calculadorFitnessLineal) : base(calculadorFitnessLineal)
    {

    }

    public new double CalcularFitness(DNA dna)
    {
        //base es como super en  c#
        return Math.Pow(base.CalcularFitness(dna),2);
    }
}