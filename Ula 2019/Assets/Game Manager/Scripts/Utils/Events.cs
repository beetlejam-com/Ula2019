using UnityEngine.Events;

public class Events
{
    [System.Serializable] public class EventFadeComple : UnityEvent<bool> { }
    [System.Serializable] public class EventGameState : UnityEvent<GameManager.GameState, GameManager.GameState> { }

}
