using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


  /*  void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Collide BALL!");
        // force is how forcefully we will push the player away from the enemy.
        float force = 300;

        // If the object we hit is the enemy
        if (collision.gameObject.tag == "player")
        {
            Debug.Log("player hits the ball!");
            // Calculate Angle Between the collision point and the player
            Vector3 dir = collision.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
     //   Debug.Log("Exit Collision!");
    }*/
}