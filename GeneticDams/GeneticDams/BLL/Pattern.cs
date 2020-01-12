using GeneticLibrary;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Elevation.Request;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;

namespace GeneticDams.BLL
{
    public class Pattern
    {
        public string Result { get; set; }
        public Pattern()
        {
            Poblacion p;
            CreadorPoblacion creador = new CreadorPoblacion();
            PoblacionBuilder pE = new PoblacionEliteBuilder();
            PoblacionBuilder pR = new PoblacionRuedaRuletaBuilder();
            creador.SetPoblacionBuilder(pE);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            Result = Elevation_ReturnsCorrectElevation();
        }
        public string Elevation_ReturnsCorrectElevation()
        {
            var request = new ElevationRequest
            {
                ApiKey = "AIzaSyAtuFD6vSzYrVkEoxvlkztgwJLWRKUkzq0",
                Locations = new[] { new Location(41.0683315, -3.34627) }
            };

           // var result = GoogleMaps.Elevation.Query(request);
            return "result.Results.First().Elevation.ToString()";
        }
    }

namespace SignalRChat.Hubs
    {
        public class ChatHub : Hub
        {
            public async Task SendMessage(string typeMessage, string message)
            {
                if (typeMessage=="init")
                {
                    await Clients.All.SendAsync("ReceiveMessage", "start", message);
                } else if(typeMessage == "elev") {
                    await Clients.All.SendAsync("ReceiveMessage", "finish", "Finishing ...");
                }
                
            }
        }
    }
}

