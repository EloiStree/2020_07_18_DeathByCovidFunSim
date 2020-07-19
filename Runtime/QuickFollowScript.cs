using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickFollowScript : MonoBehaviour
{

    public Transform m_toAffect;
    public Transform m_toFollow;

    void Update()
    {
        m_toAffect.position = m_toFollow.position;
        m_toAffect.rotation = m_toFollow.rotation;

    }
}
