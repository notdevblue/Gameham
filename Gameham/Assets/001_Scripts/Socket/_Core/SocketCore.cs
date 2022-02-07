using System;
using UnityEngine;
using WebSocketSharp;

using Server.Core.VO;

namespace Server.Core
{
    // c++ 하고싶다
    // 그립읍니다 WinSock 2.0
    public class SocketCore : Singleton<SocketCore>
    {
        // public:


        // private:
        WebSocket m_socket;
        const string ADDR = "localhost";
        const ushort PORT = 32000;

        public SocketCore()
        {
            m_socket = new WebSocket($"{ADDR}:{PORT}");

            m_socket.OnMessage += (s, e) => {
                BufferHandler.Instance.Handle(e.Data);
            };
        }

        ~SocketCore()
        {
            m_socket.Close(CloseStatusCode.Normal, "User closed application");
            m_socket = null;
        }

        /// <summary>
        /// Connects to server
        /// </summary>
        public int Connect()
        {
            if(m_socket.IsAlive) {
                Debug.Log("Already connected to server, exitting.");
                return -1;
            }

            try {
                m_socket.Connect();
            }
            catch(Exception ex) {
                Debug.LogError($"Error while connecting to server.\r\n{ex.Message}");
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Convers DataVO to json and sends
        /// </summary>
        /// <param name="vo">Packet</param>
        public int Send(DataVO vo)
        {
            try {
                m_socket.Send(JsonUtility.ToJson(vo));
            } catch (Exception ex) {
                Debug.LogError($"Error while sending packet to server.\r\n{ex.Message}");
                return -1;
            }

            return 0;
        }

        /// <summary>
        /// Disconnects from server
        /// </summary>
        public int Disconnect(CloseStatusCode code = CloseStatusCode.Normal, string reason = "User request")
        {
            try {
                m_socket.Close(code, reason);
            } catch (Exception ex) {
                Debug.LogError($"Error while closing connection with server.\r\n{ex.Message}");
                return -1;
            }

            return 0;
        }


    }

}