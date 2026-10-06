using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using AnyBoBu.info;
using GTWave.info;
using MindFusion.Diagramming.WinForms;
using Newtonsoft.Json;

namespace GTWave.utils {
	public class GroupNodeData {
		public string Text { get; set; }
		public List<GroupNodeData> Children { get; set; } = new List<GroupNodeData>();
	}

	public class DiagramPackageData {
		public List<GroupNodeData> Groups { get; set; } = new List<GroupNodeData>();
		public List<DeviceInfo> Devices { get; set; } = new List<DeviceInfo>();
	}

	public static class DiagramPackageUtil {
		// TreeView 노드를 저장용 데이터 객체로 변환
		public static List<GroupNodeData> ExportTreeNodes(TreeNodeCollection nodes) {
			List<GroupNodeData> list = new List<GroupNodeData>();
			foreach (TreeNode node in nodes) {
				GroupNodeData item = new GroupNodeData {
					Text = node.Text,
					Children = ExportTreeNodes(node.Nodes)
				};
				list.Add(item);
			}
			return list;
		}

		// 저장용 데이터 객체를 TreeView 노드로 복원
		public static void ImportTreeNodes(TreeNodeCollection targetNodes, List<GroupNodeData> sourceData) {
			targetNodes.Clear();
			if (sourceData == null) return;

			foreach (GroupNodeData item in sourceData) {
				TreeNode node = targetNodes.Add(item.Text);
				GroupInfo info = new GroupInfo(node.Text);
				node.Tag = info;
				info.node = node;

				if (item.Children != null && item.Children.Count > 0) {
					ImportTreeNodes(node.Nodes, item.Children);
				}
			}
		}

		// 통합 구성도 저장 (Zip 패키징)
		public static bool SavePackage(string filePath, DiagramView dvNetView, TreeView tvGroup, List<DeviceInfo> devices, Image backgroundImage = null) {
			try {
				if (File.Exists(filePath)) {
					File.Delete(filePath);
				}

				using (FileStream zipToOpen = new FileStream(filePath, FileMode.Create)) {
					using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create)) {
						// 1. Diagram 데이터 저장
						ZipArchiveEntry diagramEntry = archive.CreateEntry("diagram.mf");
						using (Stream entryStream = diagramEntry.Open()) {
							using (MemoryStream ms = new MemoryStream()) {
								dvNetView.SaveToStream(ms, true);
								ms.Position = 0;
								ms.CopyTo(entryStream);
							}
						}

						// 2. 배경 이미지 저장
						if (backgroundImage != null) {
							ZipArchiveEntry bgEntry = archive.CreateEntry("background.png");
							using (Stream entryStream = bgEntry.Open()) {
								using (MemoryStream ms = new MemoryStream()) {
									using (Bitmap bmpCopy = new Bitmap(backgroundImage)) {
										bmpCopy.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
									}
									ms.Position = 0;
									ms.CopyTo(entryStream);
								}
							}
						}

						// 3. 그룹 트리 + 장비 데이터 JSON 저장
						DiagramPackageData metaData = new DiagramPackageData {
							Groups = ExportTreeNodes(tvGroup.Nodes),
							Devices = devices ?? new List<DeviceInfo>()
						};

						ZipArchiveEntry metaEntry = archive.CreateEntry("metadata.json");
						using (StreamWriter writer = new StreamWriter(metaEntry.Open(), Encoding.UTF8)) {
							string json = JsonConvert.SerializeObject(metaData, Formatting.Indented);
							writer.Write(json);
						}
					}
				}
				return true;
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("SavePackage 실패: " + ex.Message);
				return false;
			}
		}

		// 통합 구성도 로드 (Zip 패키지 해제) - 기존 시그니처 호환용
		public static bool LoadPackage(string filePath, out byte[] diagramBytes, out List<GroupNodeData> groups, out List<DeviceInfo> devices) {
			return LoadPackage(filePath, out diagramBytes, out groups, out devices, out _);
		}

		// 통합 구성도 로드 (Zip 패키지 해제 - 배경 이미지 포함)
		public static bool LoadPackage(string filePath, out byte[] diagramBytes, out List<GroupNodeData> groups, out List<DeviceInfo> devices, out Image backgroundImage) {
			diagramBytes = null;
			groups = null;
			devices = null;
			backgroundImage = null;

			try {
				if (!File.Exists(filePath)) return false;

				using (FileStream zipToOpen = new FileStream(filePath, FileMode.Open, FileAccess.Read)) {
					using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Read)) {
						// 1. Diagram 데이터 읽기
						ZipArchiveEntry diagramEntry = archive.GetEntry("diagram.mf");
						if (diagramEntry != null) {
							using (MemoryStream ms = new MemoryStream()) {
								using (Stream entryStream = diagramEntry.Open()) {
									entryStream.CopyTo(ms);
								}
								diagramBytes = ms.ToArray();
							}
						}

						// 2. 배경 이미지 읽기
						ZipArchiveEntry bgEntry = archive.GetEntry("background.png");
						if (bgEntry != null) {
							using (MemoryStream ms = new MemoryStream()) {
								using (Stream entryStream = bgEntry.Open()) {
									entryStream.CopyTo(ms);
								}
								ms.Position = 0;
								using (Image tempImg = Image.FromStream(ms)) {
									backgroundImage = new Bitmap(tempImg);
								}
							}
						}

						// 3. 메타데이터 (그룹 + 장비) 읽기
						ZipArchiveEntry metaEntry = archive.GetEntry("metadata.json");
						if (metaEntry != null) {
							using (StreamReader reader = new StreamReader(metaEntry.Open(), Encoding.UTF8)) {
								string json = reader.ReadToEnd();
								DiagramPackageData metaData = JsonConvert.DeserializeObject<DiagramPackageData>(json);
								if (metaData != null) {
									groups = metaData.Groups;
									devices = metaData.Devices;
								}
							}
						}
					}
				}
				return true;
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("LoadPackage 실패: " + ex.Message);
				return false;
			}
		}
	}
}
