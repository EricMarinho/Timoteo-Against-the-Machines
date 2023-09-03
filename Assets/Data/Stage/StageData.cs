using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "StageData", order = 1)]
public class StageData : ScriptableObject
{
    public MinMax objectActivationTime;
    public float speedModifier;
    public float speedByDamageModifier;
}