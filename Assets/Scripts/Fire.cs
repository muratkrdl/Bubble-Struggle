using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] float fireSpeed = 5f;

    void Update() 
    {
        IncreaseFireScale();
    }

    void IncreaseFireScale()
    {
        Vector3 newScale = transform.localScale;
        newScale.y += fireSpeed * Time.deltaTime;
        transform.localScale = newScale;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }   
    }

}
