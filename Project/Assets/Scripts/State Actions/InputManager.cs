using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R2
{
    public class InputManager : StateAction
    {
        PlayerStateManager s;
        

        //triggers and bumbers
        bool Rb, Rt, Lb, Lt, isAttacking, b_Input, y_Input, x_Input, inventoryInput,
        leftArrow, rightArrow, upArrow, downArrow;

        public InputManager(PlayerStateManager states)
        {
            s = states;
        }
        public override bool Execute()
        {
            bool retVal = false;

            isAttacking = false;

            s.horizontal = Input.GetAxis("Horizontal");
            s.vertical = Input.GetAxis("Vertical");
            Rb = Input.GetButton("RB");
            Rt = Input.GetButton("RT");
            Lb = Input.GetButton("LB");
            Lt = Input.GetButton("LT");

            inventoryInput = Input.GetButton("A");
            b_Input = Input.GetButton("B");
            y_Input = Input.GetButtonDown("Y");
            x_Input = Input.GetButton("X");

            //leftArrow = Input.GetButton("Left");
            //rightArrow = Input.GetButton("Right");
            //upArrow = Input.GetButton("Up");
            //downArrow = Input.GetButton("Down");

            s.mouseX = Input.GetAxis("Mouse X");
            s.mouseY = Input.GetAxis("Mouse Y");

            s.moveAmount = Mathf.Clamp01(Mathf.Abs(s.horizontal) + Mathf.Abs(s.vertical));

            retVal = HandleAttacking();

            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("pressed f");
                if(s.lockOn)
                {
                    s.OnClearLookOverride();
                }
                else
                {
                    s.OnAssignLookOverride(s.target);
                }
            }


            return retVal;
        }

        bool HandleAttacking()
        {
            s.capsule.height = 1.5f;
            if (Rb || Rt || Lb || Lt)
            {
                s.capsule.height = 2.02f;
                isAttacking = true;
                
            }

            if (y_Input)
            {
                isAttacking = false;
            }

            if (isAttacking)
            {
                //play animation
                s.PlayTargetAnimation("Attack 1", true);
                s.ChangeState(s.attackStateId);
        
            }
            return isAttacking;
        }



    }
}
