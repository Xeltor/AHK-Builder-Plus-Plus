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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AhkBuilderPlusPlus));
            this.finishBox = new System.Windows.Forms.GroupBox();
            this.generateAhkButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
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
            this.lockSettingsButton = new System.Windows.Forms.Button();
            this.ovaleScaleBox = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ahkToggleKeyBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yOffsetBox = new System.Windows.Forms.TextBox();
            this.xOffsetBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.keybindBox = new System.Windows.Forms.GroupBox();
            this.addButton = new System.Windows.Forms.Button();
            this.bindingBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.spellBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.wowBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.finishBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AhkTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataTable)).BeginInit();
            this.settingBox.SuspendLayout();
            this.keybindBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // finishBox
            // 
            this.finishBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.finishBox.Controls.Add(this.generateAhkButton);
            this.finishBox.Controls.Add(this.saveButton);
            this.finishBox.Controls.Add(this.loadButton);
            this.finishBox.Location = new System.Drawing.Point(566, 12);
            this.finishBox.Name = "finishBox";
            this.finishBox.Size = new System.Drawing.Size(129, 147);
            this.finishBox.TabIndex = 2;
            this.finishBox.TabStop = false;
            this.finishBox.Text = "Finish";
            // 
            // generateAhkButton
            // 
            this.generateAhkButton.Location = new System.Drawing.Point(6, 118);
            this.generateAhkButton.Name = "generateAhkButton";
            this.generateAhkButton.Size = new System.Drawing.Size(116, 23);
            this.generateAhkButton.TabIndex = 2;
            this.generateAhkButton.Text = "Generate AHK";
            this.generateAhkButton.UseVisualStyleBackColor = true;
            this.generateAhkButton.Click += new System.EventHandler(this.generateAhkButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(6, 48);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(116, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(6, 19);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(116, 23);
            this.loadButton.TabIndex = 0;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.LoadButton_Click);
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
            this.AhkTable.Location = new System.Drawing.Point(0, 166);
            this.AhkTable.Name = "AhkTable";
            this.AhkTable.Size = new System.Drawing.Size(707, 410);
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
            this.settingBox.Controls.Add(this.lockSettingsButton);
            this.settingBox.Controls.Add(this.ovaleScaleBox);
            this.settingBox.Controls.Add(this.label4);
            this.settingBox.Controls.Add(this.ahkToggleKeyBox);
            this.settingBox.Controls.Add(this.label3);
            this.settingBox.Controls.Add(this.yOffsetBox);
            this.settingBox.Controls.Add(this.xOffsetBox);
            this.settingBox.Controls.Add(this.label2);
            this.settingBox.Controls.Add(this.label1);
            this.settingBox.Location = new System.Drawing.Point(12, 12);
            this.settingBox.Name = "settingBox";
            this.settingBox.Size = new System.Drawing.Size(200, 147);
            this.settingBox.TabIndex = 1;
            this.settingBox.TabStop = false;
            this.settingBox.Text = "Settings";
            // 
            // lockSettingsButton
            // 
            this.lockSettingsButton.Location = new System.Drawing.Point(7, 118);
            this.lockSettingsButton.Name = "lockSettingsButton";
            this.lockSettingsButton.Size = new System.Drawing.Size(187, 23);
            this.lockSettingsButton.TabIndex = 4;
            this.lockSettingsButton.Text = "Lock";
            this.lockSettingsButton.UseVisualStyleBackColor = true;
            this.lockSettingsButton.Click += new System.EventHandler(this.LockSettingsButton_Click);
            // 
            // ovaleScaleBox
            // 
            this.ovaleScaleBox.Location = new System.Drawing.Point(94, 69);
            this.ovaleScaleBox.Mask = "0.0";
            this.ovaleScaleBox.Name = "ovaleScaleBox";
            this.ovaleScaleBox.Size = new System.Drawing.Size(100, 20);
            this.ovaleScaleBox.TabIndex = 2;
            this.ovaleScaleBox.Text = "10";
            this.ovaleScaleBox.Leave += new System.EventHandler(this.OvaleScaleBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ovale scale:";
            // 
            // ahkToggleKeyBox
            // 
            this.ahkToggleKeyBox.Location = new System.Drawing.Point(94, 94);
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
            this.label3.Location = new System.Drawing.Point(7, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ahk toggle key:";
            // 
            // yOffsetBox
            // 
            this.yOffsetBox.Location = new System.Drawing.Point(94, 43);
            this.yOffsetBox.MaxLength = 4;
            this.yOffsetBox.Name = "yOffsetBox";
            this.yOffsetBox.Size = new System.Drawing.Size(100, 20);
            this.yOffsetBox.TabIndex = 1;
            this.yOffsetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordinateBox_KeyPress);
            // 
            // xOffsetBox
            // 
            this.xOffsetBox.Location = new System.Drawing.Point(94, 17);
            this.xOffsetBox.MaxLength = 4;
            this.xOffsetBox.Name = "xOffsetBox";
            this.xOffsetBox.Size = new System.Drawing.Size(100, 20);
            this.xOffsetBox.TabIndex = 0;
            this.xOffsetBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CoordinateBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ovale Y offset:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ovale X offset:";
            // 
            // keybindBox
            // 
            this.keybindBox.Controls.Add(this.addButton);
            this.keybindBox.Controls.Add(this.bindingBox);
            this.keybindBox.Controls.Add(this.label7);
            this.keybindBox.Controls.Add(this.spellBox);
            this.keybindBox.Controls.Add(this.label6);
            this.keybindBox.Controls.Add(this.label5);
            this.keybindBox.Controls.Add(this.classBox);
            this.keybindBox.Location = new System.Drawing.Point(218, 12);
            this.keybindBox.Name = "keybindBox";
            this.keybindBox.Size = new System.Drawing.Size(342, 147);
            this.keybindBox.TabIndex = 0;
            this.keybindBox.TabStop = false;
            this.keybindBox.Text = "Keybinds";
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(60, 118);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(276, 23);
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
            this.bindingBox.Size = new System.Drawing.Size(276, 20);
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
            this.spellBox.Location = new System.Drawing.Point(60, 43);
            this.spellBox.MaxDropDownItems = 15;
            this.spellBox.Name = "spellBox";
            this.spellBox.Size = new System.Drawing.Size(276, 21);
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
            this.classBox.Size = new System.Drawing.Size(276, 21);
            this.classBox.Sorted = true;
            this.classBox.TabIndex = 0;
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.ClassBox_SelectedIndexChanged);
            // 
            // wowBrowserDialog
            // 
            this.wowBrowserDialog.Description = "Please select your World of Warcraft folder.";
            this.wowBrowserDialog.ShowNewFolderButton = false;
            // 
            // AhkBuilderPlusPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 576);
            this.Controls.Add(this.keybindBox);
            this.Controls.Add(this.settingBox);
            this.Controls.Add(this.AhkTable);
            this.Controls.Add(this.finishBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(723, 614);
            this.MinimumSize = new System.Drawing.Size(723, 614);
            this.Name = "AhkBuilderPlusPlus";
            this.Text = "AHK Builder++";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AhkBuilderPlusPlus_FormClosing);
            this.Load += new System.EventHandler(this.AhkBuilderPlusPlus_Load);
            this.finishBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AhkTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ahkDataTable)).EndInit();
            this.settingBox.ResumeLayout(false);
            this.settingBox.PerformLayout();
            this.keybindBox.ResumeLayout(false);
            this.keybindBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox finishBox;
        private System.Windows.Forms.Button generateAhkButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.DataGridView AhkTable;
        private System.Windows.Forms.GroupBox settingBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xOffsetBox;
        private System.Windows.Forms.TextBox yOffsetBox;
        private System.Windows.Forms.TextBox ahkToggleKeyBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox ovaleScaleBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button lockSettingsButton;
        private System.Windows.Forms.GroupBox keybindBox;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.ComboBox spellBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox bindingBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addButton;
    }
}

