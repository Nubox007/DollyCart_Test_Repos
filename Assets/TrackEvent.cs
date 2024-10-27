using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TrackEvent : MonoBehaviour
{

    public CinemachineDollyCart playerCube = null;
    public CinemachineDollyCart testCube = null;
    public CinemachinePath[] testTrack = null;
    public int startTrack = 0;
    public bool isDone = false;

    private void Awake()
    {
        testCube.GetComponent<EnemyEvent>().SetOnClickEvent(ChangeTrack);
        testCube.m_Speed = 0f;
        testCube.m_Path = testTrack[0];
    }   

    public void ChangeTrack()
    {
        testCube.m_Path = startTrack < testTrack.Length-1 ? testTrack[++startTrack] : testTrack[0];
        
        testCube.m_Speed = 0f;
        testCube.m_Position = 0f;

        playerCube.GetComponent<DollyCart>().startMove();

    }

    public void StartMove()
    {
        testCube.m_Speed = 1f;
    }



}
