using GeneticLibrary;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Elevation.Request;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using GoogleMapsApi;
using System.Collections.Generic;
using System;
using System.Globalization;
using GeneticDams.BLL.SignalRChat.Hubs;

namespace GeneticDams.BLL
{
    public class Pattern
    {
        public string Result { get; set; }
        public Location[][] Locations{ get; set; }

        public Pattern(List<Double> limites)
        {
            Poblacion p;
            CreadorPoblacion creador = new CreadorPoblacion(limites[0], limites[1], limites[2], limites[3]);
            PoblacionBuilder pE = new PoblacionEliteBuilder();
            // ROLLO MENU
            PoblacionBuilder pR = new PoblacionRuedaRuletaBuilder();
            creador.SetPoblacionBuilder(pR);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            int num = 10;
            Locations = new Location[num][];
            Location[] oneLocation;
            for (int i = 0; i < num; i++)
            {
                Locations[i] = new Location[20];
                oneLocation = p.Simulacion(1);
                for (int j = 0; j < oneLocation.Length-1; j++) {
                    Locations[i][j] = oneLocation[j];
                        }
                Result = "";
            }

        }
    }

namespace SignalRChat.Hubs
    {
        public class ChatHub : Hub
        {
            public async Task SendMessage(string typeMessage, string message)
            {
                List<double> limites = message.Replace("(", "").Replace(")", "").Split(",").Select((coord) => double.Parse(coord, CultureInfo.InvariantCulture)).ToList();
                Pattern genetic = new Pattern(limites);
                if (typeMessage=="init")
                {
                    await Clients.All.SendAsync("ReceiveMessage",
                      genetic.Locations, genetic.Result);
                } else if(typeMessage == "elev") {
                    await Clients.All.SendAsync("ReceiveMessage", "finish", "Finishing ...");
                }
                
            }
        }
    }
}

