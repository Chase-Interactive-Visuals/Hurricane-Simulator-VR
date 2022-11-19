using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    [SerializeField] GameObject _userPhone;

    [SerializeField] TextMeshProUGUI _interactableToolTip;

    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(DoSomething);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(DoSomething);
    }
    private void DoSomething()
    {
        //_windZone.
    }

}
