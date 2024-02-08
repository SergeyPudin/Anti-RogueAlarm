using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _adjustSpeed;

    private Coroutine _coroutine;
   
    public void SoundOn()
    {
        float currentVolume = 0;
        float targetVolume = 1;

        TryToStopCoroutine();

        _audioSource.Play();

        _coroutine = StartCoroutine(AdjustSound(currentVolume, targetVolume));
    }

    public void SoundOff()
    {
        float currentVolume = 1;
        float targetVolume = 0;

        TryToStopCoroutine();

        _coroutine= StartCoroutine(AdjustSound(currentVolume,targetVolume));        
    }

    private void TryToStopCoroutine()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator AdjustSound(float currentVolume, float targetVolume)
    {
        while (currentVolume != targetVolume)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, targetVolume, _adjustSpeed * Time.deltaTime);

            _audioSource.volume = currentVolume;

            yield return null;
        }
    }
}