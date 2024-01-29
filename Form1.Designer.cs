namespace Automatum
{
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
            this.creatureRadioButton1 = new System.Windows.Forms.RadioButton();
            this.creatureRadioButton2 = new System.Windows.Forms.RadioButton();
            this.creatureRadioButton3 = new System.Windows.Forms.RadioButton();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.panelCreatureRadioButtons = new System.Windows.Forms.Panel();
            this.checkBoxHasMove = new System.Windows.Forms.CheckBox();
            this.checkBoxHasAttack = new System.Windows.Forms.CheckBox();
            this.radioButtonActionMove = new System.Windows.Forms.RadioButton();
            this.radioButtonActionAttack = new System.Windows.Forms.RadioButton();
            this.panelCreatureAction = new System.Windows.Forms.Panel();
            this.player2scoreLabel = new System.Windows.Forms.Label();
            this.player1scoreLabel = new System.Windows.Forms.Label();
            this.panelCreatureRadioButtons.SuspendLayout();
            this.panelCreatureAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // creatureRadioButton1
            // 
            this.creatureRadioButton1.AutoSize = true;
            this.creatureRadioButton1.Checked = true;
            this.creatureRadioButton1.Location = new System.Drawing.Point(4, 3);
            this.creatureRadioButton1.Name = "creatureRadioButton1";
            this.creatureRadioButton1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.creatureRadioButton1.Size = new System.Drawing.Size(85, 17);
            this.creatureRadioButton1.TabIndex = 0;
            this.creatureRadioButton1.TabStop = true;
            this.creatureRadioButton1.Tag = "0";
            this.creatureRadioButton1.Text = "radioButton1";
            this.creatureRadioButton1.UseVisualStyleBackColor = true;
            this.creatureRadioButton1.CheckedChanged += new System.EventHandler(this.creatureRadioButton_CheckedChanged);
            // 
            // creatureRadioButton2
            // 
            this.creatureRadioButton2.AutoSize = true;
            this.creatureRadioButton2.Location = new System.Drawing.Point(4, 26);
            this.creatureRadioButton2.Name = "creatureRadioButton2";
            this.creatureRadioButton2.Size = new System.Drawing.Size(85, 17);
            this.creatureRadioButton2.TabIndex = 1;
            this.creatureRadioButton2.Tag = "1";
            this.creatureRadioButton2.Text = "radioButton2";
            this.creatureRadioButton2.UseVisualStyleBackColor = true;
            this.creatureRadioButton2.CheckedChanged += new System.EventHandler(this.creatureRadioButton_CheckedChanged);
            // 
            // creatureRadioButton3
            // 
            this.creatureRadioButton3.AutoSize = true;
            this.creatureRadioButton3.Location = new System.Drawing.Point(4, 49);
            this.creatureRadioButton3.Name = "creatureRadioButton3";
            this.creatureRadioButton3.Size = new System.Drawing.Size(85, 17);
            this.creatureRadioButton3.TabIndex = 2;
            this.creatureRadioButton3.Tag = "2";
            this.creatureRadioButton3.Text = "radioButton3";
            this.creatureRadioButton3.UseVisualStyleBackColor = true;
            this.creatureRadioButton3.CheckedChanged += new System.EventHandler(this.creatureRadioButton_CheckedChanged);
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Location = new System.Drawing.Point(713, 415);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(75, 23);
            this.buttonEndTurn.TabIndex = 3;
            this.buttonEndTurn.Text = "End Turn";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // panelCreatureRadioButtons
            // 
            this.panelCreatureRadioButtons.Controls.Add(this.creatureRadioButton1);
            this.panelCreatureRadioButtons.Controls.Add(this.creatureRadioButton2);
            this.panelCreatureRadioButtons.Controls.Add(this.creatureRadioButton3);
            this.panelCreatureRadioButtons.Location = new System.Drawing.Point(713, 12);
            this.panelCreatureRadioButtons.Name = "panelCreatureRadioButtons";
            this.panelCreatureRadioButtons.Size = new System.Drawing.Size(89, 74);
            this.panelCreatureRadioButtons.TabIndex = 4;
            // 
            // checkBoxHasMove
            // 
            this.checkBoxHasMove.AutoSize = true;
            this.checkBoxHasMove.Enabled = false;
            this.checkBoxHasMove.Location = new System.Drawing.Point(717, 281);
            this.checkBoxHasMove.Name = "checkBoxHasMove";
            this.checkBoxHasMove.Size = new System.Drawing.Size(72, 17);
            this.checkBoxHasMove.TabIndex = 5;
            this.checkBoxHasMove.Text = "HasMove";
            this.checkBoxHasMove.UseVisualStyleBackColor = true;
            // 
            // checkBoxHasAttack
            // 
            this.checkBoxHasAttack.AutoSize = true;
            this.checkBoxHasAttack.Enabled = false;
            this.checkBoxHasAttack.Location = new System.Drawing.Point(717, 304);
            this.checkBoxHasAttack.Name = "checkBoxHasAttack";
            this.checkBoxHasAttack.Size = new System.Drawing.Size(76, 17);
            this.checkBoxHasAttack.TabIndex = 6;
            this.checkBoxHasAttack.Text = "HasAttack";
            this.checkBoxHasAttack.UseVisualStyleBackColor = true;
            // 
            // radioButtonActionMove
            // 
            this.radioButtonActionMove.AutoSize = true;
            this.radioButtonActionMove.Checked = true;
            this.radioButtonActionMove.Location = new System.Drawing.Point(4, 4);
            this.radioButtonActionMove.Name = "radioButtonActionMove";
            this.radioButtonActionMove.Size = new System.Drawing.Size(52, 17);
            this.radioButtonActionMove.TabIndex = 7;
            this.radioButtonActionMove.TabStop = true;
            this.radioButtonActionMove.Tag = "Move";
            this.radioButtonActionMove.Text = "Move";
            this.radioButtonActionMove.UseVisualStyleBackColor = true;
            this.radioButtonActionMove.CheckedChanged += new System.EventHandler(this.radioButtonAction_CheckedChanged);
            // 
            // radioButtonActionAttack
            // 
            this.radioButtonActionAttack.AutoSize = true;
            this.radioButtonActionAttack.Location = new System.Drawing.Point(4, 27);
            this.radioButtonActionAttack.Name = "radioButtonActionAttack";
            this.radioButtonActionAttack.Size = new System.Drawing.Size(56, 17);
            this.radioButtonActionAttack.TabIndex = 8;
            this.radioButtonActionAttack.Tag = "Attack";
            this.radioButtonActionAttack.Text = "Attack";
            this.radioButtonActionAttack.UseVisualStyleBackColor = true;
            this.radioButtonActionAttack.CheckedChanged += new System.EventHandler(this.radioButtonAction_CheckedChanged);
            // 
            // panelCreatureAction
            // 
            this.panelCreatureAction.Controls.Add(this.radioButtonActionAttack);
            this.panelCreatureAction.Controls.Add(this.radioButtonActionMove);
            this.panelCreatureAction.Location = new System.Drawing.Point(713, 109);
            this.panelCreatureAction.Name = "panelCreatureAction";
            this.panelCreatureAction.Size = new System.Drawing.Size(88, 141);
            this.panelCreatureAction.TabIndex = 9;
            // 
            // player2scoreLabel
            // 
            this.player2scoreLabel.AutoSize = true;
            this.player2scoreLabel.Location = new System.Drawing.Point(12, 19);
            this.player2scoreLabel.Name = "player2scoreLabel";
            this.player2scoreLabel.Size = new System.Drawing.Size(13, 13);
            this.player2scoreLabel.TabIndex = 10;
            this.player2scoreLabel.Text = "0";
            // 
            // player1scoreLabel
            // 
            this.player1scoreLabel.AutoSize = true;
            this.player1scoreLabel.Location = new System.Drawing.Point(12, 282);
            this.player1scoreLabel.Name = "player1scoreLabel";
            this.player1scoreLabel.Size = new System.Drawing.Size(13, 13);
            this.player1scoreLabel.TabIndex = 11;
            this.player1scoreLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.player1scoreLabel);
            this.Controls.Add(this.player2scoreLabel);
            this.Controls.Add(this.panelCreatureAction);
            this.Controls.Add(this.checkBoxHasAttack);
            this.Controls.Add(this.checkBoxHasMove);
            this.Controls.Add(this.panelCreatureRadioButtons);
            this.Controls.Add(this.buttonEndTurn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelCreatureRadioButtons.ResumeLayout(false);
            this.panelCreatureRadioButtons.PerformLayout();
            this.panelCreatureAction.ResumeLayout(false);
            this.panelCreatureAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton creatureRadioButton1;
        private System.Windows.Forms.RadioButton creatureRadioButton2;
        private System.Windows.Forms.RadioButton creatureRadioButton3;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.Panel panelCreatureRadioButtons;
        private System.Windows.Forms.CheckBox checkBoxHasMove;
        private System.Windows.Forms.CheckBox checkBoxHasAttack;
        private System.Windows.Forms.RadioButton radioButtonActionMove;
        private System.Windows.Forms.RadioButton radioButtonActionAttack;
        private System.Windows.Forms.Panel panelCreatureAction;
        private System.Windows.Forms.Label player2scoreLabel;
        private System.Windows.Forms.Label player1scoreLabel;
    }
}