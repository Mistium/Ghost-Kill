using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystem : MonoBehaviour
{
    public TMP_Text playerHPtxt;
    public TMP_Text enemyHPtxt;

    public static BattleSystem Instance;
    public class Player
    {
        string name;

        float maxHP;
        float HP;

        bool enemy;
        bool dead;

        public Player(int HPp, bool enemyp, string namep)
        {
            name = namep;
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

    int playerNum;
    int enemyNum;
    int turn = 0;
    int[] turnIDs = new int[5];
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        characters[0] = new Player(10, false, "Player");
        turnIDs[0] = 0;
        characters[1] = new Player(5, true, "Enemy1");
        turnIDs[1] = 1;

        playerNum = 1;
        enemyNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (characters[turn].isEnemy())
        {
            Attack(0);
        }
    }

    public IEnumerator Attack(int target) 
    {
        Debug.Log("Clicky");
        characters[target].changeHP(1);
        yield return new WaitForSeconds(0.5f);
        turn++;
        if (turn > playerNum + enemyNum) { turn = 0; }

        updateTexts();
    }

    public void updateTexts()
    {   
        if (characters[turn].isDead()) { playerHPtxt.SetText("Player HP: d"); } 
        else { playerHPtxt.SetText("Player HP: " + characters[0].getHP()); }

        if (characters[turn].isDead()) { enemyHPtxt.SetText("Enemy HP: d" ); }
        else { playerHPtxt.SetText("Enemy HP: " + characters[0].getHP()); }
    }

}
