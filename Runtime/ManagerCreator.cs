using UnityEngine;

namespace LightGive.ManagerSystem
{
	/// <summary>
	/// Managerオブジェクトを生成する
	/// </summary>
	[CreateAssetMenu(menuName = CreatorPath, fileName = CreatorName)]
	public class ManagerCreator : ScriptableObject
	{
		public const string CreatorName = "ManagerCreator";
		public const string CreatorPath = "LightGive/Create ManagerCreator";

		/// <summary>
		/// マネージャークラスを生成した時にログを出すかどうか
		/// </summary>
		[SerializeField, Tooltip("Whether to issue a log when generated")]
		private bool isCheckLog = true;

		[SerializeField]
		private GameObject[] createManagers;
		public GameObject[] CreateManagers { get { return createManagers; } }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeBeforeSceneLoad()
		{
			var managerCreator = Resources.Load<ManagerCreator>("ManagerCreator");
			if (managerCreator == null)
			{
				Debug.LogError(
					$"Manager Creator does not exist.\n" +
					$"Right-click on the project view and place it in{CreatorPath}");
				return;
			}

			var objectNames = "";
			for (int i = 0; i < managerCreator.createManagers.Length; i++)
			{
				if (managerCreator.createManagers[i] == null)
				{
					continue;
				}
				var obj = Instantiate(managerCreator.createManagers[i]);
				objectNames += $"\n{i + 1:0} .{obj.name}";
			}

			if (managerCreator.isCheckLog)
			{
				Debug.Log("Create manager class complete." + objectNames);
			}
		}
	}
}
