﻿namespace VixenModules.Editor.TimedSequenceEditor
{
	partial class Form_Effects
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Basic Lighting");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Advanced Lighting");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Device Action");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Effects));
			this.treeEffects = new System.Windows.Forms.TreeView();
			this.effectTreeImages = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// treeEffects
			// 
			this.treeEffects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeEffects.FullRowSelect = true;
			this.treeEffects.ImageIndex = 0;
			this.treeEffects.ImageList = this.effectTreeImages;
			this.treeEffects.ItemHeight = 22;
			this.treeEffects.Location = new System.Drawing.Point(0, 0);
			this.treeEffects.Name = "treeEffects";
			treeNode1.ImageKey = "bullet_arrow_Right.png";
			treeNode1.Name = "treeBasic";
			treeNode1.Text = "Basic Lighting";
			treeNode2.ImageKey = "bullet_arrow_Right.png";
			treeNode2.Name = "treeAdvanced";
			treeNode2.Text = "Advanced Lighting";
			treeNode3.ImageKey = "bullet_arrow_Right.png";
			treeNode3.Name = "treeDevice";
			treeNode3.SelectedImageKey = "(default)";
			treeNode3.StateImageKey = "(none)";
			treeNode3.Text = "Device Action";
			this.treeEffects.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
			this.treeEffects.SelectedImageIndex = 0;
			this.treeEffects.ShowLines = false;
			this.treeEffects.ShowPlusMinus = false;
			this.treeEffects.ShowRootLines = false;
			this.treeEffects.Size = new System.Drawing.Size(256, 402);
			this.treeEffects.TabIndex = 0;
			this.treeEffects.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeEffects_AfterCollapse);
			this.treeEffects.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeEffects_AfterExpand);
			this.treeEffects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeEffects_AfterSelect);
			this.treeEffects.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeEffects_MouseClick);
			this.treeEffects.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeEffects_MouseDown);
			this.treeEffects.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeEffects_MouseMove);
			// 
			// effectTreeImages
			// 
			this.effectTreeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("effectTreeImages.ImageStream")));
			this.effectTreeImages.TransparentColor = System.Drawing.Color.Transparent;
			this.effectTreeImages.Images.SetKeyName(0, "bullet_arrow_Right.png");
			this.effectTreeImages.Images.SetKeyName(1, "bullet_arrow_down.png");
			this.effectTreeImages.Images.SetKeyName(2, "blank.png");
			// 
			// Form_Effects
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(256, 402);
			this.ControlBox = false;
			this.Controls.Add(this.treeEffects);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form_Effects";
			this.Text = "Effects";
			this.Load += new System.EventHandler(this.Form_Effects_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList effectTreeImages;
		private System.Windows.Forms.TreeView treeEffects;
	}
}