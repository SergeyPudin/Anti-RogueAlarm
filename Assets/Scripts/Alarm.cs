using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _adjustSpeed;

    private Coroutine _coroutine;
   
    public void SoundOn()
    {        
        float targetVolume = 1;

        StopCoroutineIfRun();

        _audioSource.Play();
        _audioSource.volume = 0;

        _coroutine = StartCoroutine(AdjustSound(targetVolume));
    }

    public void SoundOff()
    {
        float targetVolume = 0;

        StopCoroutineIfRun();

        _coroutine= StartCoroutine(AdjustSound(targetVolume));      
    }

    private void StopCoroutineIfRun()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private IEnumerator AdjustSound(float targetVolume)
    {
        float currentVolume = _audioSource.volume;

        while (currentVolume != targetVolume)
        {
            currentVolume = Mathf.MoveTowards(currentVolume, targetVolume, _adjustSpeed * Time.deltaTime);

            _audioSource.volume = currentVolume;

            yield return null;
        }

        if (_audioSource.volume == 0)       
            _audioSource.Stop();           
    }
}