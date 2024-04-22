using System;
using System.Windows.Forms;

namespace Imprumuturi_Biblioteca
{
    public partial class Form1 : Form
    {
        private GestionareImprumuturi gestionareImprumuturi;

        // Declarațiile variabilelor pentru controalele din formular
        private TextBox txtTitlu;
        private TextBox txtAutor;
        private Button btnAdaugaCarte;
        private ListBox lstBiblioteca;
        private TextBox txtNume;
        private TextBox txtPrenume;
        private Button btnAdaugaMembru;
        private ListBox lstMembri;

        private const int LungimeMaximaTitlu = 50;
        private const int LungimeMaximaNume = 50;
        private const int LungimeMaximaPrenume = 50;

        public Form1()
        {
            InitializeComponent();
            InitializeazaComponente();
            gestionareImprumuturi = new GestionareImprumuturi(100, 100); // Inițializăm obiectul pentru gestionarea împrumuturilor
        }

        private void InitializeazaComponente()
        {
            // Inițializarea controalelor
            txtTitlu = new TextBox();
            txtAutor = new TextBox();
            btnAdaugaCarte = new Button();
            lstBiblioteca = new ListBox();
            txtNume = new TextBox();
            txtPrenume = new TextBox();
            btnAdaugaMembru = new Button();
            lstMembri = new ListBox();

            // Configurarea controalelor și adăugarea lor pe formular
            // Poziționare și dimensiuni
            txtTitlu.Location = new System.Drawing.Point(20, 50);
            txtAutor.Location = new System.Drawing.Point(20, 80);
            btnAdaugaCarte.Location = new System.Drawing.Point(20, 110);
            lstBiblioteca.Location = new System.Drawing.Point(20, 140);
            lstBiblioteca.Size = new System.Drawing.Size(300, 200);

            txtNume.Location = new System.Drawing.Point(350, 50);
            txtPrenume.Location = new System.Drawing.Point(350, 80);
            btnAdaugaMembru.Location = new System.Drawing.Point(350, 110);
            lstMembri.Location = new System.Drawing.Point(350, 140);
            lstMembri.Size = new System.Drawing.Size(300, 200);

            // Text
            txtTitlu.Text = "Titlu";
            txtAutor.Text = "Autor";
            txtNume.Text = "Nume";
            txtPrenume.Text = "Prenume";
            btnAdaugaCarte.Text = "Adaugă Carte";
            btnAdaugaMembru.Text = "Adaugă Membru";

            // Adăugarea controalelor pe formular
            Controls.Add(txtTitlu);
            Controls.Add(txtAutor);
            Controls.Add(btnAdaugaCarte);
            Controls.Add(lstBiblioteca);
            Controls.Add(txtNume);
            Controls.Add(txtPrenume);
            Controls.Add(btnAdaugaMembru);
            Controls.Add(lstMembri);

            // Asocierea evenimentelor cu metodele corespunzătoare
            btnAdaugaCarte.Click += btnAdaugaCarte_Click;
            btnAdaugaMembru.Click += btnAdaugaMembru_Click;
        }

        private void btnAdaugaCarte_Click(object sender, EventArgs e)
        {
            try
            {
                Carte carte = new Carte();
                carte.Titlu = txtTitlu.Text;
                carte.Autor = txtAutor.Text;
                carte.EsteDisponibila = true;

                gestionareImprumuturi.AdaugaCarte(carte);
                AfiseazaBiblioteca();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdaugaMembru_Click(object sender, EventArgs e)
        {
            try
            {
                Membru membru = new Membru();
                membru.Nume = txtNume.Text;
                membru.Prenume = txtPrenume.Text;

                gestionareImprumuturi.AdaugaMembru(membru);
                AfiseazaMembri();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AfiseazaBiblioteca()
        {
            lstBiblioteca.Items.Clear();
            foreach (Carte carte in gestionareImprumuturi.GetBiblioteca())
            {
                if (carte != null)
                {
                    lstBiblioteca.Items.Add($"ID: {carte.Id}, Titlu: {carte.Titlu}, Autor: {carte.Autor}, Disponibilă: {(carte.EsteDisponibila ? "Da" : "Nu")}");
                }
            }
        }

        private void AfiseazaMembri()
        {
            lstMembri.Items.Clear();
            foreach (Membru membru in gestionareImprumuturi.GetMembri())
            {
                if (membru != null)
                {
                    lstMembri.Items.Add($"ID: {membru.Id}, Nume: {membru.Nume}, Prenume: {membru.Prenume}");
                }
            }
        }
    }
}
