using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeneticDams.BLL
{

    public interface IBuilder
    {
        void BuildColors();
        void BuildUnits();
        void BuildStep();
    }

    public class ConcreteBuilder : IBuilder
    {
        private Product _product = new Product();
        public ConcreteBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._product = new Product();
        }
        public void BuildColors()
        {
            this._product.Add("PartA1");
        }
        public void BuildUnits()
        {
            this._product.Add("PartB1");
        }
        public void BuildStep()
        {
            this._product.Add("PartC1");
        }

        public Product GetProduct()
        {
            Product result = this._product;
            this.Reset();
            return result;
        }
    }

    public class Product
    {
        private List<object> _parts = new List<object>();

        public void Add(string part)
        {
            this._parts.Add(part);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }
    public class Map
    {
        // Map location
        public string MapString;
        // Feet = false meters = true
        public bool Measure { get; set; }
        public int Step { get; set; }
        // Array of colours
        public int ColourCollection { get; }

        public Map(bool p_measure, int p_colourCollection, int p_step, string p_map = "/maps/map.json")
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
    public class MapDirector
    {
        private IBuilder MapBuilder;
        public IBuilder Builder
        {
            set { MapBuilder = value; }
        }

        // The Director can construct several product variations using the same
        // building steps.
        public void buildFullMap()
        {
            this.MapBuilder.BuildColors();
            this.MapBuilder.BuildStep();
            this.MapBuilder.BuildUnits();
        }
        public void buildMapUnits()
        {
            this.MapBuilder.BuildUnits();
        }
        public void buildMapStep()
        {
            this.MapBuilder.BuildStep();
        }
        public void buildMapColors()
        {
            this.MapBuilder.BuildColors();
        }
    }

    public class ColorFactory
    {

    }
}
