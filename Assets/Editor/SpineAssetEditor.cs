using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SpineAsset))]
public class SpineAssetEditor : Editor
{
    [MenuItem("Asset/Create/SpineAsset")]
    public static void CreateInstance()
    {
        SpineAsset spineAsset = ScriptableObject.CreateInstance<SpineAsset>();
        AssetDatabase.CreateAsset(spineAsset, "Assets/SpineAsset.asset");
       // EditorUtility.SetDirty(spineAsset);
    }
    private SpineAsset spineAsset { get { return target as SpineAsset; } }

    private float _lastANimationTime;

    private float currentTime
    {
        get { return (float)EditorApplication.timeSinceStartup; }
    }

    private GameObject _previewGameObject;

    private SkeletonAnimation _skeletonAnimation;

    private bool _requireRefresh = false;

    //unity内部专门用来绘制预览窗口的类
    private PreviewRenderUtility _previewRenderUtility;

    private Camera previewUtilityCamera
    {
        get
        {
            if (_previewRenderUtility == null)
            {
                return null;
            }
            else
            {
                return _previewRenderUtility.camera;
            }
        }
    }
    //渲染图层
    private const int PreviewLayer = 30;
    //告诉unity我有预览窗口
    public override bool HasPreviewGUI()
    {
        return true;
    }
    //预览窗口标题
    public override GUIContent GetPreviewTitle()
    {
        return new GUIContent("Preview");
    }
    //绘制可交互预览窗口函数
    public override void OnInteractivePreviewGUI(Rect r, GUIStyle background)
    {
        if (spineAsset.skeletonDataAsset == null)
        {
            return;
        }
        DisposePreviewRenderUtility();
        DestoryPreviewGameObject();

        Initialize(spineAsset.skeletonDataAsset, "default");
        HandleInterativePreviewGui(r, background);
    }
    private void OnDestroy()
    {
        DisposePreviewRenderUtility();
        DestoryPreviewGameObject();
    }
    private void DisposePreviewRenderUtility()
    {
        if (_previewRenderUtility != null)
        {
            _previewRenderUtility.Cleanup();
            _previewRenderUtility = null;
        }
    }

    private void DestoryPreviewGameObject()
    {
        if (_previewGameObject != null)
        {
            GameObject.DestroyImmediate(_previewGameObject);
            _previewGameObject = null;
        }
    }

    private void Initialize(SkeletonDataAsset skeletonDataAsset, string skinName = "")
    {
        if (_previewRenderUtility != null)
        {
            return;
        }
        _previewRenderUtility = new PreviewRenderUtility(true);
        _lastANimationTime = currentTime;

        if (_previewGameObject == null)
        {
            _previewGameObject = SpineEditorUtilities.SpawnAnimatedSkeleton(skeletonDataAsset, skinName).gameObject;

            if (_previewGameObject != null)
            {
                _previewGameObject.hideFlags = HideFlags.HideAndDontSave;
                _previewGameObject.layer = PreviewLayer;
                _skeletonAnimation = _previewGameObject.GetComponent<SkeletonAnimation>();
                _skeletonAnimation.initialSkinName = skinName;
                _skeletonAnimation.LateUpdate();
                //初始化时不进行渲染
                _previewGameObject.GetComponent<Renderer>().enabled = false;
            }
            _requireRefresh = true;
        }
        InitializePreviewCamera();
    }
    private void InitializePreviewCamera()
    {
        int previewCameraCullMask = 1 << PreviewLayer;
        var camera = this.previewUtilityCamera;
        camera.orthographic = true;//正交相机
        camera.cullingMask = previewCameraCullMask;
        camera.nearClipPlane = 0.01f;
        camera.farClipPlane = 1000f;
        if (_previewGameObject != null)
        {
            Bounds bounds = _previewGameObject.GetComponent<Renderer>().bounds;
            camera.orthographicSize = bounds.size.y;//调整范围
            camera.transform.position = bounds.center + new Vector3(0, 0, -10);//拉远相机
        }
    }
    //处理预览窗口
    private void HandleInterativePreviewGui(Rect r, GUIStyle backGround)
    {
        if (Event.current.type == EventType.Repaint)
        {
            Texture previewTexture = null;
            //让绘制函数不用每帧执行
            if (_requireRefresh)
            {
                //固定写法
                _previewRenderUtility.BeginPreview(r, backGround);
                //进行绘制
                RenderPreview();
                previewTexture = _previewRenderUtility.EndPreview();

                _requireRefresh = false;
            }
            if (previewTexture != null)
            {
                GUI.DrawTexture(r, previewTexture, ScaleMode.StretchToFill, false);
            }
        }
    }
    //进行绘制
    private void RenderPreview()
    {
        if (this.previewUtilityCamera.activeTexture == null ||
              this.previewUtilityCamera.targetTexture == null)
        {
            return;
        }
        if (_requireRefresh && _previewGameObject != null)
        {
            var renderer = _previewGameObject.GetComponent<Renderer>();
            renderer.enabled = true;
            if (EditorApplication.isPlaying != true)
            {
                //在编辑器模式下代替Time.DeltaTime
                float current = currentTime;
                float deltaTime = current - _lastANimationTime;
                _skeletonAnimation.Update(deltaTime);
                _lastANimationTime = current;

            }
            previewUtilityCamera.Render();
            //不关的话物体会显示在场景中
            renderer.enabled = false;
        }
    }
}
