using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneHandler : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private GameObject customerSprite;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySingle(SoundManager.buttonPushSound);
            SceneManager.LoadScene("MainScene");
        });

        creditsButton.onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySingle(SoundManager.buttonPushSound);
            SceneManager.LoadScene("CreditsScene");
        });

        anim = customerSprite.GetComponent<Animator>();
        anim.SetBool("FrontWalk", true);
    }
}
