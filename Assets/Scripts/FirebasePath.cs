using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Firebase/Path")]
public class FirebasePath : ScriptableObject{

	public string BasePath, DbVersion, ObjectTypeName;
	public bool IsPlural;

	public Firebase.Database.DatabaseReference GetReferenceFromRoot(Firebase.Database.DatabaseReference root){
		var objectTypeName = ObjectTypeName + (IsPlural ? "s" : "");

		return root.Child (DbVersion).Child (BasePath).Child (objectTypeName);
	}
}