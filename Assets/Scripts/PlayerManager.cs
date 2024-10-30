using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
public class PlayerManager : MonoBehaviour
{

    public delegate void OnGameMangerCall();
    private OnGameMangerCall onGameMangerCall = null;


    
    [SerializeField] private List<int> phaseUnit = null;

    [Tooltip ("플레이어 카트 최대 속도")]
    [SerializeField] private float maxSpeed = 1.0f; 

    [Tooltip ("플레이어 카트 최소 속도")]
    [SerializeField] private float minSpeed = 0.01f;

    [Tooltip ("속도 보간 비율")]
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
        if(!isPlaying) // 게임시작을 판정
        {
            isPlaying = true;
            isPhase = false;
            Debug.Log("Game Start");


            StartCoroutine(CheckPathUnit());
        }
        StartCoroutine(LerpSpeed());
    }

    // 업데이트 대신 프레임마다 현재 트랙위치 판정
   private IEnumerator CheckPathUnit()
    {
        
        int curPath = 0;
        while(isPlaying)
        {
            curPath = (int)dollyCart.m_Position;

            if(curPath == phaseUnit[curPhase])
            {
                //카트 속도 보간 감가속 
                SetCartPhaseMode();
                isPhase = true;


                //페이즈 이벤트 콜백 메서드
                onGameMangerCall();
                curPhase = curPhase < (phaseUnit.Count-1) ? ++curPhase : 0;
                yield break;

            }

            yield return new WaitForEndOfFrame();

        }
        yield break;
    }


    //출발과 도착때마다 속도 보간처리
    private IEnumerator LerpSpeed()
    {
        if(isLerp) yield break;
        
        isLerp = true;
        if(dollyCart.m_Speed >= (maxSpeed/2))
        {            
            while(dollyCart.m_Speed >= minSpeed)
            {
                //감속 보간
                SetSpeed = Mathf.Lerp(dollyCart.m_Speed, minSpeed, blendSpeed);
                yield return new WaitForEndOfFrame();
            }

        }else
        {         
      
            while(dollyCart.m_Speed <= (maxSpeed-0.1f))
            {

                //가속 보간
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
