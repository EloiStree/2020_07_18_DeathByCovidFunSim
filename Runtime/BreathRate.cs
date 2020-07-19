using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathRate : MonoBehaviour
{
    public float m_multiplicator = 50f;
    public AnimationCurve m_breathRate;
    public ParticleSystem m_particuleSystem;
    public float m_breathDuration = 2f;
   // ParticleSystem.MinMaxCurve c = new ParticleSystem.MinMaxCurve();
    void Update()
    {
//        c.constant = m_breathRate.Evaluate(Time.time % m_breathDuration) * m_multiplicator;
        m_particuleSystem.emissionRate = m_breathRate.Evaluate(Time.time % m_breathDuration) * m_multiplicator;


    }
}
