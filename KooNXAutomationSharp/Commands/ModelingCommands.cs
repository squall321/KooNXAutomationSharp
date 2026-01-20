using System;
using NXOpen;
using NXOpen.Features;
using NXOpen.UF;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Commands
{
    /// <summary>
    /// 모델링 관련 메뉴 명령어 클래스
    /// NX 메뉴/리본에서 호출되는 모델링 기능들
    /// </summary>
    public class ModelingCommands
    {
        private const string ClassName = "ModelingCommands";

        /// <summary>
        /// Box 생성 명령
        /// </summary>
        public static void CreateBox()
        {
            Logger.MethodEntry(ClassName, "CreateBox");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine("Error: No work part available. Please create or open a part first.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // BlockFeatureBuilder를 사용하여 Box 생성
                BlockFeatureBuilder blockBuilder = workPart.Features.CreateBlockFeatureBuilder(null);

                try
                {
                    // 기본 크기 설정 (100 x 100 x 50 mm)
                    Point3d origin = new Point3d(0, 0, 0);
                    blockBuilder.SetOriginAndLengths(origin, "100", "100", "50");

                    Logger.Debug(ClassName, "Box 파라미터 설정 완료: 100 x 100 x 50");

                    // Feature 생성
                    NXObject result = blockBuilder.Commit();

                    if (result != null)
                    {
                        Logger.Info(ClassName, "Box 생성 완료");
                        session.ListingWindow.Open();
                        session.ListingWindow.WriteLine("Box created successfully (100 x 100 x 50 mm)");
                    }
                }
                finally
                {
                    blockBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Box 생성 중 오류 발생", ex);
                if (session != null)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"Error creating box: {ex.Message}");
                }
            }

            Logger.MethodExit(ClassName, "CreateBox");
        }

        /// <summary>
        /// Cylinder 생성 명령
        /// </summary>
        public static void CreateCylinder()
        {
            Logger.MethodEntry(ClassName, "CreateCylinder");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine("Error: No work part available. Please create or open a part first.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // CylinderBuilder를 사용하여 Cylinder 생성
                CylinderBuilder cylinderBuilder = workPart.Features.CreateCylinderBuilder(null);

                try
                {
                    // 기본 크기 설정 (직경 50mm, 높이 100mm)
                    cylinderBuilder.Diameter.RightHandSide = "50";
                    cylinderBuilder.Height.RightHandSide = "100";

                    // 원점과 방향 설정
                    Point3d origin = new Point3d(0, 0, 0);
                    Vector3d direction = new Vector3d(0, 0, 1);
                    cylinderBuilder.Origin = origin;
                    cylinderBuilder.Direction = direction;

                    Logger.Debug(ClassName, "Cylinder 파라미터 설정 완료: D50 x H100");

                    // Feature 생성
                    NXObject result = cylinderBuilder.Commit();

                    if (result != null)
                    {
                        Logger.Info(ClassName, "Cylinder 생성 완료");
                        session.ListingWindow.Open();
                        session.ListingWindow.WriteLine("Cylinder created successfully (D50 x H100 mm)");
                    }
                }
                finally
                {
                    cylinderBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Cylinder 생성 중 오류 발생", ex);
                if (session != null)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"Error creating cylinder: {ex.Message}");
                }
            }

            Logger.MethodExit(ClassName, "CreateCylinder");
        }

        /// <summary>
        /// Sphere 생성 명령
        /// </summary>
        public static void CreateSphere()
        {
            Logger.MethodEntry(ClassName, "CreateSphere");
            Session session = null;
            Part workPart = null;

            try
            {
                session = Session.GetSession();
                workPart = session.Parts.Work;

                if (workPart == null)
                {
                    Logger.Warning(ClassName, "작업 파트가 없습니다.");
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine("Error: No work part available. Please create or open a part first.");
                    return;
                }

                Logger.Info(ClassName, $"Work Part: {workPart.Name}");

                // SphereBuilder를 사용하여 Sphere 생성
                SphereBuilder sphereBuilder = workPart.Features.CreateSphereBuilder(null);

                try
                {
                    // 기본 크기 설정 (직경 80mm)
                    sphereBuilder.Diameter.RightHandSide = "80";

                    // 중심점 설정
                    Point3d center = new Point3d(0, 0, 0);
                    sphereBuilder.CenterPoint = workPart.Points.CreatePoint(center);

                    Logger.Debug(ClassName, "Sphere 파라미터 설정 완료: D80");

                    // Feature 생성
                    NXObject result = sphereBuilder.Commit();

                    if (result != null)
                    {
                        Logger.Info(ClassName, "Sphere 생성 완료");
                        session.ListingWindow.Open();
                        session.ListingWindow.WriteLine("Sphere created successfully (D80 mm)");
                    }
                }
                finally
                {
                    sphereBuilder.Destroy();
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "Sphere 생성 중 오류 발생", ex);
                if (session != null)
                {
                    session.ListingWindow.Open();
                    session.ListingWindow.WriteLine($"Error creating sphere: {ex.Message}");
                }
            }

            Logger.MethodExit(ClassName, "CreateSphere");
        }

        /// <summary>
        /// NX 언로드 옵션
        /// </summary>
        public static int GetUnloadOption(string arg)
        {
            return (int)Session.LibraryUnloadOption.Immediately;
        }
    }
}
