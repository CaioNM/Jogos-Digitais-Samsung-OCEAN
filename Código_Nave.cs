using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Còdigo_Nave : MonoBehaviour
{
    public float speed = 5;
    public GameObject tiro;
    public Transform canhao;
    public float cooldown = 0.1f;
    private bool shooting;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	var bottomLeft=Camera.main.ScreenToWorldPoint(Vector3.zero);
    	var topRight=Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight));
    	var cameraRect = new Rect(bottomLeft.x, bottomLeft.y,topRight.x-bottomLeft.x ,topRight.y-bottomLeft.y);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 position = transform.position;

        position.x += x * Time.deltaTime * speed;
        position.y += y * Time.deltaTime * speed;

        transform.position = position;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, cameraRect.xMin, cameraRect.xMax), Mathf.Clamp(transform.position.y, cameraRect.yMin, cameraRect.yMax));

        if (Input.GetKey(KeyCode.Space)) Shoot();
    }

    void Shoot ()
    {
        if (shooting) return;
        shooting = true;

        GameObject newShoot = Instantiate(shoot, cannon.position, cannon.rotation);
        newShoot.TryGetComponent(out Rigidbody2D rb);
        rb.AddForce(Vector3.up * speed, ForceMode2D.Impulse);
        Destroy(newShoot, 2);

        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(cooldown);
        shooting = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    	GameController controller = FindObjectOfType<GameController>();
    	controller.Respawn();
    	controller.ResetScore();

        GameObject boom = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(boom, 0.8f);

        Destroy(gameObject);
    }
}
