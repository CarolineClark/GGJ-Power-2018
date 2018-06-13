using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMoveEvent {
    private static string PLAYER_MOVE_EVENT = "player-move-event";

    public static Vector2 Read(Hashtable h)
    {
        return ReadEvent.ReadKeyFromHashtable<Vector2>(h, PLAYER_MOVE_EVENT);
    }

    public static void TriggerEvent(Vector2 data) {
        EventManager.TriggerEvent(PLAYER_MOVE_EVENT, CreateHashtable(data));
    }

    private static Hashtable CreateHashtable(Vector2 data) {
        Hashtable h = new Hashtable();
        h.Add(PLAYER_MOVE_EVENT, data);
        return h;
    }

    public static void Listen(UnityAction<Hashtable> listener)
    {
        EventManager.StartListening(PLAYER_MOVE_EVENT, listener);
    }
}
