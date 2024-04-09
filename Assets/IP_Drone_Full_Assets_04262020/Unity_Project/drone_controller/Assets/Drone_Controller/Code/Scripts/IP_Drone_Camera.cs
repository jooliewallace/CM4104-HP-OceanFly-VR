using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Drone_Camera : MonoBehaviour
    {
        #region Variables
        [Header("Camera Properties")]
        public Transform target;
        public float height = 3f;
        public float distance = 5f;
        public float lerpSpeed = 4f;

        [Header("Look Target Properties")]
        public float lookAheadDist = 0.5f;
        public float lookAheadHeight = 0.25f;

        private Vector3 finalPos;
        private Vector3 finalLookTarget;
        private Vector3 flatFwd;
        #endregion



        #region Main Methods
        void FixedUpdate()
        {
            if(!target)
            {
                return;
            }

            SetFlatForward();

            Vector3 heightOffset = Vector3.up * height;

            Vector3 distanceOffset = -flatFwd * distance;
            Vector3 wantedPos = target.position + heightOffset + distanceOffset;

            finalPos = Vector3.Lerp(finalPos, wantedPos, Time.deltaTime * lerpSpeed);
            transform.position = finalPos;

            Vector3 lookTarget = GetLookTarget();
            finalLookTarget = Vector3.Lerp(finalLookTarget, lookTarget, Time.deltaTime * lerpSpeed);
            transform.LookAt(lookTarget);
        }
        #endregion



        #region Custom Methods
        protected virtual Vector3 GetLookTarget()
        { 
            Vector3 lookTarget = target.position + (flatFwd * lookAheadDist) + (Vector3.up * lookAheadHeight);
            return lookTarget;
        }

        protected virtual void SetFlatForward()
        {
            flatFwd = target.forward;
            flatFwd.y = 0;
            flatFwd = flatFwd.normalized;
        }
        #endregion



        #region Gizmos
        private void OnDrawGizmos()
        {
            SetFlatForward();
            Vector3 lookTarget = GetLookTarget();

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(lookTarget, 0.1f);
        }
        #endregion
    }
}
