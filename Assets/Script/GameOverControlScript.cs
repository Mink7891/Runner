using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverControlScript : MonoBehaviour
{
    [SerializeField] private Image fade;
    void Start()
    {
        fade.DOFade(0, 1);
        Player.countHear = 0;
        fade.enabled = false;
    }
    public void Menu()
    {
        fade.enabled = true;
        fade.DOFade(1, 1).OnComplete(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}
