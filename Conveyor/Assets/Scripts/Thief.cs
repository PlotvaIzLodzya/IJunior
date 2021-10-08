using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 10;

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * Time.deltaTime * _speed);
    }
}
