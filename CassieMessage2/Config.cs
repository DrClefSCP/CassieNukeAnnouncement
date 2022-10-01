namespace AutoNukeTest
{
    using System.ComponentModel;
    using Exiled.API.Interfaces;

    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        
        [Description("Tiempo en segundos de la partida donde se enviara el Cassie 1")]
        public float Delay1 { get; set; } = 900;
        
        [Description("Mensaje textual del Cassie 1")]
        public string CassieText1 { get; set; } = "La nuke iniciara en 5 minutos";
        
        [Description("Mensaje verbal del Cassie 1")]
        public string CassieMessage1 { get; set; } = "The Nuke will start in 5 minutes";

        [Description("Tiempo en segundos de la partida donde se enviara el Cassie 2")]
        public float Delay2 { get; set; } = 1440;

        [Description("Mensaje textual del Cassie 2")]
        public string CassieText2 { get; set; } = "La nuke iniciara en 1 minuto";

        [Description("Mensaje verbal del Cassie 2")]
        public string CassieMessage2 { get; set; } = "The Nuke will start in 1 minutes";
    }
}
