using ElvenSong.Core;
using ElvenSong.Movement;
using UnityEngine;



namespace ElvenSong.Combat
{
    public class Fighter:MonoBehaviour,IAction
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
                AttackBehaviour();//After Fighter Stopped-Start Attack Animation

            }

        }
        private void AttackBehaviour()
        {
            GetComponent<Animator>().SetTrigger("attack");
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

        //Animation Event
        void Hit()
        {

        }
    }
}
