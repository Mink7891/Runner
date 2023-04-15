using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] private Image fade;
    public static bool tweenFrog = true;
    public AudioSource music;

    private void Start()
    {
        if (MenuConrolScript.playMusic)
        {
            music.enabled = true;
        }
        else
        {
            music.enabled = false;
        }
        fade.DOFade(0, 1);
    }
    public void GameOver()
    {
        Player.hp = 90;
        tweenFrog = false;
        fade.DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(2);
        });
    }
    public void Menu()
    {
        fade.DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
