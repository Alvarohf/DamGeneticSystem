using System;
using System.Collections.Generic;

namespace AlgoritmoGenetico
{
    class Program
    {
        static void Main(string[] args)
        {
            DNA punto = new DNA();
            Console.WriteLine(punto.X);
            Poblacion p = new Poblacion();
            p.Simulacion();
        }
    }
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
        public double Fitness { get; set; } = 0;
        public DNA mutarHijo()
        {
            Random rnd = new Random();
            if (rnd.NextDouble() < 0.1)
            {
                if (rnd.NextDouble() < 0.1)
                {
                    this.X = X - rnd.Next(10);
                    this.Y = Y - rnd.Next(10);
                }
                else
                {
                    this.X = X + rnd.Next(10);
                    this.Y = Y + rnd.Next(10);
                }

            }
            return this;

        }
    }

    class Poblacion
    {

        public DNA[] dnas = new DNA[20];
        public DNA[] seleccion = new DNA[10];
        public int[] target = { 3, 42 };
        public Poblacion()
        {

            for (int i = 0; i < dnas.Length; i++)
            {
                dnas[i] = new DNA();
            }
        }
        public void Simulacion()
        {
            for (int i = 0; i < 10; i++)
            {
                CalcularFitness();
                Seleccion();
                GenerarPoblacion();
                int j = 0;
                foreach (DNA dna in dnas)
                {
                    Console.WriteLine($"Generacion: {i}, DNA: {j} X:{dna.X} Y:{dna.Y}");
                    j++;
                }
            }
        }
        public void CalcularFitness()
        {
            for (int i = 0; i < dnas.Length; i++)
            {

                dnas[i].Fitness = (double)1.0 / (Math.Abs(target[0] - dnas[i].X) + 1) + 1.0 / (Math.Abs(target[1] - dnas[i].Y) + 1);
                Console.WriteLine($"Fitness: {dnas[i].Fitness}");
            }
        }

        public void Seleccion()
        {
            Array.Sort(dnas, new DNAComparame());
            Array.Reverse(dnas);
            for (int i = 0; i < seleccion.Length; i++)
            {
                seleccion[i] = dnas[i];
            }


        }
        public void GenerarPoblacion()
        {
            Random rnd = new Random();
            for (int i = 0; i < dnas.Length; i++)
            {
                dnas[i] = generarHijo(seleccion[rnd.Next(seleccion.Length)], seleccion[rnd.Next(seleccion.Length)]).mutarHijo();

            }
        }
        public DNA generarHijo(DNA padre, DNA madre)
        {
            return new DNA(padre.X, madre.Y);
        }

    }
    public class DNAComparame : Comparer<DNA>
    {
        // Compares by Length, Height, and Width.
        public override int Compare(DNA x, DNA y)
        {
            return x.Fitness.CompareTo(y.Fitness);

        }

    }
}
