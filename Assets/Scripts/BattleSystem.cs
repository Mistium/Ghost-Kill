using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public Text playerHPtxt;
    public Text enemyHPtxt;
    public class Player
    {
        float maxHP;
        float HP;

        bool enemy;
        bool dead;

        public Player(int HPp, bool enemyp)
        {
            maxHP = HPp;
            HP = HPp;
            enemy = enemyp;
        }

        public bool isEnemy()
        {
            return enemy;
        }
        public bool isDead()
        {
            return dead;
        }
        public float getHP()
        {
            return HP;
        }
        public float getMaxHP()
        {
            return maxHP;
        }
        public void setDead(bool value) 
        { 
            dead = value; 
        }

        public void changeHP(int amount)
        {
            HP += amount;
            Mathf.Clamp(HP, 0, maxHP);
        }
    }


    public Player[] characters = new Player[10];

    int charNum = 2;
    int turn = 0;   

    // Start is called before the first frame update
    void Start()
    {
        characters[0] = new Player(10, false);
        characters[1] = new Player(5, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (characters[turn].isEnemy())
        {
            
        }
    }

    public IEnumerator Attack(int target) 
    {
        changeHP(1);

        turn++;
        if (turn > charNum) { turn = 0; }
    }
}
