using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _delayShoot;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayShoot);
        bool isShoot = true;

        while (isShoot)
        {
            Vector3 direction = (_target.position - transform.position).normalized;
            Bullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.SetDirectionGreenAxis(direction);
            bullet.SetVelocity(direction);

            yield return delay;
        }
    }
}