using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadGameScene(bool bot)
    {
        if (bot == true)
            PlayerPrefs.SetInt("bot", 1);
        else
            PlayerPrefs.SetInt("bot", 0);
        SceneManager.LoadScene("Game");
    }
}