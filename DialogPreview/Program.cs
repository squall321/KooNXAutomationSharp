using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DialogPreview
{
    /// <summary>
    /// STEP Exporter 대화창 미리보기용 독립 프로그램
    /// NX 없이 대화창 디자인을 확인할 수 있음
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 미리보기용 대화창 실행
            StepExporterDialogPreview dialog = new StepExporterDialogPreview();
            Application.Run(dialog.CreateForm());
        }
    }

    /// <summary>
    /// STEP Exporter 대화창 미리보기
    /// 실제 StepExporterDialog.cs와 동일한 UI 구조
    /// </summary>
    public class StepExporterDialogPreview
    {
        // 테스트용 더미 데이터
        private List<string> _dummyParts = new List<string>
        {
            "Assembly_Main",
            "Part_Housing",
            "Part_Cover",
            "Part_Shaft",
            "Part_Bearing_001",
            "Part_Bearing_002",
            "Part_Gasket",
            "Part_Bolt_M8x20",
            "Part_Nut_M8",
            "Part_Washer_M8"
        };

        private string _outputFolder;

        // UI 컨트롤
        private Form _form;
        private CheckedListBox _partListBox;
        private TextBox _folderPathTextBox;
        private Label _statusLabel;
        private ProgressBar _progressBar;

        public StepExporterDialogPreview()
        {
            _outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// 폼 생성 및 반환
        /// </summary>
        public Form CreateForm()
        {
            _form = new Form
            {
                Text = "STEP Exporter (Preview)",
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
                Width = 200,
                Font = new Font("Segoe UI", 9)
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
                CheckOnClick = true,
                Font = new Font("Segoe UI", 9)
            };

            // 더미 파트 목록 추가 (모두 선택됨)
            foreach (string partName in _dummyParts)
            {
                _partListBox.Items.Add(partName, true);
            }

            _form.Controls.Add(_partListBox);
            yPos += 260;

            // Select All / Select None 버튼
            Button selectAllBtn = new Button
            {
                Text = "Select All",
                Left = 15,
                Top = yPos,
                Width = 100,
                Height = 28
            };
            selectAllBtn.Click += (s, e) => SelectAll(true);
            _form.Controls.Add(selectAllBtn);

            Button selectNoneBtn = new Button
            {
                Text = "Select None",
                Left = 125,
                Top = yPos,
                Width = 100,
                Height = 28
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
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9)
            };
            _form.Controls.Add(_statusLabel);

            _partListBox.ItemCheck += (s, e) =>
            {
                _form.BeginInvoke(new Action(() =>
                {
                    _statusLabel.Text = GetSelectionStatus();
                }));
            };

            yPos += 40;

            // 구분선
            Label separator1 = new Label
            {
                BorderStyle = BorderStyle.Fixed3D,
                Left = 15,
                Top = yPos,
                Width = 455,
                Height = 2
            };
            _form.Controls.Add(separator1);
            yPos += 15;

            // 출력 폴더 라벨
            Label folderLabel = new Label
            {
                Text = "Output Folder:",
                Left = 15,
                Top = yPos,
                Width = 100,
                Font = new Font("Segoe UI", 9)
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
                ReadOnly = true,
                Font = new Font("Segoe UI", 9)
            };
            _form.Controls.Add(_folderPathTextBox);

            // Browse 버튼
            Button browseBtn = new Button
            {
                Text = "Browse...",
                Left = 380,
                Top = yPos - 2,
                Width = 90,
                Height = 28
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
                Visible = true,
                Value = 0
            };
            _form.Controls.Add(_progressBar);
            yPos += 40;

            // Extract / Cancel 버튼
            Button extractBtn = new Button
            {
                Text = "Extract",
                Left = 260,
                Top = yPos,
                Width = 100,
                Height = 30
            };
            extractBtn.Click += OnExtractPreview;
            _form.Controls.Add(extractBtn);

            Button cancelBtn = new Button
            {
                Text = "Cancel",
                Left = 370,
                Top = yPos,
                Width = 100,
                Height = 30
            };
            cancelBtn.Click += (s, e) => _form.Close();
            _form.Controls.Add(cancelBtn);

            return _form;
        }

        private string GetSelectionStatus()
        {
            int selected = _partListBox?.CheckedItems.Count ?? _dummyParts.Count;
            int total = _dummyParts.Count;
            return $"Selected: {selected}/{total}";
        }

        private void SelectAll(bool select)
        {
            for (int i = 0; i < _partListBox.Items.Count; i++)
            {
                _partListBox.SetItemChecked(i, select);
            }
            _statusLabel.Text = GetSelectionStatus();
        }

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
                }
            }
        }

        private void OnExtractPreview(object sender, EventArgs e)
        {
            int selectedCount = _partListBox.CheckedItems.Count;

            if (selectedCount == 0)
            {
                MessageBox.Show("Please select at least one part to export.", "STEP Exporter",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 진행률 시뮬레이션
            _progressBar.Maximum = selectedCount;
            _progressBar.Value = 0;

            for (int i = 0; i < selectedCount; i++)
            {
                string partName = _partListBox.CheckedItems[i].ToString();
                _statusLabel.Text = $"Exporting: {partName} ({i + 1}/{selectedCount})";
                _progressBar.Value = i + 1;
                Application.DoEvents();
                System.Threading.Thread.Sleep(200); // 시뮬레이션 딜레이
            }

            _statusLabel.Text = GetSelectionStatus();

            // 결과 메시지
            string message = $"Export completed! (Preview)\n\n" +
                            $"Total: {selectedCount}\n" +
                            $"Success: {selectedCount}\n" +
                            $"Failed: 0\n\n" +
                            $"Output: {_outputFolder}";

            MessageBox.Show(message, "STEP Exporter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
