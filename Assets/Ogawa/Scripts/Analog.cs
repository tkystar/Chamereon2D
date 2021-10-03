using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Analog : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    #region Declarations
    [SerializeField]
    private RectTransform StickRect;

    private Vector2 _dragStartPosition;
    private Vector2 _basePosition;

    /// <summary>
    /// ジョイスティックで使用する円の構造体
    /// </summary>
    [Serializable]
    public struct Circle
    {
        public Image Image;

        public float Radius
        {
            get { return (Image) ? Image.rectTransform.sizeDelta.x / 2 : 0f; }
        }

        public Vector2 Center
        {
            get { return (Image) ? (Vector2)Image.rectTransform.position : Vector2.zero; }
        }
    }

    /// <summary>
    /// 台座部分
    /// </summary>
    [SerializeField]
    private Circle _pedestal;

    /// <summary>
    /// 入力部分
    /// </summary>
    [SerializeField]
    private Circle _inputStick;

    /// <summary>
    /// ドラッグ中かどうか
    /// </summary>
    private bool isDragging;

    /// <summary>
    /// ドラッグした距離
    /// </summary>
    private Vector2 _draggedDiff;

    /// <summary>
    /// 完了イベント
    /// </summary>
    private event Action _onDragEndEvent = delegate { };
    public event Action OnDragEndEvent
    {
        add { lock (_onDragEndEvent) _onDragEndEvent += value; }
        remove { lock (_onDragEndEvent) _onDragEndEvent -= value; }
    }

    /// <summary>
    /// 完了イベント
    /// </summary>
    private event Action<Vector2> _onDragEvent = delegate { };
    public event Action<Vector2> OnDragEvent
    {
        add { lock (_onDragEvent) _onDragEvent += value; }
        remove { lock (_onDragEvent) _onDragEvent -= value; }
    }


    #endregion

    #region MonoBehaviour

    void Update()
    {
        if (isDragging)
        {
            _onDragEvent(_draggedDiff);
        }
    }

    #endregion

    #region IDrag
    public void OnBeginDrag(PointerEventData eventData_)
    {
        //_dragStartPosition = eventData_.position;
        _dragStartPosition = StickRect.position;
        _basePosition = StickRect.position;
        _draggedDiff = Vector2.zero;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData_)
    {
        var currentPos = eventData_.position;
        var totalMove = currentPos - _dragStartPosition;
        var nextPosition = _basePosition + totalMove;

        if (CanSwipe(nextPosition))
        {
            StickRect.position = nextPosition;
            _draggedDiff = totalMove;
        }
        else
        {
            float rate = GetDistanceRate(currentPos);
            var fixedNextPosition = _basePosition + totalMove * rate;
            _draggedDiff = totalMove * rate;
            StickRect.position = fixedNextPosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData_)
    {
        StickRect.anchoredPosition = Vector2.zero;
        _onDragEndEvent();
        isDragging = false;
    }
    #endregion

    private bool CanSwipe(Vector2 nextPosition)
    {
        float distance = Vector2.Distance(_pedestal.Center, nextPosition);
        bool canSwipe = (distance + _inputStick.Radius) <= _pedestal.Radius;

        return canSwipe;
    }

    private float GetDistanceRate(Vector2 input)
    {
        float max = _pedestal.Radius - _inputStick.Radius;
        float current = Vector2.Distance(_pedestal.Center, input);
        float distanceRate = max / current;
        return distanceRate;
    }
}