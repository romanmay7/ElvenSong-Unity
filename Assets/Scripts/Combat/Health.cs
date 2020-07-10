using System;
using UnityEngine;

namespace ElvenSong.Combat
{
    public class Health:MonoBehaviour
    {
        [SerializeField] float health = 100f;
        
        public void TakeDamage(float damage)
        {
            
          health = Mathf.Max(health - damage, 0);//Health never drops below 0
          print("Health:" + health);
        } 
    }
}
