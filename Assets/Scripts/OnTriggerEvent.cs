using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class OnTriggerEvent : MonoBehaviour
{
    public UnityEvent onEnter;
    [Tag] public string hitTag = "Player";

    // Make the game run an event when an object/player/enemy enters the trigger zone.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == hitTag)
        {
            onEnter.Invoke();
        }
    }
}