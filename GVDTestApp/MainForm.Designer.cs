namespace GVDTestApp
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if( disposing && ( components != null ) )
      {
        components.Dispose();
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.uiEngineRpm = new System.Windows.Forms.Label();
      this.uiAccelerator = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.uiAccelerator)).BeginInit();
      this.SuspendLayout();
      // 
      // uiEngineRpm
      // 
      this.uiEngineRpm.AutoSize = true;
      this.uiEngineRpm.Location = new System.Drawing.Point(12, 18);
      this.uiEngineRpm.Name = "uiEngineRpm";
      this.uiEngineRpm.Size = new System.Drawing.Size(67, 13);
      this.uiEngineRpm.TabIndex = 0;
      this.uiEngineRpm.Text = "Engine RPM";
      // 
      // uiAccelerator
      // 
      this.uiAccelerator.Location = new System.Drawing.Point(15, 48);
      this.uiAccelerator.Maximum = 100;
      this.uiAccelerator.Name = "uiAccelerator";
      this.uiAccelerator.Size = new System.Drawing.Size(104, 45);
      this.uiAccelerator.SmallChange = 10;
      this.uiAccelerator.TabIndex = 10;
      this.uiAccelerator.TickFrequency = 20;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(612, 468);
      this.Controls.Add(this.uiAccelerator);
      this.Controls.Add(this.uiEngineRpm);
      this.Name = "MainForm";
      this.Text = "GVD Test App";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      ((System.ComponentModel.ISupportInitialize)(this.uiAccelerator)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label uiEngineRpm;
    private System.Windows.Forms.TrackBar uiAccelerator;
  }
}

