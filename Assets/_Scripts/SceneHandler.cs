using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadTitleScene()
    {
        SoundManager.instance.PlaySingle(SoundManager.buttonPushSound);
        SceneManager.LoadScene("TitleScene");
    }
}
