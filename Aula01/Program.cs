const string NickName = "Kazumii";
const int PercentualSucesso = 892; // 0.0892% de chance de sucesso
const int MaxDurabilidade = 180;
const int DurabilidadePerdida = 20;
const int ValorEstilhaco = 5;
const int CronsNecessarias = 4000;
const int ValorCron = 3;
const int PassarGarantido = 1000;
const int MemoriasNecessarias = 1; 

// Estoque inicial 
int estoqueCrons = 400000;
int estoqueMemorias = 500;

var random = new Random();
int profit = random.Next(1, 1000000);
int tentativas = 0;
int durabilidadeAtual = MaxDurabilidade;
int totalEstilhacosUsados = 0;
int totalCronsUsadas = 0;
int totalMemoriasUsadas = 0;
bool passou = false;
    
while (profit > PercentualSucesso && tentativas < PassarGarantido)
{
    // Verifica se tem crons e memorias suficientes
    if (estoqueCrons < CronsNecessarias || estoqueMemorias < MemoriasNecessarias)
    {
        Console.WriteLine("Faltou crons ou memórias do artesão! Contrate um CHINA.");
        break;
    }

    tentativas++;
    durabilidadeAtual -= DurabilidadePerdida;
    totalCronsUsadas += CronsNecessarias;
    totalMemoriasUsadas += MemoriasNecessarias;
    estoqueCrons -= CronsNecessarias;
    estoqueMemorias -= MemoriasNecessarias;

    Console.WriteLine($"{PercentualSucesso} de {profit} - Tentativa número {tentativas}, Durabilidade {durabilidadeAtual}");
    Console.WriteLine("Rodou amigão!");

    profit = random.Next(1, 1000000);

    if (durabilidadeAtual < DurabilidadePerdida)
    {
        Console.WriteLine("Durabilidade insuficiente para continuar. Reparando no ferreiro");
        int reparos = MaxDurabilidade - durabilidadeAtual;
        durabilidadeAtual = MaxDurabilidade;
        totalEstilhacosUsados += reparos;
        Console.WriteLine($"Durabilidade restaurada para {durabilidadeAtual}");
    }
}

if (tentativas == PassarGarantido)
{
    Console.WriteLine("Se fudeu, passou na bigorna");
    passou = true;
}

// Mensagem final caso tenha passado
if (passou)
{
    long totalGasto = (totalEstilhacosUsados * ValorEstilhaco) + (totalCronsUsadas * ValorCron);
    Console.WriteLine($"{PercentualSucesso} de {profit} - Tentativa número {tentativas}");
    Console.WriteLine($"{NickName} PASSOU! Total de estilhaços: {totalEstilhacosUsados} - Total de crons: {totalCronsUsadas} - Total de memórias: {totalMemoriasUsadas} - Total gasto: {totalGasto:N0}kk");
}
