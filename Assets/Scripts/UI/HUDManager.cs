using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    
    #region Singleton

    #endregion

    #region Variables

    #region Booleans

    #endregion

    #region Vectors And Transforms

    #endregion

    #region Integers And Floats
    #endregion

    #region Strings And Enums
    #endregion

    #region Lists
    #endregion

    #region Public GameObjects
    #endregion

    #region Private GameObjects
    #endregion

    #region UIElements

    [SerializeField] 
    private Sprite[] ui_SpaceShipeInspector;

    [SerializeField]
    private Sprite[] ui_PlanetSprites;

    [SerializeField]
    private Image ui_SpaceshipImage;

    [SerializeField]
    private Image ui_FullTankSprite;

    [SerializeField]
    private Image ui_PlanetsImg;

    private static Sprite[] ui_SpaceShipSprites;
    #endregion

    #region Others
    #endregion

    #endregion


    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
       ui_SpaceShipSprites = new Sprite[4];
       for (int i = 0; i < ui_SpaceShipeInspector.Length; i++)
       {
           ui_SpaceShipSprites[i] = ui_SpaceShipeInspector[i];
       }
       ui_SpaceshipImage.sprite = ui_SpaceShipSprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        updateSpaceShipLifeSprite();
        updatePlanetsSurvivedSprite();
        FillBar(ui_FullTankSprite, GameManager._LifeSource,125);
    }
    #endregion

    #region Methods

    void updateSpaceShipLifeSprite()
    {
        if (PlayerController.i_EnemyHitting == 0)
        {
            ui_SpaceshipImage.sprite = ui_SpaceShipSprites[0];
        }
        else if (PlayerController.i_EnemyHitting == 1)
        {
            ui_SpaceshipImage.sprite = ui_SpaceShipSprites[1];
            }
        else if(PlayerController.i_EnemyHitting == 2)
        {
            ui_SpaceshipImage.sprite = ui_SpaceShipSprites[2];
        }
        else if(PlayerController.i_EnemyHitting == 3)
        {
            ui_SpaceshipImage.sprite = ui_SpaceShipSprites[3];
        }
    }

    void updatePlanetsSurvivedSprite()
    {
        switch (GameManager._PlanetsSurvived)
        {
            case 1: ui_PlanetsImg.sprite = ui_PlanetSprites[0];
                break;
            case 2:
                ui_PlanetsImg.sprite = ui_PlanetSprites[1];
                break;
            case 3:
                ui_PlanetsImg.sprite = ui_PlanetSprites[2];
                break;
        }
    }
    
    void FillBar(Image img, int value, int originalValue)
    {
        float newValue = (float)value / originalValue;
        img.fillAmount = newValue;
    }

    #endregion

    #region Collisons And Triggers
    #endregion

    #region Coroutines
    #endregion
}
