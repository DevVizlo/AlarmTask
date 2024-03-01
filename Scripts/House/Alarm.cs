using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private AudioSource _audioSource;
    private Coroutine _corotineVolume;

    private float _volume;
    private float _minVolume = 0f;
    private float _maxVolume = 2f;

    private float movementVolume = 0.2f;


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
    }

    public void PlaySound()
    {
        _volume = _maxVolume;

        _audioSource.Play();
        ProcessingCoroutine();
    }

    public void StopSound()
    {
        _volume = _minVolume;

        ProcessingCoroutine();
    }

    private void ProcessingCoroutine()
    {
        if (_corotineVolume != null)
        {
            StopCoroutine(_corotineVolume);
        }

        _corotineVolume = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _volume, movementVolume * Time.deltaTime);

            if (_audioSource.volume == _minVolume)
                _audioSource.Stop();

            yield return null;
        }
    }
}
