using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionBehavior : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(3);
        }
    }
    public void OnPlayButton()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void OnReturnButton()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(0);
    }

    public void OnOptionsButton()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(3);
    }
    public void OnQuitButton()
    {
        GetComponent<AudioSource>().Play();
        Application.Quit();
        Debug.Log("Game has been quit.");
    }
}
