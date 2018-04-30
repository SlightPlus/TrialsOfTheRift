using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CTF_UnitTests {
    #region Object References
    GameObject CTFCamera;
    GameObject CTFMaestro;
    GameObject CTFCanvas;
    GameObject CTFRift;

    GameObject CTFRedObjective;
    GameObject CTFRedFlag;
    GameObject CTFRedPlayer;
    #endregion

    #region Before and After Methods
    [OneTimeSetUp]
    public void StartUp() {  // StartUp runs once before running any test cases.
        Debug.Log("In StartUp");
        Constants.UnitTests.C_RunningCTFTests = true;
        SpawnCamera();
        SpawnMaestro();
        SpawnCanvas();
        SpawnRift();
    }

    [OneTimeTearDown]
    public void CleanUp() {   // CleanUp runs once after all test cases are finished.
        Debug.Log("In CleanUp");
        GameObject.Destroy(CTFRift);
        GameObject.Destroy(CTFCanvas);
        GameObject.Destroy(CTFMaestro);
        GameObject.Destroy(CTFCamera);
    }

    [SetUp]
    public void SetUp() { // SetUp runs before every test case
        Debug.Log("In SetUp");
    }

    [TearDown]
    public void TearDown() {  // TearDown runs after every test case
        Debug.Log("In TearDown");
        if (CTFRedPlayer) GameObject.Destroy(CTFRedFlag);
        if (CTFRedObjective) GameObject.Destroy(CTFRedFlag);
    }
    #endregion

    #region Tests
    [UnityTest]
    public IEnumerator CTFPickup() {
        Debug.Log("In CTFPickup");

        SpawnRedObjective();
        SpawnRedPlayer();

        PickupFlag(CTFRedPlayer, CTFRedFlag);

        yield return new WaitForSeconds(Constants.UnitTests.C_WaitTime);
        Assert.True(CTFRedFlag.GetComponent<FlagController>().IsPickedUp());
        Assert.True(CTFRedPlayer.GetComponent<PlayerController>().HasFlag);
    }

    [UnityTest]
    public IEnumerator CTFDrop() {
        Debug.Log("In CTFDrop");

        SpawnRedObjective();
        SpawnRedPlayer();        

        PickupFlag(CTFRedPlayer, CTFRedFlag);
        yield return new WaitForSeconds(Constants.UnitTests.C_WaitTime);
        CTFRedPlayer.GetComponent<PlayerController>().Interact();

        yield return new WaitForSeconds(Constants.UnitTests.C_WaitTime);
        Assert.False(CTFRedFlag.GetComponent<FlagController>().IsPickedUp());
        Assert.False(CTFRedPlayer.GetComponent<PlayerController>().HasFlag);
    }
    #endregion


    #region Spawn Helper Methods
    void SpawnCamera() {
        GameObject CTFCameraPrefab = Resources.Load("Unit Tests/PerspectiveCam") as GameObject;
        CTFCamera = GameObject.Instantiate(CTFCameraPrefab);
    }

    void SpawnMaestro() {
        GameObject CTFMaestroPrefab = Resources.Load("Unit Tests/Maestro") as GameObject;
        CTFMaestro = GameObject.Instantiate(CTFMaestroPrefab);
    }

    void SpawnCanvas() {
        GameObject CTFCanvasPrefab = Resources.Load("Unit Tests/Canvas") as GameObject;
        CTFCanvas = GameObject.Instantiate(CTFCanvasPrefab);
    }

    void SpawnRift() {
        GameObject CTFRiftPrefab = Resources.Load("Unit Tests/CTF_Rift") as GameObject;
        CTFRift = GameObject.Instantiate(CTFRiftPrefab);
    }

    void SpawnRedObjective() {
        GameObject CTFRedObjectivePrefab = Resources.Load("Unit Tests/CTF_RedObjective") as GameObject;
        CTFRedObjective = GameObject.Instantiate(CTFRedObjectivePrefab);
        CTFRedObjective.GetComponent<CaptureTheFlagObjective>().Activate(1);

        // get reference to flag Object
        CTFRedFlag = CTFRedObjective.transform.GetChild(0).gameObject;
    }

    void SpawnRedPlayer() {
        GameObject CTFRedPlayerPrefab = Resources.Load("Unit Tests/CTF_RedPlayer") as GameObject;
        CTFRedPlayer = GameObject.Instantiate(CTFRedPlayerPrefab);
    }
    #endregion

    #region Other Helper Methods
    void PickupFlag(GameObject player, GameObject flag) {
        player.transform.position = flag.transform.position;
        player.GetComponent<PlayerController>().Interact();
    }
    #endregion

}
