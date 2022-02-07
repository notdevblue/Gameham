using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Commands;
using Commands.Movement.Movements;

namespace Player.Movement
{

    public class PlayerInputHandler : MonoSingleton<PlayerInputHandler>
    {
        private Dictionary<KeyCode, Command> _pushInputDictionary = new Dictionary<KeyCode, Command>();
        //private PlayerMovement _playerMove = null;

        private void Start()
        {
            //// �׽�Ʈ �� �ƹ����� ������ ��
            //#region
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
            //#endregion

            //_playerMove = FindObjectOfType<PlayerMovement>();

            //if (_playerMove == null)
            //{
            //    // Fatal
            //}

            //_pushInputDictionary.Add(KeyCode.W, new MoveFoward(_playerMove));
            //_pushInputDictionary.Add(KeyCode.S, new MoveBackword(_playerMove));
            //_pushInputDictionary.Add(KeyCode.A, new MoveLeft(_playerMove));
            //_pushInputDictionary.Add(KeyCode.D, new MoveRight(_playerMove));
        }

        private void Update()
        {
            foreach (KeyCode key in _pushInputDictionary.Keys)
            { // GetKey();
                if (Input.GetKey(key))
                    _pushInputDictionary[key].Execute();
            }
        }
    }
}