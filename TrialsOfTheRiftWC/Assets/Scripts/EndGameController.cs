using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Rewired;

public class EndGameController : MonoBehaviour {

    [SerializeField] private GameObject go_menu;
    [SerializeField] private Button butt_select;

    [SerializeField] Rewired.Integration.UnityUI.RewiredStandaloneInputModule rsim;


    private int[] i_hatNums;
    private Constants.Global.Color[] col_playerColors;
    [SerializeField] private SkinnedMeshRenderer[] smr_winnerOutfit = new SkinnedMeshRenderer[2];
    [SerializeField] private SkinnedMeshRenderer[] smr_winnerHat = new SkinnedMeshRenderer[8];
    [SerializeField] private SkinnedMeshRenderer[] smr_loserOutfit = new SkinnedMeshRenderer[2];
    [SerializeField] private SkinnedMeshRenderer[] smr_loserHat = new SkinnedMeshRenderer[8];
    private Material mat_blue;
    private Material mat_red;

    private Player p_player;
    private bool b_open = false;

    // Use this for initialization
    void Start () {
        //Only player 1 does things on this menu.
        p_player = ReInput.players.GetPlayer(0);
        rsim.RewiredPlayerIds = new int[] { 0 };

        //Setup the models here.
        col_playerColors[0] = Constants.PlayerStats.C_p1Color;
        col_playerColors[1] = Constants.PlayerStats.C_p2Color;
        col_playerColors[2] = Constants.PlayerStats.C_p3Color;
        col_playerColors[3] = Constants.PlayerStats.C_p4Color;

        i_hatNums[0] = Constants.PlayerStats.C_p1Hat;
        i_hatNums[1] = Constants.PlayerStats.C_p2Hat;
        i_hatNums[2] = Constants.PlayerStats.C_p3Hat;
        i_hatNums[3] = Constants.PlayerStats.C_p4Hat;

        //Activate the correct hat.
        int winnerCounter = 0;
        int loserCounter = 0;
        for (int i = 0; i < 4; i++) {
            if (col_playerColors[i] == Constants.Global.C_WinningTeam) {
                if (col_playerColors[i] == Constants.Global.Color.BLUE) {
                    smr_winnerOutfit[winnerCounter].materials = new Material[] { mat_blue };
                    smr_winnerHat[(4 * winnerCounter) + i_hatNums[i]].materials = new Material[] { mat_blue };
                    smr_winnerHat[(4 * winnerCounter) + i_hatNums[i]].gameObject.SetActive(true);
                } else  {
                    smr_winnerOutfit[winnerCounter].materials = new Material[] { mat_red };
                    smr_winnerHat[(4 * winnerCounter) + i_hatNums[i]].materials = new Material[] { mat_red };
                    smr_winnerHat[(4 * winnerCounter) + i_hatNums[i]].gameObject.SetActive(true);
                }
                winnerCounter++;
            } else {
                if (col_playerColors[i] == Constants.Global.Color.BLUE) {
                    smr_loserOutfit[loserCounter].materials = new Material[] { mat_blue };
                    smr_loserHat[(4 * loserCounter) + i_hatNums[i]].materials = new Material[] { mat_blue };
                    smr_loserHat[(4 * loserCounter) + i_hatNums[i]].gameObject.SetActive(true);
                } else {
                    smr_loserOutfit[loserCounter].materials = new Material[] { mat_red };
                    smr_loserHat[(4 * loserCounter) + i_hatNums[i]].materials = new Material[] { mat_red };
                    smr_loserHat[(4 * loserCounter) + i_hatNums[i]].gameObject.SetActive(true);
                }
                loserCounter++;
            }
        }


        // Need to know the winning team's color and the hats used on the players on said team.
        // Hats are in Constants. might as well add the winners as a variable in Constants as well.

    }
	
	// Update is called once per frame
	void Update () {
        //Listen for P1 hitting A.
        //Then do menu things.
        if (p_player.GetButton("UISubmit") && b_open == false) {
            OpenEndMenu();
        }
	}

    void OpenEndMenu() {
        go_menu.SetActive(true);
        butt_select.Select();
        b_open = true;
    }

    void MainMenu() {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    void Rematch() {
        SceneManager.LoadSceneAsync("BuildSetUp");
    }

    void PlayerSelect() {
        SceneManager.LoadSceneAsync("RegisterPlayers");
    }

    void Quit() {
        Application.Quit();
    }
}
