using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlaramTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _alarm;
    [SerializeField] private AnimationCurve _soundLoundessCurve;
    [SerializeField] private float _duration = 5f;

    private void Start()
    {
        _alarm = GetComponent<AudioSource>();
        _soundLoundessCurve.preWrapMode = WrapMode.PingPong;
        _soundLoundessCurve.postWrapMode = WrapMode.PingPong;
    }

    private void Update()
    {
        _alarm.volume = _soundLoundessCurve.Evaluate(Time.time / _duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief> (out Thief thief))
        {
            _alarm.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alarm.Stop();
    }
}
