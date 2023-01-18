/* Topic: Fractals Julii Method
 * Desription: The program calculates a fractal using the Julia method 
 * in a given range and for a given complex number C. The results are then displayed on the screen.
 * 
 * Author: Patryk Wikłacz
 * Semester V 2022/2023
 * 11.01.2023
 */

using System.Threading;

namespace JuliaFractalsProject
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.threadSilder = new System.Windows.Forms.TrackBar();
            this.radioButtonCSharp = new System.Windows.Forms.RadioButton();
            this.radioButtonASM = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numOfTreadsLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maxIter10000 = new System.Windows.Forms.RadioButton();
            this.maxIter5000 = new System.Windows.Forms.RadioButton();
            this.maxIter2000 = new System.Windows.Forms.RadioButton();
            this.maxIter1000 = new System.Windows.Forms.RadioButton();
            this.maxIter255 = new System.Windows.Forms.RadioButton();
            this.maxIter100 = new System.Windows.Forms.RadioButton();
            this.textMinIm = new System.Windows.Forms.TextBox();
            this.textMaxIm = new System.Windows.Forms.TextBox();
            this.textMaxRe = new System.Windows.Forms.TextBox();
            this.textMinRe = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textCIm = new System.Windows.Forms.TextBox();
            this.textCRe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadSilder)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 800);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // threadSilder
            // 
            this.threadSilder.Location = new System.Drawing.Point(857, 67);
            this.threadSilder.Maximum = 64;
            this.threadSilder.Minimum = 1;
            this.threadSilder.Name = "threadSilder";
            this.threadSilder.Size = new System.Drawing.Size(271, 45);
            this.threadSilder.TabIndex = 3;
            this.threadSilder.TabStop = false;
            this.threadSilder.TickFrequency = 3;
            this.threadSilder.Value = 1;
            this.threadSilder.ValueChanged += new System.EventHandler(this.TrackBar1_ValueChanged);
            // 
            // radioButtonCSharp
            // 
            this.radioButtonCSharp.AutoSize = true;
            this.radioButtonCSharp.Checked = true;
            this.radioButtonCSharp.Location = new System.Drawing.Point(887, 12);
            this.radioButtonCSharp.Name = "radioButtonCSharp";
            this.radioButtonCSharp.Size = new System.Drawing.Size(39, 17);
            this.radioButtonCSharp.TabIndex = 1;
            this.radioButtonCSharp.TabStop = true;
            this.radioButtonCSharp.Text = "C#";
            this.radioButtonCSharp.UseVisualStyleBackColor = true;
            // 
            // radioButtonASM
            // 
            this.radioButtonASM.AutoSize = true;
            this.radioButtonASM.Location = new System.Drawing.Point(1051, 12);
            this.radioButtonASM.Name = "radioButtonASM";
            this.radioButtonASM.Size = new System.Drawing.Size(48, 17);
            this.radioButtonASM.TabIndex = 2;
            this.radioButtonASM.Text = "ASM";
            this.radioButtonASM.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(854, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1115, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "64";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(857, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Threads:";
            // 
            // numOfTreadsLabel
            // 
            this.numOfTreadsLabel.AutoSize = true;
            this.numOfTreadsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numOfTreadsLabel.Location = new System.Drawing.Point(928, 47);
            this.numOfTreadsLabel.Name = "numOfTreadsLabel";
            this.numOfTreadsLabel.Size = new System.Drawing.Size(16, 17);
            this.numOfTreadsLabel.TabIndex = 7;
            this.numOfTreadsLabel.Text = "1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maxIter10000);
            this.groupBox1.Controls.Add(this.maxIter5000);
            this.groupBox1.Controls.Add(this.maxIter2000);
            this.groupBox1.Controls.Add(this.maxIter1000);
            this.groupBox1.Controls.Add(this.maxIter255);
            this.groupBox1.Controls.Add(this.maxIter100);
            this.groupBox1.Location = new System.Drawing.Point(819, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(90, 165);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Max Iterations";
            // 
            // maxIter10000
            // 
            this.maxIter10000.AutoSize = true;
            this.maxIter10000.Location = new System.Drawing.Point(6, 135);
            this.maxIter10000.Name = "maxIter10000";
            this.maxIter10000.Size = new System.Drawing.Size(55, 17);
            this.maxIter10000.TabIndex = 5;
            this.maxIter10000.Text = "10000";
            this.maxIter10000.UseVisualStyleBackColor = true;
            // 
            // maxIter5000
            // 
            this.maxIter5000.AutoSize = true;
            this.maxIter5000.Location = new System.Drawing.Point(7, 112);
            this.maxIter5000.Name = "maxIter5000";
            this.maxIter5000.Size = new System.Drawing.Size(49, 17);
            this.maxIter5000.TabIndex = 4;
            this.maxIter5000.Text = "5000";
            this.maxIter5000.UseVisualStyleBackColor = true;
            // 
            // maxIter2000
            // 
            this.maxIter2000.AutoSize = true;
            this.maxIter2000.Location = new System.Drawing.Point(7, 89);
            this.maxIter2000.Name = "maxIter2000";
            this.maxIter2000.Size = new System.Drawing.Size(49, 17);
            this.maxIter2000.TabIndex = 3;
            this.maxIter2000.Text = "2000";
            this.maxIter2000.UseVisualStyleBackColor = true;
            // 
            // maxIter1000
            // 
            this.maxIter1000.AutoSize = true;
            this.maxIter1000.Checked = true;
            this.maxIter1000.Location = new System.Drawing.Point(7, 66);
            this.maxIter1000.Name = "maxIter1000";
            this.maxIter1000.Size = new System.Drawing.Size(49, 17);
            this.maxIter1000.TabIndex = 2;
            this.maxIter1000.TabStop = true;
            this.maxIter1000.Text = "1000";
            this.maxIter1000.UseVisualStyleBackColor = true;
            // 
            // maxIter255
            // 
            this.maxIter255.AutoSize = true;
            this.maxIter255.Location = new System.Drawing.Point(7, 43);
            this.maxIter255.Name = "maxIter255";
            this.maxIter255.Size = new System.Drawing.Size(43, 17);
            this.maxIter255.TabIndex = 1;
            this.maxIter255.Text = "255";
            this.maxIter255.UseVisualStyleBackColor = true;
            // 
            // maxIter100
            // 
            this.maxIter100.AutoSize = true;
            this.maxIter100.Location = new System.Drawing.Point(7, 20);
            this.maxIter100.Name = "maxIter100";
            this.maxIter100.Size = new System.Drawing.Size(43, 17);
            this.maxIter100.TabIndex = 0;
            this.maxIter100.Text = "100";
            this.maxIter100.UseVisualStyleBackColor = true;
            // 
            // textMinIm
            // 
            this.textMinIm.Location = new System.Drawing.Point(1061, 178);
            this.textMinIm.Name = "textMinIm";
            this.textMinIm.Size = new System.Drawing.Size(100, 20);
            this.textMinIm.TabIndex = 9;
            this.textMinIm.TabStop = false;
            this.textMinIm.Text = "-1.25";
            // 
            // textMaxIm
            // 
            this.textMaxIm.Location = new System.Drawing.Point(1061, 204);
            this.textMaxIm.Name = "textMaxIm";
            this.textMaxIm.Size = new System.Drawing.Size(100, 20);
            this.textMaxIm.TabIndex = 10;
            this.textMaxIm.TabStop = false;
            this.textMaxIm.Text = "1.25";
            // 
            // textMaxRe
            // 
            this.textMaxRe.Location = new System.Drawing.Point(941, 204);
            this.textMaxRe.Name = "textMaxRe";
            this.textMaxRe.Size = new System.Drawing.Size(100, 20);
            this.textMaxRe.TabIndex = 12;
            this.textMaxRe.TabStop = false;
            this.textMaxRe.Text = "1.5";
            // 
            // textMinRe
            // 
            this.textMinRe.Location = new System.Drawing.Point(941, 178);
            this.textMinRe.Name = "textMinRe";
            this.textMinRe.Size = new System.Drawing.Size(100, 20);
            this.textMinRe.TabIndex = 11;
            this.textMinRe.TabStop = false;
            this.textMinRe.Text = "-1.5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1029, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(978, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Re";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1100, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Im";
            // 
            // textCIm
            // 
            this.textCIm.Location = new System.Drawing.Point(989, 268);
            this.textCIm.Name = "textCIm";
            this.textCIm.Size = new System.Drawing.Size(100, 20);
            this.textCIm.TabIndex = 17;
            this.textCIm.TabStop = false;
            this.textCIm.Text = "0.65";
            // 
            // textCRe
            // 
            this.textCRe.Location = new System.Drawing.Point(989, 242);
            this.textCRe.Name = "textCRe";
            this.textCRe.Size = new System.Drawing.Size(100, 20);
            this.textCRe.TabIndex = 16;
            this.textCRe.TabStop = false;
            this.textCRe.Text = "-0.10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(948, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "C (Re)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(948, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "C (Im)";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(914, 330);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(129, 23);
            this.generateButton.TabIndex = 20;
            this.generateButton.TabStop = false;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(914, 372);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(129, 23);
            this.resetButton.TabIndex = 21;
            this.resetButton.TabStop = false;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(911, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Min";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(911, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Max";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(914, 415);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(129, 23);
            this.testButton.TabIndex = 26;
            this.testButton.TabStop = false;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(826, 488);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 17);
            this.label10.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(948, 488);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 17);
            this.label12.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(1077, 488);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 17);
            this.label13.TabIndex = 29;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1163, 757);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textCIm);
            this.Controls.Add(this.textCRe);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textMaxRe);
            this.Controls.Add(this.textMinRe);
            this.Controls.Add(this.textMaxIm);
            this.Controls.Add(this.textMinIm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.numOfTreadsLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonASM);
            this.Controls.Add(this.radioButtonCSharp);
            this.Controls.Add(this.threadSilder);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadSilder)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void myInitCompontents()
        {

            ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);

            this.numOfTreadsLabel.Text = workerThreads.ToString();
            this.threadSilder.Value = workerThreads;
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar threadSilder;
        private System.Windows.Forms.RadioButton radioButtonCSharp;
        private System.Windows.Forms.RadioButton radioButtonASM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label numOfTreadsLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton maxIter1000;
        private System.Windows.Forms.RadioButton maxIter255;
        private System.Windows.Forms.RadioButton maxIter100;
        private System.Windows.Forms.RadioButton maxIter2000;
        private System.Windows.Forms.RadioButton maxIter10000;
        private System.Windows.Forms.RadioButton maxIter5000;
        private System.Windows.Forms.TextBox textMinIm;
        private System.Windows.Forms.TextBox textMaxIm;
        private System.Windows.Forms.TextBox textMaxRe;
        private System.Windows.Forms.TextBox textMinRe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCIm;
        private System.Windows.Forms.TextBox textCRe;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

