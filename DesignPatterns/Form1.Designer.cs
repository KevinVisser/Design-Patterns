﻿namespace DesignPatterns
{
    /// <summary>
    /// Form class
    /// </summary>
    partial class Form1
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
            this.RectangleButton = new System.Windows.Forms.Button();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ResizeButton = new System.Windows.Forms.Button();
            this.MoveButton = new System.Windows.Forms.Button();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.GroupButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RectangleButton
            // 
            this.RectangleButton.Location = new System.Drawing.Point(524, 10);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(85, 23);
            this.RectangleButton.TabIndex = 1;
            this.RectangleButton.Text = "Rectangle";
            this.RectangleButton.UseVisualStyleBackColor = true;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // EllipseButton
            // 
            this.EllipseButton.Location = new System.Drawing.Point(524, 39);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(85, 23);
            this.EllipseButton.TabIndex = 2;
            this.EllipseButton.Text = "Ellipse";
            this.EllipseButton.UseVisualStyleBackColor = true;
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(524, 68);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(85, 23);
            this.SelectButton.TabIndex = 3;
            this.SelectButton.Text = "Select";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 341);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.Panel1_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel1_MouseDown);
            // 
            // ResizeButton
            // 
            this.ResizeButton.Location = new System.Drawing.Point(524, 98);
            this.ResizeButton.Name = "ResizeButton";
            this.ResizeButton.Size = new System.Drawing.Size(85, 23);
            this.ResizeButton.TabIndex = 4;
            this.ResizeButton.Text = "Resize";
            this.ResizeButton.UseVisualStyleBackColor = true;
            this.ResizeButton.Click += new System.EventHandler(this.Resize_Click);
            // 
            // MoveButton
            // 
            this.MoveButton.Location = new System.Drawing.Point(524, 127);
            this.MoveButton.Name = "MoveButton";
            this.MoveButton.Size = new System.Drawing.Size(85, 23);
            this.MoveButton.TabIndex = 5;
            this.MoveButton.Text = "Move";
            this.MoveButton.UseVisualStyleBackColor = true;
            this.MoveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(524, 328);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 6;
            this.UndoButton.Text = "Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(605, 328);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 23);
            this.RedoButton.TabIndex = 7;
            this.RedoButton.Text = "Redo";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // GroupButton
            // 
            this.GroupButton.Location = new System.Drawing.Point(524, 185);
            this.GroupButton.Name = "GroupButton";
            this.GroupButton.Size = new System.Drawing.Size(85, 23);
            this.GroupButton.TabIndex = 8;
            this.GroupButton.Text = "Group";
            this.GroupButton.UseVisualStyleBackColor = true;
            this.GroupButton.Click += new System.EventHandler(this.GroupButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(603, 369);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 9;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 404);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.GroupButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.MoveButton);
            this.Controls.Add(this.ResizeButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.EllipseButton);
            this.Controls.Add(this.RectangleButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button EllipseButton;
        private System.Windows.Forms.Button SelectButton;
        //public Shape panel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ResizeButton;
        private System.Windows.Forms.Button MoveButton;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button GroupButton;
        private System.Windows.Forms.Button DoneButton;
    }
}

