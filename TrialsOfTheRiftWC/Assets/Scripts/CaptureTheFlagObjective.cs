/*  Capture The Flag Objective - Zak Olyarnik
 * 
 *  Desc:   Facilitates Capture The Flag Objective
 * 
 */

public class CaptureTheFlagObjective : Objective {
#region CaptureTheFlagObjective Methods
    override protected void SetUI() {
        calligrapher.CTFInit(e_color);
    }

    override protected void ResetUI() {
        calligrapher.ScoreReset(e_color);
    }

    // Update UI and check for completion
    public void UpdateFlagScore(UnityEngine.GameObject go_in) {
        i_score++;
        calligrapher.UpdateScoreUI(e_color, i_score);
        calligrapher.GoalFlashInit(e_color, go_in);
        if (i_score >= Constants.ObjectiveStats.C_CTFMaxScore) {
            b_isComplete = true;
        }
    }
#endregion

#region Unity Overrides	
    void OnEnable() {
        maestro.PlayBeginCTF();
    }
#endregion
}
