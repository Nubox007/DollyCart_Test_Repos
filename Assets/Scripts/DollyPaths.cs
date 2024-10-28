using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyPaths : MonoBehaviour
{

    [SerializeField] private CinemachinePath[] paths = null;

    public CinemachinePath[] GetCinemachinePathList
    {
        get { return paths; }
    }



}
