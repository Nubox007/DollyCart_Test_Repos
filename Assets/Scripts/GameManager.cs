using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip ("씬에 존재하는 플레이어매니저 객체")]
    [SerializeField] private PlayerManager playerManager = null;

    [Tooltip ("씬에 존재하는 PathEventManager 객체")]
    [SerializeField] private PathEventManager enemyEvent = null;



    private void Awake()
    {
        playerManager.SetGameManagerCallback(StartPhase);
        enemyEvent.SetPhaseEventCall(StartPlayerCartMove);
    }


    /// <summary>
    /// PathEventManager에게 페이스 시작 호출
    /// </summary>
    private void StartPhase()
    {
        enemyEvent.StartPhase();
    }


    /// <summary>
    /// PLayerManager에게 페이즈별 이동 호출
    /// </summary>
    private void StartPlayerCartMove()
    {

        playerManager.SetCartPhaseMode();
    }
}
