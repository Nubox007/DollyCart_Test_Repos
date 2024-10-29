using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PathEventManager : MonoBehaviour
{   
    //���� ��ü ������ ���� delegate
    public delegate void OnPhaseEventCall();
    private OnPhaseEventCall onPhaseEventCall = null;
    public void SetPhaseEventCall(OnPhaseEventCall _method)
    {
        onPhaseEventCall = _method;
    }


    public List<Enemy> enemyCube = null;
    public List<DollyPaths> enemyPaths = null;


    [Header ("Phase")]
    [Tooltip ("���� ������ ǥ�� �� ���п� �ʵ庯��")]
    [SerializeField] private int curPhase = 0;

    [Header ("CurrentEnemyCount")]
    [Tooltip ("���� ����� ���� �� ��ü ��. ���� ���� �� Awake ȣ�⿡�� �ʱ�ȭ")]
    [SerializeField] private int curCount = 0;

    [Header ("Score")]
    [Tooltip ("�ӽ�����")]
    public int score = 0;
    
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
            enemy.StartPhase();
        }
    }


    private void EnemyDestroy()
    {
        --curCount;
        //���� �̺�Ʈ �߻�....
        Debug.Log($"Get Score!! {++score}");
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
