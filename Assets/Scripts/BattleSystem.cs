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
            if (HP == 0) { dead = true; }
        }
    }


    public Player[] characters = new Player[10];

    int playerNum;
    int enemyNum;
    int charNum;
    public int turn = 0;
    bool turnDone = true;
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
        charNum = playerNum + enemyNum;

        updateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        if (characters[turn].isEnemy() && turnDone && !characters[turn].isDead())
        {
            StartCoroutine(Attack(0));
        }
    }

    public IEnumerator Attack(int target) 
    {
        if (turnDone)
        {
            turnDone = false;
            Debug.Log("Clicky");
            characters[target].changeHP(-1);
            yield return new WaitForSeconds(0.5f);
            turn++;
            if (turn > charNum - 1) { turn = 0; }

            updateTexts();
            turnDone = true;
        }
        
    }

    public void updateTexts()
    {   
        if (characters[0].isDead()) { playerHPtxt.SetText("Player Dead"); } 
        else { playerHPtxt.SetText("Player HP: " + characters[0].getHP()); }

        if (characters[1].isDead()) { enemyHPtxt.SetText("Enemy Dead" ); }
        else { enemyHPtxt.SetText("Enemy HP: " + characters[1].getHP()); }
    }

}
