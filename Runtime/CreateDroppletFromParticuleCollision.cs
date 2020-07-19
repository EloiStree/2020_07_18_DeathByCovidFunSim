using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDroppletFromParticuleCollision : MonoBehaviour
{
    public CreateDropplet m_generator;
    public float m_lifeTime = 180;

    public LayerMask m_mask = 1;
    public ParticleSystem m_particules;
    public ParticleSystem.Particle[] m_particulesRef;
    public Transform m_startPoint;
     int m_max;
    public bool m_useDrawDebug = true;
    public bool m_antispam = true;
    public bool m_linkToParent=true;
    public float m_radius = 0.03f;
    private void Start()
    {

        InitializeIfNeeded();
        m_max = m_particulesRef.Length;
    }
    void Update()
    {
       
        m_particules.GetParticles(m_particulesRef);
        for (int i = 0; i < m_particulesRef.Length; i++)
        {
            if (m_useDrawDebug)
                Debug.DrawLine(m_startPoint.position, m_particulesRef[i].position);
            Collider [] c =Physics.OverlapSphere(m_particulesRef[i].position, m_radius, m_mask);
            if (c.Length > 0) {
              GameObject obj =  m_generator.CreateWithLifeTime(m_particulesRef[i].position, m_lifeTime);
                if (m_linkToParent) {
                    obj.transform.SetParent( c[0].transform) ;
                
                }
             //  m_particulesRef[i].remainingLifetime = 0.00001f;
               // m_particulesRef[i].position = m_startPoint.position;

                if (m_antispam)
                    break;
            }
        }
        m_particules.SetParticles(m_particulesRef);

    }




    void InitializeIfNeeded()
    {
        if (m_particules == null)
            m_particules = GetComponent<ParticleSystem>();

        if (m_particulesRef == null )//|| m_particulesRef.Length < m_particules.main.maxParticles)
            m_particulesRef = new ParticleSystem.Particle[m_particules.main.maxParticles];
    }
}
