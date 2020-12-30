using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private static int[] deck = new int[120];
    private static int[] p1 = new int[30];
    private static int[] p1_add = new int[30];
    private static int[] p2 = new int[30];
    private static int[] p2_add = new int[30];
    private static int[] p3 = new int[30];
    private static int[] p3_add = new int[30];
    private static int[] p4 = new int[30];
    private static int[] p4_add = new int[30];
    private static int[] tumb = new int[30];
    private static int deck_pointer;
    private static int turn_flag;
    private static int game_over;
    private static int peng_flag;
    

    // Start is called before the first frame update
    void Start()
    {
        turn_flag = 1;
        deck_pointer = 0;
        game_over = 0;
        for(int i = 0; i < p1.Length; i++)
        {
            p1[i] = 1000;
        }
        for (int i = 0; i < p2.Length; i++)
        {
            p2[i] = 1000;
        }
        for (int i = 0; i < p3.Length; i++)
        {
            p3[i] = 1000;
        }
        for (int i = 0; i < p4.Length; i++)
        {
            p4[i] = 1000;
        }
    }

    int peng_gang_judge(int card)
    {
        int flag = 0;
        int hu_able = 0;

        /*判胡*/

        if (p1[card] == 3 && hu_able !=0)
        {
            /*用户输入 碰or杠， 碰则flag置1 杠则flag置2*/

            if (flag == 1)
            {
                p1[card] = p1[card] - 2;
                p1_add[card] = p1_add[card] + 3;
                turn_flag = 1;
                peng_flag = 1;
                /*碰动画*/

                return 0;
            }

            else if (flag == 2)
            {
                p1[card] = p1[card] - 3;
                p1_add[card] = p1_add[card] + 4;
                turn_flag = 1;
                peng_flag = 0;
                /*杠动画*/

                return 0;
            }

            else
            {
                tumb[card]++;
                turn_flag++;
                if (turn_flag == 5)
                {
                    turn_flag = 1;
                }
                return 0;
            }
        }
        else if (p1[card] == 2)
        {
            /*用户输入 碰,选择碰则flag置1*/

            if(flag == 1)
            {
                p1[card] = p1[card] - 2;
                p1_add[card] = p1_add[card] + 3;
                turn_flag = 1;
                peng_flag = 1;
                /*碰动画*/

                return 0;
            }
            else
            {
                tumb[card]++;
                turn_flag++;
                if(turn_flag == 5)
                {
                    turn_flag = 1;
                }
                return 0;
            }
        }
        return 0;
        
    }

    void Begin_sig(int rev)
    {
        int i, j, temp;
        int hu_flag = 0;

        print("start signal rev");

        for( i = 0; i < deck.Length; i++)
        {
            deck[i] = i;
        }
        for( i = 0; i < deck.Length - 1; i++)
        {
            j = UnityEngine.Random.Range(i, 120 - i + 1);
            temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
        print("shuffle done");

        for (i = 0; i < 13; i++)
        {
            temp = deck[deck_pointer] / 4;
            p1[temp]++;
            deck_pointer++;
        }
        for (i = 0; i < 13; i++)
        {
            temp = deck[deck_pointer] / 4;
            p2[temp]++;
            deck_pointer++;
        }
        for (i = 0; i < 13; i++)
        {
            temp = deck[deck_pointer] / 4;
            p3[temp]++;
            deck_pointer++;
        }
        for (i = 0; i < 13; i++)
        {
            temp = deck[deck_pointer] / 4;
            p4[temp]++;
            deck_pointer++;
        }
        print("card dealt");

        /*发牌动画*/
        print("deal begin");

        while (true)
        {
            switch (turn_flag)
            {
                case 1:
                    if(peng_flag == 0)
                    {
                        temp = deck[deck_pointer] / 4;
                        p1[temp]++;
                        deck_pointer++;
                        /*判断自摸*/
                        //hu_flag = 1;
                    }
                    peng_flag = 0;
                    /*等待用户输入*/
                    //p1[sel]--;

                    /*出牌动画*/
                    //tomb[sel]++;

                    /*AI 彭杠胡 (option)*/

                    if (deck_pointer == 120)
                    {
                        print("draw");
                        /*打平动画*/

                        game_over = 1;
                    }
                    turn_flag++;
                    break;
                case 2:
                    temp = deck[deck_pointer] / 4;
                    p2[temp]++;
                    deck_pointer++;
                    /*AI自摸*/

                    for (i = 0; i < 30; i++)
                    {
                        if(p2[i] > 0) //有待改进的ai出牌逻辑
                        {
                            /*出牌动画*/

                            hu_flag = peng_gang_judge(i);
                            break;
                        }
                    }
                    if (deck_pointer == 120)
                    {
                        print("draw");
                        /*打平动画*/

                        game_over = 1;
                    }
                    break;
                case 3:
                    temp = deck[deck_pointer] / 4;
                    p3[temp]++;
                    deck_pointer++;
                    /*AI自摸*/

                    for (i = 0; i < 30; i++)
                    {
                        if (p3[i] > 0) //有待改进的ai出牌逻辑
                        {
                            /*出牌动画*/

                            hu_flag = peng_gang_judge(i);
                            break;
                        }
                    }
                    if (deck_pointer == 120)
                    {
                        print("draw");
                        /*打平动画*/

                        game_over = 1;
                    }
                    break;
                case 4:
                    temp = deck[deck_pointer] / 4;
                    p4[temp]++;
                    deck_pointer++;
                    /*AI自摸*/

                    for (i = 0; i < 30; i++)
                    {
                        if (p4[i] > 0) //有待改进的ai出牌逻辑
                        {
                            /*出牌动画*/

                            hu_flag = peng_gang_judge(i);
                            break;
                        }
                    }
                    if (deck_pointer == 120)
                    {
                        print("draw");
                        /*打平动画*/

                        game_over = 1;
                    }
                    break;


            }
            if(hu_flag == 1 || game_over == 1)
            {
                break;
                /*结束动画*/

                /*算番*/

            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
