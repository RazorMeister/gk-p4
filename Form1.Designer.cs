
namespace gk_p4
{
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
            this.components = new System.ComponentModel.Container();
            this.wrapper = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cameraDynamicForScene = new System.Windows.Forms.RadioButton();
            this.fovLabel = new System.Windows.Forms.Label();
            this.cameraDynamicForObject = new System.Windows.Forms.RadioButton();
            this.cameraStaticForScene = new System.Windows.Forms.RadioButton();
            this.cameraStaticForObject = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.shadingGouraudRadio = new System.Windows.Forms.RadioButton();
            this.shadingContantRadio = new System.Windows.Forms.RadioButton();
            this.shadingPhongRadio = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.mTrackBar = new System.Windows.Forms.TrackBar();
            this.ksLabel = new System.Windows.Forms.Label();
            this.ksTrackBar = new System.Windows.Forms.TrackBar();
            this.kdLabel = new System.Windows.Forms.Label();
            this.kdTrackBar = new System.Windows.Forms.TrackBar();
            this.AnimationGroupBox = new System.Windows.Forms.GroupBox();
            this.animationOnCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.wrapper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).BeginInit();
            this.AnimationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // wrapper
            // 
            this.wrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wrapper.Location = new System.Drawing.Point(10, 9);
            this.wrapper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wrapper.Name = "wrapper";
            this.wrapper.Size = new System.Drawing.Size(704, 501);
            this.wrapper.TabIndex = 0;
            this.wrapper.TabStop = false;
            this.wrapper.Paint += new System.Windows.Forms.PaintEventHandler(this.wrapper_Paint);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(6, 149);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackBar1.Maximum = 150;
            this.trackBar1.Minimum = 40;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(188, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cameraDynamicForScene);
            this.groupBox1.Controls.Add(this.fovLabel);
            this.groupBox1.Controls.Add(this.cameraDynamicForObject);
            this.groupBox1.Controls.Add(this.cameraStaticForScene);
            this.groupBox1.Controls.Add(this.cameraStaticForObject);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Location = new System.Drawing.Point(737, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 199);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera";
            // 
            // cameraDynamicForScene
            // 
            this.cameraDynamicForScene.AutoSize = true;
            this.cameraDynamicForScene.Location = new System.Drawing.Point(16, 97);
            this.cameraDynamicForScene.Name = "cameraDynamicForScene";
            this.cameraDynamicForScene.Size = new System.Drawing.Size(123, 19);
            this.cameraDynamicForScene.TabIndex = 6;
            this.cameraDynamicForScene.Text = "Dynamic for scene";
            this.cameraDynamicForScene.UseVisualStyleBackColor = true;
            this.cameraDynamicForScene.CheckedChanged += new System.EventHandler(this.cameraDynamicForScene_CheckedChanged);
            // 
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Location = new System.Drawing.Point(13, 132);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(47, 15);
            this.fovLabel.TabIndex = 5;
            this.fovLabel.Text = "FOV: 50";
            // 
            // cameraDynamicForObject
            // 
            this.cameraDynamicForObject.AutoSize = true;
            this.cameraDynamicForObject.Location = new System.Drawing.Point(16, 72);
            this.cameraDynamicForObject.Name = "cameraDynamicForObject";
            this.cameraDynamicForObject.Size = new System.Drawing.Size(126, 19);
            this.cameraDynamicForObject.TabIndex = 4;
            this.cameraDynamicForObject.Text = "Dynamic for object";
            this.cameraDynamicForObject.UseVisualStyleBackColor = true;
            this.cameraDynamicForObject.CheckedChanged += new System.EventHandler(this.cameraDynamicForObject_CheckedChanged);
            // 
            // cameraStaticForScene
            // 
            this.cameraStaticForScene.AutoSize = true;
            this.cameraStaticForScene.Location = new System.Drawing.Point(16, 47);
            this.cameraStaticForScene.Name = "cameraStaticForScene";
            this.cameraStaticForScene.Size = new System.Drawing.Size(105, 19);
            this.cameraStaticForScene.TabIndex = 3;
            this.cameraStaticForScene.Text = "Static for scene";
            this.cameraStaticForScene.UseVisualStyleBackColor = true;
            this.cameraStaticForScene.CheckedChanged += new System.EventHandler(this.cameraStaticForScene_CheckedChanged);
            // 
            // cameraStaticForObject
            // 
            this.cameraStaticForObject.AutoSize = true;
            this.cameraStaticForObject.Checked = true;
            this.cameraStaticForObject.Location = new System.Drawing.Point(16, 22);
            this.cameraStaticForObject.Name = "cameraStaticForObject";
            this.cameraStaticForObject.Size = new System.Drawing.Size(108, 19);
            this.cameraStaticForObject.TabIndex = 2;
            this.cameraStaticForObject.TabStop = true;
            this.cameraStaticForObject.Text = "Static for object";
            this.cameraStaticForObject.UseVisualStyleBackColor = true;
            this.cameraStaticForObject.CheckedChanged += new System.EventHandler(this.cameraStaticForObject_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.shadingGouraudRadio);
            this.groupBox2.Controls.Add(this.shadingContantRadio);
            this.groupBox2.Controls.Add(this.shadingPhongRadio);
            this.groupBox2.Location = new System.Drawing.Point(737, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shading";
            // 
            // shadingGouraudRadio
            // 
            this.shadingGouraudRadio.AutoSize = true;
            this.shadingGouraudRadio.Location = new System.Drawing.Point(13, 72);
            this.shadingGouraudRadio.Name = "shadingGouraudRadio";
            this.shadingGouraudRadio.Size = new System.Drawing.Size(71, 19);
            this.shadingGouraudRadio.TabIndex = 5;
            this.shadingGouraudRadio.Text = "Gouraud";
            this.shadingGouraudRadio.UseVisualStyleBackColor = true;
            this.shadingGouraudRadio.CheckedChanged += new System.EventHandler(this.shadingGouraudRadio_CheckedChanged);
            // 
            // shadingContantRadio
            // 
            this.shadingContantRadio.AutoSize = true;
            this.shadingContantRadio.Checked = true;
            this.shadingContantRadio.Location = new System.Drawing.Point(13, 47);
            this.shadingContantRadio.Name = "shadingContantRadio";
            this.shadingContantRadio.Size = new System.Drawing.Size(73, 19);
            this.shadingContantRadio.TabIndex = 4;
            this.shadingContantRadio.TabStop = true;
            this.shadingContantRadio.Text = "Constant";
            this.shadingContantRadio.UseVisualStyleBackColor = true;
            this.shadingContantRadio.CheckedChanged += new System.EventHandler(this.shadingContantRadio_CheckedChanged);
            // 
            // shadingPhongRadio
            // 
            this.shadingPhongRadio.AutoSize = true;
            this.shadingPhongRadio.Location = new System.Drawing.Point(13, 22);
            this.shadingPhongRadio.Name = "shadingPhongRadio";
            this.shadingPhongRadio.Size = new System.Drawing.Size(60, 19);
            this.shadingPhongRadio.TabIndex = 3;
            this.shadingPhongRadio.Text = "Phong";
            this.shadingPhongRadio.UseVisualStyleBackColor = true;
            this.shadingPhongRadio.CheckedChanged += new System.EventHandler(this.shadingPhongRadio_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.mLabel);
            this.groupBox3.Controls.Add(this.mTrackBar);
            this.groupBox3.Controls.Add(this.ksLabel);
            this.groupBox3.Controls.Add(this.ksTrackBar);
            this.groupBox3.Controls.Add(this.kdLabel);
            this.groupBox3.Controls.Add(this.kdTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(737, 323);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Light setting";
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Location = new System.Drawing.Point(107, 22);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(36, 15);
            this.mLabel.TabIndex = 5;
            this.mLabel.Text = "M: 50";
            // 
            // mTrackBar
            // 
            this.mTrackBar.LargeChange = 1;
            this.mTrackBar.Location = new System.Drawing.Point(115, 40);
            this.mTrackBar.Maximum = 100;
            this.mTrackBar.Name = "mTrackBar";
            this.mTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.mTrackBar.Size = new System.Drawing.Size(45, 54);
            this.mTrackBar.TabIndex = 4;
            this.mTrackBar.Value = 50;
            this.mTrackBar.Scroll += new System.EventHandler(this.mTrackBar_Scroll);
            // 
            // ksLabel
            // 
            this.ksLabel.AutoSize = true;
            this.ksLabel.Location = new System.Drawing.Point(61, 22);
            this.ksLabel.Name = "ksLabel";
            this.ksLabel.Size = new System.Drawing.Size(40, 15);
            this.ksLabel.TabIndex = 3;
            this.ksLabel.Text = "Ks: 1.0";
            // 
            // ksTrackBar
            // 
            this.ksTrackBar.LargeChange = 1;
            this.ksTrackBar.Location = new System.Drawing.Point(64, 40);
            this.ksTrackBar.Name = "ksTrackBar";
            this.ksTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ksTrackBar.Size = new System.Drawing.Size(45, 54);
            this.ksTrackBar.TabIndex = 2;
            this.ksTrackBar.Value = 5;
            this.ksTrackBar.Scroll += new System.EventHandler(this.ksTrackBar_Scroll);
            // 
            // kdLabel
            // 
            this.kdLabel.AutoSize = true;
            this.kdLabel.Location = new System.Drawing.Point(13, 22);
            this.kdLabel.Name = "kdLabel";
            this.kdLabel.Size = new System.Drawing.Size(42, 15);
            this.kdLabel.TabIndex = 1;
            this.kdLabel.Text = "Kd: 1.0";
            // 
            // kdTrackBar
            // 
            this.kdTrackBar.LargeChange = 1;
            this.kdTrackBar.Location = new System.Drawing.Point(13, 40);
            this.kdTrackBar.Name = "kdTrackBar";
            this.kdTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.kdTrackBar.Size = new System.Drawing.Size(45, 54);
            this.kdTrackBar.TabIndex = 0;
            this.kdTrackBar.Value = 5;
            this.kdTrackBar.Scroll += new System.EventHandler(this.kdTrackBar_Scroll);
            // 
            // AnimationGroupBox
            // 
            this.AnimationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AnimationGroupBox.Controls.Add(this.animationOnCheckbox);
            this.AnimationGroupBox.Location = new System.Drawing.Point(737, 429);
            this.AnimationGroupBox.Name = "AnimationGroupBox";
            this.AnimationGroupBox.Size = new System.Drawing.Size(200, 81);
            this.AnimationGroupBox.TabIndex = 5;
            this.AnimationGroupBox.TabStop = false;
            this.AnimationGroupBox.Text = "Animation";
            // 
            // animationOnCheckbox
            // 
            this.animationOnCheckbox.AutoSize = true;
            this.animationOnCheckbox.Checked = true;
            this.animationOnCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.animationOnCheckbox.Location = new System.Drawing.Point(13, 39);
            this.animationOnCheckbox.Name = "animationOnCheckbox";
            this.animationOnCheckbox.Size = new System.Drawing.Size(103, 19);
            this.animationOnCheckbox.TabIndex = 0;
            this.animationOnCheckbox.Text = "Animation ON";
            this.animationOnCheckbox.UseVisualStyleBackColor = true;
            this.animationOnCheckbox.CheckedChanged += new System.EventHandler(this.animationOnCheckbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 521);
            this.Controls.Add(this.AnimationGroupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wrapper);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "GK-P4";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.wrapper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdTrackBar)).EndInit();
            this.AnimationGroupBox.ResumeLayout(false);
            this.AnimationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox wrapper;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cameraDynamicForObject;
        private System.Windows.Forms.RadioButton cameraStaticForScene;
        private System.Windows.Forms.RadioButton cameraStaticForObject;
        private System.Windows.Forms.Label fovLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton shadingGouraudRadio;
        private System.Windows.Forms.RadioButton shadingContantRadio;
        private System.Windows.Forms.RadioButton shadingPhongRadio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.TrackBar mTrackBar;
        private System.Windows.Forms.Label ksLabel;
        private System.Windows.Forms.TrackBar ksTrackBar;
        private System.Windows.Forms.Label kdLabel;
        private System.Windows.Forms.TrackBar kdTrackBar;
        private System.Windows.Forms.RadioButton cameraDynamicForScene;
        private System.Windows.Forms.GroupBox AnimationGroupBox;
        private System.Windows.Forms.CheckBox animationOnCheckbox;
    }
}
