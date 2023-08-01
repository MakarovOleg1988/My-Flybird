using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    [SerializeField]
    private string _androidGameId;
    
    [SerializeField]
    private string _iOSGameId;

    [SerializeField]
    private bool _testMode;

    private string GameId => Application.platform == RuntimePlatform.IPhonePlayer ? _iOSGameId : _androidGameId;

    private void Awake()
    {
        Advertisement.Initialize(GameId, _testMode, true);

        StartCoroutine(WaitForInit());
    }

    private IEnumerator WaitForInit()
    {
        while (!Advertisement.isInitialized)
        {
            yield return null;
        }


    }
}
