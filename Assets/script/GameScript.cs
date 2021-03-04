using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public int turn;
    public int turncounter;
    public GameObject[] turnicon;
    public Sprite[] playericon;
    public Button[] spaceicon;
    public int[] PositionTrack;
    public GameObject[] winline;
    public GameObject winingpanel;
    public int Xscore = 0;
    public int Oscore = 0;
    public Text Xscoretxt;
    public Text Oscoretxt;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        turn = 0;
        turncounter = 0;
        turnicon[0].SetActive(true);
        turnicon[1].SetActive(false);
        for (int i = 0; i < spaceicon.Length; i++)
        {
            spaceicon[i].interactable = true;
            spaceicon[i].GetComponent<Image>().sprite = null;
        }
        for (int i = 0; i < PositionTrack.Length; i++)
        {
            PositionTrack[i] = -100;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GridButtons(int ButtonNumber)
    {
        spaceicon[ButtonNumber].image.sprite = playericon[turn];
        spaceicon[ButtonNumber].interactable = false;

        PositionTrack[ButtonNumber] = turn+1;
        turncounter++;
        if (turncounter > 4)
        {
            winner();
        }

        if(turn == 0)
        {
            turn = 1;
            turnicon[0].SetActive(false);
            turnicon[1].SetActive(true);
        }
        else if(turn == 1)
        {
            turn = 0;
            turnicon[0].SetActive(true);
            turnicon[1].SetActive(false);
        }
    }

    void winner()
    {
        int s1 = PositionTrack[0] + PositionTrack[1] + PositionTrack[2];
        int s2 = PositionTrack[3] + PositionTrack[4] + PositionTrack[5];
        int s3 = PositionTrack[6] + PositionTrack[7] + PositionTrack[8];
        int s4 = PositionTrack[0] + PositionTrack[3] + PositionTrack[6];
        int s5 = PositionTrack[1] + PositionTrack[4] + PositionTrack[7];
        int s6 = PositionTrack[2] + PositionTrack[5] + PositionTrack[8];
        int s7 = PositionTrack[0] + PositionTrack[4] + PositionTrack[8];
        int s8 = PositionTrack[2] + PositionTrack[4] + PositionTrack[6];
        var solution = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for(int i=0; i<solution.Length; i++)
        {
            if(solution[i]== (3 * (turn + 1)))
            {
                if(turn == 0)
                {
                    Xscore++;
                    Xscoretxt.text = Xscore.ToString();
                    winline[i].SetActive(true);

                }
                else
                {
                    Oscore++;
                    Oscoretxt.text = Oscore.ToString();
                    winline[i].SetActive(true);
                }
               // winline[i].SetActive(true);
                winingpanel.SetActive(true);
                //Rematch();
                break;
            }

        }
    }

    public void Rematch()
    {
        StartGame();
        for(int i = 0; i < winline.Length; i++)
        {
            winline[i].SetActive(false);
        }
        winingpanel.SetActive(false);
    }
    public void ReStart()
    {
        Rematch();
        Xscore = 0;
        Oscore = 0;
        Xscoretxt.text = Xscore.ToString();
        Oscoretxt.text = Oscore.ToString();

    }
}
