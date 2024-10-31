using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{

    [Tooltip ("���� �����ϴ� �÷��̾�Ŵ��� ��ü")]
    [SerializeField] private PlayerEvent playerManager = null;

    [Tooltip ("���� �����ϴ� PathEventManager ��ü")]
    [SerializeField] private PathEventManager enemyEvent = null;

    [Tooltip ("���� �����ϴ� ScoreManager ��ü")]
    [SerializeField] private ScoreManager scoreManager = null;

    [Tooltip ("���� �����ϴ� UIManager ��ü")]
    [SerializeField] private UIEvent uiManager = null;
    




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
        Debug.Log("test Phaseint main");
        enemyEvent.StartPhase();
    }
    /// <summary>
    /// PLayerManager���� ����� �̵� ȣ��
    /// </summary>
    private void StartPlayerCartMove()
    {
        Debug.Log("Start Move ");
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
