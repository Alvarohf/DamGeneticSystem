using System.Collections.Generic;

namespace GeneticLibrary
{
    public interface ICalculadorFitness
    {
        double[] CalcularFitness(List<DNA> dna);
    }
}