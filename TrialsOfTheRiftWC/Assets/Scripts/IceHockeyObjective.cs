/*  Ice Hockey Objective - Dana Thompson
 * 
 *  Desc:   Facilitates Ice Hockey Objective
 * 
 */
 using UnityEngine;

public class IceHockeyObjective : Objective {
#region Variables and Declarations
    [SerializeField] private GoalController gc_owned;
#endregion

#region IceHockeyObjective Methods
    override protected void SetUI() {
        calligrapher.IceHockeyInit(e_color);
    }

    override protected void ResetUI() {
        calligrapher.GoalScoreReset(e_color);
    }

    // Update UI and check for completion
    public void UpdatePuckScore() {
		Constants.Global.Color oldLead = GetLeadColor();
        i_score++;
		Constants.Global.Color newLead = GetLeadColor();
		
		//If this is the first point of the game, play the first point announcement.
		if(oldLead == Constants.Global.Color.NULL && i_score == 1) maestro.PlayAnnouncementFirstScore();
		
		//If the lead changed, play the lead changed announcement.
		if(oldLead != newLead && newLead != Constants.Global.Color.NULL){
			maestro.PlayAnnouncementScoreComeback();
			maestro.PlayAnnouncementScoreLoser();
		}
		
		maestro.PlayAnnouncementScore();
		
		maestro.PlayScore();
        calligrapher.UpdateGoalScoreUI(e_color, i_score);
        gc_owned.FlashOn();
		if (i_score == Constants.ObjectiveStats.C_HockeyMaxScore - 1) {
            maestro.PlayTeamEncouragement();
        }
        else if (i_score >= Constants.ObjectiveStats.C_HockeyMaxScore) {
            b_isComplete = true;
        }
    }
#endregion

#region Unity Overrides
    void OnEnable() {
        maestro.PlayBeginHockey();
    }
#endregion
}
