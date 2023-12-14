namespace LucasNetLib.UI.Winform;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        button1 = new Button();
        textBox1 = new TextBox();
        clearableTextBox1 = new ClearableTextBox();
        bindingSource1 = new BindingSource(components);
        dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // backgroundWorker1
        // 
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.DoWork += backgroundWorker1_DoWork;
        // 
        // button1
        // 
        button1.Location = new Point(104, 80);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(109, 174);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(100, 23);
        textBox1.TabIndex = 1;
        // 
        // clearableTextBox1
        // 
        clearableTextBox1.Location = new Point(12, 12);
        clearableTextBox1.MinimumSize = new Size(84, 53);
        clearableTextBox1.Name = "clearableTextBox1";
        clearableTextBox1.Size = new Size(191, 53);
        clearableTextBox1.TabIndex = 2;
        clearableTextBox1.Title = "label1";
        clearableTextBox1.TextChanged += clearableTextBox1_TextChanged;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(288, 97);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(240, 150);
        dataGridView1.TabIndex = 3;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(dataGridView1);
        Controls.Add(clearableTextBox1);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Button button1;
    private TextBox textBox1;
    private ClearableTextBox clearableTextBox1;
    private BindingSource bindingSource1;
    private DataGridView dataGridView1;
}
