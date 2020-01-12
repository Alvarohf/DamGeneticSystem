
namespace GeneticLibrary
{
    public abstract class PoblacionBuilder
    {
        protected Poblacion poblacion;

        public Poblacion GetPoblacion()
        {
            return poblacion;
        }

        public void CrearNuevaPoblacion()
        {
            poblacion = new Poblacion();
        }

        public abstract void CrearCalculadorFitness();
        public abstract void CrearEstrategiaSeleccion();
    }
}