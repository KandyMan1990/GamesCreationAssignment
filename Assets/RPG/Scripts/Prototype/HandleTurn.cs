using UnityEngine;

[System.Serializable]
public class HandleTurn
{
    public string Attacker;
    public string Type;
    public GameObject AttackerGameObject;
    public GameObject TargetGameObject;
    public BaseAttack ChosenAttack;
}