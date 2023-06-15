using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject Doodle_PlatformGreenPrefab;
    public GameObject Doodle_BrokenPlatformPrefab;

    public int normalPlatformCount;
    public int brokenPlatformCount;

    void Start()
    {
        GeneratePlatforms();
    }

    void GeneratePlatforms()
    {
        Vector3 spawnerPosition = new Vector3();
        Vector3 spawnerPosition2 = new Vector3();

        for (int i = 0; i < normalPlatformCount; i++)
        {
            spawnerPosition.x = Random.Range(-1.7f, 1.7f);
            spawnerPosition.y += Random.Range(1.5f, 4f);

            Instantiate(Doodle_PlatformGreenPrefab, spawnerPosition, Quaternion.identity);
        }

        for (int i = 0; i < brokenPlatformCount; i++)
        {
            spawnerPosition2.x = Random.Range(-1.7f, 1.7f);
            spawnerPosition2.y += Random.Range(1.5f, 4f);

            Instantiate(Doodle_BrokenPlatformPrefab, spawnerPosition2, Quaternion.identity);
        }
    }
}
