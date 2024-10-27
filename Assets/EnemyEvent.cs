using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEvent : MonoBehaviour
{
   
    public delegate void OnClickEvent();
    private OnClickEvent onClickEvent = null;

    public void SetOnClickEvent(OnClickEvent _onclickEventMethod)
    {
        onClickEvent = _onclickEventMethod;
    }
    public void Damaged()
    {
        onClickEvent();
    }

   
}
