using UnityEngine;

public class SFX : MonoBehaviour
{
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Strawberry"))
        {
            source.Play();
        }

        else if (collision.gameObject.CompareTag("Fox"))
        {
            source.Play();
        }

        else if (collision.gameObject.CompareTag("Blueberry"))
        {
            source.Play();
        }
    }
}
