using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PinsBoard : MonoBehaviour
{
    [SerializeField] private Text _numberCount;
    [SerializeField] private Transform[] _boardLinesParent;
    [SerializeField] private Transform _pinsParent;

    public int PinsUp { get; private set; }
    public int PinsDown { get { return 10 - PinsUp;} }

    private List<Image> _boardPins = new List<Image>();
    private PinUp[] _pins;

    void Awake()
    {
        _pins = _pinsParent.GetComponentsInChildren<PinUp>();
        for (int i = 0; i < _boardLinesParent.Length; i++)
            _boardPins.AddRange(_boardLinesParent[i].GetComponentsInChildren<Image>());
    }

    void LateUpdate()
    {
        int countPins = 0;
        for (int i = 0; i < _pins.Length; i++)
        {
            if (_pins[i].IsUp)
            {
                _boardPins[i].color = Color.white;
                countPins++;
            }
            else
            {
                _boardPins[i].color = Color.black;
            }
        }

        if (PinsUp != countPins)
        {
            PinsUp = countPins;
            _numberCount.text = PinsUp.ToString();
        }
    }
}