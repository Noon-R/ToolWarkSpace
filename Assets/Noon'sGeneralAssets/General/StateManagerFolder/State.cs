using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T> {
    void Update();
    void OnEnter();
    void OnExit();
    void OnCollisionEnter(Collision2D col);
    void OnCollisionExit(Collision2D col);
    void OnCollisionStay(Collision2D col);
    void OnTriggerEnter(Collider2D col);
    void OnTriggerExit(Collider2D col);
    void OnTriggerStay(Collider2D col);
}

public class SampleState<T> : IState<T> {
    StateMachine<T> mStateMachine;

    public SampleState(StateMachine<T> stateMachine, GameObject gameObject) {
        mStateMachine = stateMachine;
    }

    public void Update() { }
    public void OnEnter() { }
    public void OnExit() { }
    public void OnCollisionEnter(Collision2D col) { }
    public void OnCollisionExit(Collision2D col) { }
    public void OnCollisionStay(Collision2D col) { }
    public void OnTriggerEnter(Collider2D col) { }
    public void OnTriggerExit(Collider2D col) { }
    public void OnTriggerStay(Collider2D col) { }
    
}

/*==============================================================================
 * 
 * ==============================================================================*/
public class EmptyState<T> : IState<T> {
    StateMachine<T> mStateMachine;

    public void Update() { }
    public void OnEnter() { }
    public void OnExit() { }
    public void OnCollisionEnter(Collision2D col) { }
    public void OnCollisionExit(Collision2D col) { }
    public void OnCollisionStay(Collision2D col) { }
    public void OnTriggerEnter(Collider2D col) { }
    public void OnTriggerExit(Collider2D col) { }
    public void OnTriggerStay(Collider2D col) { }
}

