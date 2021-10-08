using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class AlaramTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private float _currentLoudness = 0f;
    [SerializeField] private float _duration = 3;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief> (out Thief thief))
        {
            _alarm.Play();
            StopAllCoroutines();
            _currentLoudness = _alarm.volume;
            StartCoroutine(IncreaseLoudness());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopAllCoroutines();
        _currentLoudness = _alarm.volume;
        StartCoroutine(DecreaseLoudness());
    }

    private IEnumerator IncreaseLoudness()
    {
        for (float timePassed = 0; timePassed < _duration; timePassed += Time.deltaTime)
        {
            _alarm.volume = Mathf.MoveTowards(_currentLoudness, 1, timePassed/ _duration);
            yield return null;
        }
    }

    private IEnumerator DecreaseLoudness()
    {
        for (float timePassed = 0; timePassed < _duration; timePassed += Time.deltaTime)
        {
            _alarm.volume = Mathf.MoveTowards(_currentLoudness, 0, timePassed/ _duration);
            yield return null;
        }
    }
}
