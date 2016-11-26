using UnityEngine;
using System.Collections;
using System;

public class PrototypeSceneManage : MonoBehaviour
{
    [SerializeField]
    private FirstPush _push;
    [SerializeField]
    private PushBar _bar;
    [SerializeField]
    private CameraFallowBall _follow;

    private void Start()
    {
        _bar.StartBar(BarStoped);
    }

    private void BarStoped(int powerPercentage)
    {
        _push.Push(powerPercentage);
        _follow.StartFollow();
    }
}
