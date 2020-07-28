using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> {
    private Dictionary<string, IState<T>> mStatesMap = new Dictionary<string, IState<T>>();
    private IState<T> mCurrentState = new EmptyState<T>();
    private T m_data;

    public StateMachine(T data) {
        m_data = data;
    }

    public void Update() {
        mCurrentState.Update();
    }
    public void OnCollisionEnter(Collision2D col) {
        mCurrentState.OnCollisionEnter(col);
    }
    public void OnCollisionExit(Collision2D col) {
        mCurrentState.OnCollisionExit(col);
    }
    public void OnCollisionStay(Collision2D col) {

    }

    public void OnTriggerEnter(Collider2D col) {
        mCurrentState.OnTriggerEnter(col);
    }
    public void OnTriggerExit(Collider2D col) {
        mCurrentState.OnTriggerExit(col);
    }

    public void OnTriggerStay(Collider2D col) {

    }

    public T GetMachineData() {
        return m_data;
    }

    public void Change(string name) {
        if (mStatesMap[name] != null) {
            mCurrentState.OnExit();
            mCurrentState = mStatesMap[name];
            mCurrentState.OnEnter();
        }
    }
    public void Add(string name,IState<T> state) {
        if (!mStatesMap.ContainsKey(name)) {
            mStatesMap.Add(name, state);
        } else {
            Debug.Log("mStatesMap["+ name +"] is changed!!");
            mStatesMap[name] = state;
        }
    }

    public void Remove(string name) {
        mStatesMap.Remove(name);
    }
}
