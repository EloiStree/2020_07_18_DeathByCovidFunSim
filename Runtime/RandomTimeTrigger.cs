using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomTimeTrigger : MonoBehaviour
{

    public float m_minTime=0.1f;
    public float m_maxTime=1f;
    public UnityEvent m_action;
    public bool m_activateAtStart =true;
    IEnumerator Start()
    {
        if(m_activateAtStart)
            ToTheThing();
        while (true) {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(UnityEngine.Random.Range(m_minTime, m_maxTime));
            ToTheThing();
        }
        
    }

    private void ToTheThing()
    {
        m_action.Invoke();
    }
}
