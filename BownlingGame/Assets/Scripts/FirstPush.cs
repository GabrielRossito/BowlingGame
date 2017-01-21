using System;
using UnityEngine;
using UnityEngine.UI;

public class FirstPush : MonoBehaviour
{
    [SerializeField] private int _impulse = 300, _minPower = 4000, _maxPower = 6500;
    [SerializeField] private float _velocity = 80;
    [SerializeField] private Text DebugValue;

    private Rigidbody _ballRb { get { return GetComponent<Rigidbody>(); } }
    private bool _pushed;
    private Vector3 _lastAccelerationInput = Vector3.zero;

    private void Awake()
    {
        PrepareLaunch();
    }

    void LateUpdate()
    {
        if (_pushed)
        {
            _lastAccelerationInput = Input.acceleration;
            _ballRb.AddRelativeForce(new Vector3(Input.acceleration.x * _velocity, 0, 0));
        }
        string debug = string.Empty;
        debug += "Phone Tilt: " + Input.acceleration.x + System.Environment.NewLine;
        DebugValue.text = debug;
    }

    private void RestartForces()
    {
        _ballRb.velocity = Vector3.zero;
        _ballRb.angularVelocity = Vector3.zero;
    }

    public void PrepareLaunch()
    {
        _pushed = false;
        _ballRb.freezeRotation = true;
        RestartForces();
    }

    public void Push(int percentage)
    {
        _pushed = true;
        _ballRb.freezeRotation = false;
        _ballRb.AddForce(0, 0, _impulse, ForceMode.Impulse);
        _ballRb.AddForce(0, 0, (_maxPower * percentage / 100), ForceMode.Force);
    }

    public void ChangeImpulse(float value)
    {
        _impulse = (int)value;
    }

    public void ChangeVelocity(float vel)
    {
        _velocity = vel;
    }
}
