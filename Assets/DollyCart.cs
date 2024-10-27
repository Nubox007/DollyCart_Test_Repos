using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyCart : MonoBehaviour
{

    private CinemachineDollyCart dollyCart = null;
    public TrackEvent trackEvent = null;
    public float speed = 0f;
    private bool isPlaying = true;
    private int path = 1;


    private void Awake()
    {
        dollyCart = GetComponent<CinemachineDollyCart>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dollyCart.m_Speed = 0f;
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartCartMove());            
        } // start Event

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == "Enemy")
                {
                    hit.transform.GetComponent<EnemyEvent>().Damaged();
                }
            }


        }
    }


    private IEnumerator EventDollycartMove()
    {
        while(dollyCart.m_Speed > 0.01f)
        {
            int pathUnit = (int) dollyCart.m_Position;

            if(pathUnit >= path)
            {
                dollyCart.m_Speed = Mathf.Lerp(dollyCart.m_Speed, 0f, 0.01f);
            }

            yield return new WaitForEndOfFrame();
        }
        path += 3;
        Debug.Log("dolly stop");
        trackEvent.StartMove();

        yield break;
    }

    private IEnumerator StartCartMove()
    {
        if(!isPlaying) yield break;
        else isPlaying = false;


        Debug.Log("Start dolly");
        while(dollyCart.m_Speed <= (speed-0.1f))
        {
            dollyCart.m_Speed = Mathf.Lerp(dollyCart.m_Speed, speed, 0.05f);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("dolly is moving");

        StartCoroutine(EventDollycartMove());
       
        yield break;
    }

    public void startMove()
    {
        Debug.Log("Start dolly_2");
        isPlaying = true;
        StartCoroutine(StartCartMove());
    } 


    
}
