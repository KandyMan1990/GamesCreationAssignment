using UnityEngine;
using System.Collections;

public class EnemyStateMachine : MonoBehaviour
{
    public enum TurnState
    {
        PROCESSING,
        CHOOSEACTION,
        WAITING,
        ACTION,
        DEAD
    }

    public EnemyCharacter Enemy;
    public TurnState currentTurnState;
    public GameObject heroToAttack;
    public GameObject Selector;

    private float max_progress = 6f;
    private float currentProgress = 0f;
    private BattleStateMachine BSM;
    private Vector3 StartPosition;
    private bool actionStarted = false;
    private float animSpeed = 8f;


    void Start()
    {
        Selector.SetActive(false);
        currentProgress = Random.Range(0f, (max_progress * 0.25f));
        currentTurnState = TurnState.PROCESSING;
        StartPosition = transform.position;
        BSM = GameObject.Find("BattleManager").GetComponent<BattleStateMachine>();
    }

    void Update()
    {
        switch (currentTurnState)
        {
            case TurnState.PROCESSING:
                UpdateProgressBar();
                break;
            case TurnState.CHOOSEACTION:
                if(BSM.HerosInBattle.Count > 0)
                    ChooseAction();

                currentTurnState = TurnState.WAITING;
                break;
            case TurnState.WAITING:
                //idle
                break;
            case TurnState.ACTION:
                StartCoroutine(TimeForAction());
                break;
            case TurnState.DEAD:
                BSM.BattleState = BattleStateMachine.PerformAction.CHECKALIVE;
                break;
        }
    }

    void UpdateProgressBar()
    {
        currentProgress += Time.deltaTime;
        if (currentProgress >= max_progress)
        {
            currentTurnState = TurnState.CHOOSEACTION;
        }
    }

    void ChooseAction()
    {
        HandleTurn myAttack = new HandleTurn();
        myAttack.Attacker = Enemy.CharacterName;
        myAttack.Type = "Enemy";
        myAttack.AttackerGameObject = gameObject;
        myAttack.TargetGameObject = BSM.HerosInBattle[Random.Range(0, BSM.HerosInBattle.Count)];
        myAttack.ChosenAttack = Enemy.AttackList[Random.Range(0, Enemy.AttackList.Count)];

        BSM.CollectActions(myAttack);
    }

    IEnumerator TimeForAction()
    {
        if(actionStarted)
        {
            yield break;
        }

        actionStarted = true;

        Vector3 heroPosition = new Vector3(heroToAttack.transform.position.x - 1.5f, heroToAttack.transform.position.y, heroToAttack.transform.position.z);
        while(moveTowards(heroPosition))
        {
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        DoDamage();

        while (moveTowards(StartPosition))
        {
            yield return null;
        }

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

    void DoDamage()
    {
        int damage = 0;
        HeroStateMachine HSM = heroToAttack.GetComponent<HeroStateMachine>();
        BaseAttack Attack = BSM.PerformList[0].ChosenAttack;

        if (Attack.IsPhysical)
        {
            damage = Mathf.FloorToInt(Mathf.Pow(Enemy.physicalAttack, 2) / 16 + Enemy.physicalAttack);
            damage = Mathf.FloorToInt(damage * (265 / HSM.Player.physicalDefence) / 256);
            damage = Mathf.FloorToInt(damage * Attack.BaseAttackDamage / 16);
        }
        else
        {
            damage = Mathf.FloorToInt(Enemy.magicalAttack + Attack.BaseAttackDamage);
            damage = Mathf.FloorToInt(damage * (265 - HSM.Player.magicalDefence) / 4);
            damage = Mathf.FloorToInt(damage * Attack.BaseAttackDamage / 256);
        }

        //random modifier
        damage = Mathf.FloorToInt(damage * (Random.Range(0, 33) + 240) / 256);
        
        HSM.TakeDamage(damage);
    }

    public void TakeDamage(int damageAmount)
    {
        Enemy.currentHP -= damageAmount;

        if (Enemy.currentHP <= 0)
        {
            Enemy.currentHP = 0;
            BSM.RemoveEnemyFromBattle(gameObject);
            currentTurnState = TurnState.DEAD;
        }
    }
}