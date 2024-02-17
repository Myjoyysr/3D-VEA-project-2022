using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R2
{
    public class State
    {
        bool forceExit;
        List<StateAction> fixedUpdateActions;
        List<StateAction> updateActions;
        List<StateAction> lateUpdateActions;

        public delegate void OnEnter();
        public OnEnter onEnter;

        public State(List<StateAction> fixedUpdateActions, List<StateAction> updateActions, List<StateAction> lateUpdateActions)
        {
            this.fixedUpdateActions = fixedUpdateActions;
            this.updateActions = updateActions;
            this.lateUpdateActions = lateUpdateActions;

        }

        public void FixedTick()
        {
            ExecuteStateListOfActions(fixedUpdateActions);
        }

        public void Tick()
        {
            ExecuteStateListOfActions(updateActions);
        }

        public void LateTick()
        {
            ExecuteStateListOfActions(lateUpdateActions);
            forceExit = false;
        }

        void ExecuteStateListOfActions(List<StateAction> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                if (forceExit)
                {
                    return;
                }

                forceExit = l[i].Execute();

            }

        }

    }
}
