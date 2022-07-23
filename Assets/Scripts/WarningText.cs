using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningText : MonoBehaviour
{
    private bool isActive = false;
    private float timeActive = 0f;
    public void Show(string text) {
        GetComponent<TMP_Text>().text = text;
        isActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive && timeActive < 3f) {
            timeActive += Time.deltaTime;
        } else {
            GetComponent<TMP_Text>().text = "";
            timeActive = 0f;
            isActive = false;
        }
    }
}
