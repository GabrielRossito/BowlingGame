using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class PushBar : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Text _text;

    private RectTransform _holderTransform { get { return transform.GetChild(0).GetComponentInChildren<RectTransform>(); } }
    private RectTransform _rectTransform { get { return GetComponent<RectTransform>(); } }
    private float _maxPosition { get { return _rectTransform.rect.height - _holderTransform.rect.height; } }
    private int _barPercentage
    {
        get
        {
            float p = (100 * _holderTransform.anchoredPosition.y) / _maxPosition;
            return Mathf.Abs((int)p);
        }
    }

    private bool _animate = true, _goingUp = true;
    private Action<int> _stopMovement;

    private void LateUpdate()
    {
        _text.text = _barPercentage.ToString();
    }

    public void StartBar(Action<int> callback)
    {
        _stopMovement = callback;
        _animate = true;
        MoveUp();
    }

    public void StopBar()
    {
        _animate = false;
        StopAllCoroutines();
        if (_stopMovement != null)
        {
            _stopMovement(_barPercentage);
            _stopMovement = null;
        }
    }

    private void MoveUp()
    {
        StopAllCoroutines();
        StartCoroutine(GoTo(Vector2.zero, MoveDown));
    }

    private void MoveDown()
    {
        StopAllCoroutines();
        StartCoroutine(GoTo(new Vector2(0, -_maxPosition), MoveUp));
    }

    private IEnumerator GoTo(Vector2 to, Action callback)
    {
        if (_animate)
        {
            Vector2 from = _holderTransform.anchoredPosition;
            bool finished = false;
            float time = 0;
            while (!finished)
            {
                //print(Vector2.Distance(_holderTransform.anchoredPosition, to));
                finished = Vector2.Distance(_holderTransform.anchoredPosition, to) < 0.1f;
                _holderTransform.anchoredPosition = Vector2.Lerp(from, to, time);
                time += Time.deltaTime * _speed;
                yield return null;
            }

            if (finished)
                callback();
        }
    }
}
