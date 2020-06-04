using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGameObjScript : MonoBehaviour
{
    public static TrackGameObjScript s_instance = null;

    public GameObject m_target = null;
    public float m_damping = 0;
    Vector3 _offset;
    bool m_isTrack = true;

    void Start()
    {
        TrackGameObjScript.s_instance = this;
    }

    public void setTargetObj(GameObject target)
    {
        m_target = target;
        _offset = transform.position - m_target.transform.position;
    }

    public void setTrackEnable(bool enable)
    {
        m_isTrack = enable;
    }

    void LateUpdate()
    {
        if(m_isTrack && (m_target != null))
        {
            if (m_damping > 0)
            {
                Vector3 desiredPosition = m_target.transform.position + _offset;
                Vector3 position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * m_damping);
                transform.position = position;

                transform.LookAt(m_target.transform.position);
            }
            else
            {
                Vector3 desiredPosition = m_target.transform.position + _offset;
                transform.position = desiredPosition;
            }
        }
    }
}
