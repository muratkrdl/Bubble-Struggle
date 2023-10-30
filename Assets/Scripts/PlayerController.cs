using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject firePrefab;

    [SerializeField] float moveSpeed = 5f;

    bool isPressFireButton => Input.GetKeyDown(KeyCode.S);

    void Update() 
    {
        Move();
        Fire(); 
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
    
        Vector2 newPos = transform.position;
        newPos.x += moveInput * moveSpeed * Time.deltaTime;

        transform.position = newPos;
    }

    void Fire()
    {
        if(isPressFireButton && FindObjectOfType<Fire>() == null)
        {
            var fireGameObject = Instantiate(firePrefab, transform.position - new Vector3(0f, .5f, 0), Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            GameManager.Instance.ShowGameOverPanel();
        }    
    }

}
