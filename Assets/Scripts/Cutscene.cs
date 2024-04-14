using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public int i;
    public float targetTime;
    private bool imageChanged = false;
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;

    private void Start()
    {
        targetTime = 20f;
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            targetTime = 16f;
        }
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteArray[0];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimerEnded();
        }

        targetTime -= Time.deltaTime;
        int second = (int)targetTime % 60;
        print("time: " + second);

        if (second % 4 == 0 && !imageChanged && i < 4)
        {
            i++;
            if (i == 4 && SceneManager.GetActiveScene().buildIndex == 6)
            {
                i--;
            }
            print(i);
            spriteRenderer.sprite = spriteArray[i];
            print("Image change");
            imageChanged = true;
        }

        else if (second % 4 != 0)
        {
            imageChanged = false;
        }

        if (targetTime <= 0)
        {
            TimerEnded();
        }
    }

    private void TimerEnded()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            SceneManager.LoadScene(5);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(8);
        }
        else SceneManager.LoadScene(2);
    }
}
