using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace AgenteInvestigacionAI
{
    public partial class SearchIA : Form
        
    {
        string apikey = "";
        public SearchIA()
        {
            InitializeComponent();
        }
        private async Task<string> ConsultarOpenAI(string prompt)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apikey}");

                var json = @"{
            ""model"": ""gpt-3.5-turbo"",
            ""messages"": [
                {""role"": ""user"", ""content"": """ + prompt.Replace("\"", "\\\"") + @"""}
            ]
        }";

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                var responseString = await response.Content.ReadAsStringAsync();

                var obj = Newtonsoft.Json.Linq.JObject.Parse(responseString);
                string respuesta = obj["choices"][0]["message"]["content"].ToString();

                return respuesta.Trim();
            }
        }
        private void GuardarEnDB(string prompt, string respuesta)
        {
            string connectionString = @"Server=DESKTOP-VQVLT4V\SQLEXPRESS;Database=SearchIA;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO SearchIA (Prompt, Respuesta) VALUES (@prompt, @respuesta)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@prompt", prompt);
                    cmd.Parameters.AddWithValue("@respuesta", respuesta);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        { 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnInvestigar_Click(object sender, EventArgs e)
        {
            lblEstado.Text = "...";
            string tema = txtTema.Text.Trim();

            if (string.IsNullOrEmpty(tema))
            {
                lblEstado.Text = "¡Debes escribir un tema!";
                return;
            }

            string prompt = $"Investigacion sobre: {tema}";
            string resultado = "";

            try
            {

                resultado = await ConsultarOpenAI(prompt);

                txtResultado.Text = resultado;
                lblEstado.Text = "Investigación completada :) .";

                GuardarEnDB(prompt, resultado);

                try
                {
                    string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Investigaciones");
                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    string archivoWord = Path.Combine(folder, $"Investigacion{tema}{DateTime.Now:yyyyMMddHHmmss}.docx");

                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Create(archivoWord, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        MainDocumentPart mainPart = wordDoc.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        Body body = new Body();

                        Paragraph titulo = new Paragraph(
                            new Run(
                                new DocumentFormat.OpenXml.Wordprocessing.Text($"Investigación sobre: {tema}")
                            )
                        );
                        body.Append(titulo);

                        body.Append(new Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text(""))));

                        Paragraph contenido = new Paragraph(
                            new Run(
                                new DocumentFormat.OpenXml.Wordprocessing.Text(resultado)
                            )
                        );
                        body.Append(contenido);

                        mainPart.Document.Append(body);
                        mainPart.Document.Save();
                    }
                    lblEstado.Text = "FELICIDADES, Tu Investigación ha sido completada.";
                }
                catch (Exception ex)
                {
                    lblEstado.Text = "Error al generar Word: " + ex.Message;
                }
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error: " + ex.Message;
            }

        }

        private void txtResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTema_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }
    }
}

