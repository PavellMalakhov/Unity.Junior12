using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class StartRocketEngine : MonoBehaviour
{
    [SerializeField] private GameObject _ParticuleJet;
    [SerializeField] private float _speedGasJet;
    [SerializeField] private float _timeExpirationParticule;
    [SerializeField] private Transform _launchFacility;

    void Start()
    {
        StartCoroutine(GasEmission());
    }

    IEnumerator GasEmission()
    {
        while (enabled)
        {
            Vector3 jetDirection = (_launchFacility.position - transform.position).normalized;
            GameObject jet = Instantiate(_ParticuleJet, transform.position + jetDirection, Quaternion.identity);

            jet.GetComponent<Rigidbody>().transform.up = jetDirection;
            jet.GetComponent<Rigidbody>().velocity = jetDirection * _speedGasJet;

            yield return new WaitForSeconds(_timeExpirationParticule);
        }
    }
}