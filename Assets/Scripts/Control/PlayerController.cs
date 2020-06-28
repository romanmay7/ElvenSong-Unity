
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
            InteractWithCombat();
            InteractWithMovement();

            // GetComponent<Mover>().MoveByKeyboard();

        }

        private void InteractWithCombat()
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
            }
        }

        private void InteractWithMovement()
        {
            if (Input.GetMouseButton(0))
            {
                MoveToCursor();
            }
        }

        private void MoveToCursor()
        {
          
            RaycastHit hit;//Storing info(position) about where the ray cast will  hit inside this variable
            bool hasHit = Physics.Raycast( GetMouseRay(), out hit);
            if (hasHit)
            {
                GetComponent<Mover>().MoveTo(hit.point);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

    }


}

