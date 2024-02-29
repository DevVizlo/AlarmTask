using UnityEngine;
using UnityEngine.Events;

public class AlarmDetect : MonoBehaviour
{
    [SerializeField] private UnityEvent _movementEnter;
    [SerializeField] private UnityEvent _movementExit;
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider collision)
    {
        if(_player)
        _movementEnter.Invoke();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (_player)
            _movementExit.Invoke();
    }
}
