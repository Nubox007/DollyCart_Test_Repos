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

    //������ ���۽� �̵� 
    // dollycart�� �ӵ��� 0 �̻��̸� �ڵ����� �̵� 
    // �̵� �ӵ��� �̻��ϴٸ� Inspector�� Update Method Ȯ��
    public void Move(float _speed)
    {
        dollyCart.m_Speed = 1f;
        //Attackȣ�� -> Ÿ�̹��� �����ؼ� ������Ʈ�� �ƴ� �ڷ�ƾ���� ����
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
    /// �÷��̾ ���� �� ȣ��
    /// ���ǵ带 0���� �ؾ� ���� Ʈ������ �ʱ�ȭ�� �̵� ����
    /// �ݹ����� ���� PathEventManager���� ī��Ʈ �� ������ üũ  ȣ��
    /// </summary>
    public void CallEvent()
    {

        //damage ���� ���� �߰�
        this.gameObject.SetActive(false);
        dollyCart.m_Speed = 0f;
        onEnemyEventCall(enemyType);
       
    }

    
}
