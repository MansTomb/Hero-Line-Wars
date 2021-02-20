using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Data/New Unit")]
public class UnitSO : ScriptableObject
{
    public GameObject prefab;
    
    public float health;
    public float mana;

    public float moveSpeed;
}
