using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports; // systema responsável por ler as portas seriais 

namespace ProjetoBaja
{
    public partial class Form1 : Form
    {

        public Form1(){InitializeComponent();}

        private void timer1_Tick(object sender, EventArgs e){ //Timer padrão
            atualizaListaCOMs();
            if (serialArduino.IsOpen == true){

                serialArduino.Write("x"); // comunica ao arduino qual dado solicita
                string recebe1 = serialArduino.ReadLine(); // pega o dado do arduino 
                textBox2.Text = recebe1; // valor abaixo do velocímetro
                aGauge1.Value = Convert.ToInt16(recebe1); // valor do velocímetro

                serialArduino.Write("y"); // comunica ao arduino qual dado solicita
                string recebe2 = serialArduino.ReadLine(); // pega o dado do arduino 
                circularProgressBar1.Value = Convert.ToInt16(recebe2); // transforma o dado para inteiro e dá o valor da gasolina
                textBox1.Text = recebe2; // valor da gasolina 

                serialArduino.Write("z"); // comunica ao arduino qual dado solicita
                string recebe3 = serialArduino.ReadLine(); // pega o dado do arduino 
                chart1.Series["RPM (Rotações Por Minuto)"].Points.AddY(Convert.ToInt16(recebe3)); // valor do Y do gráfico RPM
                textBox3.Text = recebe3; // Valor ao lado do gráfico
                }
        }
        private void atualizaListaCOMs(){ // função responsável por atualizar as portas disponíveis
            int i = 0;
            bool quantDiferente = false;

            if (comboBox1.Items.Count == SerialPort.GetPortNames().Length){
                foreach (string s in SerialPort.GetPortNames()){
                    if (comboBox1.Items[i++].Equals(s) == false){
                    quantDiferente = true;
                    }
                }
            }
            else{quantDiferente = true;}

            if (quantDiferente == false){return;}
            comboBox1.Items.Clear();

            foreach (string s in SerialPort.GetPortNames()){comboBox1.Items.Add(s);}
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click_1(object sender, EventArgs e){ // Botão conectar
            if (serialArduino.IsOpen == false){
                try{
                    serialArduino.PortName = comboBox1.Items[comboBox1.SelectedIndex].ToString(); // Seleciona a porta escolhida e estabelece comunicação
                    serialArduino.Open();
                }
                catch (Exception ex){
                    MessageBox.Show(ex.Message, "Error"); // Mensagem de erro
                    return;
                }

                if (serialArduino.IsOpen){
                    button2.Hide(); // Esconde o botão de conectar, assim deixando o de desconectar visível
                    comboBox1.Enabled = false;
                }
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e){
            if(serialArduino.IsOpen == true){
                serialArduino.Close(); // faz a comunicação serial ser encerrada ao fechar o executável
            }
        }

        private void serialArduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string dado = serialArduino.ReadLine(); // dado recebido pelo arduino
        }

        private void button3_Click_1(object sender, EventArgs e){
            try {
                serialArduino.Close(); // Fecha a comunicação serial
                button2.Show();
                button2.Enabled = true; // Faz o botão de conectar retornar
                comboBox1.Enabled = true;
            }
            catch{return;}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void aGauge1_ValueInRangeChanged(object sender, ValueInRangeChangedEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
