

namespace BoBuAI.info
{
	public	class	ServiceInfo
	{
		public	string	mName		= "";
		public	bool	mEnable		= false;
		public	string	mCfgFile	= "";
		public	string	mSvrAddr	= "localhost";
		public	int		mSvrPort	= 0;

		public ServiceInfo(string name) {
			mName	= name;
		}

	}
}
