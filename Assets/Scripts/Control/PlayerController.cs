
using UnityEngine;
using ElvenSong.Movement;
using ElvenSong.Combat;

namespace ElvenSong.Control
{

    public class PlayerController : MonoBehaviour
    {
        //bool isMoving;
        private void Update()
        {
            if (InteractWithCombat()) return; //If there are Combat Requests, skip the Movement
            if (InteractWithMovement()) { print("Move!"); return; } //If Movement is possible perform it and return
            print("Nothere to Go");

            // GetComponent<Mover>().MoveByKeyboard();

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
            GetComponent<Mover>().MoveTo(point);
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }


}

