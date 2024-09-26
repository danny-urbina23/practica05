using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += validarNombre;
            textBox2.TextChanged += validarApellido;
            textBox3.TextChanged += validarTelefono;
            textBox4.TextChanged += validarEdad;
            textBox5.TextChanged += validarEstatura;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            String apellido = textBox2.Text;
            String telefono = textBox3.Text;
            String edad = textBox4.Text;
            String estatura = textBox5.Text;
            String genero = " ";
            if (radioButton1.Checked)
            {
                genero = "Hombre";
            }
            else if (radioButton2.Checked)
            {
                genero = "Mujer";
            }
            string datos = $"nombres: {nombre}\r\nApellido: {apellido}\r\nTelefono: {telefono}\r\nEdad: {edad}\r\nEstatura {estatura}\r\nGenero: {genero}\r\n";
            string archivo = "C:\\Users\\User\\Desktop\\programacion avanzada\\datitos.txt";
            using (StreamWriter writer = new StreamWriter(archivo, true))
            {
                writer.WriteLine(datos);
            }
            MessageBox.Show("datos guardados con exito:\n\n" + datos, "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private bool EsTextoValido(string valor)
        {
            return Regex.IsMatch(valor, @"^[a-zA-Z\s]+$");
        }

        private void validarNombre(object sender, EventArgs e)
        {
            if (!EsTextoValido(textBox1.Text))
            {
                MessageBox.Show("ingrese un nombre valido", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }

        private void validarApellido (object sender, EventArgs e)
        {
            MessageBox.Show("Ingrese un apellido valido", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            textBox2.Clear();
        }

        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }
        private void validarEdad(object senter, EventArgs e)
        {
            if (!EsEnteroValido(textBox4.Text))
            {
                MessageBox.Show("ingrese una edad valida", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
            }
        }
        private void validarEstatura(object senter, EventArgs e)
        {
            if (!EsDecimalValido(textBox5.Text))
            {
                MessageBox.Show("Ingrese una estatura valida (en metros)", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Clear();
            }
        }
        private bool EsDecimalValido(string valor)
        {
            float resultado;
            return float.TryParse(valor, out resultado);
        }
        private void validarTelefono(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string input = textbox.Text;
            if (textbox.Text.Length == 10 && EsEnteroValido10Digitos(textbox.Text))
            {
                textbox.BackColor = Color.Green;
            }
            else
            {
                textbox.BackColor = Color.Red;
            }
        }
        private bool EsEnteroValido10Digitos(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado) && valor.Length == 10;
        }

    }


    }

