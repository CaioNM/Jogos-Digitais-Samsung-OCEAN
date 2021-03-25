using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
	public int score = 100;
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D collision)
    {
    	GameController controller = FindObjectOfType<GameController>();
    	controller.Score();

        Destroy(collision.gameObject);

        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(boom, 0.8f);

        Destroy(gameObject);
    }
}
