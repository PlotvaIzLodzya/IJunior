using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(AudioSource))]

public class AlaramTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private AnimationCurve _soundLoundessCurve;
    [SerializeField] private float _duration = 5f;
    [SerializeField] private bool _isInHouse;
    [SerializeField] private float timePassed = 0;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _soundLoundessCurve.preWrapMode = WrapMode.PingPong;
        _soundLoundessCurve.postWrapMode = WrapMode.PingPong;
    }

    private void Update()
    {
        if (_isInHouse)
            StartCoroutine(ChangeLoudness());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief> (out Thief thief))
        {
            _alarm.Play();
            _isInHouse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.Stop();
        _isInHouse = false;
        timePassed = 0;
    }

    IEnumerator ChangeLoudness()
    {
        timePassed += Time.deltaTime;
        _alarm.volume = _soundLoundessCurve.Evaluate(timePassed / _duration);

        yield return null;
    }
}
