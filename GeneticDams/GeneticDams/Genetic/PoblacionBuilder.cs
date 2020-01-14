
namespace GeneticLibrary
{
    public abstract class PoblacionBuilder
    {
        protected Poblacion poblacion;

        public Poblacion GetPoblacion()
        {
            return poblacion;
        }

        public void CrearNuevaPoblacion(double minLat, double minLng, double maxLat, double maxLng)
        {
            poblacion = new Poblacion(minLat, minLng, maxLat, maxLng);
        }

        public abstract void CrearCalculadorFitness();
        public abstract void CrearEstrategiaSeleccion();
    }
}