using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public float moveSpeed;
    public int itemCount;

    Vector3 origin;

    bool isJump;
    Rigidbody rigid;
    AudioSource audioSource;

    void Awake()
    {
        origin = transform.position;
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && (!isJump))
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
        if (transform.position.y <= -20)
        {
            GameManagerLogic.gameManager.LifeDown();
            transform.position = origin;
            rigid.velocity = Vector3.zero;
        }

        if (GameManagerLogic.gameManager.life < 1)
        {
            SceneManager.LoadScene(0);
        }
    }


    public void Jump()
    {
        if (!isJump)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(GameManagerLogic.gameManager.stage);
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical")
        ; Debug.Log(h);

        rigid.AddForce(new Vector3(h, 0, v)* moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
            isJump = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            itemCount++;
            audioSource.Play();
            other.gameObject.SetActive(false);
            GameManagerLogic.gameManager.GetItem(itemCount);

        }
        else if (other.gameObject.tag == "FINISH")
        {
            Debug.Log(GameManagerLogic.gameManager.stage);
            if (itemCount == GameManagerLogic.gameManager.TotalitemCount)
            {              
                    SceneManager.LoadScene(GameManagerLogic.gameManager.stage + 1);
            }
            else
            {
                //Restart Stage
                SceneManager.LoadScene(GameManagerLogic.gameManager.stage);
            }
        }
    }





}
