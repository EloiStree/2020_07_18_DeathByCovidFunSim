using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDroppletFromStationary : MonoBehaviour
{
    public CreateDropplet m_generator;
    public ParticuleRandomPoint m_where;
    public float m_lifeTime=180;

    public void Generate() {
        
        Vector3 where = m_where.GetRandomPoint();
        Debug.Log("W" + where);
        m_generator.CreateWithLifeTime(where, m_lifeTime);
    }
}
