using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class BattleStateMachine : MonoBehaviour
{
    public enum PerformAction
    {
        WAIT,
        TAKEACTION,
        PERFORMACTION,
        CHECKALIVE,
        WIN,
        LOSE
    }

    public enum HeroGUI
    {
        ACTIVATE,
        WAITING,
        INPUT1,
        INPUT2,
        DONE
    }

    public PerformAction BattleState;
    public HeroGUI HeroInput;
    public List<HandleTurn> PerformList = new List<HandleTurn>();
    public List<GameObject> HerosInBattle = new List<GameObject>();
    public List<GameObject> EnemiesInBattle = new List<GameObject>();
    public List<GameObject> HerosToManage = new List<GameObject>();
    public GameObject enemyButton;
    public Transform EnemySelectSpacer;
    public Transform ActionSpacer;
    public Transform MagicSpacer;
    public GameObject ActionPanel;
    public GameObject EnemySelectPanel;
    public GameObject MagicPanel;
    public GameObject ActionButton;
    public GameObject MagicButton;
    public List<GameObject> ActionButtons = new List<GameObject>();

    private HandleTurn HerosChoice;
    private AudioSource Audio;
    private bool canPlayHighlightSound = true;
    private WaitForSeconds highlightWaitTime = new WaitForSeconds(0.1f);

    // Use this for initialization
    void Start()
    {
        BattleState = PerformAction.WAIT;
        EnemiesInBattle.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        HerosInBattle.AddRange(GameObject.FindGameObjectsWithTag("Hero"));
        HeroInput = HeroGUI.ACTIVATE;

        ActionPanel.SetActive(false);
        EnemySelectPanel.SetActive(false);
        MagicPanel.SetActive(false);

       // EnemyButtons();
        Audio = GetComponent<AudioSource>();

        Audio.PlayOneShot(GameManager.Instance.System_DB.BattleStartSFX);
        IntroloopPlayer.Instance.Play(GameManager.Instance.System_DB.BattleMusic);
    }

    // Update is called once per frame
    void Update()
    {
        switch (BattleState)
        {
            case PerformAction.WAIT:
                if (PerformList.Count > 0)
                {
                    BattleState = PerformAction.TAKEACTION;
                }
                break;
            case PerformAction.TAKEACTION:
                GameObject performer = GameObject.Find(PerformList[0].Attacker);
                if (PerformList[0].Type == "Enemy")
                {
                    EnemyStateMachine ESM = performer.GetComponent<EnemyStateMachine>();
                    for (int i = 0; i < HerosInBattle.Count; i++)
                    {
                        if (PerformList[0].TargetGameObject == HerosInBattle[i])
                        {
                            ESM.heroToAttack = PerformList[0].TargetGameObject;
                            ESM.currentTurnState = EnemyStateMachine.TurnState.ACTION;
                            break;
                        }
                        else
                        {
                            PerformList[0].TargetGameObject = HerosInBattle[Random.Range(0, HerosInBattle.Count)];
                            ESM.heroToAttack = PerformList[0].TargetGameObject;
                            ESM.currentTurnState = EnemyStateMachine.TurnState.ACTION;
                        }
                    }
                }

                if (PerformList[0].Type == "Hero")
                {
                    HeroStateMachine HSM = performer.GetComponent<HeroStateMachine>();
                    HSM.EnemyToAttack = PerformList[0].TargetGameObject;
                    HSM.currentTurnState = HeroStateMachine.TurnState.ACTION;
                }

                BattleState = PerformAction.PERFORMACTION;
                break;
            case PerformAction.PERFORMACTION:
                //idle
                break;
            case PerformAction.CHECKALIVE:
                if(HerosInBattle.Count < 1)
                {
                    BattleState = PerformAction.LOSE;
                }
                else if(EnemiesInBattle.Count < 1)
                {
                    BattleState = PerformAction.WIN;
                }
                else
                {
                    ClearAttackPanel();
                    HeroInput = HeroGUI.ACTIVATE;
                }
                break;
            case PerformAction.WIN:

                break;
            case PerformAction.LOSE:

                break;
        }

        switch (HeroInput)
        {
            case HeroGUI.ACTIVATE:
                if (HerosToManage.Count > 0)
                {
                    HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive(true);
                    HerosChoice = new HandleTurn();
                    ActionPanel.SetActive(true);
                    CreateActionButtons();
                    HeroInput = HeroGUI.WAITING;
                }
                break;
            case HeroGUI.WAITING:

                break;
            case HeroGUI.INPUT1:

                break;
            case HeroGUI.INPUT2:

                break;
            case HeroGUI.DONE:
                HeroInputDone();
                break;
        }
    }

    public void CollectActions(HandleTurn input)
    {
        PerformList.Add(input);
    }

    void EnemyButtons()
    {
        foreach (Transform child in EnemySelectSpacer.transform)
        {
            Destroy(child.gameObject);
        }
        
        foreach (GameObject enemy in EnemiesInBattle)
        {
            GameObject newButton = Instantiate(enemyButton) as GameObject;
            EnemySelectButton button = newButton.GetComponent<EnemySelectButton>();

            EnemyStateMachine currentEnemy = enemy.GetComponent<EnemyStateMachine>();

            Text buttonText = newButton.GetComponentInChildren<Text>();
            buttonText.text = currentEnemy.Enemy.CharacterName;

            button.EnemyPrefab = enemy;

            newButton.transform.SetParent(EnemySelectSpacer, false);
        }
    }

    public void Input1()//attack button
    {
        EnemyButtons();
        HerosChoice.Attacker = HerosToManage[0].name;
        HerosChoice.AttackerGameObject = HerosToManage[0];
        HerosChoice.Type = "Hero";
        HerosChoice.ChosenAttack = HerosToManage[0].GetComponent<HeroStateMachine>().Player.AttackList[0];
        ActionPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    public void Input2(GameObject chosenEnemy)//enemy selection
    {
        HerosChoice.TargetGameObject = chosenEnemy;
        HeroInput = HeroGUI.DONE;
    }

    public void Input3()//switch to magic attacks
    {
        ActionPanel.SetActive(false);
        MagicPanel.SetActive(true);
    }

    public void Input4(BaseAttack chosenMagic)//chosen magic attack
    {

        EnemyButtons();
        HerosChoice.Attacker = HerosToManage[0].name;
        HerosChoice.AttackerGameObject = HerosToManage[0];
        HerosChoice.Type = "Hero";

        HerosChoice.ChosenAttack = chosenMagic;
        MagicPanel.SetActive(false);
        EnemySelectPanel.SetActive(true);
    }

    void HeroInputDone()
    {
        PerformList.Add(HerosChoice);

        ClearAttackPanel();

        HerosToManage[0].transform.FindChild("Selector").gameObject.SetActive(false);
        HerosToManage.RemoveAt(0);
        HeroInput = HeroGUI.ACTIVATE;
    }

    void ClearAttackPanel()
    {
        EnemySelectPanel.SetActive(false);
        ActionPanel.SetActive(false);
        MagicPanel.SetActive(false);
        foreach (GameObject btn in ActionButtons)
        {
            Destroy(btn);
        }
        ActionButtons.Clear();
    }

    void CreateActionButtons()
    {
        GameObject AttackButton = Instantiate(ActionButton) as GameObject;
        Text AttackButtonText = AttackButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
        AttackButtonText.text = "Attack";
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Input1());
        //
        AttackButton.transform.SetParent(ActionSpacer, false);
        ActionButtons.Add(AttackButton);

        GameObject MagicSelectButton = Instantiate(ActionButton) as GameObject;
        MagicSelectButton.GetComponent<Button>().interactable = false;
        Text MagicButtonText = MagicSelectButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
        MagicButtonText.text = "Magic";
        MagicSelectButton.GetComponent<Button>().onClick.AddListener(() => Input3());
        MagicSelectButton.transform.SetParent(ActionSpacer, false);
        ActionButtons.Add(MagicSelectButton);

        if (HerosToManage[0].GetComponent<HeroStateMachine>().Player.MagicAttacks.Count > 0)
        {
            MagicSelectButton.GetComponent<Button>().interactable = true;

            foreach (BaseAttack magic in HerosToManage[0].GetComponent<HeroStateMachine>().Player.MagicAttacks)
            {
                GameObject SpellButton = Instantiate(MagicButton) as GameObject;
                Text SpellButtonText = SpellButton.transform.FindChild("Text").gameObject.GetComponent<Text>();
                SpellButtonText.text = magic.AttackName;
                MagicAttackButton btn = SpellButton.GetComponent<MagicAttackButton>();
                btn.MagicAttackToPerform = magic;
                SpellButton.transform.SetParent(MagicSpacer, false);
                ActionButtons.Add(SpellButton);
            }
        }
    }

    public void PlaySound(AudioClip sfx)
    {
        if (sfx == GameManager.Instance.System_DB.CursorSFX && !canPlayHighlightSound)
            return;

        StartCoroutine(ToggleCanPlayHighlightSound());
        Audio.PlayOneShot(sfx);
    }

    IEnumerator ToggleCanPlayHighlightSound()
    {
        canPlayHighlightSound = !canPlayHighlightSound;
        yield return highlightWaitTime;
        canPlayHighlightSound = !canPlayHighlightSound;
    }

    public void RemoveEnemyFromList(GameObject Enemy)
    {
        EnemiesInBattle.Remove(Enemy);
    }
}