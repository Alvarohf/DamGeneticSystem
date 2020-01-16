using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GeneticDams.BLL
{


    /// <summary>
    /// Singleton Factory that creates maps using Template
    /// </summary>
    public class SingleFactoryMap
    {
        // Singleton Pattern
        // Private constructor to avoid create new ones
        private SingleFactoryMap() { }
        // The unique instance
        private static SingleFactoryMap _instance;
        // Method to get the unique instance
        public static SingleFactoryMap GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingleFactoryMap();
            }
            return _instance;
        }

        // Factory maps types
        public static int METERS = 0;
        public static int FEETS = 1;

        /// <summary>
        /// Return a specific map in execution time depending on unit
        /// </summary>
        /// <param name="unit">Unit that determines the map</param>
        /// <param name="p_map">Map path</param>
        /// <returns>Map to use</returns>
        public Map GetMap(int unit, string p_map = "/maps/map.json")
        {
            if (unit == METERS)
            {
                return (new MapMeters(p_map));
            }
            else
            {
                return (new MapFeets(p_map));
            }
        }

    }

    /// <summary>
    /// Abstract class that implements the maps and use Template Pattern
    /// </summary>
    public abstract class Map
    {
        // Map path
        public string MapString;
        public abstract int[] GetHeights();
        public abstract int MaxHeight();
        public abstract int MinHeight();
        public abstract string GetUnit();
        public abstract void SetHeights(int[] heights);

        /// <summary>
        /// Counts the layers in the map
        /// </summary>
        /// <returns>Number of layers</returns>
        public int CountLayers()
        {
            int layers = 0;
            // Read the JSON
            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                // We move in the hierarchy of the JSON
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
                // We get the layers from features
                layers = features.Count;
            }
            return layers;
        }
        // Returns the geometry of the map
        public string geometryType()
        {
            return "Polygon";
        }
        /// <summary>
        /// Uses Template using primitive operations to show map data
        /// </summary>
        /// <returns>Map data</returns>
        public string getInformation()
        {
            
            return "Layers: " + CountLayers()+"\nGeometry: " +geometryType()+ "\nUnits: " + GetUnit();
        }
    }

    /// <summary>
    /// Concrete implementation of the map that uses meters
    /// </summary>
    public class MapMeters : Map
    {

        public int[] Heights;

        /// <summary>
        /// Constructor of the map
        /// </summary>
        /// <param name="p_map">Map path</param>
        public MapMeters(string p_map = "/maps/map.json")
        {
            base.MapString = p_map;

            // Read the JSON
            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                // Navigate through hierarchy
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
                // Get the elevation for each layer
                int[] heights = new int[features.Count];
                for (int i = 0; i < features.Count; i++)
                {
                    JObject properties = (JObject)features[i]["properties"];
                    heights[i] = (int)properties["elevation"];
                }
                // Set Heights with map heights
                Heights = heights;
            }
        }

        /// <summary>
        /// Gets the heights
        /// </summary>
        /// <returns>Heights of the map</returns>
        override
        public int[] GetHeights()
        {
            return Heights;
        }
        /// <summary>
        /// Gets the units of the map
        /// </summary>
        /// <returns>Type of unit</returns>
        override
        public string GetUnit()
        {
            return "Meters";
        }
        /// <summary>
        /// Set the heights to the parameter
        /// </summary>
        /// <param name="heights">Heights to set</param>
       override
       public void SetHeights(int[] heights)
        {
            this.Heights = heights;
        }

        /// <summary>
        /// Gets the path of the map
        /// </summary>
        /// <returns>Path of the map</returns>
        public string GetMapString()
        {
            return MapString;
        }
        /// <summary>
        /// Returns the maximum height
        /// </summary>
        /// <returns>Maximum height</returns>
       override
       public int MaxHeight()
        {
            return Heights[Heights.Length - 1];
        }
        /// <summary>
        /// Returns the minimum height
        /// </summary>
        /// <returns>Minimum height</returns>
       override
       public int MinHeight()
        {
            return Heights[0];
        }
    }
    /// <summary>
    /// Concrete implementation of the map that uses feets
    /// </summary>
    public class MapFeets : Map
    {
        public int[] Heights;

        /// <summary>
        /// Constructor of the map
        /// </summary>
        /// <param name="p_map">Map path</param>
        public MapFeets(string p_map = "/maps/map.json")
        {
            base.MapString = p_map;

            // Read the JSON
            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                // Navigate through hierarchy
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
                // Get the elevation for each layer
                int[] heights = new int[features.Count];
                for (int i = 0; i < features.Count; i++)
                {
                    JObject properties = (JObject)features[i]["properties"];
                    // Meters to feet conversion
                    heights[i] = (int)((double)properties["elevation"] / 0.3048);
                }
                Heights = heights;
            }
        }

        /// <summary>
        /// Gets the heights
        /// </summary>
        /// <returns>Heights of the map</returns>
        override
        public int[] GetHeights()
        {
            return Heights;
        }
        /// <summary>
        /// Gets the units of the map
        /// </summary>
        /// <returns>Type of unit</returns>
        override
        public string GetUnit()
        {
            return "Meters";
        }
        /// <summary>
        /// Set the heights to the parameter
        /// </summary>
        /// <param name="heights">Heights to set</param>
        override
        public void SetHeights(int[] heights)
        {
            this.Heights = heights;
        }

        /// <summary>
        /// Gets the path of the map
        /// </summary>
        /// <returns>Path of the map</returns>
        public string GetMapString()
        {
            return MapString;
        }
        /// <summary>
        /// Returns the maximum height
        /// </summary>
        /// <returns>Maximum height</returns>
        override
        public int MaxHeight()
        {
            return Heights[Heights.Length - 1];
        }
        /// <summary>
        /// Returns the minimum height
        /// </summary>
        /// <returns>Minimum height</returns>
        override
        public int MinHeight()
        {
            return Heights[0];
        }
    }
}
