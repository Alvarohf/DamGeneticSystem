using System;

class Decorator : ICalculadorFitness
{
    private CalculadorFitnessLineal calculadorFitnessLineal;
    
    public Decorator(CalculadorFitnessLineal calculadorFitnessLineal)
    {
        this.calculadorFitnessLineal = calculadorFitnessLineal;
    }

    public double CalcularFitness(DNA dna)
    {
        return calculadorFitnessLineal.CalcularFitness(dna);
    }
}