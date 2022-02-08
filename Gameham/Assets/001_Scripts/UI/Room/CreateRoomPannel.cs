using UnityEngine;
using UnityEngine.UI;
using Server.Core;
using Server.VO;


namespace Objects.UI
{
    public class CreateRoomPannel : MonoBehaviour
    {
        [SerializeField] InputField _nameInput;
        [SerializeField] Button _okButton;
        [SerializeField] Button _closeButton;

        private void Awake() {
            _okButton.onClick.AddListener(() => {
                string payload = JsonUtility.ToJson(new StringVO(_nameInput.text));
                SocketCore.Instance.Send(new DataVO("createroom", payload));
                gameObject.SetActive(false);
            });

            _closeButton.onClick.AddListener(() => {
                gameObject.SetActive(false);
            });

            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _nameInput.text = "멋있는 방 이름";
        }




    }
}