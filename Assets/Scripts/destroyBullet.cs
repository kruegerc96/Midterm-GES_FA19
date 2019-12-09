using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour
{
    Material material;
    bool isFading = false;
    [SerializeField] float fadeSpeed = 10f;

    void Start()
    {
        // Get the Renderer attached to this game object.
        Renderer renderer = GetComponent<Renderer>();
        // Get the material the renderer is using.
        material = renderer.material;

        Invoke("StartFading", 1f);
    }

    void StartFading()
    {
        isFading = true;
    }

    void Update()
    {
        if (transform.position.y < -20)
        {
            StartFading();
        }

        if (isFading)
        {
            // Generate the new, slightly more transparent color and apply it to the ball.
            float fadeAmount = fadeSpeed * Time.deltaTime;
            Color newColor = Color.Lerp(material.color, Color.clear, fadeAmount);
            material.color = newColor;

            // When we've reached the end of the animation (fully transparent), destroy!
            if (material.color == Color.clear)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy" || collision.collider)
        {
            Destroy(gameObject);
        }
    }
}
