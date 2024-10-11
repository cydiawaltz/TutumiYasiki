using UnityEngine;
using UnityEngine.Rendering;

/// <summary>
/// カメラが映すものを低解像度に設定できるようにするコンポーネント
/// </summary>
[RequireComponent(typeof(Camera))]
public class LowResolutionCamera : MonoBehaviour
{
    [SerializeField] int defaultWidth;
    [SerializeField] int defaultHeight;
    /// <summary>
    /// デフォルト解像度
    /// </summary>
    private Vector2 RESOLUTION;

    /// <summary>
    /// 解像度係数
    /// </summary>
    [SerializeField, Range(0.1f, 1)]
    private float _resolutionWeight = 0.3f;

    private float _currentResolutionWeight = 0.3f;

    private RenderTexture _renderTexture;
    private Camera _camera;
    private Camera _subCamera;
    [SerializeField] GameObject setting;//設定ファイルが格納されているGameObject(DontDestroy)

    private void Start()
    {
        try
        {
            setting = GameObject.FindWithTag("Setting");
            switch(setting.GetComponent<SettingStore>().graphicsSetting)
            {
                case "Low":
                    Application.targetFrameRate = 10;
                    _resolutionWeight = 0.2f;
                    break;
                case "Normal":
                    Application.targetFrameRate = 30;
                    _resolutionWeight = 0.4f;
                    break;
                case "High":
                    _resolutionWeight = 1.0f;
                    break;
            }
        }
        catch(UnityException e)
        {
            Debug.Log(e.Message);
            Application.targetFrameRate = 10;
        }
        
        RESOLUTION = new Vector2(defaultWidth, defaultHeight);
        SetResolution(_resolutionWeight);
    }

    /// <summary>
    /// 解像度を設定
    /// </summary>
    public void SetResolution(float resolutionWeight)
    {
        _resolutionWeight = resolutionWeight;
        _currentResolutionWeight = resolutionWeight;

        // 指定解像度に合わせたレンダーテクスチャーを作成
        _renderTexture = new RenderTexture(
            width: (int)(RESOLUTION.x * _currentResolutionWeight),
            height: (int)(RESOLUTION.y * _currentResolutionWeight),
            depth: 24
        );
        _renderTexture.useMipMap = false;
        _renderTexture.filterMode = FilterMode.Point;
        // カメラのレンダーテクスチャーを設定
        if (_camera == null)
        {
            _camera = GetComponent<Camera>();
        }
        _camera.targetTexture = _renderTexture;

        // レンダーテクスチャーを表示するサブカメラを設定
        if (_subCamera == null)
        {
            GameObject cameraObject = new GameObject("SubCamera");
            _subCamera = cameraObject.AddComponent<Camera>();
            _subCamera.cullingMask = 0;
            _subCamera.transform.parent = transform;
            _subCamera.tag = "SubCamera";
        }
        CommandBuffer commandBuffer = new CommandBuffer();
        commandBuffer.Blit((RenderTargetIdentifier)_renderTexture, BuiltinRenderTextureType.CameraTarget);
        _subCamera.AddCommandBuffer(CameraEvent.AfterEverything, commandBuffer);
    }

    private void Update()
    {
        if (_currentResolutionWeight == _resolutionWeight) return;
        // _resolutionWeightの値が更新された時だけ解像度変更処理を呼ぶ
        // Inspector上で_resolutionWeightを操作するとき用の処理
        SetResolution(_resolutionWeight);
    }
}
