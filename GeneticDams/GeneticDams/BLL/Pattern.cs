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
            CreadorPoblacion creador = new CreadorPoblacion(40.6874070521213, -2.44102478027344, 40.867314583648, -1.99607849121094);
            PoblacionBuilder pE = new PoblacionEliteBuilder();
            // ROLLO MENU
            PoblacionBuilder pR = new PoblacionRuedaRuletaBuilder();
            creador.SetPoblacionBuilder(pE);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            Result=(p.Simulacion(5));
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

