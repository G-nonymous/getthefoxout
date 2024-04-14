using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject[] backgroundObjects;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float timeBetweenSpawn;
    private float spawnTime;
    private void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    private void SpawnBackground()
    {

    }

    private void Spawn()
    {
        print(objects.Length);
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        int random = Random.Range(1, objects.Length);
        int randomFirefighter = Random.Range(0, objects.Length - 2);
        //Increases chance of fire spawning to 50% on level 2
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            int fireChance = Random.Range(0, 1);
            if (fireChance == 1) _ = Instantiate(objects[1], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
            else _ = Instantiate(objects[randomFirefighter], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        }
        else _ = Instantiate(objects[random], transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
    }
}
