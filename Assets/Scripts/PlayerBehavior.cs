using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    public Rigidbody2D myRigidbody;

    //private bool IDLE = true;
    //private bool MOVE = false;
    private bool JUMP = false;

    [SerializeField]
    private short maxJumps = 2;
    private short jumpCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Grounded");
            JUMP = false;
            jumpCounter = 0;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Off Ground");
            JUMP = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += (Vector3.right * speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.A)) 
        {
            this.transform.position += (Vector3.left * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && (!JUMP || jumpCounter < maxJumps))
        {
            Debug.Log("Jumping");
            Jump();
            jumpCounter++;
        }



    }

    void Jump()
    {
        if (myRigidbody.velocity.y < 0 && JUMP)
        {
            myRigidbody.transform.position += new Vector3(0, myRigidbody.velocity.y - myRigidbody.velocity.y, 0);
        }
        //myRigidbody.AddForce(transform.up * jumpForce * 10);

        myRigidbody.velocity = Vector3.up * jumpForce / 5;
    }


}
