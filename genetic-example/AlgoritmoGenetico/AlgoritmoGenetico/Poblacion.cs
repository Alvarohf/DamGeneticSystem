using System;
using System.Collections;
using System.Collections.Generic;

class Poblacion
{
    private List<DNA> dnas = new List<DNA>();
    private int popLenght = 20;
    private List<DNA> seleccion = new List<DNA>();
    private int[] target = { 3, 42 };
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
                Console.WriteLine($"Generacion: {i}, DNA: {j} X:{dna.GetX()} Y:{dna.GetY()}");
                j++;
            }
        }
    }
    public void CalcularFitness()
    {
        for (int i = 0; i < dnas.Count; i++)
        {

            dnas[i].Setfitness(this.calculadorFitness.CalcularFitness(dnas[i]));
            Console.WriteLine($"Fitness: {dnas[i].Getfitness()}");
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
        return new DNA(padre.GetX(), madre.GetY());
    }

}


