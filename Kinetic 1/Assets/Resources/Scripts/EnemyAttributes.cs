using UnityEngine;

public class EnemyAttributes : MonoBehaviour {

    public AlexAttributes alexAtt;


    public float curHealth;
    public float maxHealth;
    public float curKinetic;
    public float maxKinetic;
    public float restHamt;
    public float restKamt;
    public float attack;
    public float kineticDefense;
    public float defense;

    public bool enemyAttacking;

    public bool enemyKinesis;

    public bool enemyDefending;

    public bool enemyResting;


    public void OnTriggerEnter (Collider _other)
    {
        if (enemyAttacking == true)
        {
            if (alexAtt.isDefending == true && _other.tag == "Player")
            {
                float tempAttack = attack - alexAtt.defense;
                //attack =  attack - alexAtt.defense;

                alexAtt.curHealth = alexAtt.curHealth - tempAttack;
            }

            if (_other.tag == "Player" && alexAtt.isDefending == false)
            {
                alexAtt.curHealth = alexAtt.curHealth - attack;
            }
        }

        if (enemyKinesis == true)
        {
            if (alexAtt.isDefending == true && _other.tag == "Player")
            {
                float tempAttack = kineticDefense - alexAtt.defense;
                alexAtt.curHealth = alexAtt.curHealth - tempAttack;
                curKinetic = curKinetic - 35f;
            }

            if (_other.tag == "Player" && alexAtt.isDefending == false)
            {
                alexAtt.curHealth = alexAtt.curHealth - kineticDefense;
                curKinetic = curKinetic - 35f;

            }
        }
       
    }








    public void AdjHealth(float _amt)
    {
        if (_amt < 0)
        {
            float temp = _amt + defense;
            if (temp >= 0)
            {
                return;
            }
            else
            {
                curHealth += temp;
            }
        }
        else
        {
            curHealth += _amt;
        }

    }

    public void Rest()
    {
        if (enemyResting == true)
        {
            curHealth += restHamt;
            curKinetic += restKamt;
        }
     }
}
