namespace GeneticLibrary
{
    public class PoblacionEliteBuilder : PoblacionBuilder
    {
        /// <summary>
        /// como utilizamos un metodo de seleccion elite el calculo de la fitness no es importante
        /// dejamos la fitness standard
        /// implemeta patron builder
        /// </summary>
        public override void CrearCalculadorFitness()
        {
            CalculadorFitnessLineal calc = new CalculadorFitnessLineal();
            poblacion.SetICalculadorFitness(calc);
        }
        /// <summary>
        /// como utilizamos un metodo de seleccion elite el calculo de la fitness no es importante
        /// dejamos la fitness standard
        /// implemeta patron builder
        /// </summary>
        public override void CrearEstrategiaSeleccion()
        {
            IEstrategiaSeleccion est = new EstrategiaSeleccionElite();
            poblacion.SetIEstrategiaSeleccion(est);
        }
    }
}