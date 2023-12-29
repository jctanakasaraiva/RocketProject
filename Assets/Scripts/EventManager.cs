using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action UpdateScoreEvent;
    public static event Action ClearScoreEvent;

    public static void StartUpdateScoreEvent()
    {
        UpdateScoreEvent?.Invoke();
    }

    public static void StartClearScoreEvent()
    {
        ClearScoreEvent?.Invoke();
    }
}
