using UnityEngine;
using UnityEngine.SceneManagement;

public class PrototypeSceneManage : MonoBehaviour
{
    [SerializeField] private FirstPush _push;
    [SerializeField] private PushBar _bar;
    [SerializeField] private CameraFallowBall _follow;

    private void Start()
    {
        _bar.StartBar(BarStoped);
    }

    public void ActionRestart()
    {
        SceneManager.LoadScene(0);
    }

    private void BarStoped(int powerPercentage)
    {
        _push.Push(powerPercentage);
        _follow.StartFollow();
    }
}
