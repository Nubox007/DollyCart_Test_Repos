using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


[RequireComponent (typeof(CinemachineDollyCart))]
public class Enemy : MonoBehaviour, IEventCall, IPhaseEvent
{
    public enum EnemyType
    {   normal, epic, boss  }


    [SerializeField] private EnemyType enemyType = EnemyType.normal;
    public delegate void OnEnemyEventCall(EnemyType _type);
    private OnEnemyEventCall onEnemyEventCall = null;
    
    private CinemachineDollyCart dollyCart = null;
    public void SetMethodEventEventCall(OnEnemyEventCall _method)
    {
        onEnemyEventCall = _method;
    }

    private void Awake()
    {
        dollyCart = GetComponent<CinemachineDollyCart>();
        dollyCart.m_Position = 0f;
        dollyCart.m_Speed = 0f;
    }
    
    public CinemachineSmoothPath SetDollyPath
    {
        set { dollyCart.m_Path = value; }
    }

    //페이즈 시작시 이동 
    // dollycart의 속도가 0 이상이면 자동으로 이동 
    // 이동 속도가 이상하다면 Inspector의 Update Method 확인
    public void Move(float _speed)
    {
        dollyCart.m_Speed = 1f;
        //Attack호출 -> 타이밍을 봐야해서 업데이트가 아닌 코루틴으로 관리
    }

    public void Attack()
    {
        //
    }

    public void ResetPosition()
    {
        this.gameObject.SetActive(true);        
        dollyCart.m_Position = 0f;
    }


    /// <summary>
    /// interface call
    /// 플레이어가 공격 시 호출
    /// 스피드를 0으로 해야 다음 트랙으로 초기화시 이동 안함
    /// 콜백으로 상위 PathEventManager에게 카운트 및 페이즈 체크  호출
    /// </summary>
    public void CallEvent()
    {

        //damage 로직 추후 추가
        this.gameObject.SetActive(false);
        dollyCart.m_Speed = 0f;
        onEnemyEventCall(enemyType);
       
    }

    
}
