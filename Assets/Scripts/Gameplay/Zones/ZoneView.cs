using GameComponentAttributes.Attributes;
using GameJamEntry.Gameplay.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace GameJamEntry.Gameplay.Zones {
	
	public class ZoneView : MonoBehaviour, IPointerClickHandler {
		public int GoodManaAmount = 10;

		[NotNullReference] [SerializeField] string     ZoneId;
		[NotNullReference][SerializeField]  ZoneParams ZoneParams;

		[NotNullReference] [SerializeField] SpriteRenderer BlessingIcon;
		[NotNullReference] [SerializeField] SpriteRenderer FightIcon;
		[NotNullReference] [SerializeField] SpriteRenderer BaseTile;
 		[NotNullReference] [SerializeField] TMP_Text       ManaText;
		
		public ZoneParams Params => ZoneParams;
		public string     Id     => ZoneId;

		TurnManager        _turnManager;
		ZoneController     _zoneController;
		ManaTransferWindow _manaTransferWindow;
		ManaManager        _manaManager;
		
		[Inject]
		public void Init(TurnManager turnManager, ZoneController zoneController, ManaTransferWindow manaTransferWindow, ManaManager manaManager) {
			turnManager.OnTurnEnded                += OnTurnEnded;
			manaManager.CurrentMana.OnValueChanged += OnManaChanged;
			_zoneController                        =  zoneController;
			_manaTransferWindow                    =  manaTransferWindow;
			_manaManager                           =  manaManager;
			_turnManager                           =  turnManager;

		}

		void OnManaChanged(int newManaAmount) {
			RefreshView();
		}

		protected void Start() {
			RefreshView();
		}

		protected void OnDisable() {
			if ( _turnManager == null ) {
				return;
			}
			_turnManager.OnTurnEnded -= OnTurnEnded;
		}

		void OnTurnEnded(int newTurnIndex) {
			RefreshView();
		}

		void RefreshView() {
			var zoneState = _zoneController.GetZoneState(Id);
			if ( zoneState == null ) {
				Debug.LogError($"Can't get zone with id: {Id}");
				return;
			}
			BlessingIcon.enabled = zoneState.LeftTurnsWithBlessing > 0;
			FightIcon.enabled    = zoneState.LeftTurnsInFight > 0;
			ManaText.text        = zoneState.CurrentMana.ToString();
			
			var tValue = zoneState.CurrentMana / (float)GoodManaAmount;
			BaseTile.color = Color.Lerp(Color.red, Color.green, tValue);
		}

		public void OnPointerClick(PointerEventData eventData) {
			_manaTransferWindow.Show(Id);
		}
	}
}