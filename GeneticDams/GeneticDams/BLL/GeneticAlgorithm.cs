using GeneticLibrary;
using GoogleMapsApi.Entities.Common;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Globalization;

namespace GeneticDams.BLL
{
    /// <summary>
    /// Class that joins web and genetic module
    /// </summary>
    public class GeneticAlgorithm
    {
        public string Result { get; set; }
        public Location[][] Locations{ get; set; }

        /// <summary>
        /// Constructor that calls and get the data from genetics
        /// </summary>
        /// <param name="limites"> Bounds of the map</param>
        /// <param name="algorithm">Type of algorithm to use</param>
        /// <param name="strategy">Strategy to select DNAs</param>
        public GeneticAlgorithm(List<Double> limites, string algorithm, string strategy)
        {
            // Declare and init variables
            Poblacion p;
            PoblacionBuilder pb;
            CreadorPoblacion creador = new CreadorPoblacion(limites[0], limites[1], limites[2], limites[3], (algorithm=="Hills"));
            // Select one type of builder
            if (strategy == "Roulette")
            {
                pb = new PoblacionRuedaRuletaBuilder();
            } else
            {
                pb = new PoblacionEliteBuilder();
            }
            // Create the poblation
            creador.SetPoblacionBuilder(pb);
            creador.CrearPoblacion();
            p = creador.GetPoblacion();
            // Number of iterations
            int num = 10;
            // Locations of the points
            Locations = new Location[num][];
            Location[] oneLocation;
            // Start simulation and retrieve the points
            for (int i = 0; i < num; i++)
            {
                Locations[i] = new Location[20];
                oneLocation = p.Simulacion(1);
                // Get the data of each iteration to display it
                for (int j = 0; j < oneLocation.Length-1; j++) {
                    Locations[i][j] = oneLocation[j];
                        }
                // Best result of all
                Result = "Finished. Best point: "+"Lat: "+Locations[i][0].Latitude+"Lng: "+ Locations[i][0].Longitude;
            }

        }
    }

namespace SignalRChat.Hubs
    {
        /// <summary>
        /// Class that sends data in real time using a websocket
        /// </summary>
        public class ChatHub : Hub
        {
            /// <summary>
            /// Method to send an receive message using a Hub
            /// </summary>
            /// <param name="typeStrategy">Type of strategy (Roulette or elite)</param>
            /// <param name="typeAlgorithm">Type of algorithm to use (Hills or valleys)</param>
            /// <param name="message">Bounds of the map</param>
            /// <returns>Returns a task to send a message</returns>
            public async Task SendMessage(string typeStrategy, string typeAlgorithm, string message)
            {
                // Parse bounds from string to list of double
                List<double> limites = message.Replace("(", "").Replace(")", "").Split(",").Select((coord) => double.Parse(coord, CultureInfo.InvariantCulture)).ToList();
                // Call the genetic library
                GeneticAlgorithm genetic = new GeneticAlgorithm(limites,typeAlgorithm, typeStrategy);
                // Send answer to clients
                await Clients.All.SendAsync("ReceiveMessage",
                      genetic.Locations, genetic.Result);
                
            }
        }
    }
}

