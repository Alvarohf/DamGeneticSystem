namespace GeneticLibrary
{
   public class PoblacionRuedaRuletaBuilder : PoblacionBuilder
    {
        /// <summary>
        /// Al utilizar un metodo de seleccion Rueda Ruleta 
        /// es necesario una fitness que acentue los cambios de los individuos
        /// implemeta patron builder
        /// </summary>
        public override void CrearCalculadorFitness()
        {
            CalculadorFitnessLineal calc = new CalculadorFitnessLineal();
            Decorator cE = new CalculadorFitnessExponencial(calc);
            poblacion.SetICalculadorFitness(cE);
        }
        /// <summary>
        /// Al utilizar un metodo de seleccion Rueda Ruleta 
        /// es necesario una fitness que acentue los cambios de los individuos
        /// implemeta patron builder
        /// </summary>
        public override void CrearEstrategiaSeleccion()
        {
            IEstrategiaSeleccion est = new EstrategiaSeleccionRuedaRuleta();
            poblacion.SetIEstrategiaSeleccion(est);
        }
    }
}