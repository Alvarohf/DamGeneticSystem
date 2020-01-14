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

namespace GeneticDams.BLL
{
    public class Pattern
    {
        public string Result { get; set; }
        public Location[] Locations { get; set; }

        public Pattern(List<Double> limites)
        {
            Poblacion p;
            CreadorPoblacion creador = new CreadorPoblacion(limites[0], limites[1], limites[2], limites[3]);
            PoblacionBuilder pE = new PoblacionEliteBuilder();
            // ROLLO MENU
            PoblacionBuilder pR = new PoblacionRuedaRuletaBuilder();
            creador.SetPoblacionBuilder(pE);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            Locations = p.Simulacion(1);
            foreach (Location location in Locations)
            {
                Result += $"Position: Lat:{location.Latitude} Lon:{location.Longitude}";
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

