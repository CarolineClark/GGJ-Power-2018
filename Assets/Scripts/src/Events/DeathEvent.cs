using System.Collections;
using UnityEngine.Events;

public class DeathEvent
{
    public static void ListenForPlayerFallingEvent(UnityAction<Hashtable> listener)
    {
        EventManager.StartListening(Constants.DEATH_EVENT_PLAYER_KEY_FALLING, listener);
    }

    public static void EmitPlayerFalling()
    {
        EventManager.TriggerEvent(Constants.DEATH_EVENT_PLAYER_KEY_FALLING, null);
    }

    public static void ListenForPlayerDeathEvent(UnityAction<Hashtable> listener)
    {
        EventManager.StartListening(Constants.DEATH_EVENT_PLAYER_KEY, listener);
    }

    public static void EmitPlayerGeneral()
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
