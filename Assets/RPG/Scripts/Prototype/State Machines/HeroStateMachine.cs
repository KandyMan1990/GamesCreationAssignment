using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroStateMachine : MonoBehaviour
{
    public enum TurnState
    {
        PROCESSING,
        ADDTOLIST,
        WAITING,
        ACTION,
        DEAD
    }

    public PlayerCharacter Player;
    public TurnState currentTurnState;
    public GameObject Selector;
    public GameObject EnemyToAttack;
    public GameObject HeroPanel;

    private float max_progress = 5f;
    private float currentProgress = 0f;
    private BattleStateMachine BSM;
    private bool actionStarted = false;
    private Vector3 StartPosition;
    private float animSpeed = 8f;
    private bool isAlive = true;
    private Image ProgressBar;
    private HeroPanelStats panelStats;
    private Transform heroPanelSpacer;
    
    void Start()
    {
        heroPanelSpacer = GameObject.Find("BattleCanvas").transform.FindChild("HeroPanel").FindChild("HeroPanelSpacer");
        CreateHeroPanel();
        StartPosition = transform.position;
        currentProgress = Random.Range(0f, (max_progress * 0.25f));
        Selector.SetActive(false);
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
        currentTurnState = TurnState.PROCESSING;
    }

    void Update()
    {
        switch (currentTurnState)
        {
            case TurnState.PROCESSING:
                UpdateProgressBar();
                break;
            case TurnState.ADDTOLIST:
                BSM.HerosToManage.Add(gameObject);
                currentTurnState = TurnState.WAITING;
                break;
            case TurnState.WAITING:
                //idle
                break;
            case TurnState.ACTION:
                StartCoroutine(TimeForAction());
                break;
            case TurnState.DEAD:
                if (!isAlive)
                    return;
                else
                {
                    currentProgress = 0f;
                    gameObject.tag = "DeadHero";                                                                    //change tag
                    BSM.HerosInBattle.Remove(gameObject);                                                           //not attackable
                    BSM.HerosToManage.Remove(gameObject);                                                           //not manageable
                    Selector.SetActive(false);                                                                      //deactivate selector
                    BSM.ActionPanel.SetActive(false);                                                               //deactivate gui
                    BSM.EnemySelectPanel.SetActive(false);                                                          //deactivate gui
                    for(int i = 0; i < BSM.PerformList.Count; i++)                                                  //remove from performlist
                    {
                        if (BSM.PerformList[i].AttackerGameObject == gameObject)
                            BSM.PerformList.Remove(BSM.PerformList[i]);
                    }
                    gameObject.GetComponent<MeshRenderer>().material.color = new Color(0.4f, 0.4f, 0.4f, 1f);       //change colour / play animation
                    BSM.BattleState = BattleStateMachine.PerformAction.CHECKALIVE;                                            //reset input

                    isAlive = false;
                }
                break;
        }
    }

    void UpdateProgressBar()
    {
        currentProgress += Time.deltaTime;
        ProgressBar.fillAmount = Mathf.Clamp(currentProgress / max_progress, 0f, 1f);
        if (currentProgress >= max_progress)
        {
            currentTurnState = TurnState.ADDTOLIST;
        }
    }

    IEnumerator TimeForAction()
    {
        if (actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        Vector3 enemyPosition = new Vector3(EnemyToAttack.transform.position.x + 1.5f, EnemyToAttack.transform.position.y, EnemyToAttack.transform.position.z);
        while (moveTowards(enemyPosition))
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        DoDamage();

        while (moveTowards(StartPosition))
        {
            yield return null;
        }

        if(BSM.PerformList.Count > 0)
            BSM.PerformList.RemoveAt(0);

        BSM.BattleState = BattleStateMachine.PerformAction.WAIT;

        actionStarted = false;
        currentProgress = 0f;
        currentTurnState = TurnState.PROCESSING;
    }

    bool moveTowards(Vector3 target)
    {
        return target != (transform.position = Vector3.MoveTowards(transform.position, target, animSpeed * Time.deltaTime));
    }

    public void TakeDamage(int damageAmount)
    {
        Player.currentHP -= damageAmount;

        if(Player.currentHP <= 0)
        {
            Player.currentHP = 0;
            currentTurnState = TurnState.DEAD;
        }

        UpdateHeroPanel();
    }

    void DoDamage()
    {
        int damage = 0;
        EnemyStateMachine ESM = EnemyToAttack.GetComponent<EnemyStateMachine>();
        BaseAttack Attack = BSM.PerformList[0].ChosenAttack;

        if (Attack.IsPhysical)
        {
            damage = Mathf.FloorToInt(Mathf.Pow(Player.physicalAttack, 2) / 16 + Player.physicalAttack);
            damage = Mathf.FloorToInt(damage * (265 / ESM.Enemy.physicalDefence) / 256);
            damage = Mathf.FloorToInt(damage * Attack.BaseAttackDamage / 16);
        }
        else
        {
            damage = Mathf.FloorToInt(Player.magicalAttack + Attack.BaseAttackDamage);
            damage = Mathf.FloorToInt(damage * (265 - ESM.Enemy.magicalDefence) / 4);
            damage = Mathf.FloorToInt(damage * Attack.BaseAttackDamage / 256);
        }

        //random modifier
        damage = Mathf.FloorToInt(damage * (Random.Range(0, 33) + 240) / 256);

        ESM.TakeDamage(damage);
    }

    void CreateHeroPanel()
    {
        HeroPanel = Instantiate(HeroPanel) as GameObject;
        panelStats = HeroPanel.GetComponent<HeroPanelStats>();
        panelStats.HeroName.text = Player.CharacterName;
        panelStats.HeroHP.text = Player.HPtoString;
        ProgressBar = panelStats.HeroProgressBar;
        HeroPanel.transform.SetParent(heroPanelSpacer, false);
    }

    void UpdateHeroPanel()
    {
        panelStats.HeroHP.text = Player.HPtoString;
    }
}