using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    private int _speed;
    private Vector3 _firstPosition;
    private bool _isStarted;
    // Start is called before the first frame update
    void Start()
    {
        _firstPosition = transform.position;
        _speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isStarted)
        {
            StartCoroutine(ResetPosition());
            _isStarted = true;
        }
        this.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(10);
        this.transform.position = _firstPosition;
        _isStarted = false;
    }
}
