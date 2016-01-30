//using UnityEngine;
//using System.Collections;
//
//public static class PokemonInfoStream : MonoBehaviour {
//
//	/// <summary>
//	/// CALL THIS IN START OR AWAKE IN YOUR NETWORK MANAGER CLASS ONCE
//	/// BEFORE YOU TRY TO SEND YOUR OBJECT DATA. YOU WILL GET AN
//	/// EXCEPTION!
//	/// </summary>
//	public static void Register() {
//		ExitGames.Client.Photon.PhotonPeer.RegisterType(typeof(PokemonInfo), (byte)'Z', CustomStream.SerializeDamageInfo, CustomStream.DeserializeDamageInfo);
//	}
//	/// <summary>
//	/// byte memory stream for pokemon info. size of array must be equal to the size of the sum of all data type sizes
//	/// </summary>
//	public static readonly byte[] memDamageInfo = new byte[FLOAT_FLOAT + INTEGER_INT + FLOAT_DOUBLE];
//	/// <summary>
//	/// Serializes the damage info.
//	/// </summary>
//	/// <returns>The damage info.</returns>
//	/// <param name="outStream">Out stream.</param>
//	/// <param name="customObject">Custom object.</param>
//	static short SerializeDamageInfo(MemoryStream outStream, object customObject) {
//		DamageInfo dInfo = (DamageInfo)customObject; // Cast to object type.
//
//		// Lock the memory byte stream for damage info
//		// this prevents the byte[] from being changed while we are
//		// changing it.
//		lock(CustomStream.memDamageInfo) {
//			int index = 0; // byte stream starting index.
//
//			byte[] bytes = CustomStream.memDamageInfo;
//
//			// Serialize each value in damage info
//			Protocol.Serialize(dInfo.DamageDealt, bytes, ref index);
//			Protocol.Serialize(dInfo.PlayerID, bytes, ref index);
//			Protocol.Serialize(dInfo.TimeStamp, bytes, ref index);
//
//			outStream.Write(bytes, 0, CustomStream.memDamageInfo.Length);
//		}
//
//		return (short)CustomStream.memDamageInfo.Length;
//	}
//
//	static object DeserializeDamageInfo(MemoryStream inStream, short length) {
//		// Temperary holders for each member in DamageInfo
//		float damageDealt = 0.0F;
//		int playerID = 0;
//		double timeStamp = 0.0;
//
//		lock(CustomStream.memDamageInfo) {
//			int index = 0;
//
//			// Deserailize in the same order the object was serialized!
//			Protocol.Deserialize(out damageDealt, CustomStream.memDamageInfo, ref index);
//			Protocol.Deserialize(out playerID, CustomStream.memDamageInfo, ref index);
//			Protocol.Deserialize(out timeStamp, CustomStream.memDamageInfo, ref index);
//		}
//
//		// Return a new instance of DamageInfo with all the data.
//		return new DamageInfo(damageDealt, playerID, timeStamp);
//	}
//
//}
