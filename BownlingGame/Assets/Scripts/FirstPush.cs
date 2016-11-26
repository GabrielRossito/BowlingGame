using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstPush : MonoBehaviour
{
    [SerializeField]
    private int _impulse = 10, _minPower = 500, _maxPower = 1500;

    private Rigidbody _ballRb { get { return GetComponent<Rigidbody>(); } }

    private void Awake()
    {
        _ballRb.freezeRotation = true;
    }

    public void Push(int percentage)
    {
        _ballRb.freezeRotation = false;
        _ballRb.AddForce(0, 0, _impulse, ForceMode.Impulse);
        //print((_maxPower * percentage / 100));
        _ballRb.AddForce(0, 0, (_maxPower * percentage / 100), ForceMode.Force);
    }
}
