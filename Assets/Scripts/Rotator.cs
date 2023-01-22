using UnityEngine;

public class Rotator : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    this.transform.Rotate(0, 20 * Time.deltaTime, 0);
  }
}
