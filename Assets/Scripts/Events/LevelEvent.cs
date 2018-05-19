﻿using System.Collections;
using UnityEngine.Events;

public class LevelEvent
{

    public static void EmitCheckpoint(int level)
    {
        EventManager.TriggerEvent(Constants.LEVEL_EVENT_KEY, CreateLevelHashtable(level));
    }

    public static void Listen(UnityAction<Hashtable> listener) {
        EventManager.StartListening(Constants.LEVEL_EVENT_KEY, listener);
    }

    public static int ReadCheckpoint(Hashtable h)
    {
        if (h != null && h.ContainsKey(Constants.LEVEL_EVENT_KEY))
        {
            return (int)h[Constants.LEVEL_EVENT_KEY];
        }
        throw new System.ArgumentException("You have fed the wrong hashtable into this event");
    }

    private static Hashtable CreateLevelHashtable(int level)
    {
        Hashtable h = new Hashtable();
        h.Add(Constants.LEVEL_EVENT_KEY, level);
        return h;
    }
}