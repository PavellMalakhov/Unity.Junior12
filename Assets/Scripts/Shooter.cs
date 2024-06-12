using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _speedBullet = 10;
    [SerializeField] private float _timeReload = 1;

    public void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var wait = new WaitForSeconds(_timeReload);

        while (enabled)
        {
            Vector3 bulletDirection = (_target.position - transform.position).normalized;
            Rigidbody bullet = Instantiate(_bullet);

            bullet.transform.up = bulletDirection;
            bullet.velocity = bulletDirection * _speedBullet;

            yield return wait;
        }
    }
}