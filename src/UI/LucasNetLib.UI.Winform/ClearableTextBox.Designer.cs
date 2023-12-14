namespace LucasNetLib.UI.Winform
{
    partial class ClearableTextBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            txtValue = new TextBox();
            btnClear = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(3, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(43, 17);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "label1";
            // 
            // txtValue
            // 
            txtValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtValue.Location = new Point(3, 23);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(148, 23);
            txtValue.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(157, 23);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(31, 23);
            btnClear.TabIndex = 2;
            btnClear.Text = "bt\r\n";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // ClearableTextBox
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnClear);
            Controls.Add(txtValue);
            Controls.Add(lblTitle);
            MinimumSize = new Size(84, 53);
            Name = "ClearableTextBox";
            Size = new Size(191, 53);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtValue;
        private Button btnClear;
    }
}
