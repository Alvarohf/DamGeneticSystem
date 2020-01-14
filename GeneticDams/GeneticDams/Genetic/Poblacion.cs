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
        private readonly double minLat;
        private readonly double minLng;
        private readonly double maxLat;
        private readonly double maxLng;
        private DNA bestDNA;
        private bool max=false;

        public Poblacion(double minLat, double minLng, double maxLat, double maxLng)
        {
            this.minLat = minLat;
            this.minLng = minLng;
            this.maxLat = maxLat;
            this.maxLng = maxLng;

            for (int i = 0; i < popLenght; i++)
            {
                dnas.Add(new DNA(minLat, minLng, maxLat, maxLng));
                    System.Diagnostics.Debug.WriteLine(dnas[i].GetY());
                System.Diagnostics.Debug.WriteLine(dnas[i].GetX());
            }
            Console.WriteLine(dnas.Count + "estoy aqui");
        }

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

        public string Simulacion(int iteraciones)
        {

            for (int i = 0; i < iteraciones; i++)
            {
                CalcularFitness();
                Seleccion();
                GenerarPoblacion();
                int j = 0;
                bestDNA = dnas[0];
                foreach (DNA dna in dnas)
                {
                    Console.WriteLine($"Generacion: {i}, DNA: {j} X:{dna.GetX()} Y:{dna.GetY()}");
                    j++;
                    if (comparar(bestDNA.Getfitness(), dna.Getfitness()))
                    {
                        bestDNA = dna;
                    }
                }

            }
            return $"Generacion: {bestDNA.GetX()} {bestDNA.GetY()}";
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
            estrategiaSeleccion.Seleccion(this.dnas, this.seleccion, this.max);
        }
        public void GenerarPoblacion()
        {
            List<DNA> hijos = new List<DNA>();
            Random rnd = new Random();
            Console.WriteLine(this.seleccion.Count);
            for (int i = 0; i < dnas.Count; i++)
            {
                DNA hijo = generarHijo(seleccion[rnd.Next(seleccion.Count)], seleccion[rnd.Next(seleccion.Count)]).mutarHijo(minLat, minLng, maxLat, maxLng);
                hijos.Add(hijo);
            }
            double[] fitnesses = this.calculadorFitness.CalcularFitness(hijos);

            for (int i = 0; i < dnas.Count; i++)
            {
                if (comparar(fitnesses[i], dnas[i].Getfitness()))
                {
                    dnas[i] = hijos[i];
                }
            }

        }
        public DNA generarHijo(DNA padre, DNA madre)
        {
            DNA hijo = new DNA();
            hijo.SetX(padre.GetX());
            hijo.SetY(madre.GetY());
            return hijo;
        }

        public bool comparar(double x, double y)
        {
            bool mejor;
            if (max)
            {
                mejor = x > y;
            }
            else
            {
                mejor = x < y;
            }
            return mejor;
        }
    }
}


