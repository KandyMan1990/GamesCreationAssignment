using UnityEngine;

public class EnemySelectButton : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private bool showSelector = false;

    public void SelectEnemy()
    {
        GameObject.Find("BattleManager").GetComponent<BattleStateMachine>().Input2(EnemyPrefab);
        ToggleSelector();
    }

    public void ToggleSelector()
    {
        showSelector = !showSelector;
        EnemyPrefab.transform.FindChild("Selector").gameObject.SetActive(showSelector);
    }
}