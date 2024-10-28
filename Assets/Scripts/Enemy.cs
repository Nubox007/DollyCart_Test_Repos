using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


[RequireComponent (typeof(CinemachineDollyCart))]
public class Enemy : MonoBehaviour, IEventCall,IAttack
{
    
    public delegate void OnEnemyEventCall();
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
    public void StartPhase()
    {
        dollyCart.m_Speed = 1f;
        //AttacktoPlayer호출 -> 타이밍을 봐야해서 업데이트가 아닌 코루틴으로 관리
    }

    public void ResetPosition()
    {
        this.gameObject.SetActive(true);        
        dollyCart.m_Position = 0f;
    }
    /// <summary>
    /// interface call
    /// 플레이어가 공격 시 호출
    /// </summary>
    public void CallEvent()
    {
        this.gameObject.SetActive(false);
        dollyCart.m_Speed = 0f;
        onEnemyEventCall();
       
    }

    public void AttacktoPlayer()
    {
        //코루틴으로 적 플레이어를 바라보고 공격개시
    }
}
