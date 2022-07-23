using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseTile : MonoBehaviour
{
    public bool isTrapActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter collide");
        if(isTrapActive && other.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log("OnCollisionEnter collide");
        if(isTrapActive && other.collider.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Collider other = hit.collider;
         Debug.Log("OnControllerColliderHit collide");
        if(other.gameObject.CompareTag("Player")) {
            gameObject.SetActive(false);
        }
    }

}
