using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour
{
    public FirstPush Push { get { return GetComponent<FirstPush>(); } }

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    public void Restart()
    {
        transform.position = _startPosition;
        Push.PrepareLaunch();
    }

    public void ChangeWeight(float val)
    {
        GetComponent<Rigidbody>().mass = val;
    }

    public void ChangeDrag(float val)
    {
        GetComponent<Rigidbody>().drag = val;
    }
}
