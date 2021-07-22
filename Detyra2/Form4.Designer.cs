
namespace Detyra
{
    partial class Form4
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.llojiField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vitiField = new System.Windows.Forms.TextBox();
            this.muajiField = new System.Windows.Forms.TextBox();
            this.cmimiField = new System.Windows.Forms.TextBox();
            this.ruajBtn = new System.Windows.Forms.Button();
            this.AnuloBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(119, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Regjistrimi i faturave";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(175, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lloji";
            // 
            // llojiField
            // 
            this.llojiField.Location = new System.Drawing.Point(122, 103);
            this.llojiField.Name = "llojiField";
            this.llojiField.Size = new System.Drawing.Size(142, 20);
            this.llojiField.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(175, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Viti";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(167, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Muaji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(167, 304);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cmimi";
            // 
            // vitiField
            // 
            this.vitiField.Location = new System.Drawing.Point(122, 181);
            this.vitiField.Name = "vitiField";
            this.vitiField.Size = new System.Drawing.Size(142, 20);
            this.vitiField.TabIndex = 6;
            // 
            // muajiField
            // 
            this.muajiField.Location = new System.Drawing.Point(122, 254);
            this.muajiField.Name = "muajiField";
            this.muajiField.Size = new System.Drawing.Size(142, 20);
            this.muajiField.TabIndex = 7;
            // 
            // cmimiField
            // 
            this.cmimiField.Location = new System.Drawing.Point(122, 325);
            this.cmimiField.Name = "cmimiField";
            this.cmimiField.Size = new System.Drawing.Size(142, 20);
            this.cmimiField.TabIndex = 8;
            // 
            // ruajBtn
            // 
            this.ruajBtn.Location = new System.Drawing.Point(76, 379);
            this.ruajBtn.Name = "ruajBtn";
            this.ruajBtn.Size = new System.Drawing.Size(75, 23);
            this.ruajBtn.TabIndex = 9;
            this.ruajBtn.Text = "Ruaj";
            this.ruajBtn.UseVisualStyleBackColor = true;
            this.ruajBtn.Click += new System.EventHandler(this.ruajBtn_Click);
            // 
            // AnuloBtn
            // 
            this.AnuloBtn.Location = new System.Drawing.Point(230, 379);
            this.AnuloBtn.Name = "AnuloBtn";
            this.AnuloBtn.Size = new System.Drawing.Size(72, 23);
            this.AnuloBtn.TabIndex = 10;
            this.AnuloBtn.Text = "Anulo";
            this.AnuloBtn.UseVisualStyleBackColor = true;
            this.AnuloBtn.Click += new System.EventHandler(this.AnuloBtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.AnuloBtn);
            this.Controls.Add(this.ruajBtn);
            this.Controls.Add(this.cmimiField);
            this.Controls.Add(this.muajiField);
            this.Controls.Add(this.vitiField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.llojiField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox llojiField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox vitiField;
        private System.Windows.Forms.TextBox muajiField;
        private System.Windows.Forms.TextBox cmimiField;
        private System.Windows.Forms.Button ruajBtn;
        private System.Windows.Forms.Button AnuloBtn;
    }
}