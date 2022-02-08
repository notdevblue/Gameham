using UnityEngine;

public class Flag
{
    bool m_flag;
    bool m_autoReset;

    public void Set() => m_flag = true;
    public bool Get()
    {
        if(m_flag)
        {
            if(m_autoReset) {
                m_flag = false;
            }

            return true;
        } 

        return false;
    }

    public Flag(bool initialStatus = false, bool autoResetFlag = true)
    {
        m_flag = initialStatus;
        m_autoReset = autoResetFlag;
    }
}