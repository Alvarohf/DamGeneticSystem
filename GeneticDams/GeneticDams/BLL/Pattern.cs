using GeneticLibrary;
using GoogleMapsApi.Entities.Common;
using GoogleMapsApi.Entities.Elevation.Request;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using GoogleMapsApi;
using System.Collections.Generic;
using System;

namespace GeneticDams.BLL
{
    public class Pattern
    {
        public string Result { get; set; }

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
            System.Diagnostics.Debug.WriteLine(p.Simulacion(1));
            Result = "AAA";
        }
    }

namespace SignalRChat.Hubs
    {
        public class ChatHub : Hub
        {
            public async Task SendMessage(string typeMessage, string message)
            {

               List<double> limites = message.Replace("(", "").Replace(")", "").Split(",").Select(Double.Parse).ToList();
                Pattern genetic = new Pattern(limites);
                if (typeMessage=="init")
                {
                    await Clients.All.SendAsync("ReceiveMessage", "start",
                       genetic.Result);
                } else if(typeMessage == "elev") {
                    await Clients.All.SendAsync("ReceiveMessage", "finish", "Finishing ...");
                }
                
            }
        }
    }
}

