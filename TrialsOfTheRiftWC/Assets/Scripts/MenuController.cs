﻿/* MenuController.cs - Sam C
 * 
 * Desc: Controls the main menu and passes volume options to the main scene.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Rewired;

public class MenuController : MonoBehaviour {

    [SerializeField]GameObject go_options;
    [SerializeField]GameObject go_mainMenu;
    [SerializeField]GameObject go_help;
    [SerializeField]GameObject go_credits;
    [SerializeField]GameObject go_quit;

    [SerializeField]Text txt_buildLabel;

    [SerializeField]Button butt_optSelect;
    [SerializeField]Button butt_mainSelect;
    [SerializeField]Button butt_helpSelect;
    [SerializeField]Button butt_quitSelect;

    Player p_uiPlayer;

	public void PlayTheFuckinGame() {
        SceneManager.LoadScene("RegisterPlayers");
    }

    public void OpenOptions() {
        go_options.SetActive(true);
        go_mainMenu.SetActive(false);
        butt_optSelect.Select();
    }

    public void CloseOptions() {
        go_options.SetActive(false);
        go_mainMenu.SetActive(true);
        butt_mainSelect.Select();
    }

    public void OpenHelp() {
        go_help.SetActive(true);
        go_mainMenu.SetActive(false);
        butt_helpSelect.Select();
    }

    public void CloseHelp() {
        go_help.SetActive(false);
        go_mainMenu.SetActive(true);
        butt_mainSelect.Select();
    }

    public void OpenCredits() {
        go_credits.SetActive(true);
        go_mainMenu.SetActive(false);
    }

    public void CloseCredits() {
        go_credits.SetActive(false);
        go_mainMenu.SetActive(true);
        butt_mainSelect.Select();
    }

    public void OpenQuit() {
        go_quit.SetActive(true);
        butt_quitSelect.Select();
    }

    public void CloseQuit() {
        go_quit.SetActive(false);
        butt_mainSelect.Select();
    }

    public void AdjustMasterVolume(float f_volIn) {
        Constants.VolOptions.C_MasterVolume = f_volIn;
    }

    public void AdjustBGMVolume(float f_volIn) {
        Constants.VolOptions.C_BGMVolume = f_volIn;
    }

    public void AdjustSFXVolume(float f_volIn) {
        Constants.VolOptions.C_SFXVolume = f_volIn;
    }

    public void AdjustVOIVolume(float f_volIn) {
        Constants.VolOptions.C_VOIVolume = f_volIn;
    }

    public void QuitTheFuckinGame() {
        Application.Quit();
    }

    private void Start() {
        Time.timeScale = 1;
        txt_buildLabel.text = "Build: v" + Constants.Global.C_BuildNumber;
        p_uiPlayer = ReInput.players.GetPlayer(0);
    }

    private void Update() {
        if (go_credits.activeSelf && p_uiPlayer.GetButtonDown("UICancel")) {
            CloseCredits();
        }
    }
}
