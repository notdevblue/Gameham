using UnityEngine;
using UnityEngine.UI;


namespace Objects.UI
{
    public class CreateRoomButton : MonoBehaviour
    {
        [SerializeField] Button _btnCreate;
        [SerializeField] CreateRoomPannel _createRoomPannel;

        private void Awake()
        {
            _btnCreate.onClick.AddListener(() => {
                _createRoomPannel.gameObject.SetActive(true);
            });
        }


    }
}