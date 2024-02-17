using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R2
{
    public abstract class CharacterStateManager : StateManager
    {
        [Header("References")]
        public Animator anim;
        public new Rigidbody rigidbody;
        //public Rigidbody rigidbody;
        public AnimatorHook animHook;
        public CapsuleCollider capsule;


        [Header("States")]
        public bool isGrounded;
        public bool useRootMotion;
        public bool lockOn;
        public Transform target;


        [Header("Controller Values")]
        public float vertical;
        public float horizontal;
        public float delta;
        public Vector3 rootMovement;

        public override void Init()
        {
            anim = GetComponentInChildren<Animator>();
            animHook = GetComponentInChildren<AnimatorHook>();
            rigidbody = GetComponentInChildren<Rigidbody>();
            capsule = GetComponentInChildren<CapsuleCollider>();
            anim.applyRootMotion = false;

            animHook.Init(this);

        }

        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.SetBool("isInteracting", isInteracting);
            anim.CrossFade(targetAnim, 0.2f);
        }
        
        public virtual void OnAssignLookOverride(Transform target)
        {
            this.target = target;
            if(target != null)
            {
                lockOn = true;
            }
        }

        public virtual void OnClearLookOverride()
        {
            lockOn = false;
        }

    }
    
}
