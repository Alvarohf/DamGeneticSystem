using GoogleMapsApi;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Elevation.Request;
using GoogleMapsApi.Entities.Elevation.Response;
using System;
using System.Collections.Generic;

namespace GeneticLibrary
{
    public class CalculadorFitnessLineal : ICalculadorFitness
    {   
        /// <summary>
        /// calcula la fitness de un individuo mirando cual es la altura 
        /// del punto en el que esta el individuo
        /// </summary>
        /// <param name="dna"></param>
        /// <returns></returns>
        public double[] CalcularFitness(List<DNA> dna)
        {
            Location[] locations = new Location[dna.Count];
            double[] alturas = new double[dna.Count];
            for (int i = 0; i < dna.Count; i++)
            {

                locations[i] = new Location(dna[i].GetX(),dna[i].GetY());
            }
            var elevaciones = Elevation_ReturnsCorrectElevation(locations);
            int j = 0;
            foreach(var elevacion in elevaciones)
            {
                alturas[j] = Double.Parse(elevacion.Elevation.ToString());
                j++;
            }
            return alturas;
        }
        public IEnumerable<Result> Elevation_ReturnsCorrectElevation(IEnumerable<Location> locations)
        {
            var request = new ElevationRequest
            {
                ApiKey = "AIzaSyAtuFD6vSzYrVkEoxvlkztgwJLWRKUkzq0",
                Locations = locations
            };

            var result = GoogleMaps.Elevation.Query(request);
            return result.Results;
        }
    }

}