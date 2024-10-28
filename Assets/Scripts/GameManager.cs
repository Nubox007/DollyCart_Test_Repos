using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip ("���� �����ϴ� �÷��̾�Ŵ��� ��ü")]
    [SerializeField] private PlayerManager playerManager = null;

    [Tooltip ("���� �����ϴ� PathEventManager ��ü")]
    [SerializeField] private PathEventManager enemyEvent = null;



    private void Awake()
    {
        playerManager.SetGameManagerCallback(StartPhase);
        enemyEvent.SetPhaseEventCall(StartPlayerCartMove);
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
}
