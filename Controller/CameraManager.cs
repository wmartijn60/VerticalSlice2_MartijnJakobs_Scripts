﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//nost used in the game
namespace SA
{
    public class CameraManager : MonoBehaviour
    {
        public bool lockon;
        private float followSpeed = 9;
        private float mouseSpeed = 2;
        private float controllerSpeed = 7;

        public Transform target;

        [HideInInspector]
        public Transform pivot;
        [HideInInspector]
        public Transform camTrans;

        float turnSmoothing = .1f;
        private float minAngle = -35;
        private float maxAngle = 35;
            
        float smoothX;
        float smoothY;
        float smoothXvelocity;
        float smoothYvelocity;
        private float lookAngle;
        private float tiltAngle;

        public void Init(Transform t)
        {
            target = t;

            camTrans = Camera.main.transform;
            pivot = camTrans.parent;
        }

        //inputs
        public void Tick(float d)
        {
            float h = Input.GetAxis("Mouse X");
            float v = Input.GetAxis("Mouse Y");

            float c_h = Input.GetAxis("RightAxis X");
            float c_v = Input.GetAxis("RightAxis Y");

            float targetSpeed = mouseSpeed;

            if (c_h != 0 || c_v != 0)
            {
                h = c_h;
                v = c_v;

                targetSpeed = controllerSpeed;
            }
            FollowTarget(d);
            HandleRotations(d, v, h, targetSpeed);
        }
        //follow player
        public void FollowTarget(float d)
        {
            float speed = d * followSpeed;
            Vector3 targetPosition = Vector3.Lerp(transform.position, target.position, speed);
            transform.position = targetPosition;
        }
        //rotations
        void HandleRotations(float d, float v, float h, float targetSpeed)
        {
            if (turnSmoothing > 0)
            {
                smoothX = Mathf.SmoothDamp(smoothX, h, ref smoothXvelocity, turnSmoothing);
                smoothY = Mathf.SmoothDamp(smoothY, v, ref smoothYvelocity, turnSmoothing);
            }
            else
            {
                smoothX = h;
                smoothY = v;
            }
            if (lockon)
            {

            }

            lookAngle += smoothX * targetSpeed;
            transform.rotation = Quaternion.Euler(0, lookAngle, 0);

            tiltAngle -= smoothY * targetSpeed;
            tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
            pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);

        }

        public static CameraManager singleton;
        void Awake()
        {
            singleton = this;
        }
    }
}