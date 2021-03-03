using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject completeLevelUI;
    
    public void WinGame ()
    {
        Debug.Log("You Won!");
        completeLevelUI.SetActive(true);
    }
    
    
    public void EndGame ()
    {
        Debug.Log("GAME OVER");
        Restart();
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
