using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AppData : MonoBehaviour
{
    #region Singleton
    private static AppData instance;

    public static AppData Instance
    {
        get
        {
            //check if instance already exists, if not, search the scene for an object containing this class
            if(instance == null)
                instance = (AppData)FindObjectOfType(typeof(AppData));

            //instance == null if object does not exist in the scene
            if(instance == null)
            {
                //check if prefab exists first
                GameObject prefab = Resources.Load("AppData") as GameObject;

                GameObject appData;
                if(prefab != null) //if prefab exists, instantiate it into the scene
                {
                    appData = Instantiate(prefab);
                    appData.name = "AppData";
                }
                else //if not, create a new game object and add this class as a component
                {
                    appData = new GameObject("AppData");
                    appData.AddComponent<AppData>(); // awake is called here
                }

                instance = appData.GetComponent<AppData>(); //assign reference to gameobject
            }
            return instance;
        }
    }

    void Awake()
    {
        //check for duplicates in the scene
        Object[] appDatas = FindObjectsOfType(typeof(AppData));
        for(int i = 0; i < appDatas.Length; i++)
        {
            if (appDatas[i] != this) //destroy gameobjects that aren't this object
                Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    #endregion

    #region Globals

    //bool for active or wait in regards to ATB
    public bool ATB_Mode_Active = false;
    //amount of exp to level up
    public int EXP_To_Level_Up;
    //music used for normal battles
    public AudioClip BattleMusic;
    //music used for boss battles, add additional audio clips for other scenarios if necessary
    public AudioClip BossMusic;

    /*
    
    list of each type of magic in order to set the base power value
    list of regions in the game (either by scene or by trigger volume.  Scene will probably be easiest and make more sense)
    list of monster groups in the game  (each region would contain monster groups that appear in that region. monsters could be prefab or scriptable object, who knows atm)
    
    */

    //characters whose stats need to be kept up to date (current experiene, stat bonuses.  these are the characters that will be saved)
    //custom inspectors need creating for characters, appdata, and no doubt all other rpg classes
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;

    //fields to keep track of player location
    public Transform PlayerPosition;
    public Scene CurrentScene;

    //player inventory

    //progression flags
    
    #endregion

    #region Save/Load

    public void SaveGame()
    {

    }

    public void LoadGame()
    {

    }

    public void DeleteGame()
    {

    }

    /*
    each characters' total experience
    each characters' stat bonuses
    each characters' equipped equipment
    the current position and scene the player is in
    what is in the inventory
    current progression flags
    */

    #endregion

    #region Battle Alerts
    /*
    battle manager calls gui method ShowAlert, passing in a string for the alert text
    alert should auto disable after X seconds
    create list similar to turn list so multiple alerts can be queued?
    */
    #endregion

    #region Events
    /*

OnLevelUp, reevaluate stat curves for character

OnNewGame, set all stats and flags to default, load first scene

OnToBattleTransition
save scene and location in world
get enemy group based on region and random index
determine enemy level from party level
determine extra conditions (back attack/first strike etc)
determine if normal battle (boss battles cannot be escaped from)
get appropriate info such as music and screen transition to use
start music and play transition (any camera animations should be done OnEnable so they occur immediately on scene load)
all characters should be in an entering battle state (ATB cannot fill, preparing for battle animation)

OnBattleBegin
allow characters to fill ATB and enable UI components

OnBattleEnd
prevent ATB from filling
victory animations if winner
game over screen if loser
determine exp
play win music if applicable

OnFromBattleTransition
update characters to reflect end of last battle (statuses such as poison may be kept, character may have levelled up etc)
screen transition to previous location
*/
    #endregion
}