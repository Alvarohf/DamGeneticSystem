class CreadorPoblacion
{
    private PoblacionBuilder PoblacionBuilder;

    public void SetPoblacionBuilder(PoblacionBuilder p)
    {
        PoblacionBuilder = p;
    }
    public Poblacion GetPoblacion()
    {
        return PoblacionBuilder.GetPoblacion();
    }
    public void CrearPoblacion()
    {
        PoblacionBuilder.CrearNuevaPoblacion();
        PoblacionBuilder.CrearCalculadorFitness();
        PoblacionBuilder.CrearEstrategiaSeleccion();
    }
}