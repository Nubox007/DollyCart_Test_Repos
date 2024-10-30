using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int curScore = 0;
    [SerializeField] private TextMeshProUGUI textMeshProUGUI = null;


    private void Awake()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();

    }
    
    public void ChangeScore(int _value)
    {
        StartCoroutine(LerpScore(_value));
    }

    private IEnumerator LerpScore(int _value)
    {

        while(curScore <= _value)
        {
            textMeshProUGUI.text = $"Score : {curScore++}";
            yield return new WaitForSeconds(0.1f);
        }

        yield break;
    }
}
