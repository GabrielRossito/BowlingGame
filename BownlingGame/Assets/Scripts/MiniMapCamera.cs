using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class MiniMapCamera : MonoBehaviour
{
    [SerializeField] private Transform _lookAt, _follow;
    [SerializeField] private Vector3 _followDistance = new Vector3(0.05f, 1.35f, -8);
    [SerializeField] private float _minHeight = 1.35f, _maxHeight = 5, _speed = 5;
    [SerializeField] private int _minFoV = 15, _maxFoV = 120;

    private float _minDist = 1, _maxDist;
    private int _deltaFov { get { return _minFoV - _maxFoV; } }

    private Camera _camera { get { return GetComponent<Camera>(); } }

    void Start()
    {
        _maxDist = Vector3.Distance(_lookAt.position, transform.position);
    }

    void LateUpdate()
    {
        transform.LookAt(_lookAt);

        float dist = Vector3.Distance(_lookAt.position, transform.position);
        float deltaDist = _maxDist - _minDist;
        float deltaheight = _maxHeight - _minHeight;
        float height = (((dist - _minDist) * deltaheight) / deltaDist) + _maxHeight; 
        Vector3 followDist = _followDistance + Vector3.up * height;
        transform.position = Vector3.Lerp(transform.position, _follow.transform.position + followDist, Time.deltaTime * _speed);

        dist = _maxDist - dist;
        _camera.fieldOfView = (((_minDist - dist) * _deltaFov) / _maxFoV) + _minFoV;
    }

}
