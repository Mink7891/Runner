using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int hp = 90;

    private bool jumpBool = false;

    public GameObject[] heart;
    public GameObject[] noHeart;
    public GameObject canvas;
    public static int countHear = 0;
    public Material material;

    private bool onDeid = false;
    private static int playerScore;
    public TMP_Text Score, Best_Result;
    private float timer;
    public static int bestResult;
    public Camera cam;

    private void Awake()
    {
        if (bestResult > 0)
        {
            Best_Result.text = "Best Result: " + bestResult;
        }
        material.DOColor(Color.green, 0.5f);
        if (countHear != 0) for (int i = 0; i < countHear; i++)
        {
            heart[i].SetActive(false);
            noHeart[i].SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            jumpBool = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Frog")
        {
            hp -= 30;
            material.DOColor(Color.red, 0.1f);
            if (hp <= 0)
            {
                onDeid = true;
                if (bestResult < playerScore)
                {
                    bestResult = playerScore;
                }
                playerScore = 0;
                transform.DOKill();
                canvas.GetComponent<UIControl>().GameOver();
            }
            
            if (countHear != heart.Length)
            {
                heart[countHear].SetActive(false);
                noHeart[countHear].SetActive(true);
                countHear += 1;
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        material.DOColor(Color.green, 1f);
    }
    private void Update()
    {
        if (!onDeid)
        {
            timer += 1 * Time.deltaTime;
            if (timer > 1)
            {
                playerScore += (int)timer;
                timer = 0;
            }
        }
        Score.text = "Score: " + playerScore;
        if (Input.GetKeyDown(KeyCode.D) && transform.position != new Vector3(transform.position.x, transform.position.y, 8f) && jumpBool)
        {
            jumpBool = false;
            transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z + 4), 0.5f, 1, 0.3f);
        }
        else if (Input.GetKeyDown(KeyCode.A) && transform.position != new Vector3(transform.position.x, transform.position.y, 0f) && jumpBool)
        {
            jumpBool = false;
            transform.DOJump(new Vector3(transform.position.x, transform.position.y, transform.position.z - 4), 0.5f, 1, 0.3f);
        }
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);

    }
}
