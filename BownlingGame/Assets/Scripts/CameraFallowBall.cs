using UnityEngine;
using System.Collections;

public class CameraFallowBall : MonoBehaviour
{
    [SerializeField]
    private Transform _follow;
    [SerializeField]
    private Vector3 _offset = new Vector3(0, 1, -2);
    [SerializeField]
    private float _speed = 3;

    private bool _startFallow;

    public void StartFollow()
    {
        _startFallow = true;
    }

    private void LateUpdate()
    {
        if (_startFallow)
            transform.position = Vector3.Lerp(transform.position, _follow.transform.position + _offset, Time.deltaTime * _speed);
    }
}
