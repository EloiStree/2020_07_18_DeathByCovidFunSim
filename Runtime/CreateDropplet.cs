using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDropplet : MonoBehaviour
{
    public GameObject m_prefab;
    public GameObject Create(Vector3 worldPosition)
    {
        return GameObject.Instantiate(m_prefab, worldPosition, Quaternion.Euler(Random.value * 360, Random.value * 360, Random.value * 360));
    }
    public GameObject CreateWithLifeTime(Vector3 worldPosition, float time)
    {
        GameObject obj = GameObject.Instantiate(m_prefab, worldPosition, Quaternion.Euler(Random.value * 360, Random.value * 360, Random.value * 360));
        Destroy(obj, time);
        return obj;
    }
}
