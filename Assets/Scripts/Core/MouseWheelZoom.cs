using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElvenSong.Core
{
    public class MouseWheelZoom : MonoBehaviour
    {
    public float zoomSpeed=0.1F;

    [SerializeField] Transform target;

        // Update is called once per frame
        void Update()
        {
 
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
               transform.localScale += target.position - transform.position - new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                transform.localScale += new Vector3(zoomSpeed, zoomSpeed, zoomSpeed);
            }
            
        }

    }
}