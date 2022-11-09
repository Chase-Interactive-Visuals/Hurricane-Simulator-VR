using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class StateManager : MonoBehaviour
{
    public static UnityEvent OnStateChange = new UnityEvent();

    [HideInInspector]
    public string _currentState = States.WelcomeState;

    //Skybox Materials for all States
    [Header("Skybox Materials")]
    [Tooltip("Select the SkyBox Material for each State")]
    [SerializeField] Material _skyBoxMat_PreHurricane;
    [SerializeField] Material _skyBoxMat_OuterBands;
    [SerializeField] Material _skyBoxMat_Category1;
    [SerializeField] Material _skyBoxMat_Category2;
    [SerializeField] Material _skyBoxMat_Category3;
    [SerializeField] Material _skyBoxMat_Category4;
    [SerializeField] Material _skyBoxMat_Eyewall;
    [SerializeField] Material _skyBoxMat_Aftermath;

    //Wind Speeds for all states
    [Header("Wind Pre-Hurricane")]
    [Tooltip("Strength Of Wind")]
    [SerializeField] float _windZoneMainPreHurricane;

    [Tooltip("Randomness of Wind Strength")]
    [SerializeField] float _windZoneTurbulencePreHurricane;

    [Tooltip("Strength Of Wind Pulses")]
    [SerializeField] float _windZonePulseMagnitudePreHurricane;

    [Tooltip("Frequency Of Wind Pulses")]
    [SerializeField] float _windZonePulseFrequencyPreHurricane;

    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedPreHurricane;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyPreHurricane;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountPreHurricane;

    //Wind Speeds for all states
    [Header("Wind Outer Bands")]
    [SerializeField] float _windZoneMainOuterBands;
    [SerializeField] float _windZoneTurbulenceOuterBands;
    [SerializeField] float _windZonePulseMagnitudeOuterBands;
    [SerializeField] float _windZonePulseFrequencyOuterBands;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedOuterBands;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyOuterBands;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountOuterBands;

    //Wind Speeds for all states
    [Header("Wind Category 1")]
    [SerializeField] float _windZoneMainCategory1;
    [SerializeField] float _windZoneTurbulenceCategory1;
    [SerializeField] float _windZonePulseMagnitudeCategory1;
    [SerializeField] float _windZonePulseFrequencyCategory1;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedCategory1;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyCategory1;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountCategory1;

    //Wind Speeds for all states
    [Header("Wind Category 2")]
    [SerializeField] float _windZoneMainCategory2;
    [SerializeField] float _windZoneTurbulenceCategory2;
    [SerializeField] float _windZonePulseMagnitudeCategory2;
    [SerializeField] float _windZonePulseFrequencyCategory2;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedCategory2;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyCategory2;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountCategory2;

    //Wind Speeds for all states
    [Header("Wind Category 3")]
    [SerializeField] float _windZoneMainCategory3;
    [SerializeField] float _windZoneTurbulenceCategory3;
    [SerializeField] float _windZonePulseMagnitudeCategory3;
    [SerializeField] float _windZonePulseFrequencyCategory3;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedCategory3;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyCategory3;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountCategory3;

    //Wind Speeds for all states
    [Header("Wind Category 4")]
    [SerializeField] float _windZoneMainCategory4;
    [SerializeField] float _windZoneTurbulenceCategory4;
    [SerializeField] float _windZonePulseMagnitudeCategory4;
    [SerializeField] float _windZonePulseFrequencyCategory4;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedCategory4;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyCategory4;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountCategory4;

    //Wind Speeds for all states
    [Header("Wind Eye Wall")]
    [SerializeField] float _windZoneMainEyeWall;
    [SerializeField] float _windZoneTurbulenceEyeWall;
    [SerializeField] float _windZonePulseMagnitudeEyeWall;
    [SerializeField] float _windZonePulseFrequencyEyeWall;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedEyeWall;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyEyeWall;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountEyeWall;

    //Wind Speeds for all states
    [Header("Wind Aftermath")]
    [SerializeField] float _windZoneMainAftermath;
    [SerializeField] float _windZoneTurbulenceAftermath;
    [SerializeField] float _windZonePulseMagnitudeAftermath;
    [SerializeField] float _windZonePulseFrequencyAftermath;
    [Range(0, 5)]
    [SerializeField] float _windManagerSpeedAftermath;
    [Range(0, 0.5f)]
    [SerializeField] float _windManagerWorldFrequencyAftermath;
    [Range(0, 0.1f)]
    [SerializeField] float _windManagerBendAmountAftermath;

    //Rain levels for all states
    [Header("Rain Levels")]
    [SerializeField] float _rainLevel_PreHurricane;
    [SerializeField] float _rainLevel_OuterBands;
    [SerializeField] float _rainLevel_Category1;
    [SerializeField] float _rainLevel_Category2;
    [SerializeField] float _rainLevel_Category3;
    [SerializeField] float _rainLevel_Category4;
    [SerializeField] float _rainLevel_EyeWall;

    //May be deprecated if we decide to only use active/inactive Water Objects
    //to chnange water levels at State Change Events
    //Water levels for all states
    [Header("Water Levels")]
    [SerializeField] float _waterLevel_SurgeStart;
    [SerializeField] float _waterLevel_SurgeMax;
    [SerializeField] float _waterLevel_SurgeReceding;

    //Water Level Models for all states
    [Header("Water Object For Each State")]
    [SerializeField] GameObject _waterObjectPreHurricane;
    [SerializeField] GameObject _waterObjectSurgeStart;
    [SerializeField] GameObject _waterObjectSurgeMax;
    [SerializeField] GameObject _waterObjectSurgeReceding;

    // Debris levels for all states
    [Header("Debris Levels")]
    [SerializeField] float _debrisLevel_PreHurricane;
    [SerializeField] float _debrisLevel_OuterBands;
    [SerializeField] float _debrisLevel_Category1;
    [SerializeField] float _debrisLevel_Category2;
    [SerializeField] float _debrisLevel_Category3;
    [SerializeField] float _debrisLevel_Category4;
    [SerializeField] float _debrisLevel_Eyewall;
    [SerializeField] float _debrisLevel_StormyNight;

    //Tree Models for all states
    [Header("Tree Groups For Each State")]
    [SerializeField] GameObject _TreeGroupPreHurricane;
    [SerializeField] GameObject _TreeGroupOuterBands;
    [SerializeField] GameObject _TreeGroupCategory1;
    [SerializeField] GameObject _TreeGroupCategory2;
    [SerializeField] GameObject _TreeGroupCategory3;
    [SerializeField] GameObject _TreeGroupCategory4;
    [SerializeField] GameObject _TreeGroupEyeWall;
    [SerializeField] GameObject _TreeGroupAftermath;

    //Particle Models for all states
    [Header("Particle Groups For Each State")]
    [SerializeField] GameObject _ParticleGroupPreHurricane;
    [SerializeField] GameObject _ParticleGroupOuterBands;
    [SerializeField] GameObject _ParticleGroupCategory1;
    [SerializeField] GameObject _ParticleGroupCategory2;
    [SerializeField] GameObject _ParticleGroupCategory3;
    [SerializeField] GameObject _ParticleGroupCategory4;
    [SerializeField] GameObject _ParticleGroupEyeWall;
    [SerializeField] GameObject _ParticleGroupAftermath;

    //Debris Models for all states
    [Header("Debris Groups For Each State")]
    [SerializeField] GameObject _DebrisGroupPreHurricane;
    [SerializeField] GameObject _DebrisGroupOuterBands;
    [SerializeField] GameObject _DebrisGroupCategory1;
    [SerializeField] GameObject _DebrisGroupCategory2;
    [SerializeField] GameObject _DebrisGroupCategory3;
    [SerializeField] GameObject _DebrisGroupCategory4;
    [SerializeField] GameObject _DebrisGroupEyeWall;
    [SerializeField] GameObject _DebrisGroupAftermath;

    //Current Phone and Television Video Clips to Display
    [HideInInspector]
    public VideoClip _currentPhoneVideoClip;
    [HideInInspector]
    public VideoClip _currentTelevisionVideoClip;

    [HideInInspector]
    public Material _currentSkybox;

    [HideInInspector]
    public float _currentWindSpeed;

    [HideInInspector]
    public float _currrentRainLevel;

    [HideInInspector]
    public float _currentDebrisLevel;

    [HideInInspector]
    public float _currentWindZoneMain;

    [HideInInspector]
    public float _currentWindZoneTurbulence;

    [HideInInspector]
    public float _currentWindZonePulseMagnitude;

    [HideInInspector]
    public float _currentWindZonePulseFrequencye;

    [HideInInspector]
    public float _currentWindManagerSpeed;

    [HideInInspector]
    public float _currentWindManagerWorldFrequency;

    [HideInInspector]
    public float _currentWindManagerBendAmount;

    [HideInInspector]
    public GameObject _currentActiveTreeGroup;

    [HideInInspector]
    public float _currentWaterLevel;

    [HideInInspector]
    public GameObject _currentActiveWaterObject;

    [HideInInspector]
    public GameObject _currentActiveParticleGroup;

    [HideInInspector]
    public GameObject _currentActiveDebrisGroup;

    private void Awake()
    {
        _currentSkybox = _skyBoxMat_PreHurricane;
        _currrentRainLevel = _rainLevel_PreHurricane;
        _currentDebrisLevel = _debrisLevel_PreHurricane;

        _currentWindZoneMain = _windZoneMainPreHurricane;
        _currentWindZoneTurbulence = _windZoneTurbulencePreHurricane;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudePreHurricane;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyPreHurricane;
        _currentWindManagerSpeed = _windManagerSpeedPreHurricane;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyPreHurricane;
        _currentWindManagerBendAmount = _windManagerBendAmountPreHurricane;
        _currentActiveTreeGroup = _TreeGroupPreHurricane;
        _currentActiveWaterObject = _waterObjectPreHurricane;
        _currentActiveParticleGroup = _ParticleGroupPreHurricane;
        _currentActiveDebrisGroup = _DebrisGroupPreHurricane;
    }

    public void ChangeState(string stateName)
    {
        switch (stateName)
        {
            case States.WelcomeState:
                Enter_WelcomeState();
                break;
            case States.PreHurricaneState:
                Enter_PreHurricaneState();
                break;
            case States.OuterBandsState:
                Enter_OuterBandsState();
                break;
            case States.Category1State:
                Enter_Category1State();
                break;
            case States.Category2State:
                Enter_Category2State();
                break;
            case States.Category3State:
                Enter_Category3State();
                break;
            case States.Category4State:
                Enter_Category4State();
                break;
            case States.EyewallState:
                Enter_EyewallState();
                break;
            case States.StormSurgeStartState:
                Enter_StormSurgeStartState();
                break;
            case States.StormSurgeMaxState:
                Enter_StormSurgeMaxState();
                break;
            case States.StormSurgeRecedingState:
                Enter_StormSurgeRecedingState();
                break;
            case States.AftermathState:
                Enter_AftermathState();
                break;
            case States.CompletionState:
                Enter_CompletionState();
                break;
        }
        OnStateChange.Invoke();
    }
    private void Enter_WelcomeState()
    {
        _currentState = States.WelcomeState;
    }

    private void Enter_PreHurricaneState()
    {
        _currentState = States.PreHurricaneState;
        _currentSkybox = _skyBoxMat_PreHurricane;
        _currrentRainLevel = _rainLevel_PreHurricane;

        _currentWindZoneMain = _windZoneMainPreHurricane;
        _currentWindZoneTurbulence = _windZoneTurbulencePreHurricane;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudePreHurricane;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyPreHurricane;
        _currentWindManagerSpeed = _windManagerSpeedPreHurricane;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyPreHurricane;
        _currentWindManagerBendAmount = _windManagerBendAmountPreHurricane;

        _currentActiveTreeGroup = _TreeGroupPreHurricane;
        _currentActiveWaterObject = _waterObjectPreHurricane;
        _currentActiveParticleGroup = _ParticleGroupPreHurricane;
        _currentActiveDebrisGroup = _DebrisGroupPreHurricane;
    }
    private void Enter_OuterBandsState()
    {
        _currentState = States.OuterBandsState;
        _currentSkybox = _skyBoxMat_OuterBands;
        _currrentRainLevel = _rainLevel_OuterBands;

        _currentWindZoneMain = _windZoneMainOuterBands;
        _currentWindZoneTurbulence = _windZoneTurbulenceOuterBands;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeOuterBands;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyOuterBands;
        _currentWindManagerSpeed = _windManagerSpeedOuterBands;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyOuterBands;
        _currentWindManagerBendAmount = _windManagerBendAmountOuterBands;

        _currentActiveTreeGroup = _TreeGroupOuterBands;
        _currentActiveParticleGroup = _ParticleGroupOuterBands;
        _currentActiveDebrisGroup = _DebrisGroupOuterBands;
    }
    private void Enter_Category1State()
    {
        _currentState = States.Category1State;
        _currentSkybox = _skyBoxMat_Category1;
        _currrentRainLevel = _rainLevel_Category1;

        _currentWindZoneMain = _windZoneMainCategory1;
        _currentWindZoneTurbulence = _windZoneTurbulenceCategory1;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeCategory1;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyCategory1;
        _currentWindManagerSpeed = _windManagerSpeedCategory1;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyCategory1;
        _currentWindManagerBendAmount = _windManagerBendAmountCategory1;

        _currentActiveTreeGroup = _TreeGroupCategory1;
        _currentActiveParticleGroup = _ParticleGroupCategory1;
        _currentActiveDebrisGroup = _DebrisGroupCategory1;
    }
    private void Enter_Category2State()
    {
        _currentState = States.Category2State;
        _currentSkybox = _skyBoxMat_Category2;
        _currrentRainLevel = _rainLevel_Category2;

        _currentWindZoneMain = _windZoneMainCategory2;
        _currentWindZoneTurbulence = _windZoneTurbulenceCategory2;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeCategory2;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyCategory2;
        _currentWindManagerSpeed = _windManagerSpeedCategory2;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyCategory2;
        _currentWindManagerBendAmount = _windManagerBendAmountCategory2;

        _currentActiveTreeGroup = _TreeGroupCategory2;
        _currentActiveParticleGroup = _ParticleGroupCategory2;
        _currentActiveDebrisGroup = _DebrisGroupCategory2;
    }
    private void Enter_Category3State()
    {
        _currentState = States.Category3State;
        _currentSkybox = _skyBoxMat_Category3;
        _currentWaterLevel = _waterLevel_SurgeStart;
        _currrentRainLevel = _rainLevel_Category3;

        _currentWindZoneMain = _windZoneMainCategory3;
        _currentWindZoneTurbulence = _windZoneTurbulenceCategory3;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeCategory3;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyCategory3;
        _currentWindManagerSpeed = _windManagerSpeedCategory3;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyCategory3;
        _currentWindManagerBendAmount = _windManagerBendAmountCategory3;

        _currentActiveTreeGroup = _TreeGroupCategory3;
        _currentActiveParticleGroup = _ParticleGroupCategory3;
        _currentActiveDebrisGroup = _DebrisGroupCategory3;
    }
    private void Enter_Category4State()
    {
        _currentState = States.Category4State;
        _currentSkybox = _skyBoxMat_Category4;
        _currrentRainLevel = _rainLevel_Category4;

        _currentWindZoneMain = _windZoneMainCategory4;
        _currentWindZoneTurbulence = _windZoneTurbulenceCategory4;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeCategory4;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyCategory4;
        _currentWindManagerSpeed = _windManagerSpeedCategory4;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyCategory4;
        _currentWindManagerBendAmount = _windManagerBendAmountCategory4;

        _currentActiveTreeGroup = _TreeGroupCategory4;
        _currentActiveParticleGroup = _ParticleGroupCategory4;
        _currentActiveDebrisGroup = _DebrisGroupCategory4;
    }
    private void Enter_EyewallState()
    {
        _currentState = States.EyewallState;
        _currentSkybox = _skyBoxMat_Eyewall;
        _currrentRainLevel = _rainLevel_EyeWall;

        _currentWindZoneMain = _windZoneMainEyeWall;
        _currentWindZoneTurbulence = _windZoneTurbulenceEyeWall;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeEyeWall;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyEyeWall;
        _currentWindManagerSpeed = _windManagerSpeedEyeWall;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyEyeWall;
        _currentWindManagerBendAmount = _windManagerBendAmountEyeWall;

        _currentActiveTreeGroup = _TreeGroupEyeWall;
        _currentActiveParticleGroup = _ParticleGroupEyeWall;
        _currentActiveDebrisGroup = _DebrisGroupEyeWall;
    }
    private void Enter_AftermathState()
    {
        _currentState = States.AftermathState;
        _currentSkybox = _skyBoxMat_Aftermath;

        _currentWindZoneMain = _windZoneMainAftermath;
        _currentWindZoneTurbulence = _windZoneTurbulenceAftermath;
        _currentWindZonePulseMagnitude = _windZonePulseMagnitudeAftermath;
        _currentWindZonePulseFrequencye = _windZonePulseFrequencyAftermath;
        _currentWindManagerSpeed = _windManagerSpeedAftermath;
        _currentWindManagerWorldFrequency = _windManagerWorldFrequencyAftermath;
        _currentWindManagerBendAmount = _windManagerBendAmountAftermath;

        _currentActiveTreeGroup = _TreeGroupAftermath;
        _currentActiveParticleGroup = _ParticleGroupAftermath;
        _currentActiveDebrisGroup = _DebrisGroupAftermath;
    }
    private void Enter_CompletionState()
    {
        _currentState = States.CompletionState;
        _currentSkybox = _skyBoxMat_PreHurricane;
    }
    private void Enter_StormSurgeStartState()
    {
        _currentState = States.StormSurgeStartState;
        _currentWaterLevel = _waterLevel_SurgeStart;
        _currentActiveWaterObject = _waterObjectSurgeStart;
    }
    private void Enter_StormSurgeMaxState()
    {
        _currentState = States.StormSurgeMaxState;
        _currentWaterLevel = _waterLevel_SurgeMax;
        _currentActiveWaterObject = _waterObjectSurgeMax;
    }
    private void Enter_StormSurgeRecedingState()
    {
        _currentState = States.StormSurgeRecedingState;
        _currentWaterLevel = _waterLevel_SurgeReceding;
        _currentWaterLevel = _waterLevel_SurgeReceding;
    }

}
