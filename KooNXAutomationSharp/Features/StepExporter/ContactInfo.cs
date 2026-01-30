using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// 파트의 면 정보
    /// </summary>
    public class PartFaceInfo
    {
        public string PartName { get; set; }
        public int FaceId { get; set; }
        public string FaceType { get; set; }
    }

    /// <summary>
    /// 접촉 쌍 정보
    /// </summary>
    public class ContactPair
    {
        public int Id { get; set; }
        public string ContactType { get; set; } = "tied";
        public PartFaceInfo Part1 { get; set; }
        public PartFaceInfo Part2 { get; set; }
        public double MinDistanceMm { get; set; }
        public double ContactAreaMm2 { get; set; }
        public double[] ContactPoint { get; set; }
    }

    /// <summary>
    /// 파트 정보
    /// </summary>
    public class PartInfo
    {
        public string Name { get; set; }
        public string StepFile { get; set; }
        public int FaceCount { get; set; }
    }

    /// <summary>
    /// 분석 요약
    /// </summary>
    public class AnalysisSummary
    {
        public int TotalContacts { get; set; }
        public int TiedContacts { get; set; }
        public int PartsAnalyzed { get; set; }
        public int FacesAnalyzed { get; set; }
        public double AnalysisTimeSec { get; set; }
    }

    /// <summary>
    /// 접촉 분석 결과
    /// </summary>
    public class ContactAnalysisResult
    {
        public string Version { get; set; } = "1.0";
        public double ToleranceMm { get; set; }
        public string Generated { get; set; }
        public List<PartInfo> Parts { get; set; } = new List<PartInfo>();
        public List<ContactPair> Contacts { get; set; } = new List<ContactPair>();
        public AnalysisSummary Summary { get; set; } = new AnalysisSummary();

        /// <summary>
        /// JSON 파일로 저장
        /// </summary>
        public void SaveToJson(string filePath)
        {
            Logger.MethodEntry("ContactAnalysisResult", "SaveToJson", filePath);

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("{");

                // 기본 정보
                sb.AppendLine($"  \"version\": \"{Version}\",");
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "  \"tolerance_mm\": {0},", ToleranceMm));
                sb.AppendLine($"  \"generated\": \"{Generated}\",");

                // Parts 배열
                sb.AppendLine("  \"parts\": [");
                for (int i = 0; i < Parts.Count; i++)
                {
                    var part = Parts[i];
                    sb.AppendLine("    {");
                    sb.AppendLine($"      \"name\": \"{EscapeJson(part.Name)}\",");
                    sb.AppendLine($"      \"step_file\": \"{EscapeJson(part.StepFile)}\",");
                    sb.AppendLine($"      \"face_count\": {part.FaceCount}");
                    sb.Append("    }");
                    if (i < Parts.Count - 1) sb.Append(",");
                    sb.AppendLine();
                }
                sb.AppendLine("  ],");

                // Contacts 배열
                sb.AppendLine("  \"contacts\": [");
                for (int i = 0; i < Contacts.Count; i++)
                {
                    var contact = Contacts[i];
                    sb.AppendLine("    {");
                    sb.AppendLine($"      \"id\": {contact.Id},");
                    sb.AppendLine($"      \"type\": \"{contact.ContactType}\",");

                    // Part1
                    sb.AppendLine("      \"part1\": {");
                    sb.AppendLine($"        \"name\": \"{EscapeJson(contact.Part1.PartName)}\",");
                    sb.AppendLine($"        \"face_id\": {contact.Part1.FaceId},");
                    sb.AppendLine($"        \"face_type\": \"{contact.Part1.FaceType}\"");
                    sb.AppendLine("      },");

                    // Part2
                    sb.AppendLine("      \"part2\": {");
                    sb.AppendLine($"        \"name\": \"{EscapeJson(contact.Part2.PartName)}\",");
                    sb.AppendLine($"        \"face_id\": {contact.Part2.FaceId},");
                    sb.AppendLine($"        \"face_type\": \"{contact.Part2.FaceType}\"");
                    sb.AppendLine("      },");

                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "      \"min_distance_mm\": {0:F6},", contact.MinDistanceMm));
                    sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "      \"contact_area_mm2\": {0:F2},", contact.ContactAreaMm2));

                    // Contact Point
                    if (contact.ContactPoint != null && contact.ContactPoint.Length >= 3)
                    {
                        sb.AppendLine(string.Format(CultureInfo.InvariantCulture,
                            "      \"contact_point\": [{0:F3}, {1:F3}, {2:F3}]",
                            contact.ContactPoint[0], contact.ContactPoint[1], contact.ContactPoint[2]));
                    }
                    else
                    {
                        sb.AppendLine("      \"contact_point\": [0, 0, 0]");
                    }

                    sb.Append("    }");
                    if (i < Contacts.Count - 1) sb.Append(",");
                    sb.AppendLine();
                }
                sb.AppendLine("  ],");

                // Summary
                sb.AppendLine("  \"summary\": {");
                sb.AppendLine($"    \"total_contacts\": {Summary.TotalContacts},");
                sb.AppendLine($"    \"tied_contacts\": {Summary.TiedContacts},");
                sb.AppendLine($"    \"parts_analyzed\": {Summary.PartsAnalyzed},");
                sb.AppendLine($"    \"faces_analyzed\": {Summary.FacesAnalyzed},");
                sb.AppendLine(string.Format(CultureInfo.InvariantCulture, "    \"analysis_time_sec\": {0:F2}", Summary.AnalysisTimeSec));
                sb.AppendLine("  }");

                sb.AppendLine("}");

                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
                Logger.Info("ContactAnalysisResult", $"JSON 저장 완료: {filePath}");
            }
            catch (Exception ex)
            {
                Logger.Error("ContactAnalysisResult", "JSON 저장 실패", ex);
                throw;
            }

            Logger.MethodExit("ContactAnalysisResult", "SaveToJson");
        }

        /// <summary>
        /// JSON 문자열 이스케이프
        /// </summary>
        private string EscapeJson(string str)
        {
            if (string.IsNullOrEmpty(str)) return "";
            return str.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
        }
    }
}
