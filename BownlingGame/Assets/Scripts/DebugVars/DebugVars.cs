using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DebugVars : MonoBehaviour
{
    [SerializeField] private DebugVarsInput _inputPrefab;
    [SerializeField] private DebugVarData[] _data;

    private List<DebugVarsInput> _inputs = new List<DebugVarsInput>();

    private void Start()
    {
        for (int i = 0; i < _data.Length; i++)
        {
            DebugVarsInput input = Instantiate(_inputPrefab);
            input.transform.SetParent(transform, false);
			input.transform.localScale = Vector2.one;
            input.Initialize(_data[i]);
            _inputs.Add(input);
        }
    }
}
