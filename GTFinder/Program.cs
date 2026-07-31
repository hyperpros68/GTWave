using System.Globalization;
using System.Management;
using System.Net.NetworkInformation;

namespace GTFinder {
	internal static class Program {
		public static string ExecutionArgs = ""; // 전역 변수 추가
	
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args) { // 인자 받기
			if (args.Length > 0) {
				ExecutionArgs = args[0];
				// 로그 출력 (Debug View 등으로 확인 가능)
				System.Diagnostics.Debug.WriteLine($"[GTFinder] Received Args: {ExecutionArgs}");
			}

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			FinderForm finder = new FinderForm();
			finder.ExecutionArgs = ExecutionArgs;
			Application.Run(finder);
		}
	}
}