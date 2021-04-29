using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEnterEvent = null;
    [SerializeField] private UnityEvent _onExitEvent = null;

    private void OnTriggerEnter(Collider other)
    {
        _onEnterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _onExitEvent?.Invoke();
    }
}
