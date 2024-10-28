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

    //������ ���۽� �̵� 
    // dollycart�� �ӵ��� 0 �̻��̸� �ڵ����� �̵� 
    // �̵� �ӵ��� �̻��ϴٸ� Inspector�� Update Method Ȯ��
    public void StartPhase()
    {
        dollyCart.m_Speed = 1f;
        //AttacktoPlayerȣ�� -> Ÿ�̹��� �����ؼ� ������Ʈ�� �ƴ� �ڷ�ƾ���� ����
    }

    public void ResetPosition()
    {
        this.gameObject.SetActive(true);        
        dollyCart.m_Position = 0f;
    }
    /// <summary>
    /// interface call
    /// �÷��̾ ���� �� ȣ��
    /// </summary>
    public void CallEvent()
    {
        this.gameObject.SetActive(false);
        dollyCart.m_Speed = 0f;
        onEnemyEventCall();
       
    }

    public void AttacktoPlayer()
    {
        //�ڷ�ƾ���� �� �÷��̾ �ٶ󺸰� ���ݰ���
    }
}
