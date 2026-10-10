using System;
using System.Collections.Generic;
using System.IO;

public class GerenciadorDeMetas
{
    private List<Meta> _metas;
    private int _pontuacao;
    private string _nivelAtual; // Nova variável para o nível

    public int Pontuacao => _pontuacao;
    public string NivelAtual => _nivelAtual; // Propriedade pública para leitura
    public List<Meta> Metas => _metas;

    public GerenciadorDeMetas()
    {
        _metas = new List<Meta>();
        _pontuacao = 0;
        _nivelAtual = "Inicial"; // Nível inicial padrão
    }

    public void AdicionarMeta(Meta meta)
    {
        _metas.Add(meta);
    }

    public void RegistrarEvento(int index)
    {
        if (index >= 0 && index < _metas.Count)
        {
            string nivelAnterior = _nivelAtual;
            
            int pontosGanhos = _metas[index].RegistrarEvento();
            _pontuacao += pontosGanhos;
            
            if (pontosGanhos > 0)
            {
                Console.WriteLine($"\nParabéns! Você ganhou {pontosGanhos} pontos.");
                AtualizarNivel(mostrarMensagem: true, nivelAnterior: nivelAnterior); // Verifica se subiu de nível
            }
            else
            {
                Console.WriteLine("\nEsta meta já foi concluída ou não pode ser registrada novamente.");
            }
        }
        else
        {
            Console.WriteLine("\nÍndice de meta inválido.");
        }
    }

    // Novo método para gerenciar a gamificação dos níveis
    private void AtualizarNivel(bool mostrarMensagem = false, string nivelAnterior = "")
    {
        string novoNivel;

        if (_pontuacao >= 1500)
            novoNivel = "Mestre";
        else if (_pontuacao >= 500)
            novoNivel = "Discípulo";
        else
            novoNivel = "Inicial";

        if (mostrarMensagem && novoNivel != nivelAnterior)
        {
            Console.WriteLine("=========================================");
            Console.WriteLine($"🌟 UP! Você alcançou o nível: {novoNivel} 🌟");
            Console.WriteLine("=========================================");
        }

        _nivelAtual = novoNivel;
    }

    public void ExibirMetas()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_metas[i].ObterDetalhes()}");
        }
    }

    public void Salvar(string nomeArquivo)
    {
        using (StreamWriter writer = new StreamWriter(nomeArquivo))
        {
            writer.WriteLine(_pontuacao);
            foreach (var meta in _metas)
            {
                writer.WriteLine(meta.Serializar());
            }
        }
    }

    public void Carregar(string nomeArquivo)
    {
        if (!File.Exists(nomeArquivo)) return;

        _metas.Clear();
        string[] linhas = File.ReadAllLines(nomeArquivo);

        if (linhas.Length > 0)
        {
            _pontuacao = int.Parse(linhas[0]);
            AtualizarNivel(); // Atualiza o nível silenciosamente ao carregar os dados salvos
            
            for (int i = 1; i < linhas.Length; i++)
            {
                string[] partes = linhas[i].Split(':');
                string tipo = partes[0];
                string nome = partes[1];
                string descricao = partes[2];
                int pontos = int.Parse(partes[3]);

                if (tipo == "Simples")
                {
                    bool concluida = bool.Parse(partes[4]);
                    _metas.Add(new MetaSimples(nome, descricao, pontos, concluida));
                }
                else if (tipo == "Eterna")
                {
                    _metas.Add(new MetaEterna(nome, descricao, pontos));
                }
                else if (tipo == "Lista")
                {
                    int bonus = int.Parse(partes[4]);
                    int atual = int.Parse(partes[5]);
                    int alvo = int.Parse(partes[6]);
                    _metas.Add(new MetaDeListaDeTarefas(nome, descricao, pontos, alvo, bonus, atual));
                }
            }
        }
    }
}