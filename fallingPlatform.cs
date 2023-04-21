using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    [SerializeField] float fallTime = 0.5f, destroyTime = 1f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            PlatformManager.Instance.StartCoroutine("spawnPlatform",
                new Vector2 (transform.position.x, transform.position.y));
            Invoke("FallPlatform", fallTime);
            Destroy(gameObject, destroyTime);

        }
    }
    // Update is called once per frame
    void FallPlatform()
    {
        rb.isKinematic = false;
    }
    
}
