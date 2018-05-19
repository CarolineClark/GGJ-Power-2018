using System.Collections;
using UnityEngine.Events;

public class MonsterEvent
{
    private static string distanceKey = "distance";
    public static void EmitMonsterSawLightEvent(float distance)
    {
        EventManager.TriggerEvent(Constants.MONSTER_SAW_LIGHT_EVENT, CreateDistanceHashtable(distance));
    }

    public static void Listen(UnityAction<Hashtable> listener)
    {
        EventManager.StartListening(Constants.LEVEL_EVENT_KEY, listener);
    }

    public static float ReadDistance(Hashtable h)
    {
        if (h != null && h.ContainsKey(distanceKey))
        {
            return (float)h[distanceKey];
        }
        throw new System.ArgumentException("You have fed the wrong hashtable into this event");
    }

    private static Hashtable CreateDistanceHashtable(float distance)
    {
        Hashtable h = new Hashtable();
        h.Add(distanceKey, distance);
        return h;
    }
}
