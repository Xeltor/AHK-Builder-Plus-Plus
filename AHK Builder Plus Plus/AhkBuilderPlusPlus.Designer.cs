namespace AHK_Builder_Plus_Plus
{
    partial class AhkBuilderPlusPlus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AhkBuilderPlusPlus));
            this.AhkTable = new System.Windows.Forms.DataGridView();
            this.spellDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.keybindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ahkDataSet = new System.Data.DataSet();
            this.ahkDataTable = new System.Data.DataTable();
            this.spell = new System.Data.DataColumn();
            this.keybind = new System.Data.DataColumn();
            this.color1 = new System.Data.DataColumn();
            this.color2 = new System.Data.DataColumn();
            this.settingBox = new System.Windows.Forms.GroupBox();
            this.ovaleScaleBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ahkToggleKeyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yOffsetBox = new System.Windows.Forms.TextBox();
            this.xOffsetBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wowBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.helpTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.KeybindPage = new System.Windows.Forms.TabPage();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.keybindBox = new System.Windows.Forms.GroupBox();
            this.visualizerButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.bindingBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.spellBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.finishBox = new System.Windows.Forms.GroupBox();
            this.FuzzyColorOne = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.SlowMatching = new System.Windows.Forms.RadioButton();
            this.AltMatching = new System.Windows.Forms.RadioButton();
            this.NormalMatching = new System.Windows.Forms.RadioButton();
            this.generateAhkButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.FuzzyColorTwo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.AhkTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataTable)).BeginInit();
            this.settingBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.KeybindPage.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.keybindBox.SuspendLayout();
            this.finishBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // AhkTable
            // 
            this.AhkTable.AutoGenerateColumns = false;
            this.AhkTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AhkTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.spellDataGridViewTextBoxColumn,
            this.keybindDataGridViewTextBoxColumn,
            this.color1DataGridViewTextBoxColumn,
            this.color2DataGridViewTextBoxColumn});
            this.AhkTable.DataMember = "AhkData";
            this.AhkTable.DataSource = this.ahkDataSet;
            this.AhkTable.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AhkTable.Location = new System.Drawing.Point(0, 183);
            this.AhkTable.Name = "AhkTable";
            this.AhkTable.Size = new System.Drawing.Size(707, 429);
            this.AhkTable.TabIndex = 3;
            // 
            // spellDataGridViewTextBoxColumn
            // 
            this.spellDataGridViewTextBoxColumn.DataPropertyName = "Spell";
            this.spellDataGridViewTextBoxColumn.HeaderText = "Spell";
            this.spellDataGridViewTextBoxColumn.Name = "spellDataGridViewTextBoxColumn";
            this.spellDataGridViewTextBoxColumn.Width = 120;
            // 
            // keybindDataGridViewTextBoxColumn
            // 
            this.keybindDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.keybindDataGridViewTextBoxColumn.DataPropertyName = "Keybind";
            this.keybindDataGridViewTextBoxColumn.HeaderText = "Keybind";
            this.keybindDataGridViewTextBoxColumn.Name = "keybindDataGridViewTextBoxColumn";
            // 
            // color1DataGridViewTextBoxColumn
            // 
            this.color1DataGridViewTextBoxColumn.DataPropertyName = "Color #1";
            this.color1DataGridViewTextBoxColumn.HeaderText = "Color #1";
            this.color1DataGridViewTextBoxColumn.Name = "color1DataGridViewTextBoxColumn";
            // 
            // color2DataGridViewTextBoxColumn
            // 
            this.color2DataGridViewTextBoxColumn.DataPropertyName = "Color #2";
            this.color2DataGridViewTextBoxColumn.HeaderText = "Color #2";
            this.color2DataGridViewTextBoxColumn.Name = "color2DataGridViewTextBoxColumn";
            // 
            // ahkDataSet
            // 
            this.ahkDataSet.DataSetName = "AhkDataSet";
            this.ahkDataSet.Tables.AddRange(new System.Data.DataTable[] {
            this.ahkDataTable});
            // 
            // ahkDataTable
            // 
            this.ahkDataTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.spell,
            this.keybind,
            this.color1,
            this.color2});
            this.ahkDataTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Color #1",
                        "Color #2"}, true)});
            this.ahkDataTable.PrimaryKey = new System.Data.DataColumn[] {
        this.color1,
        this.color2};
            this.ahkDataTable.TableName = "AhkData";
            // 
            // spell
            // 
            this.spell.ColumnName = "Spell";
            // 
            // keybind
            // 
            this.keybind.ColumnName = "Keybind";
            // 
            // color1
            // 
            this.color1.AllowDBNull = false;
            this.color1.ColumnName = "Color #1";
            // 
            // color2
            // 
            this.color2.AllowDBNull = false;
            this.color2.ColumnName = "Color #2";
            // 
            // settingBox
            // 
            this.settingBox.Controls.Add(this.ovaleScaleBox);
            this.settingBox.Controls.Add(this.label4);
            this.settingBox.Controls.Add(this.ahkToggleKeyBox);
            this.settingBox.Controls.Add(this.label3);
            this.settingBox.Controls.Add(this.yOffsetBox);
            this.settingBox.Controls.Add(this.xOffsetBox);
            this.settingBox.Controls.Add(this.label2);
            this.settingBox.Controls.Add(this.label1);
            this.settingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingBox.Location = new System.Drawing.Point(3, 3);
            this.settingBox.Name = "settingBox";
            this.settingBox.Size = new System.Drawing.Size(693, 151);
            this.settingBox.TabIndex = 1;
            this.settingBox.TabStop = false;
            this.settingBox.Text = "Settings";
            // 
            // ovaleScaleBox
            // 
            this.ovaleScaleBox.Location = new System.Drawing.Point(92, 71);
            this.ovaleScaleBox.MaxLength = 3;
            this.ovaleScaleBox.Name = "ovaleScaleBox";
            this.ovaleScaleBox.Size = new System.Drawing.Size(100, 20);
            this.ovaleScaleBox.TabIndex = 2;
            this.ovaleScaleBox.Text = "100";
            this.ovaleScaleBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OvaleScaleBox_KeyPress);
            this.ovaleScaleBox.Leave += new System.EventHandler(this.OvaleScaleBox_Leave);
            this.ovaleScaleBox.MouseEnter += new System.EventHandler(this.HelpTip_MouseEnter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ovale scale %:";
            // 
            // ahkToggleKeyBox
            // 
            this.ahkToggleKeyBox.Location = new System.Drawing.Point(92, 97);
            this.ahkToggleKeyBox.MaxLength = 32676;
            this.ahkToggleKeyBox.Name = "ahkToggleKeyBox";
            this.ahkToggleKeyBox.ReadOnly = true;
            this.ahkToggleKeyBox.Size = new System.Drawing.Size(100, 20);
            this.ahkToggleKeyBox.TabIndex = 3;
            this.ahkToggleKeyBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AhkToggleKeyBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ahk toggle key:";
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(92, 45);
            this.yOffsetBox.MaxLength = 5;
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(100, 20);
            this.yOffsetBox.TabIndex = 1;
            this.yOffsetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordinateBox_KeyPress);
            this.yOffsetBox.MouseEnter += new System.EventHandler(this.HelpTip_MouseEnter);
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(92, 19);
            this.xOffsetBox.MaxLength = 5;
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(100, 20);
            this.xOffsetBox.TabIndex = 0;
            this.xOffsetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordinateBox_KeyPress);
            this.xOffsetBox.MouseEnter += new System.EventHandler(this.HelpTip_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ovale V offset:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ovale H offset:";
            // 
            // wowBrowserDialog
            // 
            this.wowBrowserDialog.Description = "Please select your World of Warcraft _retail_ folder.";
            this.wowBrowserDialog.ShowNewFolderButton = false;
            // 
            // helpTip
            // 
            this.helpTip.AutoPopDelay = 10000;
            this.helpTip.InitialDelay = 500;
            this.helpTip.ReshowDelay = 100;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.KeybindPage);
            this.tabControl1.Controls.Add(this.settingsPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(707, 183);
            this.tabControl1.TabIndex = 4;
            // 
            // KeybindPage
            // 
            this.KeybindPage.Controls.Add(this.keybindBox);
            this.KeybindPage.Controls.Add(this.finishBox);
            this.KeybindPage.Location = new System.Drawing.Point(4, 22);
            this.KeybindPage.Name = "KeybindPage";
            this.KeybindPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeybindPage.Size = new System.Drawing.Size(699, 157);
            this.KeybindPage.TabIndex = 0;
            this.KeybindPage.Text = "Keybinds";
            this.KeybindPage.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.settingBox);
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsPage.Size = new System.Drawing.Size(699, 157);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // keybindBox
            // 
            this.keybindBox.Controls.Add(this.visualizerButton);
            this.keybindBox.Controls.Add(this.addButton);
            this.keybindBox.Controls.Add(this.bindingBox);
            this.keybindBox.Controls.Add(this.label7);
            this.keybindBox.Controls.Add(this.spellBox);
            this.keybindBox.Controls.Add(this.label6);
            this.keybindBox.Controls.Add(this.label5);
            this.keybindBox.Controls.Add(this.classBox);
            this.keybindBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.keybindBox.Location = new System.Drawing.Point(3, 3);
            this.keybindBox.Name = "keybindBox";
            this.keybindBox.Size = new System.Drawing.Size(470, 151);
            this.keybindBox.TabIndex = 3;
            this.keybindBox.TabStop = false;
            this.keybindBox.Text = "Keybinds";
            // 
            // visualizerButton
            // 
            this.visualizerButton.Location = new System.Drawing.Point(9, 118);
            this.visualizerButton.Margin = new System.Windows.Forms.Padding(0);
            this.visualizerButton.Name = "visualizerButton";
            this.visualizerButton.Size = new System.Drawing.Size(21, 23);
            this.visualizerButton.TabIndex = 7;
            this.visualizerButton.Text = "V";
            this.visualizerButton.UseVisualStyleBackColor = true;
            this.visualizerButton.Click += new System.EventHandler(this.VisualizerButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(60, 118);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(404, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // bindingBox
            // 
            this.bindingBox.Location = new System.Drawing.Point(60, 69);
            this.bindingBox.MaxLength = 32676;
            this.bindingBox.Name = "bindingBox";
            this.bindingBox.ReadOnly = true;
            this.bindingBox.Size = new System.Drawing.Size(404, 20);
            this.bindingBox.TabIndex = 5;
            this.bindingBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BindingBox_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Keybind:";
            // 
            // spellBox
            // 
            this.spellBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.spellBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.spellBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.spellBox.Enabled = false;
            this.spellBox.FormattingEnabled = true;
            this.spellBox.Location = new System.Drawing.Point(60, 44);
            this.spellBox.MaxDropDownItems = 15;
            this.spellBox.Name = "spellBox";
            this.spellBox.Size = new System.Drawing.Size(404, 21);
            this.spellBox.Sorted = true;
            this.spellBox.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Spell:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Class:";
            // 
            // classBox
            // 
            this.classBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.classBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.classBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classBox.FormattingEnabled = true;
            this.classBox.Location = new System.Drawing.Point(60, 17);
            this.classBox.MaxDropDownItems = 15;
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(404, 21);
            this.classBox.Sorted = true;
            this.classBox.TabIndex = 0;
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.ClassBox_SelectedIndexChanged);
            // 
            // finishBox
            // 
            this.finishBox.Controls.Add(this.FuzzyColorTwo);
            this.finishBox.Controls.Add(this.FuzzyColorOne);
            this.finishBox.Controls.Add(this.label8);
            this.finishBox.Controls.Add(this.SlowMatching);
            this.finishBox.Controls.Add(this.AltMatching);
            this.finishBox.Controls.Add(this.NormalMatching);
            this.finishBox.Controls.Add(this.generateAhkButton);
            this.finishBox.Controls.Add(this.loadButton);
            this.finishBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.finishBox.Location = new System.Drawing.Point(479, 3);
            this.finishBox.Name = "finishBox";
            this.finishBox.Size = new System.Drawing.Size(217, 151);
            this.finishBox.TabIndex = 4;
            this.finishBox.TabStop = false;
            this.finishBox.Text = "Finish";
            // 
            // FuzzyColorOne
            // 
            this.FuzzyColorOne.AutoSize = true;
            this.FuzzyColorOne.Cursor = System.Windows.Forms.Cursors.Default;
            this.FuzzyColorOne.Location = new System.Drawing.Point(75, 78);
            this.FuzzyColorOne.Name = "FuzzyColorOne";
            this.FuzzyColorOne.Size = new System.Drawing.Size(95, 17);
            this.FuzzyColorOne.TabIndex = 11;
            this.FuzzyColorOne.Text = "Fuzzy Color #1";
            this.FuzzyColorOne.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Color matching method*";
            this.helpTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // SlowMatching
            // 
            this.SlowMatching.AutoSize = true;
            this.SlowMatching.Cursor = System.Windows.Forms.Cursors.Default;
            this.SlowMatching.Location = new System.Drawing.Point(9, 97);
            this.SlowMatching.Name = "SlowMatching";
            this.SlowMatching.Size = new System.Drawing.Size(48, 17);
            this.SlowMatching.TabIndex = 9;
            this.SlowMatching.Text = "Slow";
            this.SlowMatching.UseVisualStyleBackColor = true;
            // 
            // AltMatching
            // 
            this.AltMatching.AutoSize = true;
            this.AltMatching.Location = new System.Drawing.Point(9, 78);
            this.AltMatching.Name = "AltMatching";
            this.AltMatching.Size = new System.Drawing.Size(37, 17);
            this.AltMatching.TabIndex = 8;
            this.AltMatching.Text = "Alt";
            this.AltMatching.UseVisualStyleBackColor = true;
            // 
            // NormalMatching
            // 
            this.NormalMatching.AutoSize = true;
            this.NormalMatching.Checked = true;
            this.NormalMatching.Location = new System.Drawing.Point(9, 59);
            this.NormalMatching.Name = "NormalMatching";
            this.NormalMatching.Size = new System.Drawing.Size(58, 17);
            this.NormalMatching.TabIndex = 7;
            this.NormalMatching.TabStop = true;
            this.NormalMatching.Text = "Normal";
            this.NormalMatching.UseVisualStyleBackColor = true;
            // 
            // generateAhkButton
            // 
            this.generateAhkButton.Location = new System.Drawing.Point(6, 118);
            this.generateAhkButton.Name = "generateAhkButton";
            this.generateAhkButton.Size = new System.Drawing.Size(205, 23);
            this.generateAhkButton.TabIndex = 2;
            this.generateAhkButton.Text = "Generate AHK";
            this.generateAhkButton.UseVisualStyleBackColor = true;
            this.generateAhkButton.Click += new System.EventHandler(this.GenerateAhkButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 15);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(205, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // FuzzyColorTwo
            // 
            this.FuzzyColorTwo.AutoSize = true;
            this.FuzzyColorTwo.Cursor = System.Windows.Forms.Cursors.Default;
            this.FuzzyColorTwo.Location = new System.Drawing.Point(75, 97);
            this.FuzzyColorTwo.Name = "FuzzyColorTwo";
            this.FuzzyColorTwo.Size = new System.Drawing.Size(95, 17);
            this.FuzzyColorTwo.TabIndex = 12;
            this.FuzzyColorTwo.Text = "Fuzzy Color #2";
            this.FuzzyColorTwo.UseVisualStyleBackColor = true;
            // 
            // AhkBuilderPlusPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 612);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.AhkTable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(723, 650);
            this.MinimumSize = new System.Drawing.Size(723, 650);
            this.Name = "AhkBuilderPlusPlus";
            this.Text = "AHK Builder++";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AhkBuilderPlusPlus_FormClosing);
            this.Load += new System.EventHandler(this.AhkBuilderPlusPlus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AhkTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataTable)).EndInit();
            this.settingBox.ResumeLayout(false);
            this.settingBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.KeybindPage.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.keybindBox.ResumeLayout(false);
            this.keybindBox.PerformLayout();
            this.finishBox.ResumeLayout(false);
            this.finishBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView AhkTable;
        private System.Windows.Forms.GroupBox settingBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xOffsetBox;
        private System.Windows.Forms.TextBox yOffsetBox;
        private System.Windows.Forms.TextBox ahkToggleKeyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ovaleScaleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog wowBrowserDialog;
        private System.Data.DataSet ahkDataSet;
        private System.Data.DataTable ahkDataTable;
        private System.Data.DataColumn spell;
        private System.Data.DataColumn keybind;
        private System.Data.DataColumn color1;
        private System.Data.DataColumn color2;
        private System.Windows.Forms.DataGridViewTextBoxColumn spellDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keybindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn color1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn color2DataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolTip helpTip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage KeybindPage;
        private System.Windows.Forms.GroupBox keybindBox;
        private System.Windows.Forms.Button visualizerButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox bindingBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox spellBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.GroupBox finishBox;
        private System.Windows.Forms.RadioButton FuzzyColorTwo;
        private System.Windows.Forms.RadioButton FuzzyColorOne;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton SlowMatching;
        private System.Windows.Forms.RadioButton AltMatching;
        private System.Windows.Forms.RadioButton NormalMatching;
        private System.Windows.Forms.Button generateAhkButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.TabPage settingsPage;
    }
}

