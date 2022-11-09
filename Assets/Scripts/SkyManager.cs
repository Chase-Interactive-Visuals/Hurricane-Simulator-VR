using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyManager : MonoBehaviour
{
    [SerializeField] StateManager _stateManager;
    private void OnEnable()
    {
        StateManager.OnStateChange.AddListener(ChangeSkyBoxMaterial);
    }
    private void OnDisable()
    {
        StateManager.OnStateChange.RemoveListener(ChangeSkyBoxMaterial);
    }
    private void ChangeSkyBoxMaterial()
    {
        RenderSettings.skybox = _stateManager._currentSkybox;
        DynamicGI.UpdateEnvironment();
    }
}
