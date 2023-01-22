using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoHome : MonoBehaviour
{
  // Start is called before the first frame update
  void Start()
  {
    this.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(0));
  }

  // Update is called once per frame
  void Update()
  {

  }
}
