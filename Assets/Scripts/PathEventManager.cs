using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PathEventManager : MonoBehaviour
{   
    //상위 객체 접근을 위한 delegate
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


    [Tooltip ("일반 적 객체")]
    [SerializeField] private List<Enemy> enemyCube = null;

    [Tooltip ("적 객체들이 움직일 시네마틱 path")]
    [SerializeField] private List<DollyPaths> enemyPaths = null;

    [Tooltip ("보스 객체")]
    [SerializeField] private Enemy bossCube = null;


    [Header ("Phase")]
    [Tooltip ("현재 페이즈 표시 및 구분용 필드변수")]
    [SerializeField] private int curPhase = 0;

    [Header ("CurrentEnemyCount")]
    [Tooltip ("현재 페이즈에 남은 적 개체 수. 게임 시작 시 Awake 호출에서 초기화")]
    [SerializeField] private int curCount = 0;

    [SerializeField, Range(0f, 2f)] private float speed = 1f;


    /// <summary>
    /// 적 객체들을 전부 관리 
    /// 적 객체들이 타고다닐 경로 관리
    /// 
    /// 1. 적 객체들이 플레이어가 경로에 진입하면 페이즈 시작
    /// 2. 객체들이 죽을때마다 카운트
    /// 3. 카운트가 0이되면 플레이어 이동 명령 전달
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


    //페이즈 종료 시 적 위치 초기화
    private void ResetEnemyPosition()
    {
        foreach(var enemy in enemyCube)
        {
            enemy.ResetPosition();
        }

        //여기서 delegate로 gamemanager에게 플레이이어 이동 명령 전달
        onPhaseEventCall();
    }


    //구간 도착 시 적 페이즈 시작
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
        //점수 이벤트 발생....
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
            
            //트랙 재배치
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
