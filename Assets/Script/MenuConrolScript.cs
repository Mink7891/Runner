using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuConrolScript : MonoBehaviour
{
    [SerializeField] private Image fade;
    [SerializeField] private GameObject[] button;
    [SerializeField] TMP_Text text;
    public static bool playMusic = true;
    public static bool playerShere = true;
    void Start()
    {
        fade.DOFade(0, 1);
        if (playMusic)
        {
            button[4].GetComponent<Image>().color = Color.green;
            button[5].GetComponent<Image>().color = Color.red;
        }
        else
        {
            button[5].GetComponent<Image>().color = Color.green;
            button[4].GetComponent<Image>().color = Color.red;
        }
        if (playerShere)
        {
            button[7].GetComponent<Image>().color = Color.green;
            button[8].GetComponent<Image>().color = Color.red;
        }
        else
        {
            button[8].GetComponent<Image>().color = Color.green;
            button[7].GetComponent<Image>().color = Color.red;
        }
    }
    public void Play()
    {
        UIControl.tweenFrog = true;
        fade.DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
        });
    }
    public void Music()
    {
        text.text = "Music";
        for (int i = 0; i < button.Length; i++)
        {
            if (i < 4 ||  i > 6)
            {
                button[i].SetActive(false);
            }
            else
            {
                button[i].SetActive(true);
            }
        }
    }
    public void Back()
    {
        text.text = "Далеко не убежишь";
        for (int i = 0; i < button.Length; i++)
        {
            if (i < 4)
            {
                button[i].SetActive(true);
            }
            else
            {
                button[i].SetActive(false);
            }
        }
    }
    public void OnMusic()
    {
        playMusic = true;
        button[4].GetComponent<Image>().color = Color.green;
        button[5].GetComponent<Image>().color = Color.red;
    }
    public void OffMusic()
    {
        playMusic = false;
        button[5].GetComponent<Image>().color = Color.green;
        button[4].GetComponent<Image>().color = Color.red;
    }
    public void Person()
    {
        text.text = "Игроки";
        for (int i = 0; i < button.Length; i++)
        {
            if (i < 6)
            {
                button[i].SetActive(false);
            }
            else
            {
                button[i].SetActive(true);
            }
        }
    }
    public void Sphere()
    {
        playerShere = true;
        button[7].GetComponent<Image>().color = Color.green;
        button[8].GetComponent<Image>().color = Color.red;
    }
    public void Box()
    {
        playerShere = false;
        button[8].GetComponent<Image>().color = Color.green;
        button[7].GetComponent<Image>().color = Color.red;
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
