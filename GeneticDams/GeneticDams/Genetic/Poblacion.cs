using GoogleMapsApi.Entities.Common;
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
        // True for hills, false for valleys
        private bool algorithm = false;

        public Poblacion(double minLat, double minLng, double maxLat, double maxLng, bool algorithm)
        {
            this.minLat = minLat;
            this.minLng = minLng;
            this.maxLat = maxLat;
            this.maxLng = maxLng;
            this.algorithm = algorithm;
            for (int i = 0; i < popLenght; i++)
            {
                dnas.Add(new DNA(minLat, minLng, maxLat, maxLng));
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

        /// <summary>
        /// Proceso para simular una generacion Pasos:
        ///Calcular la fitness de los indivudos mediante el proceso calcFitness
        ///Crear una matriz de reproducion mediante el proceso Selection
        ///Creara la nueva poblacion combinando y mutando individuos de la matriz de reproducion mediante el proceso generate
        /// </summary>
        /// <returns></returns>
        public Location[] Simulacion()
        {
            Location[] localizaciones = new Location[dnas.Count];

            CalcularFitness();
            Seleccion();
            GenerarPoblacion();
            bestDNA = dnas[0];
            foreach (DNA dna in dnas)
            {
                if (!comparar(bestDNA.Getfitness(), dna.Getfitness()))
                {
                    bestDNA = dna;
                }
            }
            for (int i = 0; i < dnas.Count; i++)
            {
                localizaciones[i] = new Location(dnas[i].GetX(), dnas[i].GetY());
            }
            for (int i = 0; i < dnas.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("DNAS Fitness:" + dnas[i].Getfitness());
            }
            System.Diagnostics.Debug.WriteLine("Best Fitness:" + bestDNA.Getfitness());
            localizaciones[0] = new Location(bestDNA.GetX(), bestDNA.GetY());
            return localizaciones;
        }
        /// <summary>
        /// Proceso que calcula la fitness de cada individuo utilizando la interfaz ICalculadorFitness que implementa el patron decorator
        /// </summary>
        public void CalcularFitness()
        {

            double[] fitnesses = this.calculadorFitness.CalcularFitness(dnas);
            for (int i = 0; i < dnas.Count; i++)
            {

                dnas[i].Setfitness(fitnesses[i]);
                Console.WriteLine($"Fitness: {dnas[i].Getfitness()}");
            }
        }
        /// <summary>
        /// Proceso que crea la matriz de reporducion de esta generacion mediante la interfaz IEstrategiaSeleccion 
        /// que implementa el patron strategy
        /// </summary>
        public void Seleccion()
        {
            estrategiaSeleccion.Seleccion(this.dnas, this.seleccion, this.algorithm);

        }
        /// <summary>
        ///Proceso que crea una nueva poblacion
        ///La creacion de la poblacion se realiza:
        ///eligiendo 2 DNAs de la matriz de reproducion
        ///Utilizando el metodo generarHijo() de poblacion para crear un hijo combinando los otros 2 DNAs
        ///Utilizando el metodo generarHijo() de dna que implementa el patron state para cambiar sus genes
        ///Añadir al hijo a la poblacion
        ///Repetir hasta tener una nueva poblacion del mismo tamaño que la anterior
        /// </summary>
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
                hijos[i].Setfitness(fitnesses[i]);
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
            if (algorithm)
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


