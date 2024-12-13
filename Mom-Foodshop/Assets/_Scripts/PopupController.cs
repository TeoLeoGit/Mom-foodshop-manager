using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    [SerializeField] private List<PopupMap> _popupRefs;
    [SerializeField] private GameObject _blurPanel;

    private Dictionary<EPopup, IPopup> _popupInstants = new();

    private void Awake()
    {
        MainController.OnOpenPopup += OpenPopup;
        MainController.OnHideAllPopup += CloseAllPopup;


        _blurPanel.SetActive(false);
    }

    private void OnDestroy()
    {
        MainController.OnOpenPopup -= OpenPopup;
        MainController.OnHideAllPopup -= CloseAllPopup;
    }

    private void OpenPopup(EPopup type)
    {
        _blurPanel.SetActive(true);
        if (_popupInstants.ContainsKey(type)) _popupInstants[type].Show();
        else
        {
            var popupInstant = Instantiate(_popupRefs.Find(item => item.type == type).popup, transform);
            if (popupInstant.TryGetComponent(out IPopup iPopup)) 
                _popupInstants.Add(type, iPopup);
            _popupInstants[type].Show();
        }
    }

    private void CloseAllPopup()
    {
        _blurPanel.SetActive(false);
        foreach(var popup in _popupInstants)
            popup.Value.Hide();
    }
}
