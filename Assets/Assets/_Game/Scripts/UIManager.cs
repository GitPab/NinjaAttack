using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //singleton
    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManager>();

                if (instance == null)
                {
                    instance = new GameObject().AddComponent<UIManager>();
                }
            }

            return instance;
        }
    }

    [SerializeField] Text scoreTxt;
    [SerializeField] Text scoreFinishTxt;
    [SerializeField] GameObject gameplay;
    [SerializeField] GameObject finish;
    private float score;

    public void UpdateScore(float score)
    {
        if (this.score < score)
        {
            this.score = score;
            scoreTxt.text = score.ToString("F0");
        }
    }

    public void FinishGame()
    {
        gameplay.SetActive(false);
        finish.SetActive(true);
        scoreFinishTxt.text = score.ToString("F0");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
}
