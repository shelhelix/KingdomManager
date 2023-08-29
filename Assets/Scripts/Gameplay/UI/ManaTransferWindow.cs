using DG.Tweening;
using GameComponentAttributes.Attributes;
using GameJamEntry.Gameplay.Zones;
using GameJamEntry.Utils.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJamEntry.Gameplay.UI {
	public class ManaTransferWindow : MonoBehaviour {
		const int ManaTransferDelta = 10;

		[NotNullReference] [SerializeField] TMP_InputField ManaAmountText;
		[NotNullReference] [SerializeField] ButtonWrapper  MinusButton;
		[NotNullReference] [SerializeField] ButtonWrapper  PlusButton;
		[NotNullReference] [SerializeField] ButtonWrapper  SendManaToZoneButton;
		[NotNullReference] [SerializeField] ButtonWrapper  ExitButton;
		[NotNullReference] [SerializeField] Image          ClickBlockImage;

		[NotNullReference] [SerializeField] Transform Root;
		[NotNullReference] [SerializeField] Transform ScreenCenterPoint;
		[NotNullReference] [SerializeField] Transform HidePoint;
		[SerializeField]                    float     AnimationDuration = 0.4f;

		string      _currentReceivingZoneId;
		ManaManager _manaManager;

		int _manaToTransfer;

		Sequence _runningSequence;

		ZoneController _zoneController;

		public void Init(ZoneController zoneController, ManaManager manaManager) {
			_zoneController = zoneController;
			_manaManager    = manaManager;
			gameObject.SetActive(true);
			HideImmediately();
		}

		public void Show(string receivingZoneId) {
			_currentReceivingZoneId = receivingZoneId;
			ManaAmountText.onValueChanged.RemoveAllListeners();
			ManaAmountText.onValueChanged.AddListener(OnValueChanged);
			MinusButton.RemoveAllAndAddListener(() => ChangeManaAmountToTransfer(-ManaTransferDelta));
			PlusButton.RemoveAllAndAddListener(() => ChangeManaAmountToTransfer(ManaTransferDelta));
			SendManaToZoneButton.RemoveAllAndAddListener(SendManaToZone);
			ExitButton.RemoveAllAndAddListener(Hide);
			MoveWindowToPoint(ScreenCenterPoint.position, true, true, 0.5f);
			UpdateManaTransferView();
		}

		public void Hide() {
			MoveWindowToPoint(HidePoint.position, false, true, 0);
		}

		void HideImmediately() {
			Root.position           = HidePoint.position;
			ClickBlockImage.enabled = false;
			ClickBlockImage.color   = new Color(0, 0, 0, 0);
		}

		void SendManaToZone() {
			if ( !_manaManager.IsEnoughMana(_manaToTransfer) ) {
				Hide();
				return;
			}
			_zoneController.AddManaToZone(_currentReceivingZoneId, _manaToTransfer);
			_manaManager.TrySpendMana(_manaToTransfer);
			Hide();
		}

		void ChangeManaAmountToTransfer(int delta) {
			_manaToTransfer = Mathf.Clamp(_manaToTransfer + delta, 0, _manaManager.CurrentMana.Value);
			UpdateManaTransferView();
		}

		void OnValueChanged(string value) {
			if ( !int.TryParse(value, out var manaAmount) ) {
				return;
			}
			if ( manaAmount == _manaToTransfer ) {
				return;
			}
			_manaToTransfer = Mathf.Clamp(manaAmount, 0, _manaManager.CurrentMana.Value);
			UpdateManaTransferView();
		}

		void UpdateManaTransferView() {
			MinusButton.Interactable          = _manaToTransfer > 0;
			PlusButton.Interactable           = _manaToTransfer < _manaManager.CurrentMana.Value;
			SendManaToZoneButton.Interactable = (_manaToTransfer <= _manaManager.CurrentMana.Value) && (_manaToTransfer >= 0);
			ManaAmountText.text               = _manaToTransfer.ToString();
		}

		void MoveWindowToPoint(Vector3 point, bool enabledOnFinish, bool enabledOnStart, float endFadeValue) {
			_runningSequence?.Kill(true);
			ClickBlockImage.enabled = enabledOnStart;
			_runningSequence = DOTween.Sequence(this)
				.Append(Root.DOMove(point, AnimationDuration))
				.Join(ClickBlockImage.DOFade(endFadeValue, AnimationDuration));
			_runningSequence.onComplete += () => ClickBlockImage.enabled = enabledOnFinish;
		}
	}
}