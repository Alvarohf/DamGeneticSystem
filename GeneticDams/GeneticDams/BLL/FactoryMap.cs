using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GeneticDams.BLL
{



    public class SingleFactoryMap
    {
        // Singleton Pattern
        private SingleFactoryMap() { }
        private static SingleFactoryMap _instance;
        public static SingleFactoryMap GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingleFactoryMap();
            }
            return _instance;
        }

        public static int METERS = 0;
        public static int FEETS = 1;

        public Map getMap(int unit, string p_map = "/maps/map.json")
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

    public abstract class Map
    {
        // Map location
        public string MapString;
        public abstract int[] GetHeights();
        public abstract int MaxHeight();
        public abstract int MinHeight();
        public abstract string GetUnit();
        public abstract void SetHeights(int[] heights);
        public int CountLayers()
        {
            int layers = 0;
            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
                layers = features.Count;
            }
            return layers;
        }
        public string geometryType()
        {
            return "Polygon";
        }
        public string getInformation()
        {

            return "Layers: " + CountLayers()+"\nGeometry: " +geometryType();
        }
    }

    public class MapMeters : Map
    {

        public int[] Heights;

        override
        public int[] GetHeights()
        {
            return new int[2];
        }
        override
        public string GetUnit()
        {
            return "Meters";
        }
        override
       public void SetHeights(int[] heights)
        {
            this.Heights = heights;
        }

        public MapMeters(string p_map = "/maps/map.json")
        {
            base.MapString = p_map;

            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
                int[] heights = new int[features.Count];
                for (int i = 0; i < features.Count; i++)
                {
                    JObject properties = (JObject)features[i]["properties"];
                    heights[i] = (int)properties["elevation"];
                }
                Heights = heights;
            }
        }
        public string GetMapString()
        {
            return MapString;
        }
       override
       public int MaxHeight()
        {
            return Heights[Heights.Length - 1];
        }
       override
       public int MinHeight()
        {
            return Heights[0];
        }
    }
    public class MapFeets : Map
    {
        public int[] Heights;

        override
        public int[] GetHeights()
        {
            return Heights;
        }
        override
        public string GetUnit()
        {
            return "Feets";
        }
        override
        public void SetHeights(int[] heights)
        {
            this.Heights = heights;
        }
        public MapFeets(string p_map = "/maps/map.json")
        {
            base.MapString = p_map;

            using (StreamReader file = File.OpenText(@".\wwwroot\" + MapString))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JObject geoJson = (JObject)JToken.ReadFrom(reader);
                JArray features = (JArray)geoJson["features"];
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
       override
       public int MaxHeight()
        {
            return Heights[Heights.Length - 1];
        }
       override
       public int MinHeight()
        {
            return Heights[0];
        }
        public string GetMapString()
        {
            return MapString;
        }
    }
}
