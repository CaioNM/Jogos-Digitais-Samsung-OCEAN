using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour{
	public GameObject spawn;
	IEnumerator Start()
    {
        while (true)
        {
            float time = Random.Range(0.3f, 0.6f);
            int index = Random.Range(0, enemies.Length-1);
            float x = Random.Range(-3, 3);

            yield return new WaitForSeconds(time);

            Vector3 pos = transform.position;
            pos.x = x;

            GameObject enemy = Instantiate(enemies[index], pos, transform.rotation);
            Destroy(enemy, 5);
        }
    }
}