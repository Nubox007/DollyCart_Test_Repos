using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip ("���� �����ϴ� �÷��̾�Ŵ��� ��ü")]
    [SerializeField] private PlayerManager playerManager = null;

    [Tooltip ("���� �����ϴ� PathEventManager ��ü")]
    [SerializeField] private PathEventManager enemyEvent = null;

    [Tooltip ("���� �����ϴ� ScoreManager ��ü")]
    [SerializeField] private ScoreManager scoreManager = null;

    [Tooltip ("���� �����ϴ� UIManager ��ü")]
    [SerializeField] private UIManager uiManager = null;
    




    private void Awake()
    {
        playerManager.SetGameManagerCallback(StartPhase);
        enemyEvent.SetPhaseEventCall(StartPlayerCartMove);
        enemyEvent.SetScoreEventCall(AddScore);

        scoreManager.SetScoreChangeCall(ChangeScore);
    }


    /// <summary>
    /// PathEventManager���� ���̽� ���� ȣ��
    /// </summary>
    private void StartPhase()
    {
        enemyEvent.StartPhase();
    }
    /// <summary>
    /// PLayerManager���� ����� �̵� ȣ��
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
