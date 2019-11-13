using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class OnTriggerEvent : MonoBehaviour
{
    public UnityEvent onEnter;
    [Tag] public string hitTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == hitTag)
        {
            onEnter.Invoke();
        }
    }
}