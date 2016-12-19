using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PrototypeSceneManage : MonoBehaviour
{
    [SerializeField] private BallManager _ball;
    [SerializeField] private PushBar _bar;
    [SerializeField] private Transform _pinsParent;
    [SerializeField] private PinsBoard _board;
    [SerializeField] private CameraFallowBall _follow;

    [SerializeField] private Text _textPoints;

    private List<int> _points = new List<int>();
    private PinUp[] _pins;

    private void Awake()
    {
        Input.backButtonLeavesApp = true;
    }

    private void Start()
    {
        _pins = _pinsParent.GetComponentsInChildren<PinUp>();
        _bar.StartBar(BarStoped);
    }

    public void ActionRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void ActionSpareAttempt()
    {
        _bar.StartBar(BarStoped);
        _ball.Restart();
        _textPoints.text = string.Empty;
        int total = 0;
        for (int i = 0; i < _points.Count; i++)
        {
            _textPoints.text += _points[i].ToString() + System.Environment.NewLine;
            total += _points[i];
        }
        _textPoints.text += _board.PinsDown + "..." + System.Environment.NewLine;
        total += _board.PinsDown;
        _textPoints.text += "Total: " + total;
    }

    public void ActionNexPlay()
    {
        _bar.StartBar(BarStoped);
        _ball.Restart();
        for (int i = 0; i < _pins.Length; i++)
            _pins[i].RestartPosition();
        _points.Add(_board.PinsDown);
        _textPoints.text = string.Empty;
        int total = 0;
        for (int i = 0; i < _points.Count; i++)
        {
            _textPoints.text += _points[i].ToString() + System.Environment.NewLine;
            total += _points[i];
        }
        _textPoints.text += "Total: " + total;
    }

    private void BarStoped(int powerPercentage)
    {
        _ball.Push.Push(powerPercentage);
        _follow.StartFollow();
    }
}
