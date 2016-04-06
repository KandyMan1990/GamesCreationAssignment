[System.Serializable]
public class BasePhysicalAttackStat : BaseStat
{
    public BasePhysicalAttackStat()
    {
        StatName = "Physical Attack";
        StatDescription = "Directly modifies the characters' physical attack stat";
        StatType = StatTypes.PHYATK;
        StatBaseValue = 0;
        StatModifiedValue = 0;
    }
}