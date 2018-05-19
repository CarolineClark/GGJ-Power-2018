using System.Collections;
using UnityEngine.Events;

public class DeathEvent
{
    public static void ListenForPlayerDeathEvent(UnityAction<Hashtable> listener) {
        EventManager.StartListening(Constants.DEATH_EVENT_PLAYER_KEY, listener);    
    }

    public static void EmitPlayer()
    {
        EventManager.TriggerEvent(Constants.DEATH_EVENT_PLAYER_KEY, null);
    }

    public static void ListenForGameManagerDeathEvent(UnityAction<Hashtable> listener)
    {
        EventManager.StartListening(Constants.DEATH_EVENT_GAMEMANAGER_KEY, listener);
    }

    public static void EmitForGameManager()
    {
        EventManager.TriggerEvent(Constants.DEATH_EVENT_GAMEMANAGER_KEY, null);
    }
}
