using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    [SerializeField] Transform target;
    Ray lastRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
             
            MoveToCursor();

            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition); //Casts Ray From Main Camera to Mouse Position
            Debug.DrawRay(lastRay.origin, lastRay.direction * 100); //Draws a Line from start to dest
        }
        

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
}
