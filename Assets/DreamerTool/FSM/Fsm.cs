using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamerTool.FSM
{
    public class StateMachine
    {
        public StateBase current_state;
        public Dictionary<string,StateBase> states=new Dictionary<string,StateBase>();
        public void AddState(StateBase state)
        {
            states.Add(state.id,state);
        }
        public void RemoveState(StateBase state)
        {
            states.Remove(state.id);
        }
        public void ChangeState(string id)
        {
            if(!states.ContainsKey(id))
            {
                return;
            }
            if(current_state!=null)
            {
                current_state.OnExit();
            }
            states[id].OnEnter();
            current_state = states[id];
 
        }
    }
 
    public class  StateBase
    {
   
        public string id;
        public StateBase(string _id)
        {
            this.id = _id;
        }
        public virtual void OnEnter(params object[] args){}
        public virtual void OnStay(params object[] args){ }
        public virtual void OnExit(params object[] args){}
    
    }
    public class StateBaseTemplate<T>:StateBase
    {
        public  T owner;
        public StateBaseTemplate(string _id,T owner):base(_id)
        {
            this.id = _id;
            this.owner  = owner;
        }
    }
}
