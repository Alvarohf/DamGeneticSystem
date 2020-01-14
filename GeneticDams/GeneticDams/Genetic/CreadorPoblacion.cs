namespace GeneticLibrary
{
    public class CreadorPoblacion
    {
        private PoblacionBuilder PoblacionBuilder;
        private readonly double minLat;
        private readonly double minLng;
        private readonly double maxLat;
        private readonly double maxLng;
        public CreadorPoblacion(double minLat, double minLng, double maxLat, double maxLng)
        {
            this.maxLat = maxLat;
            this.maxLng = maxLng;
            this.minLat = minLat;
            this.minLng = minLng;
        }
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
            PoblacionBuilder.CrearNuevaPoblacion( minLat,  minLng,  maxLat,  maxLng);
            PoblacionBuilder.CrearCalculadorFitness();
            PoblacionBuilder.CrearEstrategiaSeleccion();
        }
    }
}