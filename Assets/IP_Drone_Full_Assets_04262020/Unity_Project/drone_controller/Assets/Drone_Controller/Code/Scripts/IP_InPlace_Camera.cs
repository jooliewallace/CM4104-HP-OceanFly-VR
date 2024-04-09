using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_InPlace_Camera : MonoBehaviour
    {
        #region Variables
        [Header("Camera Properties")]
        public Transform target;
        #endregion


        void FixedUpdate()
        {
            if(!target)
            {
                return;
            }

            transform.LookAt(target);
        }
    }
}
