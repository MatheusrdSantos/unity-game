using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(Random.Range(0, 2)).GetComponent<FalseTile>().isTrapActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
