using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace F1Speed.Core.Repositories
{
    public static class CircuitRepository
    {
        private static IList<Circuit> _circuits;

        static CircuitRepository()
        {
            _circuits = new List<Circuit>()
                {
                    new Circuit() {Name = "Unknown", TrackLength = 0f, Order = 0, Filename = "Unknown"},
                    new Circuit() {Name = "Australia", TrackLength = 5301.984f, Order = 1, Filename = "Australia"},
                    new Circuit() {Name = "Malaysia", TrackLength = 5549.814f, Order = 2, Filename  = "Malaysia"},
                    new Circuit() {Name = "Bahrain", TrackLength = 5409.189f, Order = 3, Filename = "Bahrain"},
                    new Circuit() {Name = "China", TrackLength = 5444.122f, Order = 4, Filename = "China"},
                    new Circuit() {Name = "Spain", TrackLength = 4651.133f, Order = 5, Filename = "Spain-Catalunya"},
                    new Circuit() {Name = "Monaco", TrackLength = 3322.418f, Order = 6, Filename = "Monaco"},
                    new Circuit() {Name = "Canada", TrackLength = 4371.447f, Order = 7, Filename = "Canada"},
                    new Circuit() {Name = "Austria", TrackLength = 4320.581f, Order = 8, Filename = "Austria"},
                    new Circuit() {Name = "Britian", TrackLength = 5896.262f, Order = 9, Filename = "Britian-Silverstone"},                    
                    new Circuit() {Name = "Germany", TrackLength = 5148.048f, Order = 10, Filename = "Germany-Nurburgring"},
                    new Circuit() {Name = "Hungary", TrackLength = 4378.222f, Order = 11, Filename = "Hungary" },
                    new Circuit() {Name = "Belgium", TrackLength = 7003.279f, Order = 12, Filename = "Belgium" },
                    new Circuit() {Name = "Italy", TrackLength = 5798.160f, Order = 13, Filename = "Italy" },
                    new Circuit() {Name = "Singapore", TrackLength = 5064.113f, Order = 14, Filename = "Singapore" },
                    new Circuit() {Name = "Japan", TrackLength = 5817.484f, Order = 15, Filename = "Japan" },
                    new Circuit() {Name = "Russia", TrackLength = 5822.213f, Order = 16, Filename = "Russia" },
                    new Circuit() {Name = "United States", TrackLength = 5515.625f, Order = 17, Filename = "COTA"},
                    new Circuit() {Name = "Brazil", TrackLength = 4293.856f, Order = 18, Filename = "Brazil" },
                    new Circuit() {Name = "Abu Dahbi", TrackLength = 5542.2f, Order = 19, Filename = "AbuDahbi"},
                    new Circuit() {Name="trento-bondone", TrackLength = 17619.0f, Order = 20, Filename = "AC_trento-bondone"},
                    new Circuit() {Name="suzuka_0.9", TrackLength = 5807.0f, Order = 21, Filename = "AC_suzuka_0.9"},
                    new Circuit() {Name="silverstone", TrackLength = 5901.0f, Order = 22, Filename = "AC_silverstone"},
                    new Circuit() {Name="road america", TrackLength = 6515.0f, Order = 23, Filename = "AC_road america"},
                    new Circuit() {Name="monza", TrackLength = 5793.0f, Order = 24, Filename = "AC_monza"},
                    new Circuit() {Name="laguna seca 2.2", TrackLength = 2238.0f, Order = 25, Filename = "AC_laguna seca 2.2"},
                    new Circuit() {Name="magione", TrackLength = 2507.0f, Order = 26, Filename = "AC_magione"},
                    new Circuit() {Name="spa", TrackLength = 7004.0f, Order = 27, Filename = "AC_spa"},
                    new Circuit() {Name="nurburgring gp", TrackLength = 5148.0f, Order = 28, Filename = "AC_nurburgring gp"},
                    new Circuit() {Name="imola", TrackLength = 4909.0f, Order = 29, Filename = "AC_imola"},
                    new Circuit() {Name="road america2", TrackLength = 40.0f, Order = 30, Filename = "AC_road america2"},
                    new Circuit() {Name="nurburgring-sprint", TrackLength = 3629.0f, Order = 31, Filename = "AC_nurburgring-sprint"},
                    new Circuit() {Name="gentrack 1", TrackLength = 4268.0f, Order = 32, Filename = "AC_gentrack 1"},
                    new Circuit() {Name="donington", TrackLength = 4020.0f, Order = 33, Filename = "AC_donington"},
                    new Circuit() {Name="drag 400m", TrackLength = 400.0f, Order = 34, Filename = "AC_drag 400m"},
                    new Circuit() {Name="silverstone-international", TrackLength = 3619.0f, Order = 35, Filename = "AC_silverstone-international"},
                    new Circuit() {Name="drift", TrackLength = 905.0f, Order = 36, Filename = "AC_drift"},
                    new Circuit() {Name="drag 1000m", TrackLength = 1000.0f, Order = 37, Filename = "AC_drag 1000m"},
                    new Circuit() {Name="silverstone-national", TrackLength = 2638.0f, Order = 39, Filename = "AC_silverstone-national"},
                    new Circuit() {Name="monza 1966", TrackLength = 5793.0f, Order = 40, Filename = "AC_monza 1966"},
                    new Circuit() {Name="bathurst", TrackLength = 6213.0f, Order = 41, Filename = "AC_bathurst"},
                    new Circuit() {Name="mugello", TrackLength = 5245.0f, Order = 42, Filename = "AC_mugello"},
                    new Circuit() {Name="sentul international circuit", TrackLength = 4120.0f, Order = 43, Filename = "AC_sentul international circuit"},
                    new Circuit() {Name="spielberg", TrackLength = 4326.0f, Order = 44, Filename = "AC_spielberg"},
                    new Circuit() {Name="nordschleife endurance", TrackLength = 25378.0f, Order = 45, Filename = "AC_nordschleife endurance"},
                    new Circuit() {Name="nordschleife tourist", TrackLength = 19100.0f, Order = 46, Filename = "AC_nordschleife tourist"},
                    new Circuit() {Name="vallelunga-club", TrackLength = 1746.0f, Order = 47, Filename = "AC_vallelunga-club"},
                    new Circuit() {Name="donington gp", TrackLength = 4020.0f, Order = 48, Filename = "AC_donington gp"},
                    new Circuit() {Name="donington national", TrackLength = 3185.0f, Order = 49, Filename = "AC_donington national"},
                    new Circuit() {Name="vallelunga", TrackLength = 4085.0f, Order = 50, Filename = "AC_vallelunga"},
                    new Circuit() {Name="nordschleife", TrackLength = 20832.0f, Order = 51, Filename = "AC_nordschleife"},
                    new Circuit() {Name="spielberg south course", TrackLength = 2400.0f, Order = 52, Filename = "AC_spielberg south course"}
                };
        }

        public static Circuit GetByTrackLength(float trackLength)
        {
            Circuit matchedCircuit;
            try
            {
                matchedCircuit = _circuits.OrderBy(x => Math.Abs(x.TrackLength - trackLength)).First();
            }
            catch (InvalidOperationException)
            {
                matchedCircuit = _circuits.ElementAt(0);
            }
            return matchedCircuit;
        }        

        public static List<Circuit> GetAll()
        {
            return _circuits.OrderBy(x => x.Order).ToList();
        }
    }
}
