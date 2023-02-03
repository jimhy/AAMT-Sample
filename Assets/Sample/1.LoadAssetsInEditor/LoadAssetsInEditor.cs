using System.Collections.Generic;
using AAMT;
using UnityEngine;
using UnityEngine.UI;

public class LoadAssetsInEditor : MonoBehaviour
{
    public Button LoadButton;
    public Button ReleaseButton;
    public Transform PrefabLayer;
    private string[] prefabBundlePathList;
    private List<GameObject> _gameObjects;

    void Start()
    {
        prefabBundlePathList = new[]
        {
            "Sample/Res/Prefabs/Capsule.prefab", //注意:这里需要Assets目录下的全路径，包含扩展名
            "Sample/Res/Prefabs/Sphere.prefab"
        };
        _gameObjects = new List<GameObject>();
        if (LoadButton != null) LoadButton.onClick.AddListener(onLoad);
        if (ReleaseButton != null) ReleaseButton.onClick.AddListener(onRelease);
    }

    private void onLoad()
    {
        AAMTManager.GetAssetsAsync<GameObject>(prefabBundlePathList, (obj) =>
        {
            if (obj != null)
            {
                var go = Instantiate(obj, obj.transform.position, Quaternion.identity, PrefabLayer);
                _gameObjects.Add(go);
            }
        });
    }

    private void onRelease()
    {
        AAMTManager.Release(prefabBundlePathList);
        foreach (var go in _gameObjects)
        {
            Destroy(go);
        }
        _gameObjects.Clear();
    }

    void Update()
    {
    }
}