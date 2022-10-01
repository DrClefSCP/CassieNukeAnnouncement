namespace AutoNukeTest
{
    using Exiled.API.Features;
    using MEC;
    using System.Collections.Generic;
    using Serv = Exiled.Events.Handlers.Server;

    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        private EventHandler Event;
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public override void OnEnabled()
        {
            Instance = this;
            Event = new EventHandler();
            Serv.RoundStarted += Event.OnRoundStart;
            Serv.EndingRound += Event.OnRoundEnd;

        }
        public override void OnDisabled()
        {
            Serv.WaitingForPlayers -= Event.OnRoundStart;
            Serv.EndingRound -= Event.OnRoundEnd;
            Instance = this;
            Event = new EventHandler();
        }
    }
}