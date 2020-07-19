using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QAD_RandomMove : MonoBehaviour
{
    public NavMeshAgent m_agent;
    public float m_range=10;
    public void ChooseNewDirection() {
        m_agent.destination = new Vector3(UnityEngine.Random.Range(-m_range, m_range), 0, UnityEngine.Random.Range(-m_range, m_range));
    }
}
