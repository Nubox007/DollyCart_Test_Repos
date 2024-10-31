using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
   

    // 임시 테스트용 Input 스크립트
    //후에 적용상태보고 나중에 그대로 쓸지 결정
    public string enemyTag = "";
    public PlayerEvent playerPathManager = null;
    public bool isPlaying = true;

    // 기능 대상 클릭 시 Ray 판정으로 Damaged호출
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.transform.tag == enemyTag) 
                    hit.transform.GetComponent<IEventCall>().CallEvent();
            }

        }

        if(Input.GetKeyDown(KeyCode.Space) && isPlaying)
        {
            isPlaying = false;
            playerPathManager.SetCartPhaseMode();
        }
    }
}
