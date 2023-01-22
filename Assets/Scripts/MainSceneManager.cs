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

    //Проверяем контент в облаке на наличие обновлений.
    var catalogIds = await Addressables.CheckForCatalogUpdates(true).Task;

    //Если контент изменился, или мы запускаем приложение в первый раз, то скачиваем обновления
    if (catalogIds.Any())
      await Addressables.UpdateCatalogs(true, catalogIds, true).Task;

    //Загружаем динамический контент в Scroll View
    _prefabsHandle = Addressables.LoadAssetsAsync<GameObject>("Prefab", asset =>
    {
      GameObject.Instantiate(asset, Content.transform);
    });

    var assets = await _prefabsHandle.Task;    
  }

  private void OnDestroy()
  {
    //При закрытии сцены, мы явно указываем, что загруженные динамические ассеты нам больше не нужны
    Addressables.Release(_prefabsHandle);
  }
}
