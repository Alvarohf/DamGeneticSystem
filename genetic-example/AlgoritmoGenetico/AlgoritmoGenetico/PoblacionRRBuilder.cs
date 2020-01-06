class PoblacionRuedaRuletaBuilder : PoblacionBuilder
{
    public override void CrearCalculadorFitness()
    {
        CalculadorFitnessLineal calc = new CalculadorFitnessLineal();
        Decorator cE = new CalculadorFitnessExponencial(calc);
        poblacion.SetICalculadorFitness(cE);
    }

    public override void CrearEstrategiaSeleccion()
    {
        IEstrategiaSeleccion est = new EstrategiaSeleccionRuedaRuleta();
        poblacion.SetIEstrategiaSeleccion(est);
    }
}