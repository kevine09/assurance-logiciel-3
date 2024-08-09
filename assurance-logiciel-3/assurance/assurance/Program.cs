using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {

    Etudiant etudiant1 = new Etudiant(1, "giovanni", "junior");
    Etudiant etudiant2 = new Etudiant(2, "Dupont", "Jean");
    Etudiant etudiant3 = new Etudiant(3, "glo", "ria");
    Etudiant etudiant4 = new Etudiant(4, "Yvan", "Sophie");

    Cours cours1 = new Cours(1, "MATH101", "Mathématiques I");
    Cours cours2 = new Cours(2, "PHYS201", "Physique II");
    Cours cours3 = new Cours(3, "PROG301", "Programmation Avancée");

    Note note1 = new Note(1, 1, 85.5);
    Note note2 = new Note(1, 2, 78.0);
    Note note3 = new Note(2, 1, 92.0);
    Note note4 = new Note(2, 3, 83.7);
    Note note5 = new Note(3, 2, 75.3);

    var gestionNotes = new GestionNotes();

    // Ajouter des étudiants
    gestionNotes.AjouterEtudiant(1, "giovanni", "junior");
    gestionNotes.AjouterEtudiant(2, "Dupont", "Jean");
    gestionNotes.AjouterEtudiant(3, "glo", "ria");
    gestionNotes.AjouterEtudiant(4, "Yvan", "Sophie");

    // Ajouter des cours
    gestionNotes.AjouterCours(1, "MATH101", "Mathématiques I");
    gestionNotes.AjouterCours(2, "PHYS201", "Physique II");
    gestionNotes.AjouterCours(3, "PROG301", "Programmation Avancée");

    // Ajouter des notes
    gestionNotes.AjouterNote(1, 1, 85.5);
    gestionNotes.AjouterNote(1, 2, 78.0);
    gestionNotes.AjouterNote(2, 1, 92.0);
    gestionNotes.AjouterNote(2, 3, 83.7);
    gestionNotes.AjouterNote(3, 2, 75.3);
    gestionNotes.AjouterNote(3, 3, 88.2);

    // Afficher les étudiants
    gestionNotes.AfficherEtudiants();

    // Afficher les cours
    gestionNotes.AfficherCours();

    // Afficher le relevé de notes pour l'étudiant 1
    gestionNotes.AfficherNotes(1);

    // Sauvegarder les informations de l'étudiant 1 dans un fichier
    gestionNotes.SauvegarderEtudiant(1);

}
    }

    // Classe Etudiant
    public class Etudiant
    {
        public int NumeroEtudiant{ get; set; }
        public string Nom{ get; set; }
        public string Prenom{ get; set; }

        public Etudiant(int numeroEtudiant, string nom, string prenom)
        {
   this. NumeroEtudiant = numeroEtudiant;
   this. Nom = nom;
   this. Prenom = prenom;
}
    }

    // Classe Cours
    public class Cours
    {
        public int NumeroCours{ get; set; }
        public   string Code{ get; set; }
        public string Titre{ get; set; }

        public Cours(int numeroCours, string code, string titre)
        {
    NumeroCours = numeroCours;
    Code = code;
    Titre = titre;
}
    }

    // Classe Note
    public class Note
    {
        public int NumeroEtudiant{ get; set; }
        public int NumeroCours{ get; set; }
        public double ValeurNote{ get; set; }

        public Note(int numeroEtudiant, int numeroCours, double valeurNote)
        {
    NumeroEtudiant = numeroEtudiant;
    NumeroCours = numeroCours;
    ValeurNote = valeurNote;
}
    }

// Classe GestionNotes (classe principale)
public class GestionNotes
{
    private List<Etudiant> etudiants;
    private List<Cours> cours;
    private List<Note> notes;

    public GestionNotes()
    {
        etudiants = new List<Etudiant>();
        cours = new List<Cours>();
        notes = new List<Note>();
    }

    public void AjouterEtudiant(int numeroEtudiant, string nom, string prenom)
    {
        if (etudiants.Any(e => e.NumeroEtudiant == numeroEtudiant))
        {
            Console.WriteLine($"un etudiant avec le numero {numeroEtudiant}existe deja. ");
            return;
        }
        Etudiant etudiant = new Etudiant(numeroEtudiant, nom, prenom);
        etudiants.Add(etudiant);
    }

    public void AjouterCours(int numeroCours, string code, string titre)
    {
        Cours coursNew = new Cours(numeroCours, code, titre);
        cours.Add(coursNew);
    }

    public void AjouterNote(int numeroEtudiant, int numeroCours, double valeurNote)
    {
        Note note = new Note(numeroEtudiant, numeroCours, valeurNote);
        notes.Add(note);
    }

    public void AfficherEtudiants()
    {
        foreach (Etudiant etudiant in etudiants)
        {
            Console.WriteLine($"Numéro d'étudiant: {etudiant.NumeroEtudiant}, Nom: {etudiant.Nom}, Prénom: {etudiant.Prenom}");
        }
    }

    public void AfficherCours()
    {
        foreach (Cours coursNew in cours)
        {
            Console.WriteLine($"Numéro de cours: {coursNew.NumeroCours}, Code: {coursNew.Code}, Titre: {coursNew.Titre}");
        }
    }

    public void AfficherNotes(int numeroEtudiant)
    {
        Console.WriteLine($"Relevé de notes pour l'étudiant numéro {numeroEtudiant}:");
        foreach (Note note in notes.Where(n => n.NumeroEtudiant == numeroEtudiant))
        {
            Console.WriteLine($"Cours numéro {note.NumeroCours}: {note.ValeurNote}");
        }
    }

    public void SauvegarderEtudiant(int numeroEtudiant)
    {
        Etudiant etudiant = etudiants.Find(e => e.NumeroEtudiant == numeroEtudiant);
        if (etudiant != null)
        {
            string fileName = $"{etudiant.Nom}_{etudiant.Prenom}_{etudiant.NumeroEtudiant}.txt";
            var lines = new List<string>
                {
                $"Numero d'etudiant : {etudiant.NumeroEtudiant}",
                    $"Nom:{etudiant.Nom}",
                    $"prenom:{etudiant.Prenom}",
                    "Notes:"
                };
            foreach (Note note in notes.Where(n => n.NumeroEtudiant == numeroEtudiant))
            {
                lines.Add($"Cours numero {note.NumeroCours}:{note.ValeurNote}");
            }
            System.IO.File.WriteAllLines(fileName, lines);
            Console.WriteLine("les informations de l'etudiant {etudiant.Nom} {etudiant.Prenom}  ont ete sauvegardees dans le fichier {fileName}. ");

        }
        else
        {
            Console.WriteLine($"Aucun étudiant avec le numéro {numeroEtudiant}n'a été trouvé.");
        }
    } }
     