using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
   

    // �ӽ� �׽�Ʈ�� Input ��ũ��Ʈ
    //�Ŀ� ������º��� ���߿� �״�� ���� ����
    public string enemyTag = "";
    public PlayerEvent playerPathManager = null;
    public bool isPlaying = true;

    // ��� ��� Ŭ�� �� Ray �������� Damagedȣ��
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
