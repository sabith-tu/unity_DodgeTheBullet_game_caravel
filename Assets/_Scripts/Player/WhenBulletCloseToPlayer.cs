using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public enum AllBulletIsCloseToPlayerState
{
    BulletsCloseToPlayer,
    NoBulletCloseToPlayer
}

public class WhenBulletCloseToPlayer : MonoBehaviour
{
    [SerializeField] private UnityEvent OnBulletIsCloseToPlayer;
    [SerializeField] private UnityEvent OnNoBulletIsCloseToPlayer;
    [SerializeField] private UnityEvent ifBulletsCouldHitPlayer;
    [SerializeField] private UnityEvent ifNoBulletsCouldHitPlayer;
    [SerializeField] private Transform centerOfTheSphere;
    [SerializeField] [Range(1, 10)] private float randiusOfTheSphere;
    [SerializeField] private Vector3 boxHalfExtent;
    [SerializeField] private LayerMask bulletLayerMask;
    [SerializeField] private LayerMask playerLayerMask;
    private int _bulletsThatCouldHitPlayer;
    private bool canAnyBulletHitPlayer = false;
    private float bulletsCloseToPlayerAmount;

    private AllBulletIsCloseToPlayerState _curentBulletCloseToPlayerState =
        AllBulletIsCloseToPlayerState.NoBulletCloseToPlayer;

    RaycastHit hit;

    [SerializeField] private bool showGizmos;
    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.CompareTag(GameStrings.tag_Bullet))
    //     {
    //         OnBulletIsCloseToPlayer.Invoke();
    //     }
    // }

    private void Start()
    {
        StartCoroutine(CheckForBullet());
        OnNoBulletIsCloseToPlayer.Invoke();
    }


    IEnumerator CheckForBullet()
    {
        while (true)
        {
            if ((GameManager.instance.GetCurentGameState() == AllGameStates.Possing) ||
                (GameManager.instance.GetCurentGameState() == AllGameStates.Running))

            {
                //var bulletsCloseToPlayer = Physics.OverlapSphere(centerOfTheSphere.position, randiusOfTheSphere , bulletLayerMask);
                Collider[] bulletsCloseToPlayer = Physics.OverlapBox(centerOfTheSphere.position, boxHalfExtent,
                    Quaternion.identity, bulletLayerMask);

                //if(this.bulletsCloseToPlayer)
                UpdateBulletsCloseToPlayer(bulletsCloseToPlayer.Length);

                _bulletsThatCouldHitPlayer = 0; // moved for foreach to here
                canAnyBulletHitPlayer = false; //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach (var bullet in bulletsCloseToPlayer)
                {
                    //if (Physics.Raycast(bullet.transform.position , bullet.transform.forward * -1f , 200 , playerLayerMask ))


                    if (Physics.SphereCast(bullet.transform.position, 0.07f, bullet.transform.forward * -1, out hit,
                        100,
                        playerLayerMask))
                    {
                        SABI_Consol.instance.Log("Bullet z pos " + bullet.transform.position.z.ToString());
                        _bulletsThatCouldHitPlayer++;
                        canAnyBulletHitPlayer = true; //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        //Debug.Log(" collided game object : " + hit.collider.gameObject.name + " point :  " + hit.point);
                        //Debug.DrawRay(bullet.transform.position, bullet.transform.forward * -1 * 40, Color.black,0.01f);
                    }
                }

                UpdateIfAnyBulletCouldHitPlayer();
            }

            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

    void UpdateIfAnyBulletCouldHitPlayer()
    {
        //Debug.Log(_bulletsThatCouldHitPlayer);

        if (_bulletsThatCouldHitPlayer > 0)
        {
            ifBulletsCouldHitPlayer.Invoke();
            //Debug.Log("dODGE IT ......");
        }
        else
        {
            ifNoBulletsCouldHitPlayer.Invoke();
        }
    }

    void UpdateBulletsCloseToPlayer(int amount)
    {
        if (amount > 0)
        {
            if (_curentBulletCloseToPlayerState == AllBulletIsCloseToPlayerState.NoBulletCloseToPlayer)
            {
                _curentBulletCloseToPlayerState = AllBulletIsCloseToPlayerState.BulletsCloseToPlayer;
                OnBulletIsCloseToPlayer.Invoke();
            }
        }
        else
        {
            if (_curentBulletCloseToPlayerState == AllBulletIsCloseToPlayerState.BulletsCloseToPlayer)
            {
                _curentBulletCloseToPlayerState = AllBulletIsCloseToPlayerState.NoBulletCloseToPlayer;
                OnNoBulletIsCloseToPlayer.Invoke();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (showGizmos == false) return;
        //Gizmos.DrawSphere(centerOfTheSphere.position, randiusOfTheSphere);
        Gizmos.DrawCube(centerOfTheSphere.position, boxHalfExtent);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(hit.point, 0.1f);
        //Gizmos.DrawRay();
    }
}