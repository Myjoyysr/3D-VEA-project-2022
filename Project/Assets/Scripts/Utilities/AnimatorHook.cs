using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R2
{
    public class AnimatorHook : MonoBehaviour
    {
        CharacterStateManager states;

        public virtual void Init(CharacterStateManager stateManager)
        {
            states = (CharacterStateManager)stateManager;
        }

        public void OnAnimatorMove()
        {
            OnAnimatorMoveOverride();
        }

        protected virtual void OnAnimatorMoveOverride()
        {
            if (states.useRootMotion == false)
            {
                return;
            }

            if (states.isGrounded && states.delta > 0)
            {
                return;
                //Vector3 v = (states.anim.deltaPosition) / states.delta;
                //v.y = states.rigidbody.velocity.y;
                //states.rigidbody.velocity = v;
            }
        }


    }
}
