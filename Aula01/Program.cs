const string nickName = "Kazumii";
const int percentualSucesso = 892; // 0.0892% de chance de sucesso
const int maxDurabilidade = 180;
const int durabilidadePerdida = 20;
const int valorEstilhaco = 5;
const int cronsNecessarias = 4000;
const int valorCron = 3;
const int passarGarantido = 1000;
const int memoriasNecessarias = 1; 

// Estoque inicial 
int estoqueCrons = 42200000;
int estoqueMemorias = 500;

var random = new Random();
int profit = random.Next(1, 1000000);
int tentativas = 0;
int durabilidadeAtual = maxDurabilidade;
int totalEstilhacosUsados = 0;
int totalCronsUsadas = 0;
int totalMemoriasUsadas = 0;
bool passou = false;
    
while (profit > percentualSucesso && tentativas < passarGarantido)
{
    // Verifica se tem crons e memorias suficientes
    if (estoqueCrons < cronsNecessarias )
    {
        Console.WriteLine("Tá sem cron dog, vai grindar mendigo.");
        break;
    }
    if (estoqueMemorias < memoriasNecessarias)
    {
        Console.WriteLine("Tá sem memória, vai farmar mendigo.");
        break;
    }

    tentativas++;
    durabilidadeAtual -= durabilidadePerdida;
    totalCronsUsadas += cronsNecessarias;
    totalMemoriasUsadas += memoriasNecessarias;
    estoqueCrons -= cronsNecessarias;
    estoqueMemorias -= memoriasNecessarias;

    Console.WriteLine($"{percentualSucesso} de {profit} - Tentativa número {tentativas}, Durabilidade {durabilidadeAtual}");
    Console.WriteLine("Rodou amigão!");

    profit = random.Next(1, 1000000);

    if (durabilidadeAtual < durabilidadePerdida)
    {
        Console.WriteLine("Durabilidade insuficiente para continuar. Reparando no ferreiro");
        int reparos = maxDurabilidade - durabilidadeAtual;
        durabilidadeAtual = maxDurabilidade;
        totalEstilhacosUsados += reparos;
        Console.WriteLine($"Durabilidade restaurada para {durabilidadeAtual}");
    }
}


if (tentativas == passarGarantido)
{
    Console.WriteLine("Se fudeu, passou no pit");
    passou = true;
}

// Mensagem final caso tenha passado
if (passou)
{
    long totalGasto = (totalEstilhacosUsados * valorEstilhaco) + (totalCronsUsadas * valorCron);
    Console.WriteLine($"{percentualSucesso} de {profit} - Tentativa número {tentativas}");
    Console.WriteLine($"{nickName} PASSOU! Total de estilhaços: {totalEstilhacosUsados} - Total de crons: {totalCronsUsadas} - Total de memórias: {totalMemoriasUsadas} - Total gasto: {totalGasto:N0}kk");
}
