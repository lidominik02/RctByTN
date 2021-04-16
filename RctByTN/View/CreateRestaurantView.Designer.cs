
namespace RctByTN.View
{
    partial class CreateRestaurantView
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
            this.acceptedButton = new System.Windows.Forms.Button();
            this.notAcceptedButton = new System.Windows.Forms.Button();
            this.userInputTableLAyout = new System.Windows.Forms.TableLayoutPanel();
            this.manuPriceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.userInputTableLAyout.SuspendLayout();
            this.SuspendLayout();
            // 
            // acceptedButton
            // 
            this.acceptedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.acceptedButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.acceptedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptedButton.Location = new System.Drawing.Point(12, 134);
            this.acceptedButton.Name = "acceptedButton";
            this.acceptedButton.Size = new System.Drawing.Size(145, 35);
            this.acceptedButton.TabIndex = 0;
            this.acceptedButton.Text = "Építés";
            this.acceptedButton.UseVisualStyleBackColor = true;
            this.acceptedButton.Click += new System.EventHandler(this.acceptedButton_Click);
            // 
            // notAcceptedButton
            // 
            this.notAcceptedButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.notAcceptedButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.notAcceptedButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.notAcceptedButton.Location = new System.Drawing.Point(247, 134);
            this.notAcceptedButton.Name = "notAcceptedButton";
            this.notAcceptedButton.Size = new System.Drawing.Size(145, 35);
            this.notAcceptedButton.TabIndex = 0;
            this.notAcceptedButton.Text = "Mégsem";
            this.notAcceptedButton.UseVisualStyleBackColor = true;
            this.notAcceptedButton.Click += new System.EventHandler(this.notAcceptedButton_Click);
            // 
            // userInputTableLAyout
            // 
            this.userInputTableLAyout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userInputTableLAyout.ColumnCount = 2;
            this.userInputTableLAyout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.68421F));
            this.userInputTableLAyout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.31579F));
            this.userInputTableLAyout.Controls.Add(this.manuPriceLabel, 0, 0);
            this.userInputTableLAyout.Controls.Add(this.priceTextBox, 1, 0);
            this.userInputTableLAyout.Location = new System.Drawing.Point(12, 52);
            this.userInputTableLAyout.Name = "userInputTableLAyout";
            this.userInputTableLAyout.RowCount = 1;
            this.userInputTableLAyout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.userInputTableLAyout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.userInputTableLAyout.Size = new System.Drawing.Size(380, 50);
            this.userInputTableLAyout.TabIndex = 1;
            // 
            // manuPriceLabel
            // 
            this.manuPriceLabel.AutoSize = true;
            this.manuPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manuPriceLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.manuPriceLabel.Location = new System.Drawing.Point(3, 0);
            this.manuPriceLabel.Name = "manuPriceLabel";
            this.manuPriceLabel.Size = new System.Drawing.Size(103, 50);
            this.manuPriceLabel.TabIndex = 0;
            this.manuPriceLabel.Text = "Menü ár:";
            this.manuPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.priceTextBox.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.priceTextBox.Location = new System.Drawing.Point(112, 13);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(265, 34);
            this.priceTextBox.TabIndex = 1;
            this.priceTextBox.TextChanged += new System.EventHandler(this.priceTextBox_TextChanged);
            this.priceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.priceTextBox_KeyPress);
            // 
            // CreateRestaurantView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(404, 181);
            this.Controls.Add(this.userInputTableLAyout);
            this.Controls.Add(this.notAcceptedButton);
            this.Controls.Add(this.acceptedButton);
            this.Name = "CreateRestaurantView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vendéglátóhely építése";
            this.Load += new System.EventHandler(this.CreateRestaurantView_Load);
            this.userInputTableLAyout.ResumeLayout(false);
            this.userInputTableLAyout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button acceptedButton;
        private System.Windows.Forms.Button notAcceptedButton;
        private System.Windows.Forms.TableLayoutPanel priceLabel;
        private System.Windows.Forms.Label manuPriceLabel;
        private System.Windows.Forms.TableLayoutPanel userInputTableLAyout;
        private System.Windows.Forms.TextBox priceTextBox;
    }
}