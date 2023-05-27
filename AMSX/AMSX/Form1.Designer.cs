
namespace AMSX
{
    partial class AMSX
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dateTimePickerSave = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewRecord = new System.Windows.Forms.DataGridView();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxCat = new System.Windows.Forms.ComboBox();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.textBoxRemark = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonShowRecord = new System.Windows.Forms.Button();
            this.chartSum = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBoxChart = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSum)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerSave
            // 
            this.dateTimePickerSave.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerSave.Name = "dateTimePickerSave";
            this.dateTimePickerSave.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerSave.TabIndex = 0;
            // 
            // dataGridViewRecord
            // 
            this.dataGridViewRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecord.Location = new System.Drawing.Point(12, 168);
            this.dataGridViewRecord.MultiSelect = false;
            this.dataGridViewRecord.Name = "dataGridViewRecord";
            this.dataGridViewRecord.ReadOnly = true;
            this.dataGridViewRecord.Size = new System.Drawing.Size(566, 371);
            this.dataGridViewRecord.TabIndex = 1;
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(12, 38);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(96, 21);
            this.comboBoxType.TabIndex = 3;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // comboBoxCat
            // 
            this.comboBoxCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCat.FormattingEnabled = true;
            this.comboBoxCat.Location = new System.Drawing.Point(114, 38);
            this.comboBoxCat.Name = "comboBoxCat";
            this.comboBoxCat.Size = new System.Drawing.Size(95, 21);
            this.comboBoxCat.TabIndex = 4;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(12, 65);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(96, 20);
            this.textBoxAmount.TabIndex = 9;
            // 
            // textBoxRemark
            // 
            this.textBoxRemark.Location = new System.Drawing.Point(114, 65);
            this.textBoxRemark.Name = "textBoxRemark";
            this.textBoxRemark.Size = new System.Drawing.Size(97, 20);
            this.textBoxRemark.TabIndex = 10;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 91);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(96, 20);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 142);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerStart.TabIndex = 13;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(215, 142);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(197, 20);
            this.dateTimePickerEnd.TabIndex = 14;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(115, 91);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(96, 20);
            this.buttonDelete.TabIndex = 16;
            this.buttonDelete.Text = "DELETE";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonShowRecord
            // 
            this.buttonShowRecord.Location = new System.Drawing.Point(428, 142);
            this.buttonShowRecord.Name = "buttonShowRecord";
            this.buttonShowRecord.Size = new System.Drawing.Size(96, 20);
            this.buttonShowRecord.TabIndex = 20;
            this.buttonShowRecord.Text = "OK";
            this.buttonShowRecord.UseVisualStyleBackColor = true;
            this.buttonShowRecord.Click += new System.EventHandler(this.buttonShowRecord_Click);
            // 
            // chartSum
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSum.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSum.Legends.Add(legend1);
            this.chartSum.Location = new System.Drawing.Point(613, 38);
            this.chartSum.Name = "chartSum";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.IsValueShownAsLabel = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSum.Series.Add(series1);
            this.chartSum.Size = new System.Drawing.Size(468, 501);
            this.chartSum.TabIndex = 21;
            this.chartSum.Text = "chart1";
            // 
            // comboBoxChart
            // 
            this.comboBoxChart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChart.FormattingEnabled = true;
            this.comboBoxChart.Location = new System.Drawing.Point(985, 11);
            this.comboBoxChart.Name = "comboBoxChart";
            this.comboBoxChart.Size = new System.Drawing.Size(96, 21);
            this.comboBoxChart.TabIndex = 22;
            // 
            // AMSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 549);
            this.Controls.Add(this.comboBoxChart);
            this.Controls.Add(this.chartSum);
            this.Controls.Add(this.buttonShowRecord);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxRemark);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.comboBoxCat);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.dataGridViewRecord);
            this.Controls.Add(this.dateTimePickerSave);
            this.Name = "AMSX";
            this.Text = "AMS";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerSave;
        private System.Windows.Forms.DataGridView dataGridViewRecord;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxCat;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.TextBox textBoxRemark;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonShowRecord;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartSum;
        private System.Windows.Forms.ComboBox comboBoxChart;
    }
}

