using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void _OnClickedStartGame()
    {
        SceneManager.LoadScene(1);
    }

}//last bracket, DON'T GO PAST! 
