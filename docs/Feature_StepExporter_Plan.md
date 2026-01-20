# STEP Exporter 기능 개발 계획서

## 1. 개요

### 1.1 기능 설명
NX 어셈블리에서 모든 파트를 리스트로 표시하고, 사용자가 선택한 파트들을 일괄적으로 STEP 파일로 추출하는 대화창 기반 기능

### 1.2 목적
- 어셈블리 내 다수의 파트를 개별 STEP 파일로 빠르게 추출
- 선택적 추출을 통한 유연한 작업 흐름 지원
- 반복 작업 자동화로 생산성 향상

---

## 2. 기능 요구사항

### 2.1 UI 요구사항

| 구성요소 | 설명 |
|----------|------|
| 파트 리스트 | 현재 세션의 모든 파트를 체크박스와 함께 리스트로 표시 |
| Select All 버튼 | 모든 파트 선택 |
| Select None 버튼 | 모든 파트 선택 해제 |
| 출력 폴더 경로 | 텍스트 필드로 경로 표시 |
| Browse 버튼 | 폴더 선택 대화창 열기 |
| Extract 버튼 | 선택된 파트들을 STEP으로 추출 |
| Cancel 버튼 | 대화창 닫기 |
| 진행 상태 표시 | 추출 진행률 표시 (선택사항) |

### 2.2 기능 요구사항

| 기능 | 설명 |
|------|------|
| 파트 목록 조회 | Session.Parts에서 모든 로드된 파트 가져오기 |
| 체크박스 선택 | 개별 파트 선택/해제 |
| 전체 선택/해제 | Select All / Select None |
| 폴더 선택 | FolderBrowserDialog로 출력 경로 지정 |
| STEP 추출 | 각 파트를 `{파트이름}.step`으로 저장 |
| 결과 보고 | 성공/실패 파트 수 표시 |

### 2.3 출력 규칙
- 파일명: `{Part.Leaf}.step` (확장자 제외한 파트 이름)
- 중복 파일명 처리: `{파트이름}_1.step`, `{파트이름}_2.step` 형식
- STEP 버전: AP214 (기본값)

---

## 3. 기술 설계

### 3.1 클래스 구조

```
KooNXAutomationSharp/
├── Features/
│   └── StepExporter/              # STEP Exporter 기능 전용 폴더
│       ├── StepExporterDialog.cs  # 대화창 UI 클래스
│       ├── StepExporterCommand.cs # 메뉴 호출 진입점
│       └── StepExportHelper.cs    # STEP 추출 유틸리티
├── Utils/                         # 공용 유틸리티 (여러 기능에서 사용)
│   ├── Logger.cs
│   └── GeometryUtils.cs
└── MenuScript/
    └── KooNXAutomation.men
```

**폴더 구조 원칙:**

- `Features/{기능명}/` - 각 기능별 전용 폴더 (Dialog, Command, Helper 등 모두 포함)
- `Utils/` - 여러 기능에서 공용으로 사용하는 유틸리티만
- 기능이 추가될 때마다 `Features/` 하위에 새 폴더 생성

### 3.2 클래스 상세

#### 3.2.1 StepExporterDialog.cs
```csharp
namespace KooNXAutomationSharp.Features.StepExporter
{
    public class StepExporterDialog
    {
        // UI 컨트롤
        private NXOpen.BlockStyler.BlockDialog theDialog;
        private NXOpen.BlockStyler.ListBox partListBox;
        private NXOpen.BlockStyler.Button selectAllButton;
        private NXOpen.BlockStyler.Button selectNoneButton;
        private NXOpen.BlockStyler.StringBlock folderPathField;
        private NXOpen.BlockStyler.Button browseButton;

        // 데이터
        private List<Part> availableParts;
        private List<bool> selectedStates;
        private string outputFolder;

        // 메서드
        public void Show();
        public void Initialize();
        private void LoadPartList();
        private void OnSelectAll();
        private void OnSelectNone();
        private void OnBrowseFolder();
        private void OnExtract();
        private void OnCancel();
    }
}
```

#### 3.2.2 StepExportHelper.cs
```csharp
namespace KooNXAutomationSharp.Features.StepExporter
{
    public static class StepExportHelper
    {
        // STEP 추출 실행
        public static ExportResult ExportToStep(Part part, string outputPath);

        // 파일명 중복 처리
        public static string GetUniqueFileName(string folder, string baseName);

        // 일괄 추출
        public static BatchExportResult ExportMultiple(
            List<Part> parts,
            string outputFolder,
            Action<int, int> progressCallback);
    }

    public class ExportResult
    {
        public bool Success { get; set; }
        public string FilePath { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class BatchExportResult
    {
        public int TotalCount { get; set; }
        public int SuccessCount { get; set; }
        public int FailureCount { get; set; }
        public List<ExportResult> Details { get; set; }
    }
}
```

### 3.3 NX Open API 사용

#### 파트 목록 조회
```csharp
Session session = Session.GetSession();
PartCollection parts = session.Parts;

foreach (Part part in parts)
{
    string partName = part.Leaf;  // 파일명 (확장자 제외)
    string fullPath = part.FullPath;
}
```

#### STEP 추출
```csharp
// StepCreator를 사용한 STEP 추출
StepCreator stepCreator = session.DexManager.CreateStepCreator();

stepCreator.ExportAs = StepCreator.ExportAsOption.Ap214;
stepCreator.InputFile = part.FullPath;
stepCreator.OutputFile = outputStepPath;
stepCreator.FileSaveFlag = false;
stepCreator.LayerMask = "1-256";

// 추출 실행
NXObject result = stepCreator.Commit();
stepCreator.Destroy();
```

#### Block Styler 대화창 (대안: Windows Forms)
```csharp
// Block Styler 사용 시
string dlxPath = "StepExporterDialog.dlx";
theDialog = theUI.CreateDialog(dlxPath);
theDialog.Show();

// 또는 Windows Forms 사용 시
using System.Windows.Forms;
Form dialog = new StepExporterForm();
dialog.ShowDialog();
```

---

## 4. UI 목업

```
┌─────────────────────────────────────────────────────────┐
│  STEP Exporter                                     [X]  │
├─────────────────────────────────────────────────────────┤
│                                                         │
│  Parts to Export:                                       │
│  ┌─────────────────────────────────────────────────┐   │
│  │ [✓] Assembly_Main                               │   │
│  │ [✓] Part_Housing                                │   │
│  │ [ ] Part_Cover                                  │   │
│  │ [✓] Part_Shaft                                  │   │
│  │ [✓] Part_Bearing_001                            │   │
│  │ [✓] Part_Bearing_002                            │   │
│  │ [ ] Part_Gasket                                 │   │
│  │ [✓] Part_Bolt_M8x20                             │   │
│  │                                                 │   │
│  └─────────────────────────────────────────────────┘   │
│                                                         │
│  [ Select All ]  [ Select None ]     Selected: 6/8     │
│                                                         │
│  ─────────────────────────────────────────────────────  │
│                                                         │
│  Output Folder:                                         │
│  ┌─────────────────────────────────────────┐ [Browse]  │
│  │ D:\Projects\Export\STEP                 │           │
│  └─────────────────────────────────────────┘           │
│                                                         │
│  ─────────────────────────────────────────────────────  │
│                                                         │
│  Progress: ████████████░░░░░░░░  6/8 (75%)             │
│                                                         │
│              [ Extract ]          [ Cancel ]            │
│                                                         │
└─────────────────────────────────────────────────────────┘
```

---

## 5. 구현 단계

### Phase 1: 기본 구조 (1단계)
- [ ] StepExportHelper.cs 생성 - STEP 추출 로직
- [ ] 단일 파트 STEP 추출 테스트
- [ ] 로깅 통합

### Phase 2: 대화창 UI (2단계)
- [ ] StepExporterDialog.cs 생성
- [ ] Block Styler 또는 Windows Forms 선택
- [ ] .dlx 파일 생성 (Block Styler 사용 시)
- [ ] 파트 리스트 표시 기능
- [ ] 체크박스 선택 기능

### Phase 3: 기능 연결 (3단계)
- [ ] Select All / Select None 구현
- [ ] 폴더 브라우저 연결
- [ ] Extract 버튼 - 일괄 추출 연결
- [ ] 진행률 표시

### Phase 4: 메뉴 통합 (4단계)
- [ ] ExportCommands.cs에 명령어 추가
- [ ] MenuScript 업데이트
- [ ] 빌드 및 테스트

### Phase 5: 마무리 (5단계)
- [ ] 오류 처리 강화
- [ ] 중복 파일명 처리
- [ ] 결과 리포트 대화창
- [ ] 문서화

---

## 6. 예상 파일 목록

### 신규 생성

| 파일 | 설명 |
|------|------|
| `Features/StepExporter/StepExporterDialog.cs` | 대화창 UI 클래스 |
| `Features/StepExporter/StepExporterCommand.cs` | 메뉴 호출 진입점 |
| `Features/StepExporter/StepExportHelper.cs` | STEP 추출 유틸리티 |
| `Features/StepExporter/StepExporterDialog.dlx` | Block Styler 정의 (선택) |

### 수정 필요

| 파일                              | 수정 내용                        |
|-----------------------------------|----------------------------------|
| `MenuScript/KooNXAutomation.men`  | STEP Exporter 메뉴 항목 추가     |
| `KooNXAutomationSharp.csproj`     | 새 파일 참조 추가                |

---

## 7. 의존성

### NX Open API
- `NXOpen.Session`
- `NXOpen.Part`
- `NXOpen.PartCollection`
- `NXOpen.StepCreator` (DexManager)
- `NXOpen.BlockStyler` (UI 사용 시)

### .NET Framework
- `System.Windows.Forms` (Windows Forms UI 사용 시)
- `System.IO` (파일 경로 처리)

---

## 8. 테스트 계획

### 8.1 단위 테스트
| 테스트 항목 | 설명 |
|-------------|------|
| 단일 파트 추출 | 하나의 파트를 STEP으로 추출 |
| 파일명 생성 | 특수문자, 공백 처리 확인 |
| 중복 파일명 | 동일 이름 파트 처리 |

### 8.2 통합 테스트
| 테스트 항목 | 설명 |
|-------------|------|
| 다중 파트 추출 | 여러 파트 일괄 추출 |
| 대화창 기능 | 모든 UI 요소 동작 확인 |
| 취소 처리 | 추출 중 취소 시 동작 |

### 8.3 예외 상황
| 테스트 항목 | 예상 동작 |
|-------------|-----------|
| 파트 없음 | "No parts available" 메시지 |
| 잘못된 경로 | 오류 메시지 및 재선택 요청 |
| 쓰기 권한 없음 | 오류 메시지 표시 |
| 추출 실패 | 실패 파트 목록 표시 후 계속 진행 |

---

## 9. 로그 출력 예시

```
[14:32:15.123] [INFO   ] [StepExporter] STEP Exporter 대화창 열림
[14:32:15.125] [DEBUG  ] [StepExporter] 파트 목록 로드: 8개 파트 발견
[14:32:20.456] [INFO   ] [StepExporter] 추출 시작 - 선택된 파트: 6개
[14:32:20.457] [INFO   ] [StepExporter] 출력 폴더: D:\Projects\Export\STEP
[14:32:20.789] [DEBUG  ] [StepExporter] [1/6] Part_Housing 추출 중...
[14:32:21.234] [INFO   ] [StepExporter] [1/6] Part_Housing.step 추출 완료
[14:32:21.235] [DEBUG  ] [StepExporter] [2/6] Part_Shaft 추출 중...
[14:32:21.567] [INFO   ] [StepExporter] [2/6] Part_Shaft.step 추출 완료
...
[14:32:25.890] [INFO   ] [StepExporter] 추출 완료 - 성공: 6, 실패: 0
[14:32:25.891] [INFO   ] [StepExporter] STEP Exporter 대화창 닫힘
```

---

## 10. 향후 확장 가능성

| 기능 | 설명 |
|------|------|
| 다른 포맷 지원 | IGES, Parasolid, JT 등 추가 |
| 필터 기능 | 파트 이름으로 필터링 |
| 설정 저장 | 마지막 사용 폴더 기억 |
| 배치 처리 | 파일 목록에서 직접 불러오기 |
| 명명 규칙 | 접두사/접미사 추가 옵션 |

---

## 11. 참고 자료

- NX Open .NET API Reference - StepCreator
- NX Open .NET API Reference - BlockStyler
- NX Block Styler User Guide
- docs/NXOpen_API_Detailed.md (프로젝트 내 API 문서)
