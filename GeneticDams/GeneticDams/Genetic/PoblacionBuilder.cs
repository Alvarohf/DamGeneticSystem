
namespace GeneticLibrary
{
    public abstract class PoblacionBuilder
    {
        protected Poblacion poblacion;

        public Poblacion GetPoblacion()
        {
            return poblacion;
        }

        public void CrearNuevaPoblacion(double minLat, double minLng, double maxLat, double maxLng,bool algorithm)
        {
            poblacion = new Poblacion(minLat, minLng, maxLat, maxLng, algorithm);
        }

        public abstract void CrearCalculadorFitness();
        public abstract void CrearEstrategiaSeleccion();
    }
}