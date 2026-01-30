# Contact Analyzer 기능 개발 계획서

## 1. 개요

### 1.1 기능 설명

STEP 파일 추출 시 파트 간 접촉면을 자동으로 분석하여, 메쉬 생성 도구에서 Tied 경계조건으로 활용할 수 있는 접촉 정보 파일을 함께 출력하는 기능

### 1.2 목적

- CAD에서 CAE로 넘어갈 때 접촉 조건 수동 설정 시간 절감
- 대규모 어셈블리에서 접촉면 누락 방지
- Octree 기반 공간 분할로 대용량 모델에서도 효율적인 접촉 탐색

### 1.3 사용 시나리오

```
1. STEP Exporter 대화창 열기
2. 추출할 파트 선택
3. "Export Contact Info" 체크박스 활성화
4. Extract 버튼 클릭
5. 출력물:
   - 각 파트별 .step 파일
   - contact_info.json (접촉 관계 정보)
```

---

## 2. 기능 요구사항

### 2.1 UI 요구사항

| 구성요소 | 설명 |
|----------|------|
| Export Contact Info 체크박스 | 접촉 분석 활성화/비활성화 |
| Contact Tolerance 입력 | 접촉 판정 허용 오차 (기본값: 0.01mm) |
| 진행률 표시 | 접촉 분석 진행 상태 표시 |

### 2.2 기능 요구사항

| 기능 | 설명 |
|------|------|
| Octree 공간 분할 | 면의 Bounding Box 기반 공간 인덱싱 |
| 접촉면 탐지 | 두 면 간 최소 거리가 tolerance 이하인 쌍 찾기 |
| 접촉 정보 출력 | JSON 형식으로 접촉 관계 저장 |
| 면 식별자 매핑 | NX Face Tag → STEP 면 ID 매핑 |

### 2.3 출력 파일 형식

**contact_info.json:**

```json
{
  "version": "1.0",
  "tolerance_mm": 0.01,
  "generated": "2026-01-21T04:50:00",
  "parts": [
    {
      "name": "Housing",
      "step_file": "Housing.step",
      "face_count": 45
    },
    {
      "name": "Cover",
      "step_file": "Cover.step",
      "face_count": 32
    }
  ],
  "contacts": [
    {
      "id": 1,
      "type": "tied",
      "part1": {
        "name": "Housing",
        "face_id": 12,
        "face_type": "PLANAR"
      },
      "part2": {
        "name": "Cover",
        "face_id": 8,
        "face_type": "PLANAR"
      },
      "min_distance_mm": 0.0,
      "contact_area_mm2": 1250.5,
      "contact_point": [100.0, 50.0, 25.0]
    }
  ],
  "summary": {
    "total_contacts": 15,
    "tied_contacts": 15,
    "parts_analyzed": 5,
    "faces_analyzed": 234,
    "analysis_time_sec": 2.5
  }
}
```

---

## 3. 기술 설계

### 3.1 클래스 구조

```
KooNXAutomationSharp/
├── Features/
│   └── StepExporter/
│       ├── StepExporterDialog.cs      # 체크박스 추가
│       ├── StepExporterCommand.cs
│       ├── StepExportHelper.cs
│       ├── ContactAnalyzer.cs         # [신규] 접촉 분석 메인 클래스
│       ├── Octree.cs                  # [신규] Octree 공간 분할
│       └── ContactInfo.cs             # [신규] 접촉 정보 데이터 클래스
└── Utils/
    └── BoundingBoxHelper.cs           # [신규] Bounding Box 유틸리티
```

### 3.2 Octree 구조

```
        ┌─────────────────────────────────────┐
        │            Root Node               │
        │   (전체 어셈블리 Bounding Box)      │
        └─────────────────────────────────────┘
                         │
         ┌───────────────┼───────────────┐
         ▼               ▼               ▼
    ┌─────────┐    ┌─────────┐    ┌─────────┐
    │ Child 0 │    │ Child 1 │    │  ...    │  (8개 자식)
    │ (면 목록)│    │ (면 목록)│    │         │
    └─────────┘    └─────────┘    └─────────┘
```

**Octree 동작:**

1. 모든 면의 Bounding Box 계산
2. 전체 공간을 8분할 (Octree 구축)
3. 각 면을 해당 영역에 삽입
4. 같은 노드 또는 인접 노드의 면만 접촉 검사 → O(n²) → O(n log n)

### 3.3 클래스 상세

#### 3.3.1 Octree.cs

```csharp
namespace KooNXAutomationSharp.Features.StepExporter
{
    public class BoundingBox3D
    {
        public double MinX, MinY, MinZ;
        public double MaxX, MaxY, MaxZ;

        public bool Intersects(BoundingBox3D other);
        public BoundingBox3D Expand(double margin);
    }

    public class OctreeNode
    {
        public BoundingBox3D Bounds { get; }
        public List<FaceData> Faces { get; }
        public OctreeNode[] Children { get; }  // 8개
        public bool IsLeaf { get; }

        public void Insert(FaceData face);
        public List<FaceData> GetPotentialContacts(FaceData face);
    }

    public class Octree
    {
        private OctreeNode _root;
        private int _maxDepth = 8;
        private int _maxFacesPerNode = 10;

        public Octree(BoundingBox3D bounds);
        public void Insert(FaceData face);
        public List<(FaceData, FaceData)> GetPotentialContactPairs();
    }

    public class FaceData
    {
        public Face NxFace { get; set; }
        public Part OwnerPart { get; set; }
        public int FaceIndex { get; set; }
        public BoundingBox3D BoundingBox { get; set; }
        public string FaceType { get; set; }  // PLANAR, CYLINDRICAL, etc.
    }
}
```

#### 3.3.2 ContactAnalyzer.cs

```csharp
namespace KooNXAutomationSharp.Features.StepExporter
{
    public class ContactAnalyzer
    {
        private double _tolerance = 0.01;  // mm
        private Octree _octree;

        public ContactAnalyzer(double tolerance = 0.01);

        // 메인 분석 메서드
        public ContactAnalysisResult Analyze(
            List<Part> parts,
            Action<int, int, string> progressCallback = null);

        // 내부 메서드
        private void BuildOctree(List<Part> parts);
        private List<ContactPair> FindContacts();
        private bool CheckFaceContact(FaceData face1, FaceData face2);
        private double GetMinimumDistance(Face face1, Face face2);
        private double GetContactArea(Face face1, Face face2);
    }
}
```

#### 3.3.3 ContactInfo.cs

```csharp
namespace KooNXAutomationSharp.Features.StepExporter
{
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

    public class PartFaceInfo
    {
        public string PartName { get; set; }
        public int FaceId { get; set; }
        public string FaceType { get; set; }
    }

    public class PartInfo
    {
        public string Name { get; set; }
        public string StepFile { get; set; }
        public int FaceCount { get; set; }
    }

    public class AnalysisSummary
    {
        public int TotalContacts { get; set; }
        public int TiedContacts { get; set; }
        public int PartsAnalyzed { get; set; }
        public int FacesAnalyzed { get; set; }
        public double AnalysisTimeSec { get; set; }
    }

    public class ContactAnalysisResult
    {
        public string Version { get; set; } = "1.0";
        public double ToleranceMm { get; set; }
        public string Generated { get; set; }
        public List<PartInfo> Parts { get; set; }
        public List<ContactPair> Contacts { get; set; }
        public AnalysisSummary Summary { get; set; }

        // JSON 출력
        public void SaveToJson(string filePath);
    }
}
```

### 3.4 알고리즘 흐름

```
┌─────────────────────────────────────────────────────────────┐
│                    Contact Analysis Flow                     │
└─────────────────────────────────────────────────────────────┘

1. 입력: List<Part> parts, double tolerance

2. 면 데이터 수집
   ┌─────────────────────────────────────┐
   │ foreach part in parts              │
   │   foreach face in part.Bodies.Faces│
   │     - Bounding Box 계산            │
   │     - FaceData 생성                │
   └─────────────────────────────────────┘

3. Octree 구축
   ┌─────────────────────────────────────┐
   │ - 전체 Bounding Box 계산           │
   │ - Root 노드 생성                   │
   │ - 각 면을 Octree에 삽입            │
   │ - 노드 분할 (면 개수 > threshold)   │
   └─────────────────────────────────────┘

4. 잠재적 접촉 쌍 추출
   ┌─────────────────────────────────────┐
   │ - 같은 노드 내 면 쌍               │
   │ - 인접 노드 간 면 쌍               │
   │ - 같은 파트 내 면은 제외           │
   └─────────────────────────────────────┘

5. 정밀 접촉 검사
   ┌─────────────────────────────────────┐
   │ foreach (face1, face2) in pairs    │
   │   dist = GetMinimumDistance(...)   │
   │   if dist <= tolerance:            │
   │     - ContactPair 생성             │
   │     - 접촉 면적 계산               │
   └─────────────────────────────────────┘

6. 결과 출력
   ┌─────────────────────────────────────┐
   │ - ContactAnalysisResult 생성       │
   │ - JSON 파일 저장                   │
   └─────────────────────────────────────┘
```

### 3.5 NX Open API 사용

#### Bounding Box 계산

```csharp
UFSession ufSession = UFSession.GetUFSession();
double[] minCorner = new double[3];
double[] directions = new double[9];  // 3x3 matrix
double[] distances = new double[3];

ufSession.Modl.AskBoundingBoxExact(face.Tag, Tag.Null, minCorner, directions, distances);

BoundingBox3D box = new BoundingBox3D
{
    MinX = minCorner[0],
    MinY = minCorner[1],
    MinZ = minCorner[2],
    MaxX = minCorner[0] + distances[0],
    MaxY = minCorner[1] + distances[1],
    MaxZ = minCorner[2] + distances[2]
};
```

#### 면 간 최소 거리

```csharp
UFSession ufSession = UFSession.GetUFSession();
double[] pt1 = new double[3];
double[] pt2 = new double[3];
double minDist;

ufSession.Modl.AskMinimumDist(
    face1.Tag, face2.Tag,
    0, new double[3],
    0, new double[3],
    out minDist, pt1, pt2);
```

#### 면 유형 확인

```csharp
UFSession ufSession = UFSession.GetUFSession();
int faceType;
ufSession.Modl.AskFaceType(face.Tag, out faceType);

// faceType: 16=Planar, 17=Cylindrical, 18=Conical, 19=Spherical, etc.
string typeStr = faceType switch
{
    16 => "PLANAR",
    17 => "CYLINDRICAL",
    18 => "CONICAL",
    19 => "SPHERICAL",
    _ => "OTHER"
};
```

---

## 4. UI 목업

```
┌─────────────────────────────────────────────────────────────┐
│  STEP Exporter                                         [X]  │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  Parts to Export:                                           │
│  ┌─────────────────────────────────────────────────────┐   │
│  │ [✓] Assembly_Main                                   │   │
│  │ [✓] Part_Housing                                    │   │
│  │ [✓] Part_Cover                                      │   │
│  │ [✓] Part_Shaft                                      │   │
│  └─────────────────────────────────────────────────────┘   │
│                                                             │
│  [ Select All ]  [ Select None ]        Selected: 4/4      │
│                                                             │
│  ─────────────────────────────────────────────────────────  │
│                                                             │
│  Output Folder:                                             │
│  ┌─────────────────────────────────────────┐ [Browse]      │
│  │ D:\Projects\Export\STEP                 │               │
│  └─────────────────────────────────────────┘               │
│                                                             │
│  ─────────────────────────────────────────────────────────  │
│                                                             │
│  Options:                                                   │
│  ┌─────────────────────────────────────────────────────┐   │
│  │ [✓] Export Contact Info (Tied conditions)           │   │
│  │     Contact Tolerance: [ 0.01 ] mm                  │   │
│  └─────────────────────────────────────────────────────┘   │
│                                                             │
│  ─────────────────────────────────────────────────────────  │
│                                                             │
│  Progress: ████████████░░░░░░░░  Analyzing contacts...     │
│                                                             │
│              [ Extract ]          [ Cancel ]                │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

---

## 5. 구현 단계

### Phase 1: 데이터 구조 (1단계)

- [ ] BoundingBox3D 클래스 구현
- [ ] FaceData 클래스 구현
- [ ] ContactInfo.cs 데이터 클래스들 구현
- [ ] JSON 직렬화 테스트

### Phase 2: Octree 구현 (2단계)

- [ ] OctreeNode 클래스 구현
- [ ] Octree 클래스 구현
- [ ] Insert, GetPotentialContactPairs 메서드 구현
- [ ] 단위 테스트

### Phase 3: 접촉 분석 (3단계)

- [ ] ContactAnalyzer 클래스 구현
- [ ] BuildOctree 메서드 구현
- [ ] FindContacts 메서드 구현
- [ ] NX API 연동 (최소거리, 면적 계산)

### Phase 4: UI 통합 (4단계)

- [ ] StepExporterDialog에 체크박스 추가
- [ ] Tolerance 입력 필드 추가
- [ ] 진행률 표시 연동
- [ ] DialogPreview 업데이트

### Phase 5: 테스트 및 최적화 (5단계)

- [ ] 소규모 어셈블리 테스트 (10개 파트 이하)
- [ ] 대규모 어셈블리 테스트 (100개 파트 이상)
- [ ] 성능 프로파일링 및 최적화
- [ ] 문서화

---

## 6. 예상 파일 목록

### 신규 생성

| 파일 | 설명 |
|------|------|
| `Features/StepExporter/ContactAnalyzer.cs` | 접촉 분석 메인 클래스 |
| `Features/StepExporter/Octree.cs` | Octree 공간 분할 |
| `Features/StepExporter/ContactInfo.cs` | 접촉 정보 데이터 클래스 |
| `Utils/BoundingBoxHelper.cs` | Bounding Box 유틸리티 |

### 수정 필요

| 파일 | 수정 내용 |
|------|-----------|
| `Features/StepExporter/StepExporterDialog.cs` | 체크박스, Tolerance 입력 추가 |
| `Features/StepExporter/StepExportHelper.cs` | 접촉 분석 호출 연동 |
| `DialogPreview/Program.cs` | 미리보기 UI 업데이트 |
| `KooNXAutomationSharp.csproj` | 새 파일 참조 추가 |

---

## 7. 성능 고려사항

### 7.1 시간 복잡도

| 단계 | Naive | Octree 적용 |
|------|-------|-------------|
| 면 쌍 비교 | O(n²) | O(n log n) |
| 공간 구축 | - | O(n log n) |
| 메모리 | O(1) | O(n) |

### 7.2 예상 성능 (1000개 면 기준)

| 방법 | 비교 횟수 | 예상 시간 |
|------|-----------|-----------|
| 전수 비교 | 499,500 | ~50초 |
| Octree | ~10,000 | ~1초 |

### 7.3 최적화 전략

1. **Bounding Box 사전 필터링**: 면 간 BB가 겹치지 않으면 스킵
2. **병렬 처리**: 독립적인 노드는 Parallel.ForEach로 처리
3. **조기 종료**: 이미 접촉 판정된 면 쌍은 재검사 안 함
4. **캐싱**: 면 정보, BB 정보 한 번만 계산

---

## 8. 테스트 계획

### 8.1 단위 테스트

| 테스트 항목 | 설명 |
|-------------|------|
| BoundingBox 겹침 | 두 BB 교차 판정 |
| Octree 삽입 | 면 삽입 후 조회 |
| 접촉 판정 | 알려진 접촉 쌍 검출 |

### 8.2 통합 테스트

| 테스트 항목 | 설명 |
|-------------|------|
| 간단한 2박스 | 접촉면 1쌍 검출 |
| 다중 파트 | 여러 접촉면 검출 |
| JSON 출력 | 파일 생성 및 형식 검증 |

### 8.3 성능 테스트

| 테스트 항목 | 목표 |
|-------------|------|
| 100개 면 | < 1초 |
| 1000개 면 | < 5초 |
| 10000개 면 | < 30초 |

---

## 9. 출력 예시

### 9.1 contact_info.json 예시

```json
{
  "version": "1.0",
  "tolerance_mm": 0.01,
  "generated": "2026-01-21T05:00:00",
  "parts": [
    {
      "name": "Housing",
      "step_file": "Housing.step",
      "face_count": 45
    },
    {
      "name": "Cover",
      "step_file": "Cover.step",
      "face_count": 32
    },
    {
      "name": "Gasket",
      "step_file": "Gasket.step",
      "face_count": 6
    }
  ],
  "contacts": [
    {
      "id": 1,
      "type": "tied",
      "part1": {
        "name": "Housing",
        "face_id": 12,
        "face_type": "PLANAR"
      },
      "part2": {
        "name": "Gasket",
        "face_id": 1,
        "face_type": "PLANAR"
      },
      "min_distance_mm": 0.0,
      "contact_area_mm2": 850.25,
      "contact_point": [100.0, 50.0, 0.0]
    },
    {
      "id": 2,
      "type": "tied",
      "part1": {
        "name": "Gasket",
        "face_id": 2,
        "face_type": "PLANAR"
      },
      "part2": {
        "name": "Cover",
        "face_id": 8,
        "face_type": "PLANAR"
      },
      "min_distance_mm": 0.0,
      "contact_area_mm2": 850.25,
      "contact_point": [100.0, 50.0, 2.0]
    }
  ],
  "summary": {
    "total_contacts": 2,
    "tied_contacts": 2,
    "parts_analyzed": 3,
    "faces_analyzed": 83,
    "analysis_time_sec": 0.45
  }
}
```

---

## 10. 로그 출력 예시

```
[05:00:00.100] [INFO   ] [ContactAnalyzer] 접촉 분석 시작
[05:00:00.101] [INFO   ] [ContactAnalyzer] 분석 대상: 3개 파트, tolerance=0.01mm
[05:00:00.150] [DEBUG  ] [ContactAnalyzer] 면 데이터 수집 완료: 83개 면
[05:00:00.200] [DEBUG  ] [Octree] Octree 구축 시작
[05:00:00.220] [DEBUG  ] [Octree] Root BB: (-50,-50,-10) ~ (200,150,100)
[05:00:00.250] [DEBUG  ] [Octree] Octree 구축 완료: depth=4, nodes=73
[05:00:00.251] [INFO   ] [ContactAnalyzer] 잠재적 접촉 쌍: 156쌍
[05:00:00.300] [DEBUG  ] [ContactAnalyzer] 접촉 검사 중... (1/156)
[05:00:00.450] [DEBUG  ] [ContactAnalyzer] 접촉 발견: Housing.Face12 <-> Gasket.Face1
[05:00:00.500] [DEBUG  ] [ContactAnalyzer] 접촉 발견: Gasket.Face2 <-> Cover.Face8
[05:00:00.550] [INFO   ] [ContactAnalyzer] 접촉 분석 완료
[05:00:00.551] [INFO   ] [ContactAnalyzer] 결과: 2개 접촉 발견 (0.45초 소요)
[05:00:00.560] [INFO   ] [ContactAnalyzer] 저장: D:\Export\contact_info.json
```

---

## 11. 향후 확장 가능성

| 기능 | 설명 |
|------|------|
| 접촉 유형 분류 | Tied 외에 Sliding, Friction 등 구분 |
| 접촉면 시각화 | NX에서 접촉면 하이라이트 |
| 접촉 그룹 | 동일 접촉 조건끼리 그룹화 |
| 메쉬 도구 연동 | Hypermesh, ANSA 등 직접 연동 |
| 병렬 분석 | 대용량 모델 멀티스레드 처리 |

---

## 12. 의존성

### NX Open API

- `NXOpen.Session`
- `NXOpen.Part`
- `NXOpen.Body`
- `NXOpen.Face`
- `NXOpen.UF.UFSession`
- `NXOpen.UF.UFModl` (AskMinimumDist, AskBoundingBoxExact, AskFaceType)

### .NET Framework

- `System.Collections.Generic`
- `System.Linq`
- `System.IO`
- `System.Text.Json` 또는 수동 JSON 생성

---

## 13. 참고 자료

- NX Open .NET API Reference - UFModl
- Octree Data Structure (Wikipedia)
- docs/NXOpen_API_Detailed.md (프로젝트 내 API 문서)
- docs/Feature_StepExporter_Plan.md (STEP Exporter 계획서)
