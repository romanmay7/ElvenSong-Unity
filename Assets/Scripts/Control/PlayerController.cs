
using UnityEngine;
using ElvenSong.Movement;
using ElvenSong.Combat;
using System;
using System.Collections;
using UnityEngine.AI;

namespace ElvenSong.Control
{

    public class PlayerController : MonoBehaviour
    {
        //bool isMoving;
        public float jumpAmount = 5;
        //private Vector3 jumpVector;
        private bool hold=true;
        private bool isJump =false;
        private NavMeshAgent agent;

        private void Update()
        {
            if (InteractWithCombat()) return; //If there are Combat Requests, skip the Movement
            if (InteractWithMovement()) {/* print("Move!"); return;/*/ } //If Movement is possible perform it and return


            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space Bar pressed");
                //jumpVector = new Vector3(0.0f, 2.0f, 0.0f);
                //GetComponent<Rigidbody>().AddForce(jumpVector * jumpAmount, ForceMode.Impulse);

                GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;

                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(0, 200, 0);
                GetComponent<Animator>().SetTrigger("jump");//Animate jump
                if (hold)
                    Hold();


            }

            // GetComponent<Mover>().MoveByKeyboard();

        }


        void OnCollisionEnter(Collision col)
        {
            Debug.Log("OnCollisionEnter");
            if ( isJump)
            {
                Debug.Log("isJump");
                agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                agent.enabled = true;
                //agent.Warp(transform.position);
                GetComponent<Rigidbody>().isKinematic = true;
                isJump = false;

            }
        }

            private  /* IEnumerator */ void Hold()
        {
            hold = false;
            //yield return new WaitForSeconds(.1f);
            isJump = true;
            hold = true;
        }

        private bool InteractWithCombat() //Check if Mouse Click Events are for CombatTargets to call Attack(target)
        {

        //Returns a List of all the things it hits
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach(RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Fighter>().Attack(target);
                    
                }
                return true;
            }
            return false;
        }

        private bool InteractWithMovement() //Check for Mouse Events to call  MoveToCursor() method
        {
            RaycastHit hit; //Storing info(position) about where the ray cast will  hit inside this variable
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit) //If We are hovering over something within range,available to move there
            {
                if (Input.GetMouseButton(0))//And if we also  have Click Event in the same time period,then we can Move
                {
                    MoveToCursor(hit.point);
                }
                return true;
            }
            return false; //we are out of the range
        }

        private void MoveToCursor(Vector3 point)
        {
            GetComponent<Mover>().StartMoveAction(point);
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }



}


}

