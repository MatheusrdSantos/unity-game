using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    // private Rigidbody rb;
    public float speed = 6.0f;
    public float jumpForce = 4.0f;
    private float gravity = -20f;
    private Vector3 initPos; 
    private CharacterController cc;
    private Vector3 moveVelocity;
    // Start is called before the first frame update
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if(cc.isGrounded){
            moveVelocity = new Vector3(moveHorizontal * speed, 0, moveVertical * speed);
            if(Input.GetButtonDown("Jump")) {
                moveVelocity.y = jumpForce;
            }
        }
        moveVelocity.y += gravity * Time.deltaTime;
        cc.Move(moveVelocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Point")) {
            other.gameObject.SetActive(false);
            GameManager.GetInstance().AddPoints(100);
        } else if (other.gameObject.CompareTag("Point2x")) {
            other.gameObject.SetActive(false);
            GameManager.GetInstance().AddPoints(200);
        }else if (other.gameObject.CompareTag("Point3x")) {
            other.gameObject.SetActive(false);
            GameManager.GetInstance().AddPoints(300);
        } else if (other.gameObject.CompareTag("MapLimit")) {
            cc.enabled = false;
            cc.transform.position = initPos;
            cc.enabled = true;  
            GameManager.GetInstance().AddPoints(-10); 
        }
        
    }


    private void OnControllerColliderHit(ControllerColliderHit hit) {
        Collider other = hit.collider;
        // added to avoid the EndLv1 being called during scene loading
        if (GameManager.GetInstance().GetCurrentSceneName() == "Lv1" && other.gameObject.CompareTag("EndLv1")) {
            GameManager.GetInstance().EndLv1();
        } else if (GameManager.GetInstance().GetCurrentSceneName() == "Lv2" && other.gameObject.CompareTag("EndLv2")) {
            GameManager.GetInstance().EndLv2();
        } else if (other.gameObject.CompareTag("IcyGround")) {
            speed = 15.0f;
        } else if (other.gameObject.CompareTag("Ground")) {
            speed = 6.0f;
        }
    }

}
