using ElvenSong.Movement;
using UnityEngine;


namespace ElvenSong.Combat
{
    public class Fighter:MonoBehaviour
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
                    GetComponent<Mover>().Stop();//stop NavMesh Agent
                   
                }

        }

        public void Attack(CombatTarget combatTarget)
        {
            target = combatTarget.transform;
            print("ARRRRGHHHHH");
        }

        public void Cancel()
        {
            target = null; //reset target
        }
        
    }
}
