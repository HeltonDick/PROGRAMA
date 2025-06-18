namespace Aula01.Models
{
    public class Variaveis
    {
        // Tipos implícitos
        // var teste = 10;

        // Anotação de Tipos
        public int userCount = 10;

        // Uma variável pode ser declarada
        // e não inicializada
        public int totalCount;

        // CONSTANTES
        // Para declarar uma constante 
        // utilizamos a palvra-chave CONST
        // No entanto a CONST deve ser inicializada
        // quando declarada
        public const int interestRate = 10;


        //O método construtor é invocado
        //na instanciação do objeto por meio 
        //da palavra reservada new
        // Por regra, o contrutor sempre tem
        // o mesmo nome da classe
        public Variaveis()
        {
            totalCount = 0;

            // Tipo implícito
            // a palvra chave var se encarrega
            // de definir o tipo da variável
            // na instrução de atribução
            var signalStrength = 22;
            var companyName = "ACME";

        }
        
    }
}
