using UnityEngine;

public class AlexAttributes : CharAttributes {

   public EnemyAttributes enemyAtt;

    public bool enemyDefeated;

    public bool isAttacking;

    public bool isDefending;

    public bool alexKinesis;

    public bool alexResting;

    // Use this for initialization
    void Start ()
    {
      //  curHealth = maxHealth;
      //  curKinetic = maxKinetic;
        
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   public void OnTriggerEnter(Collider _other)
    {
        if (isAttacking == true)
        {

            if (_other.tag == "Enemy")
            {
                enemyAtt.curHealth = enemyAtt.curHealth - attack;
                Debug.Log("Hit!");
                isAttacking = false;
                if (enemyAtt.curHealth <= 0)
                {
                    enemyDefeated = true;
                    Debug.Log("Enemy Defeated!");
                }
            }
        }

        if (alexKinesis == true)
        {
            if (enemyAtt.enemyDefending == true && _other.tag == "Enemy")
            {
                float tempAttack = kineticAttack - enemyAtt.defense;
                enemyAtt.curHealth = enemyAtt.curHealth - tempAttack;

                curKinetic = curKinetic - 25f;
                alexKinesis = false;
            }

            if (_other.tag == "Enemy" && enemyAtt.enemyDefending == false)
            {
                enemyAtt.curHealth = enemyAtt.curHealth - kineticAttack;
                curKinetic = curKinetic - 25f;
                alexKinesis = false;
            }
        }
    }


    public void Rest()
    {
       if (alexResting == true)
      {
         curHealth = curHealth + restHamt;
         curKinetic = curKinetic + restKamt;
         alexResting = false;

            if(curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }

            if(curKinetic > maxKinetic)
            {
                curKinetic = maxKinetic;
            }
        
      }
    }



}
