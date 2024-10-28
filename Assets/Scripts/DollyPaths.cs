using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyPaths : MonoBehaviour
{

    [SerializeField] private CinemachineSmoothPath[] paths = null;

    public CinemachineSmoothPath[] GetCinemachinePathList
    {
        get { return paths; }
    }



}
