
using UnityEngine;

public class GameWin : MonoBehaviour
{
    public GameManager gameManager;
    
    void OnTriggerEnter ()
    {
        gameManager.WinGame();
    }
}
