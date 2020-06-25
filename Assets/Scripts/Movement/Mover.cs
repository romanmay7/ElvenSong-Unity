using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    Ray lastRay;
    bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //print("Left Mouse Button is Pressed");
            isMoving = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            //print("Left Mouse Button is Released");
            isMoving = false;
        }



        if (isMoving)
        {
             
            MoveToCursor();

            //lastRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Casts Ray From Main Camera to Mouse Position
            //Debug.DrawRay(lastRay.origin, lastRay.direction * 100); //Draws a Line from start to dest
        }
        UpdateAnimator();
        

        //GetComponent<NavMeshAgent>().destination = target.position; //move player to the position of target object
    


    }

   private void MoveToCursor()
    {
        Ray ray= Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;//Storing info(position) about where the ray cast will  hit inside this variable
        bool hasHit=Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
    }

    private void UpdateAnimator()
    {
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;//get velocity from NavMesh Agent
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);//transform direction from World Space to Local Space
        float speed = localVelocity.z; //get z value
        GetComponent<Animator>().SetFloat("forwardSpeed", speed); //passing speed to Animator's 'forwardSpeed' variable
    }
}
