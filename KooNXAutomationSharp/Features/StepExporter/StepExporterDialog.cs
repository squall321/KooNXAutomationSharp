using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NXOpen;
using NXOpen.UF;
using KooNXAutomationSharp.Utils;

namespace KooNXAutomationSharp.Features.StepExporter
{
    /// <summary>
    /// STEP Exporter 대화창
    /// Windows Forms 기반 UI
    /// </summary>
    public class StepExporterDialog
    {
        private const string ClassName = "StepExporterDialog";

        // 데이터
        private List<Part> _availableParts;
        private List<bool> _selectedStates;
        private string _outputFolder;

        // UI 컨트롤
        private Form _form;
        private CheckedListBox _partListBox;
        private TextBox _folderPathTextBox;
        private Label _statusLabel;
        private ProgressBar _progressBar;

        public StepExporterDialog()
        {
            _availableParts = StepExportHelper.GetAllParts();
            _selectedStates = new List<bool>();
            _outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // 모든 파트 기본 선택
            foreach (var part in _availableParts)
            {
                _selectedStates.Add(true);
            }
        }

        /// <summary>
        /// 대화창 표시
        /// </summary>
        public void Show()
        {
            Logger.MethodEntry(ClassName, "Show");

            try
            {
                CreateForm();
                _form.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.Error(ClassName, "대화창 표시 오류", ex);
                MessageBox.Show($"Error: {ex.Message}", "STEP Exporter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Logger.MethodExit(ClassName, "Show");
        }

        /// <summary>
        /// 폼 생성
        /// </summary>
        private void CreateForm()
        {
            _form = new Form
            {
                Text = "STEP Exporter",
                Width = 500,
                Height = 550,
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            int yPos = 15;

            // 파트 리스트 라벨
            Label listLabel = new Label
            {
                Text = "Parts to Export:",
                Left = 15,
                Top = yPos,
                Width = 200
            };
            _form.Controls.Add(listLabel);
            yPos += 25;

            // 파트 리스트 (체크박스)
            _partListBox = new CheckedListBox
            {
                Left = 15,
                Top = yPos,
                Width = 455,
                Height = 250,
                CheckOnClick = true
            };

            // 파트 목록 추가
            for (int i = 0; i < _availableParts.Count; i++)
            {
                _partListBox.Items.Add(_availableParts[i].Leaf, _selectedStates[i]);
            }

            _form.Controls.Add(_partListBox);
            yPos += 260;

            // Select All / Select None 버튼
            Button selectAllBtn = new Button
            {
                Text = "Select All",
                Left = 15,
                Top = yPos,
                Width = 100
            };
            selectAllBtn.Click += (s, e) => SelectAll(true);
            _form.Controls.Add(selectAllBtn);

            Button selectNoneBtn = new Button
            {
                Text = "Select None",
                Left = 125,
                Top = yPos,
                Width = 100
            };
            selectNoneBtn.Click += (s, e) => SelectAll(false);
            _form.Controls.Add(selectNoneBtn);

            // 선택 개수 표시
            _statusLabel = new Label
            {
                Text = GetSelectionStatus(),
                Left = 300,
                Top = yPos + 5,
                Width = 170,
                TextAlign = System.Drawing.ContentAlignment.MiddleRight
            };
            _form.Controls.Add(_statusLabel);
            _partListBox.ItemCheck += (s, e) =>
            {
                // ItemCheck 이벤트는 변경 전에 발생하므로 BeginInvoke로 지연 처리
                _form.BeginInvoke(new Action(() =>
                {
                    _statusLabel.Text = GetSelectionStatus();
                }));
            };

            yPos += 40;

            // 구분선
            Label separator = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Left = 15,
                Top = yPos,
                Width = 455,
                Height = 2
            };
            _form.Controls.Add(separator);
            yPos += 15;

            // 출력 폴더 라벨
            Label folderLabel = new Label
            {
                Text = "Output Folder:",
                Left = 15,
                Top = yPos,
                Width = 100
            };
            _form.Controls.Add(folderLabel);
            yPos += 25;

            // 폴더 경로 텍스트박스
            _folderPathTextBox = new TextBox
            {
                Text = _outputFolder,
                Left = 15,
                Top = yPos,
                Width = 355,
                ReadOnly = true
            };
            _form.Controls.Add(_folderPathTextBox);

            // Browse 버튼
            Button browseBtn = new Button
            {
                Text = "Browse...",
                Left = 380,
                Top = yPos - 2,
                Width = 90
            };
            browseBtn.Click += OnBrowseFolder;
            _form.Controls.Add(browseBtn);
            yPos += 40;

            // 진행률 바
            _progressBar = new ProgressBar
            {
                Left = 15,
                Top = yPos,
                Width = 455,
                Height = 23,
                Visible = false
            };
            _form.Controls.Add(_progressBar);
            yPos += 40;

            // Extract / Cancel 버튼
            Button extractBtn = new Button
            {
                Text = "Extract",
                Left = 260,
                Top = yPos,
                Width = 100
            };
            extractBtn.Click += OnExtract;
            _form.Controls.Add(extractBtn);

            Button cancelBtn = new Button
            {
                Text = "Cancel",
                Left = 370,
                Top = yPos,
                Width = 100
            };
            cancelBtn.Click += (s, e) => _form.Close();
            _form.Controls.Add(cancelBtn);
        }

        /// <summary>
        /// 선택 상태 문자열 반환
        /// </summary>
        private string GetSelectionStatus()
        {
            int selected = _partListBox?.CheckedItems.Count ?? _selectedStates.FindAll(x => x).Count;
            int total = _availableParts.Count;
            return $"Selected: {selected}/{total}";
        }

        /// <summary>
        /// 전체 선택/해제
        /// </summary>
        private void SelectAll(bool select)
        {
            for (int i = 0; i < _partListBox.Items.Count; i++)
            {
                _partListBox.SetItemChecked(i, select);
            }
            _statusLabel.Text = GetSelectionStatus();
            Logger.Debug(ClassName, select ? "전체 선택" : "전체 해제");
        }

        /// <summary>
        /// 폴더 선택 대화창
        /// </summary>
        private void OnBrowseFolder(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select output folder for STEP files";
                dialog.SelectedPath = _outputFolder;
                dialog.ShowNewFolderButton = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _outputFolder = dialog.SelectedPath;
                    _folderPathTextBox.Text = _outputFolder;
                    Logger.Info(ClassName, $"출력 폴더 선택: {_outputFolder}");
                }
            }
        }

        /// <summary>
        /// STEP 추출 실행
        /// </summary>
        private void OnExtract(object sender, EventArgs e)
        {
            Logger.MethodEntry(ClassName, "OnExtract");

            // 선택된 파트 수집
            List<Part> selectedParts = new List<Part>();
            for (int i = 0; i < _partListBox.Items.Count; i++)
            {
                if (_partListBox.GetItemChecked(i))
                {
                    selectedParts.Add(_availableParts[i]);
                }
            }

            if (selectedParts.Count == 0)
            {
                MessageBox.Show("Please select at least one part to export.", "STEP Exporter",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 폴더 확인
            if (string.IsNullOrEmpty(_outputFolder) || !Directory.Exists(Path.GetDirectoryName(_outputFolder + "\\")))
            {
                MessageBox.Show("Please select a valid output folder.", "STEP Exporter",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Logger.Info(ClassName, $"추출 시작 - {selectedParts.Count}개 파트, 출력: {_outputFolder}");

            // 진행률 표시
            _progressBar.Visible = true;
            _progressBar.Minimum = 0;
            _progressBar.Maximum = selectedParts.Count;
            _progressBar.Value = 0;

            // 일괄 추출 실행
            BatchExportResult result = StepExportHelper.ExportMultiple(
                selectedParts,
                _outputFolder,
                (current, total, partName) =>
                {
                    _progressBar.Value = current;
                    _statusLabel.Text = $"Exporting: {partName} ({current}/{total})";
                    System.Windows.Forms.Application.DoEvents();
                });

            _progressBar.Visible = false;
            _statusLabel.Text = GetSelectionStatus();

            // 결과 표시
            string message = $"Export completed!\n\n" +
                            $"Total: {result.TotalCount}\n" +
                            $"Success: {result.SuccessCount}\n" +
                            $"Failed: {result.FailureCount}\n\n" +
                            $"Output: {_outputFolder}";

            if (result.FailureCount > 0)
            {
                message += "\n\nFailed parts:";
                foreach (var detail in result.Details)
                {
                    if (!detail.Success)
                    {
                        message += $"\n- {detail.PartName}: {detail.ErrorMessage}";
                    }
                }
            }

            MessageBox.Show(message, "STEP Exporter",
                result.FailureCount == 0 ? MessageBoxButtons.OK : MessageBoxButtons.OK,
                result.FailureCount == 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

            Logger.Info(ClassName, $"추출 완료 - 성공: {result.SuccessCount}, 실패: {result.FailureCount}");

            if (result.SuccessCount > 0 && result.FailureCount == 0)
            {
                _form.Close();
            }

            Logger.MethodExit(ClassName, "OnExtract");
        }
    }
}
