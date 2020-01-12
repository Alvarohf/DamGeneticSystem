using System.Collections.Generic;

namespace GeneticLibrary
{
    public class Decorator : ICalculadorFitness
    {
        private CalculadorFitnessLineal calculadorFitnessLineal;

        public Decorator(CalculadorFitnessLineal calculadorFitnessLineal)
        {
            this.calculadorFitnessLineal = calculadorFitnessLineal;
        }

        public double[] CalcularFitness(List<DNA> dna)
        {
            return calculadorFitnessLineal.CalcularFitness(dna);
        }
    }
}