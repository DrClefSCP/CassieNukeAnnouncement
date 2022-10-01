using AutoNukeTest;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
    class EventHandler
{
    public void OnRoundStart() //Round start ya que al ser relacionado con la NUKE (warhead) se debe iniciar al momento en que la partida inicie
    {
        if (Plugin.Instance.Config.Delay1 > 0) // Se inicia siempre y cuando el tiempo este por encima de 0 segundos (Para evitar posibles bugs o directamente deshabilitarlo)
            Plugin.Instance.Coroutines.Add(Timing.RunCoroutine(Events())); // Se añade la corutina a la lista iniciandola
    }
    public void OnRoundEnd(EndingRoundEventArgs ev)
    {
        foreach (CoroutineHandle i in Plugin.Instance.Coroutines) // Toma cada corutina en la lista de corutinas y las finaliza
            Timing.KillCoroutines(i);
        Plugin.Instance.Coroutines.Clear(); //Limpia la lista, de esta forma va a estar preparada y limpia para la siguiente ronda
    }
    private IEnumerator<float> Events()
    {
        yield return Timing.WaitForSeconds(Plugin.Instance.Config.Delay1); // Se inicia con el yield return del delay del primer mensaje 
        Cassie.MessageTranslated(Plugin.Instance.Config.CassieMessage1, Plugin.Instance.Config.CassieText1); // Se envia el primer mensaje traducido y dicho del cassie
        yield return Timing.WaitForSeconds(Plugin.Instance.Config.Delay2 - Plugin.Instance.Config.Delay1); // Se inicia con el yield return del delay del segundo mensaje
        Cassie.MessageTranslated(Plugin.Instance.Config.CassieMessage2, Plugin.Instance.Config.CassieText2); // Se envia el segundo mensaje traducido y dicho del cassie
    }
}