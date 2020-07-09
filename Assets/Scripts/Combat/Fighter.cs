using ElvenSong.Core;
using ElvenSong.Movement;
using UnityEngine;



namespace ElvenSong.Combat
{
    public class Fighter:MonoBehaviour,IAction
    {
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float timeBetweenAttacks = 1f;

        Transform target;
        float timeSinceLastAttack = 0;

        private void Update()
        {
            timeSinceLastAttack += Time.deltaTime; //Adding time passed since last call to Update(Time the last frame took to Render)
            if (target == null) return;

            if (Vector3.Distance(target.position, transform.position) > weaponRange)
            {
                GetComponent<Mover>().MoveTo(target.position);

            }
            else
            {
                GetComponent<Mover>().Cancel();//stop NavMesh Agent on Mover
                triggerAttackBehaviour();//After Fighter Stopped-Start Attack Animation

            }

        }
        private void triggerAttackBehaviour()
        {
            if (timeSinceLastAttack >= timeBetweenAttacks)
            {
                GetComponent<Animator>().SetTrigger("attack");
                timeSinceLastAttack = 0; //Reseting the counter
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

        //Animation Event
        void Hit()
        {

        }
    }
}
