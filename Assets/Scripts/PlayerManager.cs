using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{

    public delegate void OnGameMangerCall();
    private OnGameMangerCall onGameMangerCall = null;


    
    [SerializeField] private List<int> phaseUnit = null;

    [Tooltip ("�÷��̾� īƮ �ִ� �ӵ�")]
    [SerializeField] private float maxSpeed = 1.0f; 

    [Tooltip ("�÷��̾� īƮ �ּ� �ӵ�")]
    [SerializeField] private float minSpeed = 0.01f;

    [Tooltip ("�ӵ� ���� ����")]
    [SerializeField] private float blendSpeed = 0.03f;



    private CinemachineDollyCart dollyCart = null;
    private bool isLerp = false;
    private bool isPlaying = false;
    private bool isPhase = false;

    private int curPhase = 0;


    private void Awake()
    {
        dollyCart = GetComponent<CinemachineDollyCart>();
        dollyCart.m_Speed = 0.0f;
    }


    public float SetSpeed
    {
       set{ dollyCart.m_Speed = value; }
    }

    public void SetGameManagerCallback(OnGameMangerCall _method)
    {
        onGameMangerCall = _method;
    }


    public void SetCartPhaseMode()
    {           
        if(!isPlaying) // ���ӽ����� ����
        {
            isPlaying = true;
            isPhase = false;
            Debug.Log("Game Start");


            StartCoroutine(CheckPathUnit());
        }
        StartCoroutine(LerpSpeed());
    }

    // ������Ʈ ��� �����Ӹ��� ���� Ʈ����ġ ����
   private IEnumerator CheckPathUnit()
    {
        
        int curPath = 0;
        while(isPlaying)
        {
            curPath = (int)dollyCart.m_Position;

            if(curPath == phaseUnit[curPhase])
            {
                //īƮ �ӵ� ���� ������ 
                SetCartPhaseMode();
                isPhase = true;


                //������ �̺�Ʈ �ݹ� �޼���
                onGameMangerCall();
                curPhase = curPhase < (phaseUnit.Count-1) ? ++curPhase : 0;
                yield break;

            }

            yield return new WaitForEndOfFrame();

        }
        yield break;
    }


    //��߰� ���������� �ӵ� ����ó��
    private IEnumerator LerpSpeed()
    {
        if(isLerp) yield break;
        
        isLerp = true;
        if(dollyCart.m_Speed >= (maxSpeed/2))
        {            
            while(dollyCart.m_Speed >= minSpeed)
            {
                //���� ����
                SetSpeed = Mathf.Lerp(dollyCart.m_Speed, minSpeed, blendSpeed);
                yield return new WaitForEndOfFrame();
            }

        }else
        {         
      
            while(dollyCart.m_Speed <= (maxSpeed-0.1f))
            {

                //���� ����
                SetSpeed = Mathf.Lerp(dollyCart.m_Speed, maxSpeed, blendSpeed);
                yield return new WaitForEndOfFrame();
            }
            isPhase = false;
        }
        if(isPlaying)StartCoroutine(CheckPathUnit());
        

        isLerp = false;

        yield break;
    }


}
