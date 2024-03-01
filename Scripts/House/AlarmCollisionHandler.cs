using UnityEngine;

public class AlarmCollisionHandler : Alarm
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider collision)
    {
        if (_player)
            PlaySound();
    }

    private void OnTriggerExit(Collider collision)
    {
        if (_player)
            StopSound();
    }
}
