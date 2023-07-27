using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderScript : MonoBehaviour
{
    public Transform playerSpawn;
    Vector3 startPos;
    Rigidbody rb;
    [Tooltip("Adjust the thrust of the boulder.")]
    [Range(-100,500)]
    public float thrust = 100;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * thrust, ForceMode.Impulse);
        playerSpawn = GameObject.Find("PlayerSpawn").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero;
         
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerCollider")
        {
            Debug.Log("Boulder strikes player!");
            ResetBoulder();
            //This is disabling the character controller
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = false;
            //Teleports you back to player spwan
            collision.gameObject.transform.parent.position = playerSpawn.position;
            //this turns back on character controller
            collision.gameObject.transform.parent.GetComponent<CharacterController>().enabled = true;
        }
    }
    void ResetBoulder()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
    }
}
