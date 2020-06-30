using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElvenSong.Movement
{
    public class Mover : MonoBehaviour
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
        public void Stop() 
        {
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
    }

}