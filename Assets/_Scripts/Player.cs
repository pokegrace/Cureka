using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Text goldValue;
    [SerializeField] private Text mistakeValue;

    public int goldAmount;
    public int mistakeAmount;

    private void Update()
    {
        goldValue.text = goldAmount.ToString();
        mistakeValue.text = mistakeAmount.ToString();

        if (mistakeAmount >= 3)
            SceneManager.LoadScene("GameOverScene");
    }
}
