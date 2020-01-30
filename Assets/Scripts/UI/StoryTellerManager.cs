using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoryTellerManager : MonoBehaviour
{
    [System.Serializable]
    public struct StoryScreen
    {
        public Sprite storyImg;
        public string storyText;
    }



    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    private int i_CurrentScreen;
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    
    [SerializeField]
    StoryScreen[] StoryScreens;


    #endregion

    #region Public GameObjects
    [SerializeField]
    GameObject go_LoadingScreen;
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements
    private Image img_CurrentImage;
    private TextMeshProUGUI text_CurrentText;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Awake()
    {
        

        img_CurrentImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        text_CurrentText = transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>();

        img_CurrentImage.sprite = StoryScreens[i_CurrentScreen].storyImg;
        StartCoroutine(AnimateDialogue(StoryScreens[i_CurrentScreen].storyText));
    }

    // Update is called once per frame
    void Update()
    {
        TraverseScreens();
    }
    #endregion

    #region Methods
    public void TraverseScreens()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (i_CurrentScreen != StoryScreens.Length + 1)
            {
                i_CurrentScreen++;
                img_CurrentImage.sprite = StoryScreens[i_CurrentScreen].storyImg;
                StopAllCoroutines();
                StartCoroutine(AnimateDialogue(StoryScreens[i_CurrentScreen].storyText));
            }
            else
            {
                if (go_LoadingScreen != null && !go_LoadingScreen)
                    go_LoadingScreen.SetActive(true);
            }
        }
       
            
    }
    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    IEnumerator AnimateDialogue(string storyText)
    {
        text_CurrentText.text = "";
        foreach(char letter in storyText)
        {
            text_CurrentText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
    #endregion
}
