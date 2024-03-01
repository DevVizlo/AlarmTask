using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _corotineVolume;

    private float _minVolume = 0f;
    private float _maxVolume = 2f;

    private float _movementVolume = 0.2f;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void PlaySound()
    {
        _audioSource.Play();
        ProcessingCoroutine(_maxVolume);
    }

    public void StopSound()
    {
        ProcessingCoroutine(_minVolume);
    }

    private void ProcessingCoroutine(float volumeBoundary)
    {
        if (_corotineVolume != null)
        {
            StopCoroutine(_corotineVolume);
        }

        _corotineVolume = StartCoroutine(ChangeVolume(volumeBoundary));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _movementVolume * Time.deltaTime);

            if (_audioSource.volume == _minVolume)
                _audioSource.Stop();

            yield return null;
        }
    }
}
