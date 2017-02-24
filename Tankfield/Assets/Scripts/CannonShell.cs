using UnityEngine;
using System.Collections;

public class CannonShell : MonoBehaviour {
    public Transform burstDust;

    private Vector3 massCenter;
    private Rigidbody _rigidbody;
    private float damage = 20;

	// Use this for initialization
	void Start () {
        massCenter = new Vector3(0, 0, 0.1f);
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = massCenter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision _collistion) {
        Instantiate(burstDust, this.transform.position, burstDust.rotation);
        if (_collistion.gameObject.tag == "Tank") {
            TankController _tank;
            _tank = _collistion.gameObject.GetComponent<TankController>();
            _tank.isHit = true;
            _tank.health -= damage;
            _collistion.rigidbody.AddForce(_rigidbody.transform.forward * _rigidbody.velocity.magnitude * 0.15f, ForceMode.Impulse);
        }

        Destroy(this.gameObject);
    }
}
