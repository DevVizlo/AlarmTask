using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _activateCorotineVolume;
    private Coroutine _deactivateCorotineVolume;

    private float _volume;
    private float _minVolume = 1f;
    private float _maxVolume = 0f;

    private float movementVolume = 0.2f;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void PlaySound()
    {
        StopCoroutineBefore();

        _volume = _minVolume;
        _audioSource.Play();
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        StopCoroutineBefore();

        _volume = _maxVolume;
        StopCoroutine(_activateCorotineVolume);
        _activateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    private void StopCoroutineBefore()
    {
        if (_deactivateCorotineVolume != null)
        {
            StopCoroutine(_deactivateCorotineVolume);
        }

        _deactivateCorotineVolume = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volume, movementVolume * Time.deltaTime);

            yield return null;
        }
    }
}
