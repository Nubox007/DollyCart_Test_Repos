using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public delegate void OnScoreChangeCall(int _value);
    private OnScoreChangeCall onScoreChangeCall = null;
    public void SetScoreChangeCall(OnScoreChangeCall _method)
    {
       onScoreChangeCall = _method;
    }


    private int curScore = 0;

    private void Start()
    {
        onScoreChangeCall(Score);
    }
    public int Score
    {
        private set {  curScore = value; }
        get { return curScore; }
    }

    public void AddScore(int _value)
    {
        Score += _value;
        onScoreChangeCall(Score);
    }
}
