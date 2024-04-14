using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text berryText;
    [SerializeField] private TMP_Text HPvalueText;
    public TimerUI timer;
    public Animator anim;
    public int finalScore;
    private int berryScore;
    private int foxScore;
    private float berryCount = 0;
    private int HPvalue = 3;

    public static int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (GetComponent<Animator>() != null && SceneManager.GetActiveScene().buildIndex == 5)
        {
            anim.SetBool("extinguish", false);
        }
    }

    private void Update()
    {
        HPvalue = Clamp(HPvalue, 0, 3);
        HPvalueText.text = "HP:" + HPvalue.ToString();
        berryText.text = SceneManager.GetActiveScene().buildIndex == 5 ? "Foxes: " + foxScore.ToString() : "Berries: " + berryCount.ToString();
        scoreText.text = berryScore.ToString();

        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 5)
        {
            anim.SetBool("extinguish", true);
        }
        if (Input.GetKeyUp(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 5)
        {
            anim.SetBool("extinguish", false);
        }
        if (HPvalue == 0)
        {
            SceneManager.LoadScene(4);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fox"))
        {
            foxScore++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Burning"))
        {
            if (anim.GetBool("extinguish") && SceneManager.GetActiveScene().buildIndex == 5)
            {
                Destroy(collision.gameObject);
            }
            else HPvalue--;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            HPvalue++;
            berryScore += 500;
            berryCount++;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Blueberry"))
        {
            berryScore += 300;
            berryCount++;
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Fox"))
        {
            Destroy(collision.gameObject);
        }

        finalScore = berryScore * HPvalue;

        scoreText.text = berryScore.ToString();

        if (HPvalue >= 2)
        {
            finalScore += 2000; //HP bonus
        }
    }
}
