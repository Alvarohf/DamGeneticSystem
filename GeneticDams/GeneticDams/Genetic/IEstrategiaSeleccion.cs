using System.Collections.Generic;
namespace GeneticLibrary
{
    public interface IEstrategiaSeleccion
    {
        void Seleccion(List<DNA> poblacion, List<DNA> seleccion, bool max);
    }
}