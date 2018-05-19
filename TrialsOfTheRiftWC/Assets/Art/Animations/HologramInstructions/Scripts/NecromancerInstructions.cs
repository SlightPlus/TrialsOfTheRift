using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecromancerInstructions : MonoBehaviour
{
    public GameObject apprentice;
    public GameObject magicMissile;
    public GameObject necromancer;
    public GameObject[] skeletons;


    Vector3 originalPos;
    Vector3 necromancerPos;

    public Animator apprenticeAnim;
    public Animator necroAnim;


    private bool canShoot = false;
    private bool isRunning = false;
    private bool isChasing = false;

    private Rigidbody rb;
    private float _fireRate;
    private float _bulletLifetime;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DestroyTheNecromancer());
        originalPos = apprentice.transform.position;
        necromancerPos = necromancer.transform.position;
        isRunning = true;

        skeletons[0].SetActive(false);
        skeletons[1].SetActive(false);
        skeletons[2].SetActive(false);

        _fireRate = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            apprentice.transform.Translate(Vector3.forward * Time.unscaledDeltaTime * 3.0f);
            necromancer.transform.Translate(Vector3.back * Time.unscaledDeltaTime * 2.0f);
        }
        if(isChasing)
        {
            skeletons[0].transform.position = Vector3.MoveTowards(skeletons[0].transform.position, apprentice.transform.position, 0.5f * Time.unscaledDeltaTime);
            skeletons[1].transform.position = Vector3.MoveTowards(skeletons[1].transform.position, apprentice.transform.position, 0.5f * Time.unscaledDeltaTime);
            skeletons[2].transform.position = Vector3.MoveTowards(skeletons[2].transform.position, apprentice.transform.position, 0.5f * Time.unscaledDeltaTime);
        }
        if (canShoot)
        {
            if (_fireRate <= 0f)
            {
                GameObject go_spell1 = Instantiate(magicMissile, apprentice.transform.position, apprentice.transform.rotation);
                go_spell1.GetComponent<Rigidbody>().velocity = Vector3.forward * Constants.SpellStats.C_MagicMissileSpeed;
                Destroy(go_spell1, _bulletLifetime);
                _fireRate = 1.0f;
            }
            _fireRate -= Time.unscaledDeltaTime;
        }
    }

    IEnumerator DestroyTheNecromancer()
    {
        //Phase 1: Attack retreating Necromancer.
        apprenticeAnim.Play("Run", -1, 0f);
        Shoot();
        _bulletLifetime = 1f;
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(2f));
        isRunning = false;
        canShoot = false;
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(0.5f));
        necromancer.SetActive(false);     
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(1f));

        //Phase 2: Necromancer Spawns Skeletons
        ResetPosition();
        _bulletLifetime = 0.5f;
        StartCoroutine(NecromancerSummon());
        apprenticeAnim.Play("3Fire", -1, 0f);
        //yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(0.5f));
        Shoot();
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(3f));
        canShoot = false;
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(1f));



        Debug.Log("End of Instruction.");
    }

    IEnumerator NecromancerSummon()
    {
        necroAnim.Play("Summon", -1, 0f);
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(0.2f));
        Summon();
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(2.8f));
        skeletons[0].SetActive(false);
        yield return StartCoroutine(CoroutineUnscaledWait.WaitForSecondsUnscaled(1.2f));
        isChasing = false;
    }

    void Shoot()
    {
        canShoot = true;
    }

    void ResetPosition()
    {
        apprentice.transform.position = originalPos;
        necromancer.transform.position = necromancerPos;
        necromancer.SetActive(true);
    }

    void Summon()
    {
        Debug.Log("Summoned.");
        skeletons[0].SetActive(true);
        skeletons[1].SetActive(true);
        skeletons[2].SetActive(true);
        isChasing = true;
    }
}
