using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticDams.BLL
{
    public class Map2
    {
        // Map location
        public string MapString;
        // Feet = false meters = true
        public bool Measure { get; set; }
        public int Step { get; set; }
        // Array of colours
        public int ColourCollection { get; }

        public Map2(bool p_measure, int p_colourCollection,int p_step,string p_map="/maps/map.json")
        {
            this.Step = p_step;
            this.Measure = p_measure;
            this.ColourCollection = p_colourCollection;
            this.MapString = p_map;
        }
        public string GetMapString()
        {
            return MapString;
        }
    }
}
