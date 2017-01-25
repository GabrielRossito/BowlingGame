using UnityEngine;
using System.Collections;

public class BallJump : MonoBehaviour
{
    [SerializeField]
    private float _jumpStrenght = 35;

    private Rigidbody _ballRb { get { return GetComponent<Rigidbody>(); } }
    private bool _jumping = false;
    private float _timer = 1;

    public void Jump()
    {
        if (_jumping) return;
        _jumping = true;
        _ballRb.AddForce(0, _jumpStrenght, 0, ForceMode.Impulse);

        StartCoroutine(JumpTimerCount());
    }

    public void JumpStrength(float strenght)
    {
        _jumpStrenght = strenght;
    }

    public void JumpTimer(float timer)
    {
        _timer = timer;
    }

    private IEnumerator JumpTimerCount()
    {
        float timer = 0;
        while (timer < _timer)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _jumping = false;
    }
}