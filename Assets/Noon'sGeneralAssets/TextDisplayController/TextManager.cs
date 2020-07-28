using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class TextManager : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI window;



    public void Talking(string script, Func<bool> finEvent, Action function) {
        gameObject.SetActive(true);
        StartCoroutine(TextUpdate(script, finEvent, function));
    }
    private IEnumerator TextUpdate(string script, Func<bool> finEvent = null, Action function = null){

        
        window.text = "";

        for (int i = 0; i < script.Length ; i++){

            window.text = script.Substring(0,i + 1);

            yield return new WaitForSeconds(0.1f);

        }

        if (finEvent != null) {
            yield return new WaitUntil(finEvent);
        }
        if (function != null) {
            function();
        }

        //window.text = "";
        //gameObject.SetActive(false);

    }


}
