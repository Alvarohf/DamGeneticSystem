using System;
using System.Collections.Generic;

namespace GeneticLibrary
{
    public class CalculadorFitnessExponencial : Decorator
    {
        //para heredar el constructor
        public CalculadorFitnessExponencial(CalculadorFitnessLineal calculadorFitnessLineal) : base(calculadorFitnessLineal)
        {

        }

        public double[] CalcularFitness(List<DNA> dna)
        {
            //base es como super en  c#
            return squareArray(base.CalcularFitness(dna));
        }
        public double[] squareArray(double[] array)
        {
            double[] resultado = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                resultado[i] = Math.Pow(array[i], 2);
            }
            return resultado;
        }
    }
}