using System;

namespace KooNXAutomationSharp.Utils
{
    /// <summary>
    /// NX 독립적인 기하학 유틸리티 - 단위 테스트 가능
    /// </summary>
    public static class GeometryUtils
    {
        public static double Distance(double[] p1, double[] p2)
        {
            double dx = p2[0] - p1[0];
            double dy = p2[1] - p1[1];
            double dz = p2[2] - p1[2];
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        public static double[] MidPoint(double[] p1, double[] p2)
        {
            return new double[]
            {
                (p1[0] + p2[0]) / 2.0,
                (p1[1] + p2[1]) / 2.0,
                (p1[2] + p2[2]) / 2.0
            };
        }
    }
}
