using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class MainSceneManager : MonoBehaviour
{
  public GameObject Content;

  private AsyncOperationHandle _prefabsHandle;
  async Task Start()
  {
    await Addressables.InitializeAsync(true).Task;
    var catalogIds = await Addressables.CheckForCatalogUpdates(true).Task;
    if (catalogIds.Any())
      await Addressables.UpdateCatalogs(true, catalogIds, true).Task;

    _prefabsHandle = Addressables.LoadAssetsAsync<GameObject>("Prefab", asset =>
    {
      GameObject.Instantiate(asset, Content.transform);
    });

    var assets = await _prefabsHandle.Task;    
  }

  private void OnDestroy()
  {
    Addressables.Release(_prefabsHandle);
  }
}
