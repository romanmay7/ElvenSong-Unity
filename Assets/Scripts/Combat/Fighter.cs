using ElvenSong.Core;
using ElvenSong.Movement;
using UnityEngine;



namespace ElvenSong.Combat
{
    public class Fighter:MonoBehaviour, IAction
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update()
        {
            if (target == null) return;

            if (Vector3.Distance(target.position, transform.position) > weaponRange)
            {
                GetComponent<Mover>().MoveTo(target.position);

            }
            else
            {
                GetComponent<Mover>().Cancel();//stop NavMesh Agent on Mover

            }

        }

        public void Attack(CombatTarget combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
            print("ARRRRGHHHHH");
        }

        public void Cancel()
        {
            target = null; //reset target
            print("Cancelling Attack Action");
        }

        
    }
}
