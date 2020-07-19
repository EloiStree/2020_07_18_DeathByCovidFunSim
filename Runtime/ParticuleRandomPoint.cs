using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticuleRandomPoint : MonoBehaviour
{
    public ParticleSystem m_particules;
    public ParticleSystem.Particle[] m_particulesRef;
    public Transform m_startPoint;
    public int m_max;
    public bool m_useDrawDebug=true;

    private void Awake()
    {

        InitializeIfNeeded();
    }

    void Update()
    {
        InitializeIfNeeded();
        m_max = m_particulesRef.Length;
        for (int i = 0; i < m_particules.particleCount; i++)
        {
            if(m_useDrawDebug)
                Debug.DrawLine(m_startPoint.position, m_particulesRef[i].position);
        }

    }


    public Vector3 GetRandomPoint()
    {
        InitializeIfNeeded();
        if (m_particulesRef.Length==0)
            return m_startPoint.position;
        ParticleSystem.Particle [] parts = m_particulesRef.Where(k => k.position != Vector3.zero).OrderByDescending(k => Vector3.Distance(m_startPoint.position, k.position)).ToArray();
        if (parts.Length == 0)
            return m_startPoint.position;

        Vector3 p = parts.First().position;

        return Vector3.Lerp(p, m_startPoint.position, UnityEngine.Random.value);
    }


    void InitializeIfNeeded()
    {
        if (m_particules == null)
            m_particules = GetComponent<ParticleSystem>();

        if (m_particulesRef == null || m_particulesRef.Length < m_particules.main.maxParticles)
            m_particulesRef = new ParticleSystem.Particle[m_particules.main.maxParticles];
        m_particules.GetParticles(m_particulesRef);
    }
}
