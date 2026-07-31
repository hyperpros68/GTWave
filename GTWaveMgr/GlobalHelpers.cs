using AnyBoBu.info;
using LiteDB;
using System.ComponentModel;

namespace GTWave.info {
	internal class GlobalHelpers {
		public static ILiteCollection<GroupInfo>	mGroupTb;
		public static ILiteCollection<UserInfo>		mUserTb;
		public static ILiteCollection<SystemInfo>	mSystemTb;
		public static ILiteCollection<DeviceInfo>	mDeviceTb;
		public static ILiteCollection<SnmpInfo>		mSnmpTb;
		public static ILiteCollection<SwitchInfo>	mSwitchTb;
		public static ILiteCollection<OidTuple>		mOidTupleTb;

		public static void Init(LiteDatabase mLDB) {
			mGroupTb	= mLDB.GetCollection<GroupInfo>("GroupInfo");
			mUserTb		= mLDB.GetCollection<UserInfo>("UserInfo");
			mSystemTb	= mLDB.GetCollection<SystemInfo>("SystemInfo");
			mDeviceTb	= mLDB.GetCollection<DeviceInfo>("DeviceInfo");
			mSnmpTb		= mLDB.GetCollection<SnmpInfo>("SnmpInfo");
			mSwitchTb	= mLDB.GetCollection<SwitchInfo>("SwitchInfo");
			mOidTupleTb = mLDB.GetCollection<OidTuple>("OidTuple");
		}

	}
}
