using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void DePause()
    {
        Time.timeScale = 1;
    }
}
