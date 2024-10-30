using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PathEventManager : MonoBehaviour
{   
    //���� ��ü ������ ���� delegate
    public delegate void OnPhaseEventCall();
    public delegate void OnScoreEventCall(int _value);
    private OnPhaseEventCall onPhaseEventCall = null;
    private OnScoreEventCall onScoreEventCall = null;
    public void SetPhaseEventCall(OnPhaseEventCall _method)
    {
        onPhaseEventCall = _method;
    }
    public void SetScoreEventCall(OnScoreEventCall _method)
    {
        onScoreEventCall = _method;
    }


    [Tooltip ("�Ϲ� �� ��ü")]
    [SerializeField] private List<Enemy> enemyCube = null;

    [Tooltip ("�� ��ü���� ������ �ó׸�ƽ path")]
    [SerializeField] private List<DollyPaths> enemyPaths = null;

    [Tooltip ("���� ��ü")]
    [SerializeField] private Enemy bossCube = null;


    [Header ("Phase")]
    [Tooltip ("���� ������ ǥ�� �� ���п� �ʵ庯��")]
    [SerializeField] private int curPhase = 0;

    [Header ("CurrentEnemyCount")]
    [Tooltip ("���� ����� ���� �� ��ü ��. ���� ���� �� Awake ȣ�⿡�� �ʱ�ȭ")]
    [SerializeField] private int curCount = 0;

    [SerializeField, Range(0f, 2f)] private float speed = 1f;


    /// <summary>
    /// �� ��ü���� ���� ���� 
    /// �� ��ü���� Ÿ��ٴ� ��� ����
    /// 
    /// 1. �� ��ü���� �÷��̾ ��ο� �����ϸ� ������ ����
    /// 2. ��ü���� ���������� ī��Ʈ
    /// 3. ī��Ʈ�� 0�̵Ǹ� �÷��̾� �̵� ��� ����
    /// </summary>


    public void StartPhase()
    {
        EnemyPhaseStart();
    }

    private void Awake()
    {
        curCount = enemyCube.Count;
        curPhase = 0;

        foreach(var enemy in enemyCube)
        {
            enemy.SetMethodEventEventCall(EnemyDestroy);
        }
    }


    //������ ���� �� �� ��ġ �ʱ�ȭ
    private void ResetEnemyPosition()
    {
        foreach(var enemy in enemyCube)
        {
            enemy.ResetPosition();
        }

        //���⼭ delegate�� gamemanager���� �÷����̾� �̵� ��� ����
        onPhaseEventCall();
    }


    //���� ���� �� �� ������ ����
    private void EnemyPhaseStart()
    {        
        foreach(var enemy in enemyCube)
        {
            enemy.Move(speed);
        }
    }


    private void EnemyDestroy(Enemy.EnemyType _type)
    {
        --curCount;
        //���� �̺�Ʈ �߻�....
        switch(_type)
        {
            case Enemy.EnemyType.normal:
                onScoreEventCall(10);
                break;
            case Enemy.EnemyType.epic:
                onScoreEventCall(15);
                break;
            case Enemy.EnemyType.boss:
                onScoreEventCall(40);
                break;
        }


        if(curCount <= 0) 
        {
            curPhase = (curPhase < enemyPaths.Count-1) ? ++curPhase : 0;
            
            //Ʈ�� ���ġ
            int i = 0;
     
            foreach(var enemy in enemyCube)
            {
                enemy.SetDollyPath = enemyPaths[curPhase].GetCinemachinePathList[i++];
            }

            
            ResetEnemyPosition();
            curCount = enemyCube.Count;
        }
    }


   
}
