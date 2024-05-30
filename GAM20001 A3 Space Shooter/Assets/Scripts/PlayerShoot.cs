using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    [SerializeField]
    private float _tripleShotDuration = 5f; // Duration of the triple shot power-up

    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime;

    private bool _isTripleShotActive = false;

    void Update()
    {
        if (_fireContinuously || _fireSingle)
        {
            float timeSinceLastFire = Time.time - _lastFireTime;

            if (timeSinceLastFire >= _timeBetweenShots)
            {
                FireBullet();

                _lastFireTime = Time.time;
                _fireSingle = false;
            }
        }
    }

    private void FireBullet()
    {
        if (_isTripleShotActive)
        {
            TripleShot();
        }
        else
        {
            SingleShot();
        }
    }

    private void SingleShot()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        rigidbody.velocity = _bulletSpeed * transform.up;
    }

    private void TripleShot()
    {
        // Center bullet
        GameObject centerBullet = Instantiate(_bulletPrefab, _gunOffset.position, transform.rotation);
        Rigidbody2D centerRigidbody = centerBullet.GetComponent<Rigidbody2D>();
        centerRigidbody.velocity = _bulletSpeed * transform.up;

        // Calculate angles for left and right bullets
        float angleOffset = 15f; // Angle offset from the center bullet direction
        Vector3 leftDirection = Quaternion.AngleAxis(-angleOffset, Vector3.forward) * transform.up;
        Vector3 rightDirection = Quaternion.AngleAxis(angleOffset, Vector3.forward) * transform.up;

        // Instantiate left bullet
        Vector3 leftOffset = _gunOffset.position + leftDirection * 0.5f; // Adjust the distance from the center bullet
        GameObject leftBullet = Instantiate(_bulletPrefab, leftOffset, Quaternion.identity);
        Rigidbody2D leftRigidbody = leftBullet.GetComponent<Rigidbody2D>();
        leftRigidbody.velocity = _bulletSpeed * leftDirection;

        // Instantiate right bullet
        Vector3 rightOffset = _gunOffset.position + rightDirection * 0.5f; // Adjust the distance from the center bullet
        GameObject rightBullet = Instantiate(_bulletPrefab, rightOffset, Quaternion.identity);
        Rigidbody2D rightRigidbody = rightBullet.GetComponent<Rigidbody2D>();
        rightRigidbody.velocity = _bulletSpeed * rightDirection;
    }



    private void OnFire(InputValue inputValue)
    {
        _fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            _fireSingle = true;
        }
    }

    public void ActivateTripleShot(float duration)
    {
        StartCoroutine(TripleShotCoroutine(duration));
    }

    private IEnumerator TripleShotCoroutine(float duration)
    {
        _isTripleShotActive = true;
        yield return new WaitForSeconds(duration);
        _isTripleShotActive = false;
    }
}
