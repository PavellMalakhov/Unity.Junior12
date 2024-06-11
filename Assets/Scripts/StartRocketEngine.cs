using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class StartRocketEngine : MonoBehaviour
{
    [SerializeField] private Rigidbody _particuleJet;
    [SerializeField] private Transform _launchFacility;
    [SerializeField] private float _speedGasJet;
    [SerializeField] private float _timeExpirationParticule;

    public void Start()
    {
        StartCoroutine(GasEmission());
    }

    private IEnumerator GasEmission()
    {
        var wait = new WaitForSeconds(_timeExpirationParticule);

        while (enabled)
        {
            Vector3 jetDirection = (_launchFacility.position - transform.position).normalized;
            Rigidbody jet = Instantiate(_particuleJet, transform.position + jetDirection, Quaternion.identity);

            jet.transform.up = jetDirection;
            jet.velocity = jetDirection * _speedGasJet;

            yield return wait;
        }
    }
}