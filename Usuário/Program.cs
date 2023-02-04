//Enunciado

//Implementar um programa que lê um nome e uma senha (entre 4 e 8 caracteres) e verifica se o usuário 
//está autorizado ou não. Para essa verificação, o programa deverá solicitar um pré cadastro dos 
//usuários e suas senhas e armazená-las em uma (ou mais) lista de nomes e respectivas senhas. O 
//programa mostra mensagens de erro se o nome ou a senha estiverem incorretos. São permitidas até 3 
//tentativas. Utilize APENAS ArrayList para as listas nessa implementação.
using Sharprompt;
using System.Collections;

public class Aula02ArrayLists
{
    static void Main()
    {
        do
        {
            Usuario.CadastrarUsuario();
            Console.WriteLine("\nCadastrar novo usuário?\n[S] - SIM\n[Qualquer tecla] - NÃO");
        } while (Console.ReadLine() == "S");
        Usuario.LogarUsuario();
    }
}

public class Usuario
{
    private static ArrayList _usuario = new ArrayList() { "Celso", "Geovana" };
    private static ArrayList _senhaUsuario = new ArrayList() { "celso", "petisco"};
    private static int _contador = 0;

    public static void CadastrarUsuario()
    {
        Console.WriteLine(">>>Cadastro de usuários<<<\n");
        Console.Write("Informe o nome do Usuário: ");
        string usuario = Console.ReadLine();
        while(_usuario.IndexOf(usuario) != -1)
        {
            Console.Write("Nome de usuário já existe, informe outro nome: ");
            usuario = Console.ReadLine();
        }
        _usuario.Add(usuario);
        string senha = Prompt.Password("Informe a senha", validators: new[]
        {
            Validators.Required(),
            Validators.MinLength(4),
            Validators.MaxLength(8)
        });
        _senhaUsuario.Add(senha);
    }

    public static void LogarUsuario()
    {
        Console.Clear();
        Console.WriteLine(">>>Logar usuário<<<\n");
        int indice = -2;
        int contadorTentativa = 3;
        Console.Write("Nome do Usuário: ");
        indice = _usuario.IndexOf(Console.ReadLine());
        while(indice == -1)
        {
            contadorTentativa--;
            if (contadorTentativa == 0)
            {
                Console.WriteLine($"Acesso negado! Operação finalizada.");
                return;
            }
            Console.WriteLine($"Usuário inexistente, você só pode tentar 3 vezes. Ainda restam {contadorTentativa} vezes.");
            Console.Write("Informe novamente o nome do Usuário: ");
            indice = _usuario.IndexOf(Console.ReadLine());
        }
        string senha = Prompt.Password("Senha", validators: new[]
        {
            Validators.Required(),
            Validators.MinLength(4),
            Validators.MaxLength(8)
        });
        while (senha != _senhaUsuario[indice].ToString())
        {
            contadorTentativa--;
            if(contadorTentativa == 0)
            {
                Console.WriteLine($"Usuário {_usuario[indice]} bloqueado! Operação finalizada.");
                return;
            }
            Console.WriteLine($"Senha incorreta, você só pode tentar 3 vezes. Ainda restam {contadorTentativa} vezes.");
            senha = Prompt.Password("Senha", validators: new[]
            {
                Validators.Required(),
                Validators.MinLength(4),
                Validators.MaxLength(8)
            });
        }
        Console.WriteLine("\nLogin realizado com sucesso!");
        return;
    }
}
