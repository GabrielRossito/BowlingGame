using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System;

public class ObstacleDeath : MonoBehaviour
{
    [Serializable]
    public class ObstacleEvent : UnityEvent { }

    public ObstacleEvent _onBallHit = new ObstacleEvent();

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallManager>())
            _onBallHit.Invoke();
    }
}