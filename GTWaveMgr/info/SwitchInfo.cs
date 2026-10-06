using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyBoBu.info
{
	public	class	SwitchInfo
    {
		public	int		id			{ get; set; }	= 0;
		public	int		deviceId	{ get; set; }	= 0;

		public	int		numPoe		{ get; set; }	= 0;
		public	int		numEth		{ get; set; }	= 0;
		public	int		numSfp		{ get; set; }	= 0;
		public	int		numCombo	{ get; set; }	= 0;

		public	bool	isWatch		{ get; set; }	= true;
		public	int		idxFirst	{ get; set; }	= 2001;

		public	string	desc		{ get; set; }	= "";

		public SwitchInfo() {
		}

		public SwitchInfo(int deviceId) {
			this.deviceId = deviceId;
		}
	}
}
