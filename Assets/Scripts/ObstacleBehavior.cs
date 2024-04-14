using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float fallSpeed;
    public float despawnY = -8f;

    private void Start()
    {
        fallSpeed = Random.Range(8f, 8f);
    }

    private void Update()
    {

        transform.position += fallSpeed * Time.deltaTime * Vector3.down;

        if (transform.position.y <= despawnY)
        {
            Destroy(gameObject);
        }
    }
}
