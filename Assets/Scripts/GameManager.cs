using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip ("씬에 존재하는 플레이어매니저 객체")]
    [SerializeField] private PlayerManager playerManager = null;

    [Tooltip ("씬에 존재하는 PathEventManager 객체")]
    [SerializeField] private PathEventManager enemyEvent = null;

    [Tooltip ("씬에 존재하는 ScoreManager 객체")]
    [SerializeField] private ScoreManager scoreManager = null;

    [Tooltip ("씬에 존재하는 UIManager 객체")]
    [SerializeField] private UIManager uiManager = null;
    




    private void Awake()
    {
        playerManager.SetGameManagerCallback(StartPhase);
        enemyEvent.SetPhaseEventCall(StartPlayerCartMove);
        enemyEvent.SetScoreEventCall(AddScore);

        scoreManager.SetScoreChangeCall(ChangeScore);
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

    private void AddScore(int _value)
    {
        scoreManager.AddScore(_value);
    }

    private void ChangeScore(int _value)
    {
        uiManager.ChangeScore(_value);
    }
}
