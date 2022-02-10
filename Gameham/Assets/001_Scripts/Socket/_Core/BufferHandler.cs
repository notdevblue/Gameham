using System;
using System.Collections.Generic;
using Server.VO;
using UnityEngine;

namespace Server.Core
{
    public class BufferHandler : Singleton<BufferHandler>
    {
        // public:


        // private:
        private Dictionary<string, Action<string>> m_bufferDictionary;

        public BufferHandler()
        {
            m_bufferDictionary = new Dictionary<string, Action<string>>();
        }

        ~BufferHandler()
        {
            m_bufferDictionary = null;
        }

        

        public void Handle(string data)
        {
            try {
                DataVO vo = JsonUtility.FromJson<DataVO>(data);

                if (!m_bufferDictionary.ContainsKey(vo.type)) {
                    Debug.LogError($"BufferHandler > Handler does not exitst for request key:{vo.type}, exitting.");
                    return;
                }
                
                m_bufferDictionary[vo.type](vo.payload);

            } catch (Exception ex)  {
                Debug.LogError($"BufferHandler > Error while handling packet\r\n{ex}");
            }
        }

        /// <summary>
        /// 헨들러를 추가합니다.<br/>
        /// ## 유니티 스레드에서 호출되지 않음 ##
        /// </summary>
        public int Add(string type, Action<string> handledEvent, bool supressMultipleHandlerWarning = false)
        {
            bool bContains = m_bufferDictionary.ContainsKey(type);

            if(bContains && !supressMultipleHandlerWarning) { // 중복 헨들러 등록 체크
                Debug.LogWarning($"BufferHandler > Handled type:{type} already has its own handler, exitting.\r\n" +
                                  "If it's intended, set suppressMultipleHandlerWarning to true.");
                return -1;
            }

            if(bContains) {
                m_bufferDictionary[type] += handledEvent;
            } else {
                Debug.Log("added : " + type);
                m_bufferDictionary.Add(type, handledEvent);
            }

            return 0;
        }
    }

}