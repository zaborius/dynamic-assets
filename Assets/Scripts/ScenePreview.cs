using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ScenePreview : MonoBehaviour
{
  [SerializeField]
  public AssetReference Scene;

  [SerializeField]
  public Button Button;
  // Start is called before the first frame update
  void Start()
  {
    Button.onClick.AddListener(() => Scene.LoadSceneAsync());
  }

  // Update is called once per frame
  void Update()
  {

  }
}
