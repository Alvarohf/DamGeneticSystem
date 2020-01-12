using System;
using System.Collections.Generic;
namespace GeneticLibrary
{
    public class Poblacion
    {
        private List<DNA> dnas = new List<DNA>();
        private int popLenght = 20;
        private List<DNA> seleccion = new List<DNA>();
        private IEstrategiaSeleccion estrategiaSeleccion;
        private ICalculadorFitness calculadorFitness;

        public IEstrategiaSeleccion GetIEstrategiaSeleccion()
        {
            return this.estrategiaSeleccion;
        }

        public void SetIEstrategiaSeleccion(IEstrategiaSeleccion value)
        {
            estrategiaSeleccion = value;
        }

        public ICalculadorFitness GetICalculadorFitness()
        {
            return this.calculadorFitness;
        }

        public void SetICalculadorFitness(ICalculadorFitness value)
        {
            calculadorFitness = value;
        }

        public Poblacion()
        {
            for (int i = 0; i < popLenght; i++)
            {
                dnas.Add(new DNA());

            }
            Console.WriteLine(dnas.Count + "estoy aqui");
        }
        public string Simulacion(int iteraciones)
        {

            for (int i = 0; i < iteraciones; i++)
            {
                CalcularFitness();
                Seleccion();
                GenerarPoblacion();
                int j = 0;
                foreach (DNA dna in dnas)
                {
                    Console.WriteLine($"Generacion: {i}, DNA: {j} X:{dna.GetX()} Y:{dna.GetY()}");
                    j++;
                }

            }
            return $"Generacion: {dnas[1].GetX()} {dnas[1].GetX()}";
        }
        public void CalcularFitness()
        {

            double[] fitnesses = this.calculadorFitness.CalcularFitness(dnas);
            for (int i = 0; i < dnas.Count; i++)
            {

                dnas[i].Setfitness(fitnesses[i]);
                Console.WriteLine($"Fitness: {dnas[i].Getfitness()}");
            }
        }

        public void Seleccion()
        {
            estrategiaSeleccion.Seleccion(this.dnas, this.seleccion);

        }
        public void GenerarPoblacion()
        {
            List<DNA> hijos = new List<DNA>();
            Random rnd = new Random();
            Console.WriteLine(this.seleccion.Count);
            for (int i = 0; i < dnas.Count; i++)
            {
                DNA hijo = generarHijo(seleccion[rnd.Next(seleccion.Count)], seleccion[rnd.Next(seleccion.Count)]).mutarHijo();
                hijos.Add(hijo);
            }
            double[] fitnesses = this.calculadorFitness.CalcularFitness(hijos);

            for (int i = 0; i < dnas.Count; i++)
            {
                if (fitnesses[i]>dnas[i].Getfitness())
                {
                    dnas[i] = hijos[i];
                }
            }

        }
        public DNA generarHijo(DNA padre, DNA madre)
        {
            return new DNA(padre.GetX(), madre.GetY());
        }

    }
}


