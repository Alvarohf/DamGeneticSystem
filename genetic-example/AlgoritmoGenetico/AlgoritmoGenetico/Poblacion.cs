using System;
using System.Collections;
using System.Collections.Generic;

class Poblacion
{
    private List<DNA> dnas = new List<DNA>();
    private int popLenght = 20;
    private List<DNA> seleccion = new List<DNA>();
    public int[] target = { 3, 42 };  
    public IEstrategiaSeleccion estrategiaSeleccion;
    public Poblacion(IEstrategiaSeleccion seleccion)
    {
        this.estrategiaSeleccion = seleccion;

        for (int i = 0; i < popLenght; i++)
        {
            dnas.Add(new DNA());

        }
        Console.WriteLine(dnas.Count + "estoy aqui");
    }
    public void Simulacion()
    {
        for (int i = 0; i < 20; i++)
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
        for (int i = 0; i < dnas.Count; i++)
        {

            dnas[i].fitness = (double)1.0 / (Math.Abs(target[0] - dnas[i].X) + 1) + 1.0 / (Math.Abs(target[1] - dnas[i].Y) + 1);
            Console.WriteLine($"Fitness: {dnas[i].fitness}");
        }
    }

    public void Seleccion()
    {
        estrategiaSeleccion.Seleccion(this.dnas,this.seleccion);

    }
    public void GenerarPoblacion()
    {
        Random rnd = new Random();
        Console.WriteLine(this.seleccion.Count);
        for (int i = 0; i < dnas.Count; i++)
        {
            dnas[i] = generarHijo(seleccion[rnd.Next(seleccion.Count)], seleccion[rnd.Next(seleccion.Count)]).mutarHijo();

        }
    }
    public DNA generarHijo(DNA padre, DNA madre)
    {
        return new DNA(padre.X, madre.Y);
    }

}


