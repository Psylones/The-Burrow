using System.Collections;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    [SerializeField] GameObject GemPrefab;
    [SerializeField] int GemAmount;







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnGem());
    }



    IEnumerator SpawnGem()

    {
        for (int i = 0; i < GemAmount; i++)
        {
            GameObject gem = Instantiate(GemPrefab);
            float randomX = Random.Range(88, 151);
            float randomY = Random.Range(-1, 9);
            gem.transform.position = new Vector3(randomX, randomY, 0);
            yield return new WaitForSeconds(0);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
