using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ElvenSong.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] Transform target;

        public float sensitivity = 10f;
        public float maxYAngle = 80f;
        private Vector2 currentRotation;

        public bool is_down { get; private set; }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                is_down = true;
            }

            //In case the Right mouse button is clicked
            if (Input.GetMouseButton(1) && is_down)
            {
                Debug.Log("Mouse is DOWN");
                //Cursor.lockState = CursorLockMode.Locked;

                // 1. We will track mouse movement 
                currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
                currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
                currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
                currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
                //2. Then we will rotate the Camera according to mouse movement
                transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);

            }//Otherwise we will update Camera's position with Target's(Player) position (Follow the Target(Player)) 
            else
            {
                transform.position = target.position;
            }

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("Mouse is UP");
                is_down = false;

            }


        }
    }
}