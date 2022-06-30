using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour
{
    //[SerializeField] private Transform[] spawners;
    [SerializeField] private GameObject bulletPrefab;
    [Range(5, 50)] public float bulletSpeed;
    [SerializeField] private bool shouldFire = true;

    [SerializeField] private Transform[] scenario_Animation1; //1 //2
    [SerializeField] private Transform[] scenario_Animation2;
    [SerializeField] private Transform[] scenario_Animation3;
    [SerializeField] private Transform[] scenario_Animation4;
    [SerializeField] private Transform[] scenario_Animation5;
    [SerializeField] private Transform[] scenario_Animation6;
    [SerializeField] private Transform[] scenario_Animation7;

    private void Start()
    {
        //Invoke(nameof(FireABullet), 0.1f);
    }

    [ContextMenu("Scenario 1")]
    public void ActivateScenario1() => ActivateScenario(1);

    [ContextMenu("Scenario 2")]
    public void ActivateScenario2() => ActivateScenario(2);

    [ContextMenu("Scenario 3")]
    public void ActivateScenario3() => ActivateScenario(3);

    [ContextMenu("Scenario 4")]
    public void ActivateScenario4() => ActivateScenario(4);

    [ContextMenu("Scenario 5")]
    public void ActivateScenario5() => ActivateScenario(5);

    [ContextMenu("Scenario 6")]
    public void ActivateScenario6() => ActivateScenario(6);

    [ContextMenu("Scenario 7")]
    public void ActivateScenario7() => ActivateScenario(7);

    public void DoSetShouldFire(bool input) => shouldFire = input;

    public void ActivateScenario(int index)
    {
        if (shouldFire == false) return;

        switch (index)
        {
            case 1:

                foreach (var VARIABLE in scenario_Animation1)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 2:

                foreach (var VARIABLE in scenario_Animation2)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 3:

                foreach (var VARIABLE in scenario_Animation3)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 4:

                foreach (var VARIABLE in scenario_Animation4)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 5:

                foreach (var VARIABLE in scenario_Animation5)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 6:

                foreach (var VARIABLE in scenario_Animation6)
                {
                    FireABullet(VARIABLE);
                }

                break;

            case 7:

                foreach (var VARIABLE in scenario_Animation7)
                {
                    FireABullet(VARIABLE);
                }

                break;
        }
    }

    private void FireABullet(Transform spawner)
    {
        GameObject bullet = Instantiate(bulletPrefab, spawner.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = -1 * Vector3.forward * bulletSpeed;
    }
}