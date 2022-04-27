using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using ElvenSong.Core;


namespace ElvenSong.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        [SerializeField] Transform target;
        NavMeshAgent navMeshAgent;
        //Ray lastRay;


        public float movespeed = 5.66f;
        public float rotatespeed = 75f;
        private float vInput;
        private float hInput;

        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.isStopped = false;
        }

        // Update is called once per frame
        void LateUpdate()
        {

            //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Casts Ray From Main Camera to Mouse Position
            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100); //Draws a Line from start to dest

            UpdateAnimator();

        }
        public void Cancel() 
        {
            print("Cancelling Movement Action");
            navMeshAgent.isStopped = true;
        }

        public void MoveByKeyboard()
        {
            vInput = Input.GetAxis("Vertical") * movespeed;
            hInput = Input.GetAxis("Horizontal") * rotatespeed;
            this.transform.Translate(Vector3.forward * vInput * Time.deltaTime);
            this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
            GetComponent<Animator>().SetFloat("forwardSpeed", vInput);
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
            
        }

        public void MoveTo(Vector3 destination)
        {
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = destination;
           
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;//get velocity from NavMesh Agent
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);//transform direction from World Space to Local Space
            float speed = localVelocity.z; //get z value
            GetComponent<Animator>().SetFloat("forwardSpeed", speed); //passing speed to Animator's 'forwardSpeed' variable
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Collide");
            // force is how forcefully we will push the player away from the enemy.
            float force = 300;

            // If the object we hit is the ball
            if (collision.gameObject.tag == "ball")
            {
                Debug.Log("player hits the ball!");
                // Calculate Angle Between the collision point and the player
                Vector3 dir = collision.contacts[0].point - transform.position;
                // We then get the opposite (-Vector3) and normalize it
                dir = -dir.normalized;
                // And finally we add force in the direction of dir and multiply it by force. 
                // This will push back the player
                GameObject ball = GameObject.FindWithTag("ball");
                ball.GetComponent<Rigidbody>().AddForce(dir * force);

                navMeshAgent.isStopped = true;
                navMeshAgent.GetComponent<Rigidbody>().velocity = Vector3.zero;
                navMeshAgent.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                //  while (GetComponent<Rigidbody>().velocity.magnitude != 0)
                //  {
                // GetComponent<Rigidbody>().velocity = Vector3.zero;
                // GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                //   }
            }
            else if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("players atacks enemy!");
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("Exit Collision!");
        }

        //void StopForce()
        //{
        //    if (transform.rigidbody.velocity.magnitude != 0)
        //    {
        //        Vector3 dampeningDirection = transform.rigidbody.velocity.normalized * -1.0f;
        //        transform.rigidbody.AddForce(dampeningDirection * dampeningRate);
        //    }
        //}
    }

}

