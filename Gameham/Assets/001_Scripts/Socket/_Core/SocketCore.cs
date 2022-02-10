using System;
using UnityEngine;
using WebSocketSharp;
using Server.VO;

namespace Server.Core
{
    // c++ 하고싶다
    // 그립읍니다 WinSock 2.0
    public class SocketCore : Singleton<SocketCore>
    {
        // public:
        public RequestType LastRequest { get; set; } = RequestType.Default;
        public string LastRequestPayload { get; set; } = null;

        // private:
        WebSocket   m_socket;
        const   string      ADDR = "localhost";
        const   ushort      PORT = 48000;


        public SocketCore()
        {
            m_socket = new WebSocket($"ws://{ADDR}:{PORT}");

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
        public int Send(DataVO vo, RequestType reqType = RequestType.Default)
        {
            LastRequest = reqType;

            if(reqType != RequestType.Default) {
                LastRequestPayload = vo.payload;
            }

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

        /// <summary>
        /// Gets payload of last unique flag send event;
        /// </summary>
        /// <typeparam name="T">VO type</typeparam>
        /// <returns>VO of T</returns>
        public T GetLastRequestPayload<T>()
        {
            return JsonUtility.FromJson<T>(LastRequestPayload);
        }

        /// <summary>
        /// Checks if last request was handled type
        /// </summary>
        /// <param name="type">Request type</param>
        /// <returns>true when handled type was last request type</returns>
        public bool IsType(RequestType type)
        {
            return LastRequest == type;
        }
    }

}