using Aspose.CAD.FileFormats.Cad;
using Aspose.CAD.FileFormats.Cad.CadConsts;
using Aspose.CAD.FileFormats.Cad.CadObjects;
using Aspose.CAD.FileFormats.Cad.CadObjects.AttEntities;
using Aspose.CAD.FileFormats.Cad.CadTables;
using Aspose.CAD.ImageOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Awool.library
{
    public  class   HyperCad
    {
        public  void    load(string sourceFilePath)
        {
            // 기존 DWG 파일을 CadImage로 로드합니다.
            using (CadImage cadImage = (CadImage)Aspose.CAD.Image.Load(sourceFilePath))
            {
                // 파일에서 텍스트 검색 
                foreach (CadEntityBase entity in cadImage.Entities)
                {
                    // 우리는 CadText 엔터티를 통해 반복하지만 일부 다른 엔터티에는 텍스트도 포함될 수 있습니다(예: CadMText 및 기타).
                    IterateCADNodes(entity);
                }

                // 특정 레이아웃에서 텍스트를 검색하여 모든 레이아웃 이름을 가져오고 각 레이아웃을 엔티티가 있는 해당 블록과 연결합니다.
                CadLayoutDictionary layouts = cadImage.Layouts;
                string[] layoutNames = new string[layouts.Count];
                int i = 0;
                foreach (CadLayout layout in layouts.Values)
                {
                    layoutNames[i++] = layout.LayoutName;
                    System.Console.WriteLine("Layout " + layout.LayoutName + " is found");

                    // 블록 찾기, DWG에만 적용 가능
                    CadBlockTableObject blockTableObjectReference = null;
                    foreach (CadBlockTableObject tableObject in cadImage.BlocksTables)
                    {
                        if (string.Equals(tableObject.HardPointerToLayout, layout.ObjectHandle))
                        {
                            blockTableObjectReference = tableObject;
                            break;
                        }
                    }

                    if (blockTableObjectReference != null)
                    {
                        // 컬렉션 cadBlockEntity.Entities에는 특정 레이아웃의 모든 엔티티에 대한 정보가 포함되어 있습니다.
                        CadBlockEntity cadBlockEntity = cadImage.BlockEntities[blockTableObjectReference.BlockName];
                    }
                }

                // PDF로 내보내기
                CadRasterizationOptions rasterizationOptions = new CadRasterizationOptions();
                rasterizationOptions.PageWidth = 1600;
                rasterizationOptions.PageHeight = 1600;
                rasterizationOptions.AutomaticLayoutsScaling = true;

                // 선택한 레이아웃에 대한 cadBlockEntity 컬렉션 또는 레이아웃의 BlockTableRecordHandle(dxf용)에 의한 entitiesOnLayouts 컬렉션이 비어 있는 경우
                rasterizationOptions.Layouts = new[] { "Layout1" };

                Aspose.CAD.ImageOptions.PdfOptions pdfOptions = new PdfOptions();

                pdfOptions.VectorRasterizationOptions = rasterizationOptions;
                cadImage.Save("SearchText_CAD.pdf", pdfOptions);
            }
        }

        public  static  void    SearchTextInDWGAutoCADFile()
        {
            // 문서 디렉토리의 경로입니다.            
            string sourceFilePath = "C:\\Project\\TwinCity\\받은파일\\연세대120주년기념관_평면도\\옥탑02층02바닥구조평면도.dwg";
            // 기존 DWG 파일을 CadImage로 로드합니다. 
            CadImage cadImage = (CadImage)Aspose.CAD.Image.Load(sourceFilePath);

            // 엔터티 섹션에서 텍스트 검색 
            foreach (var entity in cadImage.Entities)
            {
                IterateCADNodes(entity);
            }

            // 블록 섹션에서 텍스트 검색 
            foreach (CadBlockEntity blockEntity in cadImage.BlockEntities.Values)
            {
                foreach (var entity in blockEntity.Entities)
                {
                    IterateCADNodes(entity);
                }
            }
        }

        private static void IterateCADNodes(CadEntityBase obj)
        {
            switch (obj.TypeName)
            {
                case CadEntityTypeName.TEXT:
                    CadText childObjectText = (CadText)obj;

                    Console.WriteLine(childObjectText.DefaultValue);

                    break;

                case CadEntityTypeName.MTEXT:
                    CadMText childObjectMText = (CadMText)obj;

                    Console.WriteLine(childObjectMText.Text);

                    break;

                case CadEntityTypeName.INSERT:
                    CadInsertObject childInsertObject = (CadInsertObject)obj;

                    foreach (var tempobj in childInsertObject.ChildObjects)
                    {
                        IterateCADNodes(tempobj);
                    }
                    break;

                case CadEntityTypeName.ATTDEF:
                    CadAttDef attDef = (CadAttDef)obj;

                    Console.WriteLine(attDef.DefaultString);
                    break;

                case CadEntityTypeName.ATTRIB:
                    CadAttrib attAttrib = (CadAttrib)obj;

                    Console.WriteLine(attAttrib.DefaultText);
                    break;
            }
        }
    }
}
