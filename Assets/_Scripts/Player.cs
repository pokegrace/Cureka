using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text goldValue;
    [SerializeField] private Text mistakeValue;

    private int goldAmount;
    private int mistakeAmount;

    public int GoldAmount
    {
        get { return goldAmount; }
        set { goldAmount = value; }
    }
    public int MistakeAmount
    {
        get { return mistakeAmount; }
        set { mistakeAmount = value; }
    }

    private void Update()
    {
        goldValue.text = goldAmount.ToString();
        mistakeValue.text = mistakeAmount.ToString();

        if (mistakeAmount >= 3)
            SceneManager.LoadScene("GameOverScene");
    }
}
