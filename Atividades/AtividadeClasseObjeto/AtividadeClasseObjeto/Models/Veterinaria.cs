namespace AtividadeClasseObjeto.Models
{
    public class Veterinaria
    {
        public static void main(String[] args)
        {
            var animal1 = new Veterinaria();
            animal1.ClinicaVet = "VidaVet";
            animal1.NomeDoutor = "Washington";
            animal1.NomeAnimal = "Mateus";
            animal1.Laudo = "Castração";
            animal1.DataAtendimento = "25-03-2023";

            var animal2 = new Veterinaria();
            animal2.ClinicaVet = "AnimalPlanet";
            animal2.NomeDoutor = "Jonhatan";
            animal2.NomeAnimal = "Bartolomeu";
            animal2.Laudo = "Ingeriu brinquedo infantil, necessário intervenção cirúrgica";
            animal2.DataAtendimento = "16-02-2025";

            var animal3 = new Veterinaria();
            animal3.ClinicaVet = "MundoVet";
            animal3.NomeDoutor = "Thiago Balbinot";
            animal3.NomeAnimal = "José Alfredo";
            animal3.Laudo = "Amputação de pata decorrente de atropelamento";
            animal3.DataAtendimento = "06-06-2024";

            var animal4 = new Veterinaria();
            animal4.ClinicaVet = "Hospital4Patas";
            animal4.NomeDoutor = "Thiago Thomasi";
            animal4.NomeAnimal = "Branch";
            animal4.Laudo = "Mordida de cobra, necessário internação durante 2 dias";
            animal4.DataAtendimento = "26-04-2025";

            var animal5 = new Veterinaria();
            animal5.ClinicaVet = "GrupoCausaAnimal";
            animal5.NomeDoutor = "Osvaldo";
            animal5.NomeAnimal = "Pituca";
            animal5.Laudo = "Cesária canina";
            animal5.DataAtendimento = "15-08-2020";
        }

        public string ClinicaVet { get; set; }
        public string NomeAnimal { get; set; }
        public string NomeDoutor { get; set; }
        public string Laudo { get; set; }
        public string DataAtendimento { get; set; }
        public Veterinaria() { }

    }



}
