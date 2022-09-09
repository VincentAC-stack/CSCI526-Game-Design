using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float healthPoints = 50.0f;
    public float maxHealthPoints = 100.0f;

    virtual public void CharacterDie()
    {
        Destroy(gameObject);
    }

    virtual public IEnumerable TakeDamage(float damageAmount, float interval)
    {
        while (true)
        {
            healthPoints -= damageAmount;
            if (healthPoints <= float.Epsilon)
            {
                CharacterDie();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }
}
