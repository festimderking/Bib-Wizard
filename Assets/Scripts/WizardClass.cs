
using UnityEngine;
[CreateAssetMenu(menuName ="ScriptableObjects/Class")]
public class WizardClass : ScriptableObject
{
    public int maxMana = 100;	
    public int maxHealth = 100;

    public float mana = 100f;
    public float health = 100f;

    public float movementspeed = 5f;

    WizardClass() {
        mana = maxMana;
        health = maxHealth;
    }
    public float HealthPercentage(){
        return health / maxHealth;
    }
}
