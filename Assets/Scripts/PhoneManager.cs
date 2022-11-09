using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PhoneManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;

    [SerializeField] VideoPlayer _phoneVideoPlayer;

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
        SetPhoneCurrentVideoDisplayed();
    }

    void SetPhoneCurrentVideoDisplayed()
    {
        _phoneVideoPlayer.clip = _stateManager._currentPhoneVideoClip;
    }
}
