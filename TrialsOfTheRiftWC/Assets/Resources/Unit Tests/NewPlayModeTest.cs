using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

	[Test]
	public void NewPlayModeTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

    [UnityTest]
    public IEnumerator CTFPickup()
    {
        // spawn Camera
        GameObject CTFCameraPrefab = Resources.Load("Unit Tests/PerspectiveCam") as GameObject;
        GameObject CTFCamera = GameObject.Instantiate(CTFCameraPrefab);

        // spawn Maestro
        GameObject CTFMaestroPrefab = Resources.Load("Unit Tests/Maestro") as GameObject;
        GameObject CTFMaestro = GameObject.Instantiate(CTFMaestroPrefab);

        // spawn Canvas
        GameObject CTFCanvasPrefab = Resources.Load("Unit Tests/Canvas") as GameObject;
        GameObject CTFCanvas = GameObject.Instantiate(CTFCanvasPrefab);

        // spawn Rift
        GameObject CTFRiftPrefab = Resources.Load("Unit Tests/CTF_Rift") as GameObject;
        GameObject CTFRift = GameObject.Instantiate(CTFRiftPrefab);


        // spawn Objective
        GameObject CTFRedObjectivePrefab = Resources.Load("Unit Tests/CTF_RedObjective") as GameObject;
        GameObject CTFRedObjective = GameObject.Instantiate(CTFRedObjectivePrefab);
        CTFRedObjective.GetComponent<CaptureTheFlagObjective>().Activate(1);

        // spawn Player
        GameObject CTFRedPlayerPrefab = Resources.Load("Unit Tests/CTF_RedPlayer") as GameObject;
        GameObject CTFRedPlayer = GameObject.Instantiate(CTFRedPlayerPrefab);
        CTFRedPlayer.transform.position = new Vector3(8f, 0, 0);
        CTFRedPlayer.GetComponent<CTF_PlayerController>().Interact();

        // get reference to flag Object
        GameObject CTFRedFlag = CTFRedObjective.transform.GetChild(0).gameObject;

        yield return new WaitForSeconds(1.5f);
        Assert.IsNotNull(CTFRedObjective, "CTFRedObjective was read in as null.");
        Assert.IsNotNull(CTFRedPlayer, "CTFRedPlayer was read in as null.");
        Assert.True(CTFRedFlag.GetComponent<FlagController>().IsPickedUp());
    }
}
