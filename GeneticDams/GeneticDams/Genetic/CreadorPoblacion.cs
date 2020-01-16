namespace GeneticLibrary
{
    public class CreadorPoblacion
    {
        private PoblacionBuilder PoblacionBuilder;
        private readonly double minLat;
        private readonly double minLng;
        private readonly double maxLat;
        private readonly double maxLng;
        // True search for hills false search for valleys
        private readonly bool algorithm;
        public CreadorPoblacion(double minLat, double minLng, double maxLat, double maxLng,bool algorithm)
        {
            this.maxLat = maxLat;
            this.maxLng = maxLng;
            this.minLat = minLat;
            this.minLng = minLng;
            this.algorithm = algorithm;
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
            PoblacionBuilder.CrearNuevaPoblacion( minLat,  minLng,  maxLat,  maxLng, algorithm);
            PoblacionBuilder.CrearCalculadorFitness();
            PoblacionBuilder.CrearEstrategiaSeleccion();
        }
    }
}