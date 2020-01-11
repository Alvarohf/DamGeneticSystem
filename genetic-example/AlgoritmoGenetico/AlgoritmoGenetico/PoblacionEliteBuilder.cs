class PoblacionEliteBuilder : PoblacionBuilder
{
    public override void CrearCalculadorFitness()
    {
        CalculadorFitnessLineal calc = new CalculadorFitnessLineal();
        poblacion.SetICalculadorFitness(calc);
    }

    public override void CrearEstrategiaSeleccion()
    {
        IEstrategiaSeleccion est = new EstrategiaSeleccionElite();
        poblacion.SetIEstrategiaSeleccion(est);
    }
}