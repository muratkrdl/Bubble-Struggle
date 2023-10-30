using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D myRigid;
    [SerializeField] float bounceAmount = 1f;
    [SerializeField] float xMoveAmount = 15f;

    public float XMoveAmount
    {
        get
        {
            return xMoveAmount;
        }
        set
        {
            xMoveAmount = value;
        }
    }

    [SerializeField] bool isXL;
    [SerializeField] bool isL;
    [SerializeField] bool isM;

    [SerializeField] GameObject LBall;
    [SerializeField] GameObject MBall;
    [SerializeField] GameObject SBall;

    void Start() 
    {
        myRigid.AddForce(new Vector2(xMoveAmount * Time.fixedDeltaTime, bounceAmount * Time.fixedDeltaTime /2));
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Bounce"))
        {
            myRigid.velocity = Vector2.zero;
            myRigid.AddForce(new Vector2(xMoveAmount * Time.fixedDeltaTime, bounceAmount * Time.fixedDeltaTime));
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            myRigid.velocity = Vector2.zero;
            xMoveAmount *= -1;
            myRigid.AddForce(new Vector2(xMoveAmount * 1.75f * Time.fixedDeltaTime, 0));
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Fire"))
        {
            Destroy(gameObject);
            
            if(isXL)
            {
                var first = Instantiate(LBall, transform.position, Quaternion.identity);

                var second = Instantiate(LBall, transform.position, Quaternion.identity);
                second.GetComponent<Ball>().XMoveAmount *= -1; 

            }
            else if(isL)
            {
                var first = Instantiate(MBall, transform.position, Quaternion.identity);

                var second = Instantiate(MBall, transform.position, Quaternion.identity);
                second.GetComponent<Ball>().XMoveAmount *= -1; 
            }
            else if(isM)
            {
                var first = Instantiate(SBall, transform.position, Quaternion.identity);

                var second = Instantiate(SBall, transform.position, Quaternion.identity);
                second.GetComponent<Ball>().XMoveAmount *= -1; 
            }
        }    
    }

    void OnDestroy() 
    {
        if(GameManager.Instance.CheckWin())
        {
            GameManager.Instance.ShowWinPanel();
        }    
    }

}
