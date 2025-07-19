using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonController : MonoBehaviour
{


    //attach to exit button, exits game
    public void ExitGame()
    {
        SoundManager.Instance.PlayButton();
        Application.Quit();
    }

    // move to level selector
    public void EnterLevelSelecter()
    {
        SoundManager.Instance.PlayButton();
        GameManager.Instance.LevelSelectState();
        SceneManager.LoadScene("LevelSelectScene");
    }

    //funciton to open  scene 1
    public void PlayGame1()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.Save();
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("GameLevel1");  
        GameManager.Instance.ResetGameState();
        GameManager.Instance.totalCoins = 0;
 
    }

    //funciton to open game scene 2
    public void PlayGame2()
    {
        PlayerPrefs.SetInt("Level", 2);
        PlayerPrefs.Save();
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("GameLevel2");
        GameManager.Instance.ResetGameState();
        GameManager.Instance.totalCoins = 0;
    }
    //funciton to open game scene 3
    public void PlayGame3()
    {
        PlayerPrefs.SetInt("Level", 3);
        PlayerPrefs.Save();
        SoundManager.Instance.PlayButton();
        SceneManager.LoadScene("GameLevel3");  
        GameManager.Instance.ResetGameState();
        GameManager.Instance.totalCoins = 0;
        
    }

}
