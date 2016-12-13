using UnityEngine;
using UnityEngine.UI;

public class FirstPush : MonoBehaviour
{
    [SerializeField] private int _impulse = 10, _minPower = 500, _maxPower = 1500;
    [SerializeField] private float _velocity = 20;
    [SerializeField] private Text DebugValue;

    private Rigidbody _ballRb { get { return GetComponent<Rigidbody>(); } }

    private bool _pushed;
    private Vector3 _lastAcceleration;

    private void Awake()
    {
        Input.backButtonLeavesApp = true;

        _ballRb.freezeRotation = true;
        _lastAcceleration = transform.rotation.eulerAngles;

    }
    
    void LateUpdate()
    {
        if (_pushed)
            _ballRb.AddForce(new Vector3(Input.acceleration.x * _velocity, 0,0));
        string debug = string.Empty;
        debug += Input.acceleration + System.Environment.NewLine;
        DebugValue.text = debug;
    }

    public void Push(int percentage)
    {
        _pushed = true;
        _ballRb.freezeRotation = false;
        _ballRb.AddForce(0, 0, _impulse, ForceMode.Impulse);
        //print((_maxPower * percentage / 100));
        _ballRb.AddForce(0, 0, (_maxPower * percentage / 100), ForceMode.Force);
    }
}
