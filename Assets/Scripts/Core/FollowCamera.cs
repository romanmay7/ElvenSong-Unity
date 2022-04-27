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
            if (Input.GetMouseButton(1) && is_down)
            {
                // Do Something
                Debug.Log("Mouse is DOWN");
                //Cursor.lockState = CursorLockMode.Locked;
                currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
                currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
                currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
                currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
                transform.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
            }

            if (Input.GetMouseButtonUp(1))
            {
                Debug.Log("Mouse is UP");
                is_down = false;
                transform.position = target.position;
            }


        }
    }
}