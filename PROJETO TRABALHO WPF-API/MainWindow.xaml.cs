using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using DocumentFormat.OpenXml.Office.Word;
using MySqlConnector;
using MySql.Data.MySqlClient;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;

namespace PROJETOTRABALHOAPI
{/// <summary>
 /// Interaction logic for MainWindow.xaml
 /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Botão_Click(object sender, RoutedEventArgs e)
        {
            ChamarApiCep();
        }

        private void ChamarApiCep()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.postmon.com.br/v1/cep/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(CepTextBox.Text).Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<Endereco>().Result;
                Console.WriteLine(dataObjects);
                CidadeTextBox1.Text = dataObjects.Cidade;
                EstadoTextBox.Text = dataObjects.Estado;
                RuaTextBox.Text = dataObjects.Logradouro;
                BairroTextBox.Text = dataObjects.Bairro;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode,
                              response.ReasonPhrase);
                MessageBox.Show("CEP Não Encontrado");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CadastroButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dados Cadastrados!");
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void PesquisaCEP_Click(object sender, RoutedEventArgs e)
        {
            ChamarApiCep();
        }


        private void CadastroButton_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection("DATABASE=trabalhoapi ; port=3306; SERVER=localhost;  UID=root; pwd='' ");
                

                string sql = "INSERT INTO endereco (rua, bairro, cidade, estado, cep) " +
                    "VALUES " +
                    "('" + CidadeTextBox1.Text + "', '" + EstadoTextBox.Text + "', '" + RuaTextBox.Text + "', '" + BairroTextBox.Text + "','" + CepTextBox.Text + "')";

                MySqlCommand comando = new MySqlCommand(sql, conexao);
                conexao.Open();
                comando.ExecuteReader();

                MessageBox.Show("DADOS CADASTRADOS COM SUCESSO!");
            }
            catch (Exception t)
            {
                MessageBox.Show("FALHA AO SALVAR OS DADOS!" + t);
            }
        }
    }

 }