using UnityEngine;

public class PinUp : MonoBehaviour
{
    [Header("Debug"), SerializeField] private float _angle;

    [HideInInspector] public bool IsUp;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    void Start()
    {
        _startRotation = transform.GetChild(0).transform.rotation;
        _startPosition = transform.GetChild(0).transform.position;
    }

    void LateUpdate()
    {
        _angle = Quaternion.Angle(_startRotation, transform.GetChild(0).transform.rotation);
        IsUp = _angle < 25;
    }

    public void RestartPosition()
    {
        transform.GetChild(0).transform.position = _startPosition;
        transform.GetChild(0).transform.rotation = _startRotation;
    }
}
